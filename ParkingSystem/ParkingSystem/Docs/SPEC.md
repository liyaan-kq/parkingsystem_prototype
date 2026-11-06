# Parking Location Management System — Spec Sheet (v0.5.3)

> Purpose of this file: if a new chat/session starts, paste or attach this file so work can resume
> without re-deciding anything. Update the **Status** section at the bottom as work progresses.

## 0. Project context
- BSIT project, prototype level. Graded on **functionality**, **CRUD**, validation and defense answers.
- Team for this build: user + Claude.
- Guiding rules:
  - **Do not overengineer.** No password hashing, no ORM, no repository/DI frameworks, no audit log.
  - **Modularity:** `Forms` (UI only) → `Logic` (rules + SQL per domain) → `Classes` (provided helper library: database, form controls, charts, printing) + `Helpers` (project-specific plumbing); reusable UI pieces in `Controls`.
  - **No redundancy:** one way to reach each screen from the sidebar, plus shortcuts from the map. No duplicate button sets.
  - Nothing important hardcoded in the UI: rates live in the database and are editable in a form.
  - Every error case a panelist might try must show a clear message (duplicates, empty input, bad format, full lot, etc.).

## 1. Platform
| Item | Choice |
|---|---|
| Language | C# 7.3 (default for .NET Framework projects — avoid C# 8+ syntax) |
| Project type | Visual Studio → Windows Forms App (**.NET Framework 4.8**) |
| Database | **Service-based Database** `ParkingDB.mdf` (SQL Server Express LocalDB) |
| Data access | `AppDb.Instance` (provided `IDatabase` / `SqlDatabase` classes, see §4a). Values are always passed as parameters from an object (`new { SlotID = id }` → `@SlotID`), never pasted into SQL. |
| Connection string | `App.config` → `connectionStrings/AppDB` (name required by `AppDb`) using `AttachDbFilename=|DataDirectory|\ParkingDB.mdf` |
| DataDirectory | `Program.cs` points it at the **project folder** copy of the .mdf (one database file, so Server Explorer shows the same data the app uses) |
| Printing | `ReportPrinter` (provided class): `PrintDocument` + `PrintPreviewDialog` (mock print: shows the page, no printer needed) |
| Charts | `Charts.Bind` (provided class) on the built-in `System.Windows.Forms.DataVisualization` chart |

## 2. Business rules (decided)
| Topic | Rule |
|---|---|
| Slots | 50 slots: zones **A–E**, 10 per zone → `A01`…`E10` |
| Slot statuses | `Available` (shown as "Free"), `Occupied`, `Reserved` |
| Reserved | Reserve / release from the slot's info panel on the map (VIP / maintenance). Occupied slots can't be reserved. Reserved slots are never offered at entry. Reversible, so no confirmation popup. |
| Vehicle types | Car, Motorcycle, Van/SUV (rows of `VehicleRates`) |
| Fee rule | **Flat rate covers the first N hours** (N = FlatHours, default 3). Every succeeding hour **or part of an hour** adds SucceedingRate. Minimum charge = flat rate. |
| Default rates | Car ₱50 flat (3 h) + ₱20/h · Motorcycle ₱20 flat (3 h) + ₱10/h · Van/SUV ₱70 flat (3 h) + ₱30/h |
| Fee examples (Car) | 0–3h00m → ₱50 · 3h01m → ₱70 · 4h30m → ₱90 · 2h09m → ₱50 |
| Rate edits | Editable in **Rates Settings**. Fee is computed at **exit** using current rates, then stored, so past records never change. |
| Plate numbers | Stored as typed but tidied (`ABC 1234`: uppercase, single spaces). **Compared by `PlateKey`** = plate without spaces/dashes, so `abc1234`, `ABC 1234` and `ABC-1234` are the **same vehicle** (unique in the DB). |
| Entry time | Auto-filled with the current date/time and **read-only** (prevents back-dating fraud, negative durations, typos). |
| Exit time | **Recomputed at the moment of payment** so the charged amount is never stale. |
| Card stub | Issued at **exit** as the payment receipt, shown on screen, printable/reprintable. Stub No. = 6 digits from `CardStubs.StubID`. No physical entry card → no lost-card rule. |
| Returning vehicles | Same plate reuses its `Vehicles` row (history). Picking it from the suggestions fills type and owner. |
| Users | Single admin account. Plain-text password (`admin` / `parking`) by design — see §0. |
| Records (CRUD) | **Controlled CRUD** — every record can be created, read, updated and deleted, but money/time fields stay locked. See §2a. |
| Last updated | Every transaction has `UpdatedAt`, set at entry, payment and every edit. |
| Messages | Results and validation problems appear **inline** (green = done, red = fix this, grey = hint). Popups only for: payment confirm, delete confirm, vehicle-wide edit confirm, rates save confirm, logout/exit, unexpected DB errors. |

## 2a. Records CRUD rules
| | Parked record | Completed record |
|---|---|---|
| **Create** | Records → *Add New Entry* (same Vehicle Entry form) | — (created by payment at exit) |
| **Read** | Grid + tabs + live search (plate or owner) + date filter | same |
| **Update** | Plate, vehicle type, owner, **slot** (chosen on the map = move the vehicle) | Plate, vehicle type, owner |
| **Locked** | Entry time | Entry time, exit time, duration, fee |
| **Delete** | "Void entry": record deleted, slot becomes free | Record + its stub deleted, income totals change |

- Plate/type/owner live in `Vehicles`, so an edit applies to **every visit** of that vehicle (confirmed first; stamps `UpdatedAt` on all of them).
- An edited plate can't match another vehicle's plate (any spacing).
- Deleting a vehicle's last visit also removes the vehicle row (no orphans). Stub numbers are never reused.
- Every update/delete runs in one transaction.
- Defense line: *"Times and fees are system-generated, so they can't be edited — that prevents tampering. A wrong entry is fixed by deleting it and registering again."*

## 3. Screens and flow (v0.5)
```
Login ──> Parking Map (home) ──sidebar──> Vehicle Entry | Vehicle Exit | Records & Reports | Rates Settings | Debug Tools | Logout
              │
              └─ click a slot ─> info panel
                    Free:      [Park vehicle here] -> Vehicle Entry (slot preselected)
                               [Reserve slot]
                    Occupied:  plate, owner, type, since, time parked, fee so far
                               [Process exit]      -> Vehicle Exit (car preselected)
                               [Edit record]       -> Edit Record
                               [Vehicle history]   -> Records filtered to that plate
                    Reserved:  [Release reservation]
              Find vehicle box (top): type plate / owner / slot -> jumps to the car on the map
```
| # | Form | Purpose |
|---|---|---|
| 1 | `LoginForm` | Username/password, show-password toggle, inline errors |
| 2 | `DashboardForm` | **Home = live parking map** (`SlotMapControl`) + info panel with actions + 4 cards (Free, Occupied, Reserved, Today's income + stub count) + Find vehicle + status line. Refreshes after every dialog and every 30 s. |
| 3 | `VehicleEntryForm` | Plate (live suggestions by plate **or** owner; returning car fills type/owner; already-parked car flagged), type, owner, **Zone (A–E with free counts) + Slot no. (free only)**, **[Parking slots]** map picker, next free slot pre-chosen, read-only entry time. Closes on success. |
| 4 | `VehicleExitForm` | **List of parked vehicles** + one search box (plate, owner or slot; filters as you type; first match auto-selected) + **[Parking slots]** map picker. Bill panel → Process payment (1 confirm) → stub shown → Print stub. |
| 5 | `SlotPickerForm` | Pop-up map: only valid slots clickable (free for entry/move, occupied for exit). Click = choose. |
| 6 | `RatesForm` | Grid of the 3 vehicle types, edit FlatRate/FlatHours/SucceedingRate, validated save (inline messages) |
| 7 | `RecordsForm` | Tabs + live search + date filter + grid (incl. Last Updated) + totals; **Add / Edit / Delete**; Print Preview, Export CSV, **View Chart**, Reprint Stub. Double-click = Edit. Opens pre-filtered for "Vehicle history". |
| 8 | `RecordEditForm` | Edit plate, type, owner; **Change slot** (map picker, parked only); locked panel shows times, fee, last updated |
| 9 | `ReportChartForm` | Opened by **View Chart**: chart of the records currently shown — Daily Income (column or line, by exit date) or Visits by Vehicle Type (pie). Built in code, no designer file. |
| 10 | `DebugForm` | **Debug Tools** (sidebar, above Logout): data utilities, failure simulations and diagnostics for demonstrations. See §3a. |

## 3a. Debug Tools (v0.5.3)
Sidebar → **Debug Tools**. Every action writes a timestamped line to the on-screen log. Destructive actions ask for confirmation. The map and cards refresh when the window closes.

| Group | Tool | What it does |
|---|---|---|
| Data | Generate Sample Data | Replaces all records with random data: 30 vehicles, 1–3 completed visits each over the last 7 days (fees from current rates, stubs issued in payment order), 12 parked vehicles, 3 reserved slots. One transaction. |
| Data | Clear All Records | Deletes all stubs, transactions and vehicles; sets every slot to Available. Keeps users and rates. Stub numbers are not reused. |
| Data | Reset Rates to Defaults | Car ₱50 / Motorcycle ₱20 / Van/SUV ₱70 flat (3 h) + ₱20 / ₱10 / ₱30 per succeeding hour. |
| Simulations | Advance Parked Time (+1 Hour) | Moves entry times of parked vehicles back one hour, so durations and fees visibly increase (demonstrates the fee rule without waiting). |
| Simulations | Simulate Query Timeout | Runs a 5-second `WAITFOR` with a 2-second command timeout → SQL timeout → standard database error dialog. The normal timeout is restored. |
| Simulations | Simulate Connection Failure | Opens a separate, throw-away connection to a `.mdf` that doesn't exist → connection error dialog. The app's own connection (`AppDb.Instance`) is never touched. |
| Simulations | Simulate Unexpected Error | Throws an unhandled exception → caught by the application-wide handler in `Program.cs`; the app keeps running. Under the Visual Studio debugger, press Continue (F5) if it breaks first. |
| Diagnostics | Run Self-Tests | 28 checks of the pure rules: fee examples from §2, duration math and text, plate/name/amount validation, plate key, search matching. No database. |
| Diagnostics | Check Data Integrity | Connection time, slot count, Occupied slot ↔ Parked record consistency, stub ↔ Completed record consistency, missing exit data, orphan vehicles. |

Code: `Logic/DebugService.cs` (data + simulations), `Logic/DiagnosticsService.cs` (checks, returns `CheckResult` rows), `Forms/DebugForm.cs`. For a production release, remove the sidebar button (`btnNavDebug`).

Removed in v0.5 (redundant): dashboard Quick Action buttons, separate Parking Slots screen (the map **is** the home screen), Records Search button (search is live), success popups.

## 4. Architecture / file map
```
ParkingSystem/
├─ Program.cs                 entry point, DataDirectory, global error handler
├─ App.config                 connection string
├─ Forms/                     UI only: read inputs, call Logic, show results
│   ├─ LoginForm, DashboardForm, VehicleEntryForm, VehicleExitForm,
│   ├─ SlotPickerForm, RatesForm, RecordsForm, RecordEditForm, DebugForm   (+ .Designer.cs each)
│   └─ ReportChartForm        code-built chart dialog (no designer file)
├─ Controls/                  reusable UI pieces
│   ├─ SlotMapControl.cs      the 5x10 map (used by the home screen and the picker)
│   └─ SuggestBox.cs          live suggestion list under any TextBox
├─ Logic/                     business rules + SQL, one class per area
│   ├─ Models.cs              small data classes (SlotInfo, VehicleRate, ActiveParking, StubInfo, ...)
│   ├─ OperationResult.cs     Success + Message returned to forms
│   ├─ Session.cs             logged-in user
│   ├─ AuthService.cs         login check
│   ├─ FeeCalculator.cs       pure fee/duration math (no DB)
│   ├─ SearchHelper.cs        pure matching rules for suggestions/search (no DB)
│   ├─ RateService.cs         read/save VehicleRates
│   ├─ SlotService.cs         map data (incl. parked car per slot), reserve, release
│   ├─ ParkingService.cs      vehicles + parked list, park (entry), complete exit + stub
│   ├─ ReportService.cs       dashboard stats, records query, stub lookup
│   ├─ RecordService.cs       record update (incl. slot move) and delete
│   ├─ DebugService.cs        Debug Tools: sample data, clear, reset rates, simulations
│   ├─ DiagnosticsService.cs  Debug Tools: self-tests and data integrity checks
│   └─ StubFormatter.cs       stub text lines (shared by screen + print)
├─ Classes/                   provided helper library (namespace red_framework), see §4a
│   ├─ AppDb.cs               shared database object: AppDb.Instance
│   ├─ IDatabase.cs           what the database object can do
│   ├─ SqlDatabase.cs         SQL Server implementation (CRUD, queries, transactions, mapping to models)
│   ├─ FormControls.cs        required-field checks, clearing inputs
│   ├─ Charts.cs              DataTable → chart series
│   └─ ReportPrinter.cs       table report preview/print + parking stub preview
├─ Helpers/                   project-specific plumbing, no business rules
│   ├─ Validator.cs           plate/name/number format checks, PlateKey
│   ├─ StatusLine.cs          inline green/red/grey messages
│   ├─ UiHelper.cs            confirm dialog, warnings, DB error message
│   ├─ ExportHelper.cs        CSV export of a DataTable
│   └─ Theme.cs               colours used by code-built controls
├─ Database/  01_schema.sql · 02_seed.sql · 03_sample_data.sql
└─ Docs/      SPEC.md · SETUP.md · schema_references.md
```
Rule of thumb: a Form never contains SQL; a Service never shows a MessageBox.

## 4a. Helper classes (`Classes/`, namespace `red_framework`)
The provided C# WinForms helper classes replace the earlier `DbHelper` and `PrintHelper`.

| Class | Used for | Where |
|---|---|---|
| `AppDb.Instance` (`IDatabase`) | Every database call | All `Logic/*Service.cs` |
| `QueryList<T>` / `QuerySingle<T>` | Read rows straight into models (`SlotInfo`, `VehicleRate`, `ActiveParking`, `RecordDetails`, `StubInfo`, `DashboardStats`) — columns map to properties by name | Slot, Rate, Parking, Record, Report services |
| `TableData` | Records grid data, login lookup, slot check with `UPDLOCK` | Report, Auth, Parking, Record services |
| `Save` / `Update` / `Delete` | Simple single-table INSERT / UPDATE / DELETE from an object | Parking (new transaction, slot status), Record (vehicle, slot move, delete), Rate (save rates) |
| `CUD` / `Scalar` | Conditional updates (`... AND Status = 'Parked'`), INSERT that returns the new ID / stub number | Parking, Record, Slot services |
| `ExecuteTransaction(tran => ...)` | All-or-nothing entry, exit, edit, delete, rate save. Return `false` = roll back | Parking, Record, Rate services |
| `Table(dt, grid, headers)` | Fill the Records grid with column headers | `RecordsForm` |
| `FormControls.FirstRequired` / `ClearInputs` / `ClearText` | Required-field checks; clearing password, filters, search | Login, Vehicle Entry, Edit Record, Records, Vehicle Exit |
| `Charts.Bind` | Daily income / visits by type chart | `ReportChartForm` |
| `ReportPrinter.Preview` / `PreviewStub` | Records report; parking stub (exit + reprint) | `RecordsForm`, `VehicleExitForm` |

Changes made to the provided classes so they fit this project:
- `SqlDatabase`: commands run inside `ExecuteTransaction` now join that transaction automatically (before, `CUD`/`Scalar`/`TableData` could not be used inside it). The connection opens on first use (not in the constructor) and reopens if it breaks, so a missing database at login doesn't break the app until restart. Mapping skips read-only properties (e.g. `IsParked`).
- `ReportPrinter`: multi-line subtitle, totals line after the last row, optional column widths, "Printed" date in the page footer, owner window, a clear message when no printer is installed, and `PreviewStub` (the parking stub with barcode, moved from the old `PrintHelper`).
- `AppDb`, `IDatabase`, `FormControls`, `Charts`: unchanged (comments removed, as in the rest of the source).
- `App.config` connection string renamed `ParkingDB` → `AppDB`, the name `AppDb` expects. `Program.cs` closes the shared connection on exit (`AppDb.Dispose()`).

Defense line: *"All SQL goes through one shared database class with parameterized queries. Multi-step operations like entry and exit run inside one transaction, so either everything is saved or nothing is."*

## 5. Database (see `schema_references.md` for full detail)
- `Users`(UserID PK, Username UQ, Password, FullName)
- `VehicleRates`(VehicleType PK, FlatRate, FlatHours, SucceedingRate, UpdatedAt)
- `Vehicles`(VehicleID PK, PlateNumber UQ, VehicleType FK→VehicleRates, OwnerName, CreatedAt, **PlateKey computed UQ**)
- `ParkingSlots`(SlotID PK, SlotNumber UQ, Zone, Status CHECK, UpdatedAt)
- `ParkingTransactions`(TransactionID PK, VehicleID FK, SlotID FK, EntryTime, ExitTime NULL, DurationMinutes NULL, Fee NULL, Status CHECK, UpdatedAt)
- `CardStubs`(StubID PK, StubNo computed, TransactionID FK UQ, IssuedAt)
- Safety nets in the DB itself: filtered unique indexes so a vehicle or a slot can only have **one** `Parked` transaction at a time; `PlateKey` unique so spacing variants can't create a second vehicle.

## 6. Usability assessment (v0.4 → v0.5)
Found by clicking through every screen as an attendant (scripted, see §8) and fixed in v0.5:

| # | Hole in v0.4 | Fix in v0.5 |
|---|---|---|
| 1 | Dashboard Quick Actions duplicated the sidebar; dashboard showed numbers only | Dashboard **is** the parking map; Quick Actions removed |
| 2 | Parking Slots was a separate screen from home | Merged into the home map |
| 3 | Clicking an occupied slot only showed a warning | Info panel: car details, time parked, fee so far + actions |
| 4 | Entry slot picker was one 50-item dropdown | Zone (with free counts) + Slot no. (free only) + map picker; next free slot pre-chosen |
| 5 | `ABC1234` and `ABC 1234` became two vehicles → same car parked twice | `PlateKey` (unique) — spacing/dashes ignored everywhere |
| 6 | No plate suggestions | Live suggestions by plate or owner; returning car autofills |
| 7 | Exit required the exact plate | Parked list + search by plate/owner/slot + map picker |
| 8 | Records couldn't search by owner | Live search by plate or owner |
| 9 | Exit said "already paid" when the record was actually deleted | Correct message for each case |
| 10 | 2–3 popups per entry/exit | Inline status lines; exit = 1 confirm |
| 11 | (found while testing v0.5) a Save error was wiped when focus left the plate box | Plate check only clears its own messages |

## 7. Validation checklist (all rows covered by the scripted click-through)
| Where | Case | Expected (inline unless noted) |
|---|---|---|
| Login | Empty / wrong credentials | "Enter your username and password." / "Invalid username or password." |
| Login | Database missing | Popup "Cannot connect to the database…" with hint |
| Entry | Empty plate / bad plate / no type / empty or bad owner / no slot | Field-specific message, cursor moves to the field |
| Entry | Plate already parked (any spacing) | Flagged as soon as you leave the box; Save refused: "ABC 1234 is already parked at A05. Process its exit first." |
| Entry | Preset slot taken meanwhile | "That slot was just taken or reserved. The next free slot is selected instead." |
| Entry | Zone full / lot full | "Zone B — full" + hint / Save disabled + "Parking is full…" |
| Exit | No match / nothing parked | Clear message, Pay disabled |
| Exit | Answer No to payment confirm | Nothing changes |
| Exit | Double payment / record deleted meanwhile | "already paid" / "was deleted" + list refreshed |
| Map | Reserve / release | Status line; occupied slots offer exit/edit/history instead |
| Rates | Non-number / negative / FlatHours < 1 / too large | Inline message, save blocked |
| Records | Bad date range / nothing selected / nothing to print | Inline message |
| Records | Edit: duplicate plate / no changes / slot taken meanwhile | Inline message |
| Records | Delete parked / completed | Confirm popup → status line, slot freed / totals update |
| Any | Logout / closing the app | Yes/No confirmation |
| Debug | Generate / clear / reset rates | Confirm popup → log line; map and cards refresh on close |
| Debug | Query timeout / connection failure / unexpected error | Standard error dialog; app keeps running |

## 8. Status
- [x] Spec agreed, database scripts, helpers, logic, all forms + designers
- [x] Controlled CRUD on Records + Last Updated (v0.4)
- [x] Map-centred flow, pickers, suggestions, inline messages (v0.5)
- [x] Compiles (Mono `mcs` against WinForms/SqlClient); 92/92 scripted flow checks pass on a SQLite stand-in database
- [x] v0.5.1: data access, form checks, printing and charts moved onto the provided helper classes; compiles with no warnings (Roslyn C# 7.3 against .NET Framework 4.8 reference assemblies); report and stub print pages render correctly. Not run against LocalDB here (no SQL Server available).
- [x] v0.5.2: `PlateKey` index warning fixed (schema only)
- [x] v0.5.3: Debug Tools module. No compiler was available in the build environment: every `.cs` file passes a C# syntax parse and was reviewed by hand for C# 7.3, but it has **not** been compiled or run — build it in Visual Studio first.
- [ ] Run in Visual Studio on Windows + LocalDB (user)
- [ ] Documentation chapters (if the instructor requires them)

## 9. Change log
- v0.1 initial spec from mockup
- v0.2 editable rates form, read-only entry time, view-only records
- v0.3 implementation layout (Forms / Logic / Helpers), DataDirectory → project folder, CSV export + stub reprint
- v0.4 view-only records replaced by controlled CRUD; `ParkingTransactions.UpdatedAt`
- v0.5.1 helper classes integrated (§4a): `DbHelper` and `PrintHelper` removed; all services use `AppDb.Instance`; forms use `FormControls`, `ReportPrinter`, `Charts`; new **View Chart** button + `ReportChartForm`; connection string renamed `AppDB`; admin password `parking`; car-front login logo. No schema change.
- v0.5.3 **Debug Tools** module (§3a): `DebugForm`, `DebugService`, `DiagnosticsService`, `CheckResult` model, sidebar button. Built on the helper classes (`AppDb.Instance`); not ported from v0.6. No schema change.
- v0.5.2 schema fix: `Vehicles.PlateKey` cast to `NVARCHAR(15)` so `UQ_Vehicles_PlateKey` no longer triggers SQL Server's 1700-byte index key warning (present since v0.5). **Re-run 01/02 (and 03 if wanted).** No code change.
- v0.5 usability revamp (§6): home = parking map with info panel/actions, SlotMapControl + SlotPickerForm, zone + number slot picker, exit list/search/picker, live plate/owner suggestions (SuggestBox), Find vehicle, `Vehicles.PlateKey`, inline status lines, removed Quick Actions / SlotManagementForm / Search button. **Schema changed → re-run 01/02/03.**
