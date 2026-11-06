using System;
using System.Collections.Generic;
using red_framework;

namespace ParkingSystem.Logic
{
    public static class RateService
    {
        private const string RateSelect = "SELECT VehicleType, FlatRate, FlatHours, SucceedingRate FROM VehicleRates ";

        public static List<VehicleRate> GetAll()
        {
            return AppDb.Instance.QueryList<VehicleRate>(RateSelect +
                "ORDER BY CASE VehicleType WHEN 'Car' THEN 1 WHEN 'Motorcycle' THEN 2 ELSE 3 END, VehicleType");
        }

        public static VehicleRate Get(string vehicleType)
        {
            return AppDb.Instance.QuerySingle<VehicleRate>(RateSelect + "WHERE VehicleType = @VehicleType",
                new { VehicleType = vehicleType });
        }

        public static OperationResult SaveAll(List<VehicleRate> rates)
        {
            IDatabase db = AppDb.Instance;
            DateTime now = DateTime.Now;
            db.ExecuteTransaction(tran =>
            {
                foreach (VehicleRate r in rates)
                {
                    db.Update("VehicleRates", new
                    {
                        r.VehicleType,
                        r.FlatRate,
                        r.FlatHours,
                        r.SucceedingRate,
                        UpdatedAt = now
                    }, "VehicleType");
                }
                return true;
            });
            return OperationResult.Ok("Rates saved. New rates apply to vehicles that exit from now on.");
        }
    }
}
