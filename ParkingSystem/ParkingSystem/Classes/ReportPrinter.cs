using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace red_framework
{
    public static class ReportPrinter
    {
        public static void Preview(DataTable data, string title, string subtitle = null, string footer = null,
                                   float[] columnWeights = null, IWin32Window owner = null)
        {
            using (var document = CreateDocument(data, title, subtitle, footer, columnWeights))
                ShowPreview(document, owner);
        }

        public static void Print(DataTable data, string title, string subtitle = null, string footer = null,
                                 float[] columnWeights = null, IWin32Window owner = null)
        {
            using (var document = CreateDocument(data, title, subtitle, footer, columnWeights))
            using (var dialog = new PrintDialog { Document = document, UseEXDialog = true })
            {
                try
                {
                    if (dialog.ShowDialog(owner) == DialogResult.OK)
                        document.Print();
                }
                catch (InvalidPrinterException)
                {
                    ShowNoPrinter();
                }
            }
        }

        public static void PreviewStub(IList<string> lines, string stubNo, IWin32Window owner = null)
        {
            using (var document = new PrintDocument { DocumentName = "Parking Stub " + stubNo })
            {
                document.PrintPage += (sender, args) =>
                {
                    StubRenderer.Render(args.Graphics, args.MarginBounds, lines, stubNo);
                    args.HasMorePages = false;
                };
                ShowPreview(document, owner);
            }
        }

        internal static PrintDocument CreateDocument(DataTable data, string title, string subtitle, string footer, float[] columnWeights)
        {
            var document = new PrintDocument
            {
                DocumentName = string.IsNullOrWhiteSpace(title) ? "Report" : title
            };
            document.DefaultPageSettings.Margins = new Margins(44, 44, 52, 44);
            document.DefaultPageSettings.Landscape = data != null && data.Columns.Count >= 6;

            var currentRow = 0;
            var pageNumber = 1;
            var printedAt = DateTime.Now;
            document.BeginPrint += (sender, args) => { currentRow = 0; pageNumber = 1; printedAt = DateTime.Now; };
            document.PrintPage += (sender, args) =>
            {
                var result = PrintPageRenderer.Render(
                    args.Graphics,
                    args.MarginBounds,
                    data,
                    title,
                    subtitle,
                    footer,
                    columnWeights,
                    currentRow,
                    pageNumber,
                    printedAt);
                currentRow = result.NextRow;
                args.HasMorePages = result.HasMorePages;
                pageNumber++;
            };
            return document;
        }

        private static void ShowPreview(PrintDocument document, IWin32Window owner)
        {
            using (var preview = new PrintPreviewDialog
            {
                Document = document,
                Width = 1000,
                Height = 750,
                StartPosition = FormStartPosition.CenterScreen,
                UseAntiAlias = true,
                Text = "Print Preview - " + document.DocumentName
            })
            {
                try
                {
                    preview.ShowDialog(owner);
                }
                catch (InvalidPrinterException)
                {
                    ShowNoPrinter();
                }
            }
        }

        private static void ShowNoPrinter()
        {
            MessageBox.Show("Printing needs at least one printer installed in Windows.\n" +
                            "Tip: enable \"Microsoft Print to PDF\" in Settings > Printers & scanners.",
                            "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    internal sealed class ReportPageResult
    {
        internal int NextRow;
        internal bool HasMorePages;
    }

    internal static class PrintPageRenderer
    {
        private const float HeaderHeight = 25f;
        private const float RowHeight = 25f;
        private const float FooterHeight = 20f;
        private const float SubtitleLineHeight = 16f;

        internal static ReportPageResult Render(
            Graphics graphics,
            Rectangle bounds,
            DataTable data,
            string title,
            string subtitle,
            string footer,
            float[] columnWeights,
            int firstRow,
            int pageNumber,
            DateTime printedAt)
        {
            if (graphics == null) throw new ArgumentNullException(nameof(graphics));
            var result = new ReportPageResult { NextRow = Math.Max(0, firstRow) };
            var left = (float)bounds.Left;
            var top = (float)bounds.Top;
            var width = Math.Max(1f, bounds.Width);
            var footerTop = bounds.Bottom - FooterHeight;

            var subtitleLines = string.IsNullOrWhiteSpace(subtitle) ? new string[0] : subtitle.Split('\n');
            DrawTitle(graphics, left, top, width, title, subtitleLines);
            top += 42f + subtitleLines.Length * SubtitleLineHeight;

            using (var footerFont = new Font("Segoe UI", 8f))
            using (var footerBrush = new SolidBrush(Color.DimGray))
            using (var footerFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center })
                graphics.DrawString("Page " + pageNumber + "   |   Printed " + printedAt.ToString("yyyy-MM-dd hh:mm tt"),
                    footerFont, footerBrush, new RectangleF(left, footerTop, width, FooterHeight), footerFormat);

            if (data == null || data.Columns.Count == 0 || data.Rows.Count == 0)
            {
                using (var emptyFont = new Font("Segoe UI", 10f))
                using (var emptyBrush = new SolidBrush(Color.Gray))
                    graphics.DrawString("No data to display.", emptyFont, emptyBrush, left, top + 12f);
                result.HasMorePages = false;
                return result;
            }

            var columnCount = data.Columns.Count;
            var columnX = new float[columnCount];
            var columnWidth = new float[columnCount];
            ComputeColumns(left, width, columnCount, columnWeights, columnX, columnWidth);
            var bodyFontSize = Math.Max(6f, 9f - Math.Max(0, columnCount - 6) * 0.35f);
            DrawTableHeader(graphics, data, left, top, width, columnX, columnWidth, bodyFontSize);
            top += HeaderHeight;

            var reserveForFooter = string.IsNullOrWhiteSpace(footer) ? 0f : RowHeight;
            if (top + RowHeight > footerTop)
                throw new InvalidOperationException("The page is too small to print a report row.");
            var rowIndex = Math.Max(0, firstRow);
            while (rowIndex < data.Rows.Count && top + RowHeight <= footerTop)
            {
                var isLast = rowIndex == data.Rows.Count - 1;
                if (isLast && top + RowHeight + reserveForFooter > footerTop && rowIndex > firstRow) break;

                var rowBounds = new RectangleF(left, top, width, RowHeight);
                if (rowIndex % 2 == 1)
                {
                    using (var alternate = new SolidBrush(Color.FromArgb(245, 247, 250)))
                        graphics.FillRectangle(alternate, rowBounds);
                }
                DrawRow(graphics, data.Rows[rowIndex], top, columnX, columnWidth, bodyFontSize);
                using (var line = new Pen(Color.FromArgb(220, 225, 230)))
                    graphics.DrawLine(line, left, top + RowHeight, left + width, top + RowHeight);
                top += RowHeight;
                rowIndex++;
            }

            result.NextRow = rowIndex;
            result.HasMorePages = rowIndex < data.Rows.Count;

            if (!result.HasMorePages && !string.IsNullOrWhiteSpace(footer))
            {
                using (var totalFont = new Font("Segoe UI", 9f, FontStyle.Bold))
                using (var totalBrush = new SolidBrush(Color.FromArgb(31, 55, 78)))
                    graphics.DrawString(footer, totalFont, totalBrush, new RectangleF(left, top + 6f, width, RowHeight));
            }
            return result;
        }

        private static void ComputeColumns(float left, float width, int count, float[] weights, float[] x, float[] w)
        {
            var useWeights = weights != null && weights.Length == count;
            float total = 0f;
            for (var i = 0; i < count; i++) total += useWeights ? Math.Max(0.01f, weights[i]) : 1f;

            var position = left;
            for (var i = 0; i < count; i++)
            {
                x[i] = position;
                w[i] = width * (useWeights ? Math.Max(0.01f, weights[i]) : 1f) / total;
                position += w[i];
            }
        }

        private static void DrawTitle(Graphics graphics, float left, float top, float width, string title, string[] subtitleLines)
        {
            using (var titleFont = new Font("Segoe UI", 18f, FontStyle.Bold))
            using (var titleBrush = new SolidBrush(Color.FromArgb(31, 55, 78)))
                graphics.DrawString(string.IsNullOrWhiteSpace(title) ? "Report" : title, titleFont, titleBrush,
                    new RectangleF(left, top, width, 28f));

            if (subtitleLines.Length == 0) return;
            using (var subtitleFont = new Font("Segoe UI", 9f))
            using (var subtitleBrush = new SolidBrush(Color.DimGray))
            {
                for (var i = 0; i < subtitleLines.Length; i++)
                    graphics.DrawString(subtitleLines[i].TrimEnd('\r'), subtitleFont, subtitleBrush,
                        new RectangleF(left, top + 32f + i * SubtitleLineHeight, width, SubtitleLineHeight));
            }
        }

        private static void DrawTableHeader(Graphics graphics, DataTable data, float left, float top, float width,
                                            float[] columnX, float[] columnWidth, float fontSize)
        {
            using (var background = new SolidBrush(Color.FromArgb(37, 78, 112)))
                graphics.FillRectangle(background, left, top, width, HeaderHeight);
            using (var headerFont = new Font("Segoe UI", fontSize, FontStyle.Bold))
            using (var headerBrush = new SolidBrush(Color.White))
            using (var format = CellFormat())
            {
                for (var column = 0; column < data.Columns.Count; column++)
                {
                    var cell = new RectangleF(columnX[column] + 4f, top + 2f,
                        Math.Max(1f, columnWidth[column] - 8f), HeaderHeight - 4f);
                    graphics.DrawString(data.Columns[column].ColumnName, headerFont, headerBrush, cell, format);
                }
            }
        }

        private static void DrawRow(Graphics graphics, DataRow row, float top, float[] columnX, float[] columnWidth, float fontSize)
        {
            using (var bodyFont = new Font("Segoe UI", fontSize))
            using (var bodyBrush = new SolidBrush(Color.FromArgb(40, 47, 54)))
            using (var format = CellFormat())
            {
                for (var column = 0; column < row.Table.Columns.Count; column++)
                {
                    var cell = new RectangleF(columnX[column] + 4f, top + 2f,
                        Math.Max(1f, columnWidth[column] - 8f), RowHeight - 4f);
                    graphics.DrawString(FormatValue(row[column]), bodyFont, bodyBrush, cell, format);
                }
            }
        }

        private static StringFormat CellFormat()
        {
            return new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };
        }

        private static string FormatValue(object value)
        {
            if (value == null || value == DBNull.Value) return string.Empty;
            if (value is DateTime date) return date.ToString("d");
            if (value is decimal number) return number.ToString("N2");
            return Convert.ToString(value);
        }
    }

    internal static class StubRenderer
    {
        private const int LineWidth = 36;

        internal static void Render(Graphics graphics, Rectangle margins, IList<string> lines, string stubNo)
        {
            using (var mono = new Font("Consolas", 10f))
            using (var border = new Pen(Color.Gray, 1f) { DashStyle = DashStyle.Dash })
            {
                var lineHeight = mono.GetHeight(graphics) + 2;
                var textWidth = graphics.MeasureString(new string('W', LineWidth), mono).Width;
                var boxWidth = textWidth + 40;
                var boxHeight = lines.Count * lineHeight + 110;
                var left = margins.Left + (margins.Width - boxWidth) / 2;
                var top = (float)margins.Top;

                graphics.DrawRectangle(border, left, top, boxWidth, boxHeight);

                var y = top + 20;
                foreach (var line in lines)
                {
                    graphics.DrawString(line, mono, Brushes.Black, left + 20, y);
                    y += lineHeight;
                }

                DrawBarcode(graphics, stubNo, left + 20, y + 10, textWidth, 45);
                using (var small = new Font("Consolas", 8f))
                {
                    var caption = "Stub No. " + stubNo;
                    var size = graphics.MeasureString(caption, small);
                    graphics.DrawString(caption, small, Brushes.Black, left + (boxWidth - size.Width) / 2, y + 60);
                }
            }
        }

        private static void DrawBarcode(Graphics graphics, string code, float x, float y, float width, float height)
        {
            var pattern = "101";
            foreach (var c in code ?? "")
            {
                var digit = char.IsDigit(c) ? c - '0' : c % 10;
                pattern += Convert.ToString(digit + 8, 2).PadLeft(5, '0') + "0";
            }
            pattern += "101";

            var barWidth = width / pattern.Length;
            for (var i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '1')
                    graphics.FillRectangle(Brushes.Black, x + i * barWidth, y, barWidth, height);
            }
        }
    }
}
