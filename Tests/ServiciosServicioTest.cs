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
            databaseContext.Database.ExecuteSqlCommand("insert into HabilidadesEspecificas(nombre,Descripcion,HabilidadId,FechaCreacion,FechaModificacion) values ('Carpinteria artesanal','Esculturas y disenios tradicionales sobre madera', (select id from Habilidades where nombre = 'Carpinteria'), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");
            databaseContext.Database.ExecuteSqlCommand("insert into HabilidadesEspecificas(nombre,Descripcion,HabilidadId,FechaCreacion,FechaModificacion) values ('Carpinteria en madera artifici', 'Fabricacion y reparacion de estructuras en madera artificial', (select id from Habilidades where nombre = 'Carpinteria'), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");

            databaseContext.Database.ExecuteSqlCommand("DELETE FROM Servicios");
            databaseContext.Database.ExecuteSqlCommand("DELETE FROM PrestadoresServicio");
            databaseContext.Database.ExecuteSqlCommand("DELETE FROM Clientes");
            databaseContext.Database.ExecuteSqlCommand("DELETE FROM Personas");
            databaseContext.Database.ExecuteSqlCommand("DELETE FROM PSHabilidadesEspecificas");
            // Clientes
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento,FechaCreacion,FechaModificacion) values ('Jose', 'Montoya', '43985039', 'carrera 78', '911911321', CAST(N'1985-07-26' AS datetime), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento,FechaCreacion,FechaModificacion) values ('John', 'Gallardo Lopez', '5832013', 'carrera 78', '911911321', CAST(N'1983-07-26' AS datetime), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento,FechaCreacion,FechaModificacion) values ('Guillermo', 'Alvaro Martinez', '6920384', 'carrera 78', '911911321', CAST(N'1987-07-26' AS datetime), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");
            // Prestadores de servicios
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento,FechaCreacion,FechaModificacion) values ('Hector', 'Perez Penia', '230984823', 'carrera 78', '911911321', CAST(N'1974-07-26' AS datetime), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento,FechaCreacion,FechaModificacion) values ('Victor', 'Alvarez Piniero', '34823821', 'carrera 78', '911911321', CAST(N'1969-07-26' AS datetime), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento,FechaCreacion,FechaModificacion) values ('Juan', 'Trigueros Salazar', '90948291', 'carrera 78', '911911321', CAST(N'1988-07-26' AS datetime), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");
            databaseContext.Database.ExecuteSqlCommand("insert into Personas(nombres,apellidos,cedula,Direccion,telefono,FechaNacimiento,FechaCreacion,FechaModificacion) values ('Jorge', 'Vallejo Pelayo', '93488238', 'carrera 78', '911911321', CAST(N'1981-07-26' AS datetime), CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");

            databaseContext.Database.ExecuteSqlCommand("insert into PrestadoresServicio(FechaAfiliacion,Id) values (CAST(N'2017-07-26' AS datetime), (Select id from Personas where cedula = '43985039'))");
            databaseContext.Database.ExecuteSqlCommand("insert into PrestadoresServicio(FechaAfiliacion,Id) values (CAST(N'2017-07-26' AS datetime), (Select id from Personas where cedula = '5832013'))");
            databaseContext.Database.ExecuteSqlCommand("insert into PrestadoresServicio(FechaAfiliacion,Id) values (CAST(N'2017-07-26' AS datetime), (Select id from Personas where cedula = '6920384'))");

            databaseContext.Database.ExecuteSqlCommand("insert into Clientes(id,Puntos) values ((select id from personas where cedula = '230984823'), 0)");
            databaseContext.Database.ExecuteSqlCommand("insert into Clientes(id,Puntos) values ((select id from personas where cedula = '34823821'), 0)");
            databaseContext.Database.ExecuteSqlCommand("insert into Clientes(id,Puntos) values ((select id from personas where cedula = '90948291'), 0)");
            databaseContext.Database.ExecuteSqlCommand("insert into Clientes(id,Puntos) values ((select id from personas where cedula = '93488238'), 0)");

            databaseContext.Database.ExecuteSqlCommand("insert into PSHabilidadesEspecificas(PrecioHora,AniosExperiencia,PrestadorServicioId,HabilidadEspecificaId,FechaCreacion,FechaModificacion) values (30000,2,(Select id from Personas where cedula = '43985039'),(select id from HabilidadesEspecificas where Nombre = 'Carpinteria artesanal'),CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");

            databaseContext.Database.ExecuteSqlCommand("insert into Servicios(Descripcion,HoraServicio,HorasEstimadas,FechaServicio,DireccionServicio,PrecioMinimo,PrecioMaximo,PSPersonal,Finalizado,ClienteId,PSHabilidadEspecificaId,FechaCreacion,FechaModificacion) values ('hola',CAST(N'15:00:00' AS datetime),1,CAST(N'2019-09-26' AS datetime),'malhabar car',15000,60000,0,0,(select id from personas where cedula = '230984823'),(select id from PSHabilidadesEspecificas where PrecioHora = 30000),CAST(N'2019-05-07T02:00:12.000' AS DateTime), CAST(N'2019-02-27T05:50:00.000' AS DateTime))");

            databaseContext.SaveChanges();
        }
        /*
        [TestMethod]
        public void SolicitarServicioNormal()
        {
            var cliente_esperado = databaseContext.Clientes.Where(c => c.Cedula == "230984823").FirstOrDefault();
            var habilidad_esperada = databaseContext.HabilidadesEspecificas.Where(h => h.Nombre == "Carpinteria artesanal").FirstOrDefault();
            var servicio_esperado = new Servicio("Arreglar mesa de noche", Convert.ToDateTime("18:00:00"), 1, Convert.ToDateTime("2019-07-30"), "Carrera 87", 10000, 140000, false);
            var ps_esperado = servicioController.AssignService(servicio_esperado, habilidad_esperada.Id);
            var servicio_actual = databaseContext.Servicios.Where(s => s.PSHabilidadEspecifica.PrestadorServicio.Id == ps_esperado.Id).FirstOrDefault();
            Assert.AreEqual(servicio_esperado, servicio_actual);
            Assert.AreEqual(cliente_esperado, servicio_actual.Cliente);
            Assert.AreEqual(habilidad_esperada, servicio_actual.PSHabilidadEspecifica.PrestadorServicio.Habilidades.Where(h => h.HabilidadEspecifica == habilidad_esperada).FirstOrDefault());
        }*/

        [TestMethod]
        public void ConsultarServiciosCliente()
        {
            var servicio_esperado = databaseContext.Servicios.Where(serv => serv.Descripcion == "hola").FirstOrDefault();
            var cliente = databaseContext.Clientes.Where(c => c.Cedula == "230984823").FirstOrDefault();
            var servicio_actual = servicioController.GetClientServices(cliente.Id).FirstOrDefault();
            Assert.AreEqual(servicio_esperado.Id,servicio_actual.Id);
        }

        [TestMethod]
        public void ClienteSinServicios()
        {
            var cliente = databaseContext.Clientes.Where(c => c.Cedula == "34823821").FirstOrDefault();
            var servicio_actual = servicioController.GetClientServices(cliente.Id).FirstOrDefault();
            Assert.AreEqual(null,servicio_actual);
        }

        [TestMethod]
        public void ClienteInexistente()
        {
            var servicio_actual = servicioController.GetClientServices(-1).FirstOrDefault();
            Assert.AreEqual(null, servicio_actual);
        }
    }
}
