using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionVentasCel.data;
using Microsoft.EntityFrameworkCore;

namespace Testing.ventas
{
    public class TestFacturaRepo
    {
        private readonly TestFacturaRepo _facturaRepo;

        public TestFacturaRepo()
        {
            // hay que crear un contexto in memory para que EF core no toque la DB real

            var opciones = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "memoria")
                .Options;
        }

    }
}
