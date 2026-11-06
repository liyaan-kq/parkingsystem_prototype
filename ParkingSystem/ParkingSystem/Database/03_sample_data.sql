/* =====================================================================
   Parking Location Management System - 03_sample_data.sql   (OPTIONAL)
   Demo data so Records/Reports and the Dashboard are not empty.
   Run ONCE on a fresh database (after 01 and 02). Times are relative
   to "now" so the data always looks recent.
   Fees below follow the default rates (flat 3 h, then per extra hour).
   ===================================================================== */

IF EXISTS (SELECT 1 FROM dbo.ParkingTransactions)
BEGIN
    RAISERROR('Sample data skipped: transactions already exist. Re-run 01 and 02 first for a clean database.', 16, 1);
    SET NOEXEC ON;
END

DECLARE @now DATETIME = GETDATE();
DECLARE @y   DATETIME = CAST(CAST(DATEADD(DAY, -1, @now) AS DATE) AS DATETIME);  -- yesterday 00:00

INSERT INTO dbo.Vehicles (PlateNumber, VehicleType, OwnerName, CreatedAt) VALUES
('ABC 1234', 'Car',        'Juan Dela Cruz', @y),
('DEF 1357', 'Van/SUV',    'Pedro Reyes',    @y),
('GHI 2468', 'Motorcycle', 'Ana Lopez',      @y),
('XYZ 5678', 'Car',        'Maria Santos',   @now),
('JKL 9012', 'Car',        'Carlo Mendoza',  @now);

-- Completed visits (yesterday + one today). Fee = flat + extra hours x succeeding rate.
INSERT INTO dbo.ParkingTransactions (VehicleID, SlotID, EntryTime, ExitTime, DurationMinutes, Fee, Status, UpdatedAt)
SELECT v.VehicleID, s.SlotID, x.EntryTime, x.ExitTime, DATEDIFF(MINUTE, x.EntryTime, x.ExitTime), x.Fee, 'Completed', x.ExitTime
FROM (VALUES
    ('ABC 1234', 'A05', DATEADD(MINUTE,  8*60+15, @y), DATEADD(MINUTE, 10*60+24, @y),  50.00),  -- 2h 09m  Car
    ('DEF 1357', 'A08', DATEADD(MINUTE,  7*60+45, @y), DATEADD(MINUTE, 11*60+20, @y), 100.00),  -- 3h 35m  Van/SUV 70+30
    ('GHI 2468', 'B05', DATEADD(MINUTE, 12*60+30, @y), DATEADD(MINUTE, 14*60+15, @y),  20.00),  -- 1h 45m  Motorcycle
    ('ABC 1234', 'C01', DATEADD(MINUTE, -300, @now),   DATEADD(MINUTE, -60, @now),     70.00)   -- 4h 00m  Car 50+20
) AS x (Plate, Slot, EntryTime, ExitTime, Fee)
JOIN dbo.Vehicles v     ON v.PlateNumber = x.Plate
JOIN dbo.ParkingSlots s ON s.SlotNumber  = x.Slot;

-- One stub per completed visit, issued at exit time
INSERT INTO dbo.CardStubs (TransactionID, IssuedAt)
SELECT TransactionID, ExitTime FROM dbo.ParkingTransactions WHERE Status = 'Completed' ORDER BY ExitTime;

-- Vehicles currently parked
INSERT INTO dbo.ParkingTransactions (VehicleID, SlotID, EntryTime, Status, UpdatedAt)
SELECT v.VehicleID, s.SlotID, x.EntryTime, 'Parked', x.EntryTime
FROM (VALUES
    ('XYZ 5678', 'B03', DATEADD(MINUTE, -75,  @now)),
    ('JKL 9012', 'A02', DATEADD(MINUTE, -200, @now))
) AS x (Plate, Slot, EntryTime)
JOIN dbo.Vehicles v     ON v.PlateNumber = x.Plate
JOIN dbo.ParkingSlots s ON s.SlotNumber  = x.Slot;

-- Keep slot statuses consistent with the data above
UPDATE dbo.ParkingSlots SET Status = 'Occupied', UpdatedAt = @now WHERE SlotNumber IN ('B03', 'A02');
UPDATE dbo.ParkingSlots SET Status = 'Reserved', UpdatedAt = @now WHERE SlotNumber IN ('A10', 'B10');

SET NOEXEC OFF;
