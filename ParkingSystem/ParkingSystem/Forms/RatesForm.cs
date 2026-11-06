using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;

namespace ParkingSystem.Forms
{
    public partial class RatesForm : Form
    {
        private const decimal MaxMoney = 10000m;
        private const int MaxFlatHours = 24;

        private bool loading;
        private bool dirty;

        public RatesForm()
        {
            InitializeComponent();
        }

        private void RatesForm_Load(object sender, EventArgs e)
        {
            colFlatRate.HeaderText = "Flat Rate (" + FeeCalculator.Peso + ")";
            colSucceedingRate.HeaderText = "Succeeding Rate (" + FeeCalculator.Peso + "/hr)";
            LoadRates();
        }

        private void LoadRates()
        {
            loading = true;
            try
            {
                dgvRates.Rows.Clear();
                foreach (VehicleRate r in RateService.GetAll())
                    dgvRates.Rows.Add(r.VehicleType, r.FlatRate.ToString("0.00"), r.FlatHours.ToString(), r.SucceedingRate.ToString("0.00"));
                dirty = false;
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
                btnSave.Enabled = false;
            }
            finally
            {
                loading = false;
            }
        }

        private void dgvRates_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!loading) dirty = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvRates.EndEdit();

            List<VehicleRate> rates = new List<VehicleRate>();
            foreach (DataGridViewRow row in dgvRates.Rows)
            {
                string type = Convert.ToString(row.Cells[colVehicleType.Index].Value);
                decimal flatRate, succeedingRate;
                int flatHours;

                if (!Validator.TryParseMoney(Convert.ToString(row.Cells[colFlatRate.Index].Value), 0, MaxMoney, out flatRate))
                {
                    ShowCellError(row, colFlatRate, type + ": Flat Rate must be a number from 0 to " + MaxMoney.ToString("N0") + " (max 2 decimals).");
                    return;
                }
                if (!Validator.TryParseWholeNumber(Convert.ToString(row.Cells[colFlatHours.Index].Value), 1, MaxFlatHours, out flatHours))
                {
                    ShowCellError(row, colFlatHours, type + ": Flat Hours must be a whole number from 1 to " + MaxFlatHours + ".");
                    return;
                }
                if (!Validator.TryParseMoney(Convert.ToString(row.Cells[colSucceedingRate.Index].Value), 0, MaxMoney, out succeedingRate))
                {
                    ShowCellError(row, colSucceedingRate, type + ": Succeeding Rate must be a number from 0 to " + MaxMoney.ToString("N0") + " (max 2 decimals).");
                    return;
                }

                rates.Add(new VehicleRate { VehicleType = type, FlatRate = flatRate, FlatHours = flatHours, SucceedingRate = succeedingRate });
            }

            if (!UiHelper.Confirm("Save the new rates?\nThey will apply to vehicles that exit from now on.")) return;

            try
            {
                OperationResult result = RateService.SaveAll(rates);
                LoadRates();
                StatusLine.Ok(lblNote, result.Message);
            }
            catch (Exception ex)
            {
                UiHelper.DbError(ex);
            }
        }

        private void ShowCellError(DataGridViewRow row, DataGridViewColumn column, string message)
        {
            dgvRates.CurrentCell = row.Cells[column.Index];
            StatusLine.Error(lblNote, message);
            dgvRates.BeginEdit(true);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (dirty && !UiHelper.Confirm("Discard your changes and reload the saved rates?")) return;
            LoadRates();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RatesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dirty && !UiHelper.Confirm("You have unsaved changes. Close without saving?"))
                e.Cancel = true;
        }
    }
}
