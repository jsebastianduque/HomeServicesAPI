using System;
using Business_logic.Services;
using Data_access;
using Data_access.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{


    [TestClass]
    public class ServiciosHabilidadesTest
    {
        HomeServicesContext BD = new HomeServicesContext();

        [TestInitialize]
        public void ConfiguracionPrevia()
        {

            BD.Database.ExecuteSqlCommand("DELETE FROM HABILIDADES");

            BD.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [HomeServicesAPIDB].[dbo].[HABILIDADES] ON;" +
                "INSERT INTO Habilidades (Id, Nombre, Descripcion) VALUES (1, 'Carpintería','Ejemplo servicio carpintería');" +
                 "INSERT INTO Habilidades (Id, Nombre, Descripcion) VALUES (2, 'Cerrajería', 'Ejemplo servicio cerrajería');" +
                 "INSERT INTO Habilidades (Id, Nombre, Descripcion) VALUES (3, 'Plomería', 'Ejemplo servicio plomería');" +
                 "SET IDENTITY_INSERT [HomeServicesAPIDB].[dbo].[HABILIDADES] OFF;");

           // BD.Habilidades.Add(new Habilidad(1,"Carpintería","Ejemplo servicio carpintería"));
            //BD.Habilidades.Add(new Habilidad(2, "Cerrajería", "Ejemplo servicio cerrajería"));
            //BD.Habilidades.Add(new Habilidad(3, "Plomería", "Ejemplo servicio plomería"));
            //BD.Habilidades.Add(new Habilidad() { Id = 4, Nombre = "Ejemplo1", Descripcion = "Ejmplo de serviciijeijfeo "});

            //BD.Database.ExecuteSqlCommand("INSERT INTO Habilidades (Id, Nombre, Descripcion) VALUES (1, 'Carpintería','Ejemplo servicio carpintería')");
          

            BD.SaveChanges();
        }

     
        [TestMethod]

        public void Test01()
        {

            var habilidadEsperada = BD.Habilidades.Find(1);

            var habilidad = new ServiciosHabilidad();
            var habilidadObtenida = habilidad.Get(1);

            Assert.AreEqual(habilidadEsperada.Id, habilidadObtenida.Id);
            Assert.AreEqual(habilidadEsperada.Nombre, habilidadObtenida.Nombre);
            Assert.AreEqual(habilidadEsperada.Descripcion, habilidadObtenida.Descripcion);

        }

        [TestMethod]
        public void Test02()
        {

            var habilidad = new ServiciosHabilidad();
            var habilidadObtenida = habilidad.Get(-2);

            Assert.IsNull(habilidadObtenida);
        }
    }
}
