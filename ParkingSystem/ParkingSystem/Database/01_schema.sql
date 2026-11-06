/* =====================================================================
   Parking Location Management System - 01_schema.sql
   Creates all tables. Safe to re-run: drops existing tables first
   (WARNING: re-running deletes all data). Run 02_seed.sql afterwards.
   How to run: Server Explorer > right-click ParkingDB.mdf > New Query
               > paste this file > Execute (Ctrl+Shift+E).
   ===================================================================== */

-- Drop in reverse dependency order (children first)
IF OBJECT_ID('dbo.CardStubs', 'U')            IS NOT NULL DROP TABLE dbo.CardStubs;
IF OBJECT_ID('dbo.ParkingTransactions', 'U')  IS NOT NULL DROP TABLE dbo.ParkingTransactions;
IF OBJECT_ID('dbo.Vehicles', 'U')             IS NOT NULL DROP TABLE dbo.Vehicles;
IF OBJECT_ID('dbo.ParkingSlots', 'U')         IS NOT NULL DROP TABLE dbo.ParkingSlots;
IF OBJECT_ID('dbo.VehicleRates', 'U')         IS NOT NULL DROP TABLE dbo.VehicleRates;
IF OBJECT_ID('dbo.Users', 'U')                IS NOT NULL DROP TABLE dbo.Users;
GO

-- 1. Users: system login (single admin account by design)
CREATE TABLE dbo.Users (
    UserID      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
    Username    NVARCHAR(50)      NOT NULL CONSTRAINT UQ_Users_Username UNIQUE,
    Password    NVARCHAR(50)      NOT NULL,
    FullName    NVARCHAR(100)     NOT NULL
);
GO

-- 2. VehicleRates: one row per vehicle type, editable in Rates Settings
CREATE TABLE dbo.VehicleRates (
    VehicleType     NVARCHAR(20)   NOT NULL CONSTRAINT PK_VehicleRates PRIMARY KEY,
    FlatRate        DECIMAL(10,2)  NOT NULL CONSTRAINT CK_VehicleRates_FlatRate CHECK (FlatRate >= 0),
    FlatHours       INT            NOT NULL CONSTRAINT CK_VehicleRates_FlatHours CHECK (FlatHours >= 1),
    SucceedingRate  DECIMAL(10,2)  NOT NULL CONSTRAINT CK_VehicleRates_SuccRate CHECK (SucceedingRate >= 0),
    UpdatedAt       DATETIME       NOT NULL CONSTRAINT DF_VehicleRates_UpdatedAt DEFAULT GETDATE()
);
GO

-- 3. Vehicles: one row per plate number (reused on every visit -> history)
CREATE TABLE dbo.Vehicles (
    VehicleID    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Vehicles PRIMARY KEY,
    PlateNumber  NVARCHAR(15)      NOT NULL CONSTRAINT UQ_Vehicles_Plate UNIQUE,
    VehicleType  NVARCHAR(20)      NOT NULL CONSTRAINT FK_Vehicles_VehicleRates
                                   REFERENCES dbo.VehicleRates (VehicleType),
    OwnerName    NVARCHAR(100)     NOT NULL,
    CreatedAt    DATETIME          NOT NULL CONSTRAINT DF_Vehicles_CreatedAt DEFAULT GETDATE(),
    -- Search/compare key: no spaces or dashes, so 'ABC1234', 'ABC 1234' and 'ABC-1234' are the SAME vehicle.
    -- CAST keeps the key at 15 characters (REPLACE alone returns NVARCHAR(4000) -> 1700-byte index warning).
    PlateKey     AS CAST(REPLACE(REPLACE(PlateNumber, ' ', ''), '-', '') AS NVARCHAR(15)) PERSISTED,
    CONSTRAINT UQ_Vehicles_PlateKey UNIQUE (PlateKey)
);
GO

-- 4. ParkingSlots: 50 slots, A01..E10
CREATE TABLE dbo.ParkingSlots (
    SlotID      INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ParkingSlots PRIMARY KEY,
    SlotNumber  NVARCHAR(5)       NOT NULL CONSTRAINT UQ_ParkingSlots_Number UNIQUE,
    Zone        NCHAR(1)          NOT NULL,
    Status      NVARCHAR(15)      NOT NULL CONSTRAINT DF_ParkingSlots_Status DEFAULT 'Available'
                                  CONSTRAINT CK_ParkingSlots_Status
                                  CHECK (Status IN ('Available', 'Occupied', 'Reserved')),
    UpdatedAt   DATETIME          NOT NULL CONSTRAINT DF_ParkingSlots_UpdatedAt DEFAULT GETDATE()
);
GO

-- 5. ParkingTransactions: one row per visit (entry -> exit)
CREATE TABLE dbo.ParkingTransactions (
    TransactionID    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ParkingTransactions PRIMARY KEY,
    VehicleID        INT               NOT NULL CONSTRAINT FK_Transactions_Vehicles
                                       REFERENCES dbo.Vehicles (VehicleID),
    SlotID           INT               NOT NULL CONSTRAINT FK_Transactions_Slots
                                       REFERENCES dbo.ParkingSlots (SlotID),
    EntryTime        DATETIME          NOT NULL,
    ExitTime         DATETIME          NULL,       -- NULL while still parked
    DurationMinutes  INT               NULL,       -- filled at exit
    Fee              DECIMAL(10,2)     NULL,       -- filled at exit (frozen, rate changes do not affect it)
    Status           NVARCHAR(15)      NOT NULL CONSTRAINT DF_Transactions_Status DEFAULT 'Parked'
                                       CONSTRAINT CK_Transactions_Status
                                       CHECK (Status IN ('Parked', 'Completed')),
    UpdatedAt        DATETIME          NOT NULL CONSTRAINT DF_Transactions_UpdatedAt DEFAULT GETDATE(),  -- last change (entry, payment or edit)
    CONSTRAINT CK_Transactions_ExitAfterEntry CHECK (ExitTime IS NULL OR ExitTime >= EntryTime)
);
GO

-- Safety nets: a vehicle can be parked only once at a time, a slot can hold only one vehicle
CREATE UNIQUE INDEX UX_Transactions_ActiveVehicle ON dbo.ParkingTransactions (VehicleID) WHERE Status = 'Parked';
CREATE UNIQUE INDEX UX_Transactions_ActiveSlot    ON dbo.ParkingTransactions (SlotID)    WHERE Status = 'Parked';
GO

-- 6. CardStubs: the receipt issued at exit. Plate/times/fee come from the transaction (JOIN), not copied.
CREATE TABLE dbo.CardStubs (
    StubID         INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_CardStubs PRIMARY KEY,
    StubNo         AS RIGHT('000000' + CAST(StubID AS VARCHAR(10)), 6) PERSISTED,  -- 000001, 000002 ...
    TransactionID  INT               NOT NULL CONSTRAINT UQ_CardStubs_Transaction UNIQUE
                                     CONSTRAINT FK_CardStubs_Transactions
                                     REFERENCES dbo.ParkingTransactions (TransactionID),
    IssuedAt       DATETIME          NOT NULL CONSTRAINT DF_CardStubs_IssuedAt DEFAULT GETDATE()
);
GO
