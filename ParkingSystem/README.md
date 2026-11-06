# Parking Location Management System (v0.5.3)

C# WinForms (.NET Framework 4.8) and a Service-based Database (LocalDB).
Database access, required-field checks, report printing and charts use the provided helper classes in
`ParkingSystem/Classes` (`AppDb`, `SqlDatabase`, `FormControls`, `Charts`, `ReportPrinter`) — see `SPEC.md` §4a.

- **Setup (start here):** `ParkingSystem/Docs/SETUP.md`
- **Spec, decisions, usability assessment and validation checklist:** `ParkingSystem/Docs/SPEC.md`
- **Every table and column, and who uses it:** `ParkingSystem/Docs/schema_references.md`

Quick start: open `ParkingSystem.sln` → add a Service-based Database named `ParkingDB.mdf` → run
`Database/01_schema.sql`, `02_seed.sql` (and `03_sample_data.sql` for demo data) from Server Explorer → F5 →
log in with `admin` / `parking`.
