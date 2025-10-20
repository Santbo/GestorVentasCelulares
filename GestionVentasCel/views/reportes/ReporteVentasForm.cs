using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using GestionVentasCel.controller.reportes;
using GestionVentasCel.models.reportes;
using GestionVentasCel.service;

namespace GestionVentasCel.views.reportes
{
    public partial class ReporteVentasForm : Form
    {
        private readonly ReporteVentaController _ventaController;
        private readonly ExportService _exportService;
        private BindingList<ReporteVentaDTO> _ventas = new BindingList<ReporteVentaDTO>();

        public ReporteVentasForm(ReporteVentaController ventaController, ExportService exportService)
        {
            InitializeComponent();
            _ventaController = ventaController;
            _exportService = exportService;
            ConfigurarFormulario();
            CargarDatosMesActual();
        }

        private void ConfigurarFormulario()
        {
            // Configurar fechas por defecto (mes actual)
            var hoy = DateTime.Today;
            var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            dtpVentasDesde.Value = primerDiaDelMes;
            dtpVentasHasta.Value = ultimoDiaDelMes;

            // Configurar DataGridView de Ventas
            ConfigurarDataGridViewVentas();
            ConfigurarGrafico();
        }

        private void ConfigurarDataGridViewVentas()
        {
            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvVentas.Columns.Clear();
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                MinimumWidth = 85,
                FillWeight = 10,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NumeroComprobante",
                DataPropertyName = "NumeroComprobante",
                HeaderText = "N° Comp.",
                MinimumWidth = 90,
                FillWeight = 10
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cliente",
                DataPropertyName = "Cliente",
                HeaderText = "Cliente",
                MinimumWidth = 150,
                FillWeight = 25
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoPagoDescripcion",
                DataPropertyName = "TipoPagoDescripcion",
                HeaderText = "Pago",
                MinimumWidth = 80,
                FillWeight = 10
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstadoDescripcion",
                DataPropertyName = "EstadoDescripcion",
                HeaderText = "Estado",
                MinimumWidth = 80,
                FillWeight = 10
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontoTotal",
                DataPropertyName = "MontoTotal",
                HeaderText = "Total",
                MinimumWidth = 100,
                FillWeight = 13,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = new CultureInfo("es-AR"),
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontoSinIva",
                DataPropertyName = "MontoSinIva",
                HeaderText = "Sin IVA",
                MinimumWidth = 100,
                FillWeight = 13,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = new CultureInfo("es-AR"),
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontoIva",
                DataPropertyName = "MontoIva",
                HeaderText = "IVA",
                MinimumWidth = 100,
                FillWeight = 13,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = new CultureInfo("es-AR"),
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
        }

        private void ConfigurarGrafico()
        {
            // Configurar gráfico de ventas
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            var areaVentas = new ChartArea("MainArea");
            chartVentas.ChartAreas.Add(areaVentas);

            var seriesVentas = new Series("Ventas por Tipo")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "C2"
            };
            chartVentas.Series.Add(seriesVentas);
            chartVentas.Legends.Add(new Legend("Legend"));
        }

        private void CargarDatosMesActual()
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            try
            {
                var ventas = _ventaController.ObtenerVentasPorRangoFecha(
                    dtpVentasDesde.Value.Date,
                    dtpVentasHasta.Value.Date
                );

                _ventas = new BindingList<ReporteVentaDTO>(ventas.ToList());
                dgvVentas.DataSource = _ventas;

                ActualizarResumenVentas();
                ActualizarGraficoVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResumenVentas()
        {
            var resumen = _ventaController.ObtenerResumenVentas(
                dtpVentasDesde.Value.Date,
                dtpVentasHasta.Value.Date
            );

            lblVentasTotalGeneral.Text = resumen.TotalGeneral.ToString("C2", new CultureInfo("es-AR"));
            lblVentasCantidad.Text = resumen.CantidadOperaciones.ToString();
            lblVentasPromedio.Text = resumen.PromedioOperacion.ToString("C2", new CultureInfo("es-AR"));
        }

        private void ActualizarGraficoVentas()
        {
            var resumen = _ventaController.ObtenerResumenVentas(
                dtpVentasDesde.Value.Date,
                dtpVentasHasta.Value.Date
            );

            chartVentas.Series[0].Points.Clear();

            foreach (var tipo in resumen.TotalesPorTipo)
            {
                if (tipo.Value > 0)
                {
                    var point = chartVentas.Series[0].Points.Add((double)tipo.Value);
                    point.Label = $"{tipo.Key}\n{tipo.Value.ToString("C2", new CultureInfo("es-AR"))}";
                    point.LegendText = tipo.Key;
                }
            }
        }

        private void btnVentasFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpVentasDesde.Value.Date > dtpVentasHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.",
                    "Error de Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            CargarVentas();
        }

        private void btnVentasLimpiar_Click(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            dtpVentasDesde.Value = primerDiaDelMes;
            dtpVentasHasta.Value = ultimoDiaDelMes;
            CargarVentas();
        }

        private void btnExportarVentas_Click(object sender, EventArgs e)
        {
            MostrarMenuExportacion();
        }

        private void MostrarMenuExportacion()
        {
            var menu = new ContextMenuStrip();

            var itemExcel = new ToolStripMenuItem("Exportar a Excel");
            itemExcel.Click += (s, e) => ExportarAExcel();
            menu.Items.Add(itemExcel);

            var itemPdf = new ToolStripMenuItem("Exportar a PDF");
            itemPdf.Click += (s, e) => ExportarAPdf();
            menu.Items.Add(itemPdf);

            menu.Show(btnExportarVentas, new System.Drawing.Point(0, btnExportarVentas.Height));
        }

        private void ExportarAExcel()
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                    FileName = $"ReporteVentas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    DefaultExt = "xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var resumen = _ventaController.ObtenerResumenVentas(
                        dtpVentasDesde.Value.Date,
                        dtpVentasHasta.Value.Date
                    );
                    _exportService.ExportarVentasAExcel(_ventas.ToList(), resumen, saveDialog.FileName);

                    MessageBox.Show("Reporte exportado exitosamente a Excel.", "Exportación Exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Preguntar si desea abrir el archivo
                    if (MessageBox.Show("¿Desea abrir el archivo?", "Abrir archivo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarAPdf()
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Archivo PDF (*.pdf)|*.pdf",
                    FileName = $"ReporteVentas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                    DefaultExt = "pdf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var resumen = _ventaController.ObtenerResumenVentas(
                        dtpVentasDesde.Value.Date,
                        dtpVentasHasta.Value.Date
                    );
                    _exportService.ExportarVentasAPdf(_ventas.ToList(), resumen, saveDialog.FileName);

                    MessageBox.Show("Reporte exportado exitosamente a PDF.", "Exportación Exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Preguntar si desea abrir el archivo
                    if (MessageBox.Show("¿Desea abrir el archivo?", "Abrir archivo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a PDF: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
