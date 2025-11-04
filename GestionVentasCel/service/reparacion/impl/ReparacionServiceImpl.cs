using GestionVentasCel.controller.compra;
using GestionVentasCel.enumerations.reparacion;
using GestionVentasCel.exceptions.reparacion;
using GestionVentasCel.models.compra;
using GestionVentasCel.models.reparacion;
using GestionVentasCel.repository.reparacion;

namespace GestionVentasCel.service.reparacion.impl
{
    public class ReparacionServiceImpl : IReparacionService
    {

        private readonly IReparacionRepository _repo;

        public ReparacionServiceImpl(IReparacionRepository reparacionRepository)
        {
            _repo = reparacionRepository;
        }

        public void CrearReparacion(Reparacion reparacion)
        {
            _repo.Add(reparacion);
        }

        public void ActualizarReparacion(Reparacion reparacion)
        {
            if (!_repo.Exist(reparacion.Id))
                throw new ReparacionNoEncontradaException("La reparación no existe.");

            _repo.Update(reparacion);
        }

        public IEnumerable<Reparacion> ListarReparaciones() => _repo.GetAll();
        public IEnumerable<Reparacion> ListarReparacionesTerminadasCliente(int idCliente) => _repo.ListarReparacionesTerminadasCliente(idCliente);
        public Reparacion? ObtenerPorId(int id) => _repo.GetById(id);

        public Reparacion? ObtenerPorIdConCliente(int id) => _repo.GetWithClienteById(id);
        public bool Existe(int id) => _repo.Exist(id);


        public void CambiarEstado(int id, EstadoReparacionEnum nuevoEstado)
        {
            if (!_repo.Exist(id))
                throw new ReparacionNoEncontradaException("La reparación no existe.");

            _repo.CambiarEstado(id, nuevoEstado);
        }

        public IEnumerable<Reparacion>? ObtenerPorDispositivo(Dispositivo dispositivo)
        {
            return _repo.GetReparacionesDispositivo(dispositivo);
        }

        public void Desactivar(int id)
        {
            _repo.Desactivar(id);
        }

        public IEnumerable<Dispositivo>? ObtenerDispositivoPorCliente(int ClienteId)
        {
            return _repo.BuscarDispositivoPorCliente(ClienteId);
        }

        public void AddDispositivo(string nombre, int clienteId)
        {
            var dispositivo = new Dispositivo
            {
                Nombre = nombre,
                ClienteId = clienteId
            };

            _repo.AddDispositivo(dispositivo);
        }

        public void UpdateDispositivo(Dispositivo dispositivo)
        {
            if (!_repo.ExistDispositivo(dispositivo.Id)) throw new DispositivoNoEncontradoException("El dispositivo no fue encontrado.");
            _repo.UpdateDispositivo(dispositivo);
        }

        public Dispositivo? GetDispositivoById(int dispositivoId)
        {
            return _repo.GetDispositivoById(dispositivoId);
        }

        public void ExportarComprobante(int reparacionID)
        {
            try
            {
                var reparacion = _repo.ObtenerParaExportar(reparacionID);


                var saveDialog = new SaveFileDialog
                {
                    Filter = "Archivo PDF (*.pdf)|*.pdf",
                    FileName = $"Presupuesto de reparación N {reparacionID:D7}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                    DefaultExt = "pdf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var es = new ExportService();

                    es.ExportarReparacionAPDF(reparacion!, saveDialog.FileName);

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
