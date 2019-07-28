using System;
using System.Linq;
using Business_logic.Services;
using Data_access;
using Data_access.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ServiciosServicioTest
    {
        readonly HomeServicesContext databaseContext = new HomeServicesContext();
        readonly ServiciosServicio servicioController = new ServiciosServicio();

        [TestInitialize]
        public void ConfiguracionPrevia()
        {
            databaseContext.Database.ExecuteSqlCommand("DELETE FROM Habilidades");
            databaseContext.Database.ExecuteSqlCommand("insert into Habilidades(nombre,Descripcion) values ('Carpinteria','Trabajo manual sobre madera')");

            databaseContext.Database.ExecuteSqlCommand("DELETE FROM HabilidadesEspecificas");
            databaseContext.Database.ExecuteSqlCommand("insert into HabilidadesEspecificas(nombre,Descripcion,HabilidadId) values ('Carpinteria artesanal','Esculturas y disenios tradicionales sobre madera', (select id from Habilidades where nombre = 'Carpinteria'))");
            databaseContext.Database.ExecuteSqlCommand("insert into HabilidadesEspecificas(nombre,Descripcion,HabilidadId) values ('Carpinteria en madera artifici', 'Fabricacion y reparacion de estructuras en madera artificial', (select id from Habilidades where nombre = 'Carpinteria'))");

            databaseContext.Database.ExecuteSqlCommand("DELETE FROM Servicios");
            databaseContext.Database.ExecuteSqlCommand("DELETE FROM PrestadoresServicio");
            databaseContext.Database.ExecuteSqlCommand("DELETE FROM Clientes");
            databaseContext.Database.ExecuteSqlCommand("DELETE FROM Personas");
            // Clientes
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento) values ('Jose', 'Montoya', '43985039', 'carrera 78', '911911321', CAST(N'1985-07-26' AS datetime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento) values ('John', 'Gallardo Lopez', '5832013', 'carrera 78', '911911321', CAST(N'1983-07-26' AS datetime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento) values ('Guillermo', 'Alvaro Martinez', '6920384', 'carrera 78', '911911321', CAST(N'1987-07-26' AS datetime))");
            // Prestadores de servicios
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento) values ('Hector', 'Perez Penia', '230984823', 'carrera 78', '911911321', CAST(N'1974-07-26' AS datetime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento) values ('Victor', 'Alvarez Piniero', '34823821', 'carrera 78', '911911321', CAST(N'1969-07-26' AS datetime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento) values ('Juan', 'Trigueros Salazar', '90948291', 'carrera 78', '911911321', CAST(N'1988-07-26' AS datetime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento) values ('Jorge', 'Vallejo Pelayo', '93488238', 'carrera 78', '911911321', CAST(N'1981-07-26' AS datetime))");

            databaseContext.Database.ExecuteSqlCommand("insert into PrestadoresServicio(FechaAfiliacion,Id) values (CAST(N'2017-07-26' AS datetime), (Select id from Personas where cedula = '43985039'))");
            databaseContext.Database.ExecuteSqlCommand("insert into PrestadoresServicio(FechaAfiliacion,Id) values (CAST(N'2017-07-26' AS datetime), (Select id from Personas where cedula = '5832013'))");
            databaseContext.Database.ExecuteSqlCommand("insert into PrestadoresServicio(FechaAfiliacion,Id) values (CAST(N'2017-07-26' AS datetime), (Select id from Personas where cedula = '6920384'))");

            databaseContext.Database.ExecuteSqlCommand("insert into Clientes(id,Puntos) values ((select id from personas where cedula = '230984823'), 0)");
            databaseContext.Database.ExecuteSqlCommand("insert into Clientes(id,Puntos) values ((select id from personas where cedula = '34823821'), 0)");
            databaseContext.Database.ExecuteSqlCommand("insert into Clientes(id,Puntos) values ((select id from personas where cedula = '90948291'), 0)");
            databaseContext.Database.ExecuteSqlCommand("insert into Clientes(id,Puntos) values ((select id from personas where cedula = '93488238'), 0)");

            databaseContext.SaveChanges();
        }

        [TestMethod]
        public void SolicitarServicioNormal()
        {
            var cliente_esperado = databaseContext.Clientes.Where(c => c.Cedula == "230984823").FirstOrDefault();
            var habilidad_esperada = databaseContext.HabilidadesEspecificas.Where(h => h.Nombre == "Carpinteria artesanal").FirstOrDefault();
            var servicio_esperado = new Servicio("Arreglar mesa de noche", Convert.ToDateTime("18:00:00"), 1, Convert.ToDateTime("2019-07-30"), "Carrera 87", 10000, 140000, false);
            var ps_esperado = servicioController.AssignService(servicio_esperado, habilidad_esperada.Id);
            var servicio_actual = databaseContext.Servicios.Where(s => s.PrestadorServicio.Id == ps_esperado.Id).FirstOrDefault();
            Assert.AreEqual(servicio_esperado, servicio_actual);
            Assert.AreEqual(cliente_esperado, servicio_actual.Cliente);
            Assert.AreEqual(habilidad_esperada, servicio_actual.PrestadorServicio.Habilidades.Where(h => h.HabilidadEspecifica == habilidad_esperada).FirstOrDefault());
        }
    }
}
