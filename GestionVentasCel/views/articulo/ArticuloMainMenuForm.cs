using System.ComponentModel;
using System.Data;
using System.Globalization;
using GestionVentasCel.controller.articulo;
using GestionVentasCel.controller.categoria;
using GestionVentasCel.enumerations.modoForms;
using GestionVentasCel.exceptions.articulo;
using GestionVentasCel.models.articulo;
using GestionVentasCel.models.clientes;
using GestionVentasCel.temas;

namespace GestionVentasCel.views.articulo
{

    public partial class ArticuloMainMenuForm : Form
    {
        private readonly ArticuloController _articuloController;
        private readonly CategoriaController _categoriaController;
        private BindingList<Articulo> _articulos;
        private BindingSource _bindingSource;
        public ArticuloMainMenuForm(ArticuloController articuloController, CategoriaController categoriaController)
        {
            InitializeComponent();
            _articuloController = articuloController;
            _categoriaController = categoriaController;
            CargarArticulos();
        }

        //Se crea un bindingList de usuario y se lo agrega al DGV
        //El BindingList a diferencia del List, actualiza el DGV si hay un cambio en los Objetos
        //Se crea un bindingSource para poder filtrar entre usuarios activos e inactivos
        private void CargarArticulos()
        {
            var listaArticulos = _articuloController.ObtenerArticulos().ToList();

            _articulos = new BindingList<Articulo>(listaArticulos);

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _articulos;

            AplicarFiltro();

            dgvListarArticulos.DataSource = _bindingSource;
            dgvListarArticulos.Columns["Id"].Visible = false;
            dgvListarArticulos.Columns["CategoriaId"].Visible = false;
            dgvListarArticulos.Columns["Precio"].Visible = false;
            dgvListarArticulos.Columns["Stock"].Visible = false;
            dgvListarArticulos.Columns["Detalle"].Visible = false;

            if (dgvListarArticulos.Columns["PrecioFormateado"] == null)
            {
                dgvListarArticulos.Columns.Add("PrecioFormateado", "Precio");
            }

            if (dgvListarArticulos.Columns["StockFormateado"] == null)
            {
                dgvListarArticulos.Columns.Add("StockFormateado", "Stock");
            }

            // Bindear al bindingcomplete para formatear las columnas nuevas
            dgvListarArticulos.DataBindingComplete += (s, e) =>
            {
                // Ordenarlas y que tengan el espacio correcto
                dgvListarArticulos.Columns["Nombre"].DisplayIndex = 1;
                dgvListarArticulos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvListarArticulos.Columns["Marca"].DisplayIndex = 2;
                dgvListarArticulos.Columns["PrecioFormateado"].DisplayIndex = 3;
                dgvListarArticulos.Columns["StockFormateado"].DisplayIndex = 4;
                dgvListarArticulos.Columns["Descripcion"].DisplayIndex = 5;
                dgvListarArticulos.Columns["Categoria"].DisplayIndex = 6;
                dgvListarArticulos.Columns["Aviso_stock"].DisplayIndex = 7;
                dgvListarArticulos.Columns["Activo"].DisplayIndex = 8;

                foreach (DataGridViewRow row in dgvListarArticulos.Rows)
                {
                    if (row.DataBoundItem is Articulo articulo)
                    {
                        // formatear el precio como moneda
                        row.Cells["PrecioFormateado"].Value = articulo.Precio.ToString("C2", new CultureInfo("es-AR"));


                        // Formatear el nuevo stock en base al aviso. Si es menor al aviso, se pone en rojo y se le agrega un signo de exclamación
                        row.Cells["StockFormateado"].Value = articulo.Stock;

                        if (articulo.Stock <= articulo.Aviso_stock)
                        {

                            row.Cells["StockFormateado"].Value += "   ❗";
                            row.Cells["StockFormateado"].Style.ForeColor = Color.Red;

                        }
                    }
                }
            };
        }

        private void chckMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void bntToggleActivo_Click(object sender, EventArgs e)
        {
            if (dgvListarArticulos.CurrentRow != null)
            {
                int id = (int)dgvListarArticulos.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show(
                    "¿Seguro que desea Habilitar/Deshabilitar este Articulo?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No) return;

                try
                {

                    // Actualizo en la BD
                    _articuloController.ToggleActivo(id);

                    // Actualizo en memoria
                    var articulo = _articulos.FirstOrDefault(u => u.Id == id);
                    if (articulo != null)
                        articulo.Activo = !articulo.Activo;

                    // Reaplico el filtro inmediatamente
                    AplicarFiltro();
                }
                catch (ArticuloNoEncontradoException ex)
                {

                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void AplicarFiltro()
        {

            // punto de partida: todos los usuarios
            IEnumerable<Articulo> filtrados = _articulos;

            // filtro por Activo
            if (!chkMostrarInactivos.Checked)
                filtrados = filtrados.Where(u => u.Activo);

            // filtro por búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(a =>
                    a.Nombre.ToLower().Contains(filtro)
                    || a.Marca.ToLower().Contains(filtro)
                    || a.Categoria.Nombre.ToLower().Contains(filtro)
                );
            }

            // asignar al BindingSource
            _bindingSource.DataSource = new BindingList<Articulo>(filtrados.ToList());
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var agregarArticulo = new AgregarEditarArticuloForm(_articuloController, _categoriaController))
            {
                agregarArticulo.Modo = ModoFormulario.Agregar;
                //si el usuario apreta guardar, muestra el msj y actualiza el binding
                if (agregarArticulo.ShowDialog() == DialogResult.OK)
                {

                    MessageBox.Show("El articulo se guardó correctamente",
                    "Articulo Guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    CargarArticulos();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvListarArticulos.CurrentRow != null)
            {
                int id = (int)dgvListarArticulos.CurrentRow.Cells["Id"].Value;

                var articulo = _articuloController.GetById(id);
                if (articulo == null)
                {
                    MessageBox.Show("El articulo no fue encontrado",
                        "Articulo no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using (var editarArticulo = new AgregarEditarArticuloForm(_articuloController, _categoriaController))
                {
                    editarArticulo.Modo = ModoFormulario.Editar;
                    editarArticulo.ArticuloActual = articulo;
                    //si el usuario apreta guardar, muestra el msj y actualiza el binding
                    if (editarArticulo.ShowDialog() == DialogResult.OK)
                    {

                        MessageBox.Show("El articulo se actualizó correctamente",
                        "Articulo Guardado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        CargarArticulos();
                    }
                }
            }
        }

        private void ConfigurarEstilosVisuales()
        {
            this.panelHeader.BackColor = Tema.ColorSuperficie;
            this.splitContainer1.BackColor = Tema.ColorSuperficie;
            this.panelBtn.BackColor = Tema.ColorSuperficie;


            this.lblTituloForm.ForeColor = Tema.ColorTextoSecundario;

            this.splitContainer1.Panel2.BackColor = Tema.ColorSuperficie;

            // Configuración del DGV. Esto se puede hacer en el diseñador, pero acá queda mas visible el código

            // Eliminar divisores entre columnas y filas
            dgvListarArticulos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvListarArticulos.GridColor = dgvListarArticulos.BackgroundColor;

            // Eliminar divisores entre columnas del header
            dgvListarArticulos.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Cambiar el color de fondo, de la letra y el tamaño de fuente de la fila del header
            dgvListarArticulos.EnableHeadersVisualStyles = false;
            dgvListarArticulos.ColumnHeadersDefaultCellStyle.BackColor = Tema.ColorFondo;
            dgvListarArticulos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvListarArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Colorear alternando las filas
            dgvListarArticulos.RowsDefaultCellStyle.BackColor = Color.White;
            dgvListarArticulos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Eliminar la columna de seleccion y configurar los modos de seleccion
            dgvListarArticulos.RowHeadersVisible = false;
            dgvListarArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListarArticulos.MultiSelect = false;
            dgvListarArticulos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.ColorFondo;
        }

        private void ConfigurarAtajos()
        {
            // Hayq ue setear en true esto para que el formulario atrape los atajos antes que los controles
            // Si no, los atajos se tienen que bindear a cada control específico y solo funcionarían si 
            // tienen focus.
            this.KeyPreview = true;

            this.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.N)
                {
                    // Control N para nuevo usuario
                    btnAgregar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.U)
                {
                    // Control U para actualizar el usuario
                    btnActualizar.PerformClick();
                }

                if (e.Control && e.KeyCode == Keys.F)
                {
                    // Control F para buscar usuarios
                    txtBuscar.Focus();
                }

                // Supr para habilitar/deshabilitar el usuario
                if (e.KeyCode == Keys.Delete)
                {
                    btnToggleActivo.PerformClick();
                }
            };
        }

        private void ArticuloMainMenuForm_Load(object sender, EventArgs e)
        {
            this.ConfigurarEstilosVisuales();
            this.ConfigurarAtajos();
        }
    }
}
