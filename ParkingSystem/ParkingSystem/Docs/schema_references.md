# Schema References — ParkingDB

Every table and column, what it means, and which part of the program reads (R) or writes (W) it.
Scripts: `Database/01_schema.sql` (tables), `Database/02_seed.sql` (defaults), `Database/03_sample_data.sql` (optional demo rows).

## Relationship overview
```
VehicleRates 1 ──< Vehicles 1 ──< ParkingTransactions >── 1 ParkingSlots
                                         │
                                         1
                                         │
                                    CardStubs (0..1 per transaction)
Users (stand-alone, login only)
```
- A **vehicle** (plate) can have many transactions over time → visit history.
- A **slot** can have many transactions over time, but only **one `Parked`** at a time (filtered unique index).
- A **transaction** gets **at most one** stub (`UQ_CardStubs_Transaction`), created at payment.

---

## Users
| Column | Type | Rules | Meaning |
|---|---|---|---|
| UserID | INT IDENTITY | PK | Internal id |
| Username | NVARCHAR(50) | NOT NULL, UNIQUE | Login name (`admin`) |
| Password | NVARCHAR(50) | NOT NULL | Plain text by design (prototype scope) |
| FullName | NVARCHAR(100) | NOT NULL | Shown as "Welcome, …" on the dashboard |

Used by: `AuthService.Login` (R) ← `LoginForm`.

## VehicleRates
| Column | Type | Rules | Meaning |
|---|---|---|---|
| VehicleType | NVARCHAR(20) | PK | `Car`, `Motorcycle`, `Van/SUV` |
| FlatRate | DECIMAL(10,2) | ≥ 0 | Charge covering the first `FlatHours` |
| FlatHours | INT | ≥ 1 | Hours covered by the flat rate (default 3) |
| SucceedingRate | DECIMAL(10,2) | ≥ 0 | Charge per extra hour or part of an hour |
| UpdatedAt | DATETIME | default now | Last time the rate was edited |

Used by: `RateService.GetAll/Get` (R) ← `VehicleEntryForm` (type list + rate hint), `VehicleExitForm` (fee), `DashboardForm` (fee so far);
`RateService.SaveAll` (W) ← `RatesForm`; `DebugService.ResetRates` (W) ← `DebugForm`.

## Vehicles
| Column | Type | Rules | Meaning |
|---|---|---|---|
| VehicleID | INT IDENTITY | PK | Internal id |
| PlateNumber | NVARCHAR(15) | NOT NULL, UNIQUE | Normalized: uppercase, single spaces (e.g. `ABC 1234`) |
| VehicleType | NVARCHAR(20) | FK → VehicleRates | Determines the rate |
| OwnerName | NVARCHAR(100) | NOT NULL | Latest owner/driver name entered |
| CreatedAt | DATETIME | default now | First time the plate was seen |
| PlateKey | NVARCHAR(15), computed, persisted | `CAST(REPLACE(REPLACE(PlateNumber,' ',''),'-','') AS NVARCHAR(15))`, **UNIQUE** | Comparison key: `ABC1234`, `ABC 1234` and `ABC-1234` are the same vehicle. All plate lookups use it. |

Used by: `ParkingService.GetVehicles` (R, plate/owner suggestions), `ParkingService.FindVehicle` (R by PlateKey), `ParkingService.ParkVehicle` (W: insert new or update type/owner),
`RecordService.UpdateRecord` (W: plate/type/owner edit), `RecordService.DeleteRecord` (W: removes a vehicle with no visits left), `DebugService.GenerateSampleData/ClearAllRecords` (W), `DiagnosticsService.CheckIntegrity` (R: orphan vehicles);
JOINed by `ParkingService.GetActiveList/FindActive`, `SlotService.GetAll` (car details on occupied slots), `ReportService.GetRecords` (search by PlateKey or OwnerName) / `GetStub`.

## ParkingSlots
| Column | Type | Rules | Meaning |
|---|---|---|---|
| SlotID | INT IDENTITY | PK | Internal id |
| SlotNumber | NVARCHAR(5) | NOT NULL, UNIQUE | `A01` … `E10` |
| Zone | NCHAR(1) | NOT NULL | `A` … `E` (grid row) |
| Status | NVARCHAR(15) | `Available` / `Occupied` / `Reserved` | Current state |
| UpdatedAt | DATETIME | default now | Last status change ("Free since" / "Reserved since" on the map) |

Status changes:
| From → To | Who | Where in code |
|---|---|---|
| Available → Occupied | Vehicle entry | `ParkingService.ParkVehicle` (only `WHERE Status='Available'`) |
| Occupied → Available | Payment at exit | `ParkingService.CompleteExit` |
| Available → Reserved | "Reserve slot" on the map | `SlotService.Reserve` (only `WHERE Status='Available'`) |
| Reserved → Available | "Release reservation" on the map | `SlotService.Release` (only `WHERE Status='Reserved'`) |
| Occupied → Available + Available → Occupied | Move a parked vehicle (Edit Record) | `RecordService.UpdateRecord` |
| Occupied → Available | Delete a parked record (void entry) | `RecordService.DeleteRecord` |

Used by: `SlotService.GetAll` (R, every slot + parked car) ← `DashboardForm` map, `SlotPickerForm`;
`SlotService.GetAvailable` (R) ← `VehicleEntryForm` zone/number pickers; `ReportService.GetDashboardStats` (R) ← `DashboardForm` cards; `DebugService` (W: sample data, clear).

## ParkingTransactions
| Column | Type | Rules | Meaning |
|---|---|---|---|
| TransactionID | INT IDENTITY | PK | One row per visit |
| VehicleID | INT | FK → Vehicles | Who parked |
| SlotID | INT | FK → ParkingSlots | Where |
| EntryTime | DATETIME | NOT NULL | Set automatically at entry (read-only in UI) |
| ExitTime | DATETIME | NULL until exit, ≥ EntryTime | Set at payment |
| DurationMinutes | INT | NULL until exit | Whole minutes parked |
| Fee | DECIMAL(10,2) | NULL until exit | Amount charged — frozen, later rate changes do not alter it |
| Status | NVARCHAR(15) | `Parked` / `Completed` | `Parked` = still inside |
| UpdatedAt | DATETIME | NOT NULL, default now | "Last updated": set at entry, at payment, and on every edit (vehicle edits stamp all visits of that vehicle) |

Indexes: `UX_Transactions_ActiveVehicle` and `UX_Transactions_ActiveSlot` — unique on VehicleID / SlotID **where Status = 'Parked'**.
They make double-parking impossible even if the program had a bug.

Used by: `ParkingService.ParkVehicle` (W insert `Parked`), `ParkingService.GetActiveList/FindActive` (R, Vehicle Exit list), `ParkingService.CompleteExit` (W → `Completed`, only `WHERE Status='Parked'` so it cannot be paid twice),
`ReportService.GetRecords` (R) ← `RecordsForm`, `ReportService.GetDashboardStats` (R, today's income),
`RecordService.GetRecord` (R) / `UpdateRecord` (W: slot move + UpdatedAt) / `DeleteRecord` (W) ← `RecordEditForm`, `RecordsForm`;
`DebugService` (W: sample data, clear, advance parked time) and `DiagnosticsService.CheckIntegrity` (R) ← `DebugForm`.

## CardStubs
| Column | Type | Rules | Meaning |
|---|---|---|---|
| StubID | INT IDENTITY | PK | Internal id |
| StubNo | computed | `RIGHT('000000'+StubID, 6)`, persisted | Printed number `000001` … |
| TransactionID | INT | FK → ParkingTransactions, UNIQUE | The paid visit |
| IssuedAt | DATETIME | default now | When the stub was issued (= payment time) |

Plate, slot, times and fee are **not copied** here; they are read with a JOIN (normalized design).

Used by: `ParkingService.CompleteExit` (W), `RecordService.DeleteRecord` (W, deleted with its transaction), `ReportService.GetStub` (R, reprint from Records),
`ReportService.GetDashboardStats` (R, stubs issued today), `ReportService.GetRecords` (R, stub no. column), `DebugService` (W: sample data, clear), `DiagnosticsService.CheckIntegrity` (R).

---

## Key queries (for defense)
**Parking map (every slot + the car in it)**
```sql
SELECT s.SlotID, s.SlotNumber, s.Zone, s.Status, s.UpdatedAt, t.TransactionID, t.EntryTime,
       v.PlateNumber, v.OwnerName, v.VehicleType
FROM ParkingSlots s
LEFT JOIN ParkingTransactions t ON t.SlotID = s.SlotID AND t.Status = 'Parked'
LEFT JOIN Vehicles v ON v.VehicleID = t.VehicleID
ORDER BY s.SlotNumber;
```
**Dashboard counts**
```sql
SELECT COUNT(*) AS Total,
       SUM(CASE WHEN Status = 'Available' THEN 1 ELSE 0 END) AS Available,
       SUM(CASE WHEN Status = 'Occupied'  THEN 1 ELSE 0 END) AS Occupied,
       SUM(CASE WHEN Status = 'Reserved'  THEN 1 ELSE 0 END) AS Reserved
FROM ParkingSlots;
```
**Total card stubs (all time)**
```sql
SELECT COUNT(*) AS TotalStubs FROM CardStubs;
```
**Today's income**
```sql
SELECT ISNULL(SUM(t.Fee), 0) AS Income, COUNT(*) AS Stubs
FROM CardStubs c JOIN ParkingTransactions t ON t.TransactionID = c.TransactionID
WHERE c.IssuedAt >= @today AND c.IssuedAt < @tomorrow;
```
**Vehicle history**
```sql
SELECT t.*, s.SlotNumber FROM ParkingTransactions t
JOIN Vehicles v ON v.VehicleID = t.VehicleID
JOIN ParkingSlots s ON s.SlotID = t.SlotID
WHERE v.PlateKey = @key ORDER BY t.EntryTime DESC;   -- @key = plate without spaces/dashes
```
**Records search (plate or owner)**
```sql
... WHERE (@text = '' OR v.PlateKey LIKE @keyPattern OR v.OwnerName LIKE @namePattern)
```

## Fee formula (FeeCalculator.ComputeFee)
```
hours = ceiling(DurationMinutes / 60), minimum 1
fee   = FlatRate                                         if hours <= FlatHours
      = FlatRate + (hours - FlatHours) * SucceedingRate  otherwise
```
