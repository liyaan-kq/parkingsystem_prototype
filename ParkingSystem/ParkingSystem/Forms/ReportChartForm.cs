using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ParkingSystem.Helpers;
using ParkingSystem.Logic;
using red_framework;

namespace ParkingSystem.Forms
{
    public sealed class ReportChartForm : Form
    {
        private readonly DataTable records;
        private readonly Chart chart;
        private readonly ComboBox cboView;
        private readonly Label lblNote;

        public ReportChartForm(DataTable records, string filterText)
        {
            this.records = records;

            Text = UiHelper.AppTitle + " - Records Chart";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(860, 540);
            MinimumSize = new Size(640, 420);
            MinimizeBox = false;
            ShowInTaskbar = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9.75F);

            Label lblHeader = new Label
            {
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = Theme.Navy,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15.75F, FontStyle.Bold),
                Padding = new Padding(16, 0, 0, 0),
                Text = "Records Chart",
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblShow = new Label { Text = "Show:", AutoSize = true, Margin = new Padding(0, 8, 6, 0) };
            cboView = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 260 };
            cboView.Items.AddRange(new object[] { "Daily Income (Column)", "Daily Income (Line)", "Visits by Vehicle Type (Pie)" });

            Button btnClose = new Button
            {
                Text = "Close",
                Width = 100,
                Height = 30,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Theme.Navy,
                Margin = new Padding(16, 0, 0, 0)
            };
            btnClose.FlatAppearance.BorderColor = Theme.Neutral;
            btnClose.Click += delegate { Close(); };

            FlowLayoutPanel toolbar = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 46,
                Padding = new Padding(12, 8, 12, 0),
                WrapContents = false
            };
            toolbar.Controls.Add(lblShow);
            toolbar.Controls.Add(cboView);
            toolbar.Controls.Add(btnClose);

            lblNote = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                Padding = new Padding(16, 0, 0, 0),
                ForeColor = StatusLine.HintColor,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = filterText
            };

            chart = new Chart { Dock = DockStyle.Fill, BackColor = Color.White };
            chart.ChartAreas.Add(new ChartArea("MainArea"));
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Theme.Neutral;
            chart.ChartAreas[0].AxisX.Interval = 1;

            Controls.Add(chart);
            Controls.Add(lblNote);
            Controls.Add(toolbar);
            Controls.Add(lblHeader);

            CancelButton = btnClose;
            cboView.SelectedIndexChanged += delegate { BindChart(); };
            cboView.SelectedIndex = 0;
        }

        private void BindChart()
        {
            chart.Titles.Clear();
            Series series;

            if (cboView.SelectedIndex == 2)
            {
                series = Charts.Bind(chart, ReportService.VisitsByType(records), "VehicleType", "Visits", "Visits", SeriesChartType.Pie);
                if (series != null)
                {
                    series.Label = "#VALX: #VAL (#PERCENT{P0})";
                    series.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                chart.Titles.Add(new Title(series == null ? "No records to chart." : "Visits by Vehicle Type"));
            }
            else
            {
                SeriesChartType type = cboView.SelectedIndex == 1 ? SeriesChartType.Line : SeriesChartType.Column;
                series = Charts.Bind(chart, ReportService.DailyIncome(records), "Day", "Income", "Income", type);
                if (series != null)
                {
                    series.Color = Theme.Primary;
                    series.BorderWidth = 3;
                    series.MarkerStyle = MarkerStyle.Circle;
                    series.IsValueShownAsLabel = true;
                    series.LabelFormat = FeeCalculator.Peso + "#,##0";
                    chart.ChartAreas[0].AxisY.LabelStyle.Format = FeeCalculator.Peso + "#,##0";
                }
                chart.Titles.Add(new Title(series == null
                    ? "No completed (paid) records to chart. Income is counted on the exit date."
                    : "Daily Income (by exit date)"));
            }

            chart.Titles[0].Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            chart.Titles[0].ForeColor = Theme.Navy;
        }
    }
}
