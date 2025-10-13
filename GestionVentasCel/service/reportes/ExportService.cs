using GestionVentasCel.models.reportes;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;

//Libreria para exportar a excel y pdf

namespace GestionVentasCel.service
{
    public class ExportService
    {
        public ExportService()
        {
            // Configurar licencia de EPPlus (modo no comercial)
            ExcelPackage.License.SetNonCommercialPersonal("MantoSoft");
        }

        #region Exportación a Excel

        public void ExportarVentasAExcel(IEnumerable<ReporteVentaDTO> ventas, ResumenReporteDTO resumen, string rutaArchivo)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Reporte de Ventas");

                // Configurar título
                worksheet.Cells["A1:H1"].Merge = true;
                worksheet.Cells["A1"].Value = "REPORTE DE VENTAS";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Información del reporte
                worksheet.Cells["A2"].Value = $"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Cells["A2"].Style.Font.Italic = true;

                // Encabezados
                int row = 4;
                worksheet.Cells[row, 1].Value = "Fecha";
                worksheet.Cells[row, 2].Value = "N° Comprobante";
                worksheet.Cells[row, 3].Value = "Cliente";
                worksheet.Cells[row, 4].Value = "Tipo de Pago";
                worksheet.Cells[row, 5].Value = "Estado";
                worksheet.Cells[row, 6].Value = "Monto sin IVA";
                worksheet.Cells[row, 7].Value = "Monto IVA";
                worksheet.Cells[row, 8].Value = "Monto Total";

                // Estilo de encabezados
                using (var range = worksheet.Cells[row, 1, row, 8])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(68, 114, 196));
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Datos
                row++;
                foreach (var venta in ventas)
                {
                    worksheet.Cells[row, 1].Value = venta.Fecha.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 2].Value = venta.NumeroComprobante;
                    worksheet.Cells[row, 3].Value = venta.Cliente;
                    worksheet.Cells[row, 4].Value = venta.TipoPagoDescripcion;
                    worksheet.Cells[row, 5].Value = venta.EstadoDescripcion;
                    worksheet.Cells[row, 6].Value = venta.MontoSinIva;
                    worksheet.Cells[row, 7].Value = venta.MontoIva;
                    worksheet.Cells[row, 8].Value = venta.MontoTotal;

                    // Formato de moneda
                    worksheet.Cells[row, 6].Style.Numberformat.Format = "$#,##0.00";
                    worksheet.Cells[row, 7].Style.Numberformat.Format = "$#,##0.00";
                    worksheet.Cells[row, 8].Style.Numberformat.Format = "$#,##0.00";

                    row++;
                }

                // Resumen
                row++;
                worksheet.Cells[row, 7].Value = "Total General:";
                worksheet.Cells[row, 7].Style.Font.Bold = true;
                worksheet.Cells[row, 8].Value = resumen.TotalGeneral;
                worksheet.Cells[row, 8].Style.Numberformat.Format = "$#,##0.00";
                worksheet.Cells[row, 8].Style.Font.Bold = true;

                row++;
                worksheet.Cells[row, 7].Value = "Cantidad de Operaciones:";
                worksheet.Cells[row, 7].Style.Font.Bold = true;
                worksheet.Cells[row, 8].Value = resumen.CantidadOperaciones;
                worksheet.Cells[row, 8].Style.Font.Bold = true;

                row++;
                worksheet.Cells[row, 7].Value = "Promedio por Operación:";
                worksheet.Cells[row, 7].Style.Font.Bold = true;
                worksheet.Cells[row, 8].Value = resumen.PromedioOperacion;
                worksheet.Cells[row, 8].Style.Numberformat.Format = "$#,##0.00";
                worksheet.Cells[row, 8].Style.Font.Bold = true;

                // Auto ajustar columnas
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Guardar archivo
                package.SaveAs(new FileInfo(rutaArchivo));
            }
        }

        public void ExportarComprasAExcel(IEnumerable<ReporteCompraDTO> compras, ResumenReporteDTO resumen, string rutaArchivo)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Reporte de Compras");

                // Configurar título
                worksheet.Cells["A1:F1"].Merge = true;
                worksheet.Cells["A1"].Value = "REPORTE DE COMPRAS";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Información del reporte
                worksheet.Cells["A2"].Value = $"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}";
                worksheet.Cells["A2"].Style.Font.Italic = true;

                // Encabezados
                int row = 4;
                worksheet.Cells[row, 1].Value = "Fecha";
                worksheet.Cells[row, 2].Value = "N° Comprobante";
                worksheet.Cells[row, 3].Value = "Proveedor";
                worksheet.Cells[row, 4].Value = "Tipo de Compra";
                worksheet.Cells[row, 5].Value = "Monto Total";
                worksheet.Cells[row, 6].Value = "Observaciones";

                // Estilo de encabezados
                using (var range = worksheet.Cells[row, 1, row, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(68, 114, 196));
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Datos
                row++;
                foreach (var compra in compras)
                {
                    worksheet.Cells[row, 1].Value = compra.Fecha.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 2].Value = compra.NumeroComprobante;
                    worksheet.Cells[row, 3].Value = compra.Proveedor;
                    worksheet.Cells[row, 4].Value = compra.TipoCompra;
                    worksheet.Cells[row, 5].Value = compra.MontoTotal;
                    worksheet.Cells[row, 6].Value = compra.Observaciones;

                    // Formato de moneda
                    worksheet.Cells[row, 5].Style.Numberformat.Format = "$#,##0.00";

                    row++;
                }

                // Resumen
                row++;
                worksheet.Cells[row, 4].Value = "Total General:";
                worksheet.Cells[row, 4].Style.Font.Bold = true;
                worksheet.Cells[row, 5].Value = resumen.TotalGeneral;
                worksheet.Cells[row, 5].Style.Numberformat.Format = "$#,##0.00";
                worksheet.Cells[row, 5].Style.Font.Bold = true;

                row++;
                worksheet.Cells[row, 4].Value = "Cantidad de Operaciones:";
                worksheet.Cells[row, 4].Style.Font.Bold = true;
                worksheet.Cells[row, 5].Value = resumen.CantidadOperaciones;
                worksheet.Cells[row, 5].Style.Font.Bold = true;

                row++;
                worksheet.Cells[row, 4].Value = "Promedio por Operación:";
                worksheet.Cells[row, 4].Style.Font.Bold = true;
                worksheet.Cells[row, 5].Value = resumen.PromedioOperacion;
                worksheet.Cells[row, 5].Style.Numberformat.Format = "$#,##0.00";
                worksheet.Cells[row, 5].Style.Font.Bold = true;

                // Auto ajustar columnas
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Guardar archivo
                package.SaveAs(new FileInfo(rutaArchivo));
            }
        }

        #endregion

        #region Exportación a PDF

        public void ExportarVentasAPdf(IEnumerable<ReporteVentaDTO> ventas, ResumenReporteDTO resumen, string rutaArchivo)
        {
            using (var fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                var document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
                var writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                // Título
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var title = new Paragraph("REPORTE DE VENTAS", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 10
                };
                document.Add(title);

                // Fecha de generación
                var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, new BaseColor(128, 128, 128));
                var dateParagraph = new Paragraph($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}", dateFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                document.Add(dateParagraph);

                // Tabla de datos
                var table = new PdfPTable(8)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 10,
                    SpacingAfter = 10
                };

                float[] widths = { 10f, 12f, 20f, 12f, 10f, 12f, 12f, 12f };
                table.SetWidths(widths);

                // Encabezados
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, new BaseColor(255, 255, 255));
                var headerColor = new BaseColor(68, 114, 196);

                AddTableHeader(table, "Fecha", headerFont, headerColor);
                AddTableHeader(table, "N° Comprobante", headerFont, headerColor);
                AddTableHeader(table, "Cliente", headerFont, headerColor);
                AddTableHeader(table, "Tipo Pago", headerFont, headerColor);
                AddTableHeader(table, "Estado", headerFont, headerColor);
                AddTableHeader(table, "Sin IVA", headerFont, headerColor);
                AddTableHeader(table, "IVA", headerFont, headerColor);
                AddTableHeader(table, "Total", headerFont, headerColor);

                // Datos
                var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                foreach (var venta in ventas)
                {
                    table.AddCell(new PdfPCell(new Phrase(venta.Fecha.ToString("dd/MM/yyyy"), cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(venta.NumeroComprobante, cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(venta.Cliente, cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(venta.TipoPagoDescripcion, cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(venta.EstadoDescripcion, cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase($"${venta.MontoSinIva:N2}", cellFont)) { Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase($"${venta.MontoIva:N2}", cellFont)) { Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase($"${venta.MontoTotal:N2}", cellFont)) { Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
                }

                document.Add(table);

                // Resumen
                var summaryFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                document.Add(new Paragraph($"\nTotal General: ${resumen.TotalGeneral:N2}", summaryFont));
                document.Add(new Paragraph($"Cantidad de Operaciones: {resumen.CantidadOperaciones}", summaryFont));
                document.Add(new Paragraph($"Promedio por Operación: ${resumen.PromedioOperacion:N2}", summaryFont));

                // Totales por tipo
                if (resumen.TotalesPorTipo.Any())
                {
                    document.Add(new Paragraph("\nTotales por Tipo de Pago:", summaryFont) { SpacingBefore = 10 });
                    foreach (var total in resumen.TotalesPorTipo)
                    {
                        document.Add(new Paragraph($"  • {total.Key}: ${total.Value:N2}", cellFont));
                    }
                }

                document.Close();
            }
        }

        public void ExportarComprasAPdf(IEnumerable<ReporteCompraDTO> compras, ResumenReporteDTO resumen, string rutaArchivo)
        {
            using (var fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                var document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
                var writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                // Título
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var title = new Paragraph("REPORTE DE COMPRAS", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 10
                };
                document.Add(title);

                // Fecha de generación
                var dateFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, new BaseColor(128, 128, 128));
                var dateParagraph = new Paragraph($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}", dateFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                document.Add(dateParagraph);

                // Tabla de datos
                var table = new PdfPTable(6)
                {
                    WidthPercentage = 100,
                    SpacingBefore = 10,
                    SpacingAfter = 10
                };

                float[] widths = { 12f, 15f, 25f, 18f, 15f, 15f };
                table.SetWidths(widths);

                // Encabezados
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, new BaseColor(255, 255, 255));
                var headerColor = new BaseColor(68, 114, 196);

                AddTableHeader(table, "Fecha", headerFont, headerColor);
                AddTableHeader(table, "N° Comprobante", headerFont, headerColor);
                AddTableHeader(table, "Proveedor", headerFont, headerColor);
                AddTableHeader(table, "Tipo de Compra", headerFont, headerColor);
                AddTableHeader(table, "Monto Total", headerFont, headerColor);
                AddTableHeader(table, "Observaciones", headerFont, headerColor);

                // Datos
                var cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                foreach (var compra in compras)
                {
                    table.AddCell(new PdfPCell(new Phrase(compra.Fecha.ToString("dd/MM/yyyy"), cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(compra.NumeroComprobante, cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(compra.Proveedor, cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase(compra.TipoCompra, cellFont)) { Padding = 5 });
                    table.AddCell(new PdfPCell(new Phrase($"${compra.MontoTotal:N2}", cellFont)) { Padding = 5, HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new PdfPCell(new Phrase(compra.Observaciones ?? "", cellFont)) { Padding = 5 });
                }

                document.Add(table);

                // Resumen
                var summaryFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                document.Add(new Paragraph($"\nTotal General: ${resumen.TotalGeneral:N2}", summaryFont));
                document.Add(new Paragraph($"Cantidad de Operaciones: {resumen.CantidadOperaciones}", summaryFont));
                document.Add(new Paragraph($"Promedio por Operación: ${resumen.PromedioOperacion:N2}", summaryFont));

                // Totales por tipo
                if (resumen.TotalesPorTipo.Any())
                {
                    document.Add(new Paragraph("\nTotales por Tipo de Compra:", summaryFont) { SpacingBefore = 10 });
                    foreach (var total in resumen.TotalesPorTipo)
                    {
                        document.Add(new Paragraph($"  • {total.Key}: ${total.Value:N2}", cellFont));
                    }
                }

                document.Close();
            }
        }

        private void AddTableHeader(PdfPTable table, string headerText, iTextSharp.text.Font font, BaseColor backgroundColor)
        {
            var cell = new PdfPCell(new Phrase(headerText, font))
            {
                BackgroundColor = backgroundColor,
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 8
            };
            table.AddCell(cell);
        }

        #endregion
    }
}

