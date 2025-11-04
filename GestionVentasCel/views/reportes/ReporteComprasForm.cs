using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using GestionVentasCel.controller.reportes;
using GestionVentasCel.models.reportes;
using GestionVentasCel.service;

namespace GestionVentasCel.views.reportes
{
    public partial class ReporteComprasForm : Form
    {
        private readonly ReporteCompraController _compraController;
        private readonly ExportService _exportService;
        private BindingList<ReporteCompraDTO> _compras = new BindingList<ReporteCompraDTO>();

        public ReporteComprasForm(ReporteCompraController compraController, ExportService exportService)
        {
            InitializeComponent();
            _compraController = compraController;
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

            dtpComprasDesde.Value = primerDiaDelMes;
            dtpComprasHasta.Value = ultimoDiaDelMes;

            // Configurar DataGridView de Compras
            ConfigurarDataGridViewCompras();
            ConfigurarGrafico();
        }

        private void ConfigurarDataGridViewCompras()
        {
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.ReadOnly = true;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.MultiSelect = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Agregar evento de doble click
            dgvCompras.CellDoubleClick += DgvCompras_CellDoubleClick;

            dgvCompras.Columns.Clear();
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                MinimumWidth = 85,
                FillWeight = 12,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NumeroComprobante",
                DataPropertyName = "NumeroComprobante",
                HeaderText = "N° Comp.",
                MinimumWidth = 90,
                FillWeight = 12
            });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Proveedor",
                DataPropertyName = "Proveedor",
                HeaderText = "Proveedor",
                MinimumWidth = 150,
                FillWeight = 22
            });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CondicionIVAProveedor",
                DataPropertyName = "CondicionIVAProveedor",
                HeaderText = "Tipo",
                MinimumWidth = 100,
                FillWeight = 15
            });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontoTotal",
                DataPropertyName = "MontoTotal",
                HeaderText = "Monto Total",
                MinimumWidth = 110,
                FillWeight = 15,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = new CultureInfo("es-AR"),
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Observaciones",
                DataPropertyName = "Observaciones",
                HeaderText = "Observaciones",
                MinimumWidth = 150,
                FillWeight = 24
            });
        }

        private void ConfigurarGrafico()
        {
            // Configurar gráfico de compras
            chartCompras.Series.Clear();
            chartCompras.ChartAreas.Clear();
            var areaCompras = new ChartArea("MainArea");
            chartCompras.ChartAreas.Add(areaCompras);

            var seriesCompras = new Series("Compras por Tipo")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "C2"
            };
            chartCompras.Series.Add(seriesCompras);
            chartCompras.Legends.Add(new Legend("Legend"));
        }

        private void CargarDatosMesActual()
        {
            CargarCompras();
        }

        private void CargarCompras()
        {
            try
            {
                var compras = _compraController.ObtenerComprasPorRangoFecha(
                    dtpComprasDesde.Value.Date,
                    dtpComprasHasta.Value.Date
                );

                _compras = new BindingList<ReporteCompraDTO>(compras.ToList());
                dgvCompras.DataSource = _compras;

                ActualizarResumenCompras();
                ActualizarGraficoCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar compras: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarResumenCompras()
        {
            var resumen = _compraController.ObtenerResumenCompras(
                dtpComprasDesde.Value.Date,
                dtpComprasHasta.Value.Date
            );

            lblComprasTotalGeneral.Text = resumen.TotalGeneral.ToString("C2", new CultureInfo("es-AR"));
            lblComprasCantidad.Text = resumen.CantidadOperaciones.ToString();
            lblComprasPromedio.Text = resumen.PromedioOperacion.ToString("C2", new CultureInfo("es-AR"));
        }

        private void ActualizarGraficoCompras()
        {
            var resumen = _compraController.ObtenerResumenCompras(
                dtpComprasDesde.Value.Date,
                dtpComprasHasta.Value.Date
            );

            chartCompras.Series[0].Points.Clear();

            foreach (var tipo in resumen.TotalesPorTipo)
            {
                if (tipo.Value > 0)
                {
                    var point = chartCompras.Series[0].Points.Add((double)tipo.Value);
                    point.Label = $"{tipo.Key}\n{tipo.Value.ToString("C2", new CultureInfo("es-AR"))}";
                    point.LegendText = tipo.Key;
                }
            }
        }

        private void btnComprasFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpComprasDesde.Value.Date > dtpComprasHasta.Value.Date)
            {
                MessageBox.Show(
                    "La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.",
                    "Error de Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            CargarCompras();
        }

        private void btnComprasLimpiar_Click(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            var primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            dtpComprasDesde.Value = primerDiaDelMes;
            dtpComprasHasta.Value = ultimoDiaDelMes;
            CargarCompras();
        }

        private void btnExportarCompras_Click(object sender, EventArgs e)
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

            menu.Show(btnExportarCompras, new System.Drawing.Point(0, btnExportarCompras.Height));
        }

        private void ExportarAExcel()
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                    FileName = $"ReporteCompras_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    DefaultExt = "xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var resumen = _compraController.ObtenerResumenCompras(
                        dtpComprasDesde.Value.Date,
                        dtpComprasHasta.Value.Date
                    );
                    _exportService.ExportarComprasAExcel(_compras.ToList(), resumen, saveDialog.FileName);

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
                    FileName = $"ReporteCompras_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                    DefaultExt = "pdf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var resumen = _compraController.ObtenerResumenCompras(
                        dtpComprasDesde.Value.Date,
                        dtpComprasHasta.Value.Date
                    );
                    _exportService.ExportarComprasAPdf(_compras.ToList(), resumen, saveDialog.FileName);

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

        private void lblTituloCompras_Click(object sender, EventArgs e)
        {

        }

        private void DgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var compraSeleccionada = _compras[e.RowIndex];
                    var detalleCompraForm = new DetalleCompraForm(_compraController, compraSeleccionada.Id);
                    detalleCompraForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al abrir el detalle de la compra: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
