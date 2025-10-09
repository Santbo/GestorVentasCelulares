using GestionVentasCel.data;
using GestionVentasCel.enumerations.persona;
using GestionVentasCel.models.proveedor;
using GestionVentasCel.repository.proveedor.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.compras
{
    public class TestProveedorRepository
    {
        private AppDbContext GetDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new AppDbContext(options);
        }

        private Proveedor CrearProveedor(string nombre, string cuit, int id = 0)
        {
            return new Proveedor
            {
                Id = id,
                Nombre = nombre,
                Dni = cuit,
                TipoDocumento = TipoDocumentoEnum.CUIT,
                Activo = true
            };
        }

        [Fact]
        public void Add_Proveedor_SeGuardaEnBD()
        {
            using var context = GetDbContext(nameof(Add_Proveedor_SeGuardaEnBD));
            var repo = new ProveedorRepositoryImpl(context);

            var proveedor = CrearProveedor("Proveedor 1", "20123456789");

            repo.Add(proveedor);

            Assert.Single(context.Proveedores);
            Assert.Equal("Proveedor 1", context.Proveedores.First().Nombre);
        }

        [Fact]
        public void CambiarEstado_CambiaActivoCorrectamente()
        {
            using var context = GetDbContext(nameof(CambiarEstado_CambiaActivoCorrectamente));
            var proveedor = CrearProveedor("Proveedor 1", "20123456789");
            context.Proveedores.Add(proveedor);
            context.SaveChanges();

            var repo = new ProveedorRepositoryImpl(context);

            repo.CambiarEstado(proveedor.Id, false);

            var actualizado = context.Proveedores.Find(proveedor.Id);
            Assert.False(actualizado.Activo);
        }

        [Fact]
        public void DocumentoExist_DevuelveTrueSiExiste()
        {
            using var context = GetDbContext(nameof(DocumentoExist_DevuelveTrueSiExiste));
            var proveedor = CrearProveedor("Proveedor 1", "20123456789");
            context.Proveedores.Add(proveedor);
            context.SaveChanges();

            var repo = new ProveedorRepositoryImpl(context);

            var existe = repo.DocumentoExist("20123456789", TipoDocumentoEnum.CUIT.ToString());

            Assert.True(existe);
        }

        [Fact]
        public void DocumentoExist_DevuelveFalseSiNoExiste()
        {
            using var context = GetDbContext(nameof(DocumentoExist_DevuelveFalseSiNoExiste));
            var repo = new ProveedorRepositoryImpl(context);

            var existe = repo.DocumentoExist("20123456789", TipoDocumentoEnum.CUIT.ToString());

            Assert.False(existe);
        }

        [Fact]
        public void Exist_DevuelveTrueSiProveedorExiste()
        {
            using var context = GetDbContext(nameof(Exist_DevuelveTrueSiProveedorExiste));
            var proveedor = CrearProveedor("Proveedor 1", "20123456789");
            context.Proveedores.Add(proveedor);
            context.SaveChanges();

            var repo = new ProveedorRepositoryImpl(context);

            Assert.True(repo.Exist(proveedor.Id));
        }

        [Fact]
        public void Exist_DevuelveFalseSiProveedorNoExiste()
        {
            using var context = GetDbContext(nameof(Exist_DevuelveFalseSiProveedorNoExiste));
            var repo = new ProveedorRepositoryImpl(context);

            Assert.False(repo.Exist(99));
        }

        [Fact]
        public void GetAll_DevuelveTodosLosProveedores()
        {
            using var context = GetDbContext(nameof(GetAll_DevuelveTodosLosProveedores));
            context.Proveedores.AddRange(
                CrearProveedor("Proveedor 1", "20123456789"),
                CrearProveedor("Proveedor 2", "20987654321")
            );
            context.SaveChanges();

            var repo = new ProveedorRepositoryImpl(context);

            var result = repo.GetAll().ToList();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetById_DevuelveProveedorCorrecto()
        {
            using var context = GetDbContext(nameof(GetById_DevuelveProveedorCorrecto));
            var proveedor = CrearProveedor("Proveedor 1", "20123456789");
            context.Proveedores.Add(proveedor);
            context.SaveChanges();

            var repo = new ProveedorRepositoryImpl(context);

            var result = repo.GetById(proveedor.Id);

            Assert.NotNull(result);
            Assert.Equal("Proveedor 1", result.Nombre);
        }

        [Fact]
        public void Update_ModificaProveedorCorrectamente()
        {
            using var context = GetDbContext(nameof(Update_ModificaProveedorCorrectamente));
            var proveedor = CrearProveedor("Proveedor 1", "20123456789");
            context.Proveedores.Add(proveedor);
            context.SaveChanges();

            var repo = new ProveedorRepositoryImpl(context);

            proveedor.Nombre = "Proveedor Modificado";
            repo.Update(proveedor);

            var actualizado = context.Proveedores.Find(proveedor.Id);
            Assert.Equal("Proveedor Modificado", actualizado.Nombre);
        }



    }
}
