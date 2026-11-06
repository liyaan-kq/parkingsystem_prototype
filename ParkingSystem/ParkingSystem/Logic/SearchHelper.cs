using System;
using System.Collections.Generic;
using ParkingSystem.Helpers;

namespace ParkingSystem.Logic
{
    public static class SearchHelper
    {
        public static int Score(string typed, string plate, string owner, string slot)
        {
            string text = (typed ?? "").Trim();
            if (text.Length == 0) return 0;

            string key = Validator.PlateKey(text);
            string plateKey = Validator.PlateKey(plate);
            if (key.Length > 0 && plateKey.StartsWith(key, StringComparison.Ordinal)) return 3;
            if (key.Length > 0 && plateKey.Contains(key)) return 2;
            if (OwnerMatches(text, owner)) return 1;
            if (SlotMatches(text, slot)) return 1;
            return 0;
        }

        public static bool OwnerMatches(string typed, string owner)
        {
            if (string.IsNullOrWhiteSpace(typed) || string.IsNullOrEmpty(owner)) return false;
            string t = typed.Trim();
            if (owner.StartsWith(t, StringComparison.OrdinalIgnoreCase)) return true;
            foreach (string word in owner.Split(' '))
                if (word.StartsWith(t, StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }

        public static bool SlotMatches(string typed, string slot)
        {
            if (string.IsNullOrEmpty(slot)) return false;
            string t = (typed ?? "").Trim().ToUpperInvariant();
            if (t.Length < 2 || t.Length > 3 || t[0] < 'A' || t[0] > 'E') return false;
            int n;
            if (!int.TryParse(t.Substring(1), out n)) return false;
            return slot == t[0] + n.ToString("00");
        }

        public static List<VehicleInfo> MatchVehicles(List<VehicleInfo> vehicles, string typed, int max)
        {
            List<KeyValuePair<int, VehicleInfo>> scored = new List<KeyValuePair<int, VehicleInfo>>();
            foreach (VehicleInfo v in vehicles)
            {
                int score = Score(typed, v.PlateNumber, v.OwnerName, null);
                if (score > 0) scored.Add(new KeyValuePair<int, VehicleInfo>(score, v));
            }
            scored.Sort((a, b) => a.Key != b.Key ? b.Key.CompareTo(a.Key) : string.CompareOrdinal(a.Value.PlateNumber, b.Value.PlateNumber));

            List<VehicleInfo> result = new List<VehicleInfo>();
            for (int i = 0; i < scored.Count && i < max; i++) result.Add(scored[i].Value);
            return result;
        }

        public static List<ActiveParking> MatchActive(List<ActiveParking> parked, string typed)
        {
            if (string.IsNullOrWhiteSpace(typed)) return new List<ActiveParking>(parked);
            List<ActiveParking> result = new List<ActiveParking>();
            foreach (ActiveParking p in parked)
                if (Score(typed, p.PlateNumber, p.OwnerName, p.SlotNumber) > 0) result.Add(p);
            return result;
        }
    }
}
