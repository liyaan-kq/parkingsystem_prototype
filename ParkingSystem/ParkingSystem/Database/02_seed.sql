/* =====================================================================
   Parking Location Management System - 02_seed.sql
   Default data: admin account, vehicle rates, 50 parking slots.
   Run right after 01_schema.sql.
   ===================================================================== */

-- Admin account (plain text by design - prototype scope)
INSERT INTO dbo.Users (Username, Password, FullName)
VALUES ('admin', 'parking', 'Administrator');

-- Rates: flat rate covers the first FlatHours, then SucceedingRate per extra hour (or part)
INSERT INTO dbo.VehicleRates (VehicleType, FlatRate, FlatHours, SucceedingRate) VALUES
('Car',        50.00, 3, 20.00),
('Motorcycle', 20.00, 3, 10.00),
('Van/SUV',    70.00, 3, 30.00);

-- 50 slots: zones A-E, 10 slots each (A01..E10)
DECLARE @z INT = 0, @n INT;
WHILE @z < 5
BEGIN
    SET @n = 1;
    WHILE @n <= 10
    BEGIN
        INSERT INTO dbo.ParkingSlots (SlotNumber, Zone, Status)
        VALUES (CHAR(65 + @z) + RIGHT('0' + CAST(@n AS VARCHAR(2)), 2), CHAR(65 + @z), 'Available');
        SET @n = @n + 1;
    END
    SET @z = @z + 1;
END

-- Quick check (should return 1, 3, 50)
SELECT (SELECT COUNT(*) FROM dbo.Users)        AS Users,
       (SELECT COUNT(*) FROM dbo.VehicleRates) AS Rates,
       (SELECT COUNT(*) FROM dbo.ParkingSlots) AS Slots;
