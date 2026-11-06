using System;
using System.Data;
using System.IO;
using System.Text;

namespace ParkingSystem.Helpers
{
    public static class ExportHelper
    {
        public static void SaveCsv(string path, DataTable data)
        {
            StringBuilder sb = new StringBuilder();
            string[] values = new string[data.Columns.Count];

            for (int c = 0; c < data.Columns.Count; c++)
                values[c] = data.Columns[c].ColumnName;
            sb.AppendLine(ToCsvLine(values));

            foreach (DataRow row in data.Rows)
            {
                for (int c = 0; c < data.Columns.Count; c++)
                    values[c] = Convert.ToString(row[c]);
                sb.AppendLine(ToCsvLine(values));
            }

            File.WriteAllText(path, sb.ToString(), new UTF8Encoding(true));
        }

        private static string ToCsvLine(string[] values)
        {
            string[] escaped = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                string v = values[i] ?? "";
                if (v.Contains(",") || v.Contains("\"") || v.Contains("\n"))
                    v = "\"" + v.Replace("\"", "\"\"") + "\"";
                escaped[i] = v;
            }
            return string.Join(",", escaped);
        }
    }
}
