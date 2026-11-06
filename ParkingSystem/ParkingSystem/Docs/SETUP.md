# Setup Guide — Parking Location Management System

## Requirements
- **Visual Studio 2022** (Community is fine) with the **.NET desktop development** workload.
- **SQL Server Express LocalDB** — normally installed with that workload.
  If not: Visual Studio Installer → Modify → *Individual components* → tick **SQL Server Express 2019 LocalDB**.
- **.NET Framework 4.8** targeting pack (included with the workload).

## 1. Open the project
1. Unzip `ParkingSystem.zip`.
2. Double-click **`ParkingSystem.sln`**.

## 2. Create the database file (Service-based Database)
1. In **Solution Explorer**, right-click the **ParkingSystem** project → **Add → New Item…**
2. Search for **Service-based Database**, name it exactly **`ParkingDB.mdf`**, click **Add**.
   - If a *Data Source Configuration Wizard* appears, click **Cancel**. It's not needed.
3. Click `ParkingDB.mdf` in Solution Explorer → in **Properties** set
   **Copy to Output Directory = Do not copy**.
   The app reads the `.mdf` in the project folder directly (see `Program.cs`). That way the app and
   Server Explorer always show the same data.

## 3. Create the tables and default data
1. Open **View → Server Explorer** → *Data Connections* → **ParkingDB.mdf**.
2. Right-click **ParkingDB.mdf** → **New Query**.
3. Open `Database/01_schema.sql`, copy everything, paste it into the query window, and press **Execute**
   (green ▶ or **Ctrl+Shift+E**).
4. Clear the query window, then paste and execute **`Database/02_seed.sql`**.
   The last result should show `Users 1 | Rates 3 | Slots 50`.
5. *(Optional, recommended for the demo)* paste and execute **`Database/03_sample_data.sql`**.
   This adds a few completed and parked visits so Records and the Dashboard aren't empty.
6. In Server Explorer, right-click **Tables → Refresh**. You should see 6 tables.

## 4. Run
Press **F5**. Log in with:

| Username | Password |
|---|---|
| `admin` | `parking` |

## Updating from an earlier version
The schema changed in v0.4 (`UpdatedAt`), v0.5 (`Vehicles.PlateKey`) and v0.5.2 (`PlateKey` cast to `NVARCHAR(15)`, removes the 1700-byte index warning). If your tables came from an older
`01_schema.sql`, run `01_schema.sql`, `02_seed.sql` and (optionally) `03_sample_data.sql` again.
Until you do, you'll get errors like "Invalid column name 'PlateKey'".

The admin password changed from `admin123` to `parking`. To keep your existing data, run just this instead:
`UPDATE dbo.Users SET Password = 'parking' WHERE Username = 'admin';`

## Reset the database to a clean state
Run `01_schema.sql` and then `02_seed.sql` again (and `03_sample_data.sql` if you want demo data).
Running `01` **deletes all data**.

## Troubleshooting
| Problem | Fix |
|---|---|
| "Cannot connect to the database…" at login | Check `ParkingDB.mdf` exists in the **project folder** (next to `Program.cs`) and steps 3.1–3.6 were done. |
| "Invalid object name 'Users'" | The scripts ran against a different database. Make sure the query window was opened from **ParkingDB.mdf** in Server Explorer, then run 01 and 02 again. |
| LocalDB not found / instance error | In **Tools → Command Line → Developer Command Prompt**, run `sqllocaldb info`. If `MSSQLLocalDB` is missing, run `sqllocaldb create MSSQLLocalDB`, then `sqllocaldb start MSSQLLocalDB`. |
| Database file "in use" error | In Server Explorer, right-click ParkingDB.mdf → **Close Connection**, then run the app again. |
| Print preview says a printer is needed | Windows needs at least one printer installed. "Microsoft Print to PDF" counts (Settings → Printers & scanners). |
| Peso sign (₱) shows as a box | Use a font that has it (Segoe UI does). This only happens if fonts were changed. |
| Designer added `.resx` files | Normal; Visual Studio creates them when you edit a form in the designer. |
| Designer shows an error box for `slotMap` | Build the project once (Ctrl+Shift+B), then close and reopen the form. |

## Project layout (where to change things)
| Want to change… | Look in |
|---|---|
| Screen layout | Open the form in the designer (`Forms/*.cs` → Shift+F7). Build once (Ctrl+Shift+B) first so the designer can show the parking map control. |
| The parking map | `Controls/SlotMapControl.cs` (used by the home screen and the slot picker) |
| Suggestions while typing | `Controls/SuggestBox.cs` + matching rules in `Logic/SearchHelper.cs` |
| What a button does | `Forms/<Form>.cs` |
| Business rules (fees, duplicate checks, slot rules) | `Logic/` |
| Input format rules (plate, name, numbers) | `Helpers/Validator.cs` |
| Colours of the slot grid / tabs | `Helpers/Theme.cs` |
| Database calls, report printing, charts, required-field checks | `Classes/` (provided helper classes, see `SPEC.md` §4a) |
| Rates | Run the app → **Rates Settings** (stored in the database) |
| Connection string | `App.config` (name must stay `AppDB`) |
| Tables and columns | `Database/01_schema.sql` + `Docs/schema_references.md` |
