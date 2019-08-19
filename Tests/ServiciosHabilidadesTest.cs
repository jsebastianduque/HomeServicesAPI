﻿using System;
using Business_logic.Services;
using Data_access;
using Data_access.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{

    /// <summary>Clase para las pruebas unitarias del servicio habilidades
    /// </summary>
    [TestClass]
    public class ServiciosHabilidadesTest
    {
        HomeServicesContext BD = new HomeServicesContext();

        /// <summary>Configuración inicial, se ejecuta de primero, antes que todas las pruebas
        /// </summary>
        [TestInitialize]
        public void ConfiguracionPrevia()
        {

            BD.Database.ExecuteSqlCommand("DELETE FROM HABILIDADES");

            BD.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [HomeServicesAPIDB].[dbo].[HABILIDADES] ON;" +
                "INSERT INTO Habilidades (Id, Nombre, Descripcion) VALUES (1, 'Carpintería','Ejemplo servicio carpintería');" +
                 "INSERT INTO Habilidades (Id, Nombre, Descripcion) VALUES (2, 'Cerrajería', 'Ejemplo servicio cerrajería');" +
                 "INSERT INTO Habilidades (Id, Nombre, Descripcion) VALUES (3, 'Plomería', 'Ejemplo servicio plomería');" +
                 "SET IDENTITY_INSERT [HomeServicesAPIDB].[dbo].[HABILIDADES] OFF;");

       

             BD.SaveChanges();
        }


        /// <summary>Caso de prueba en el se pasa como parametro un ID existente en la BD
        /// </summary>
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


        /// <summary>Prueba en la que se pasa como parametro un ID negativo
        /// </summary>
        [TestMethod]
        public void Test02()
        {

            var habilidad = new ServiciosHabilidad();
            var habilidadObtenida = habilidad.Get(-2);

            Assert.IsNull(habilidadObtenida);
        }
    }
}
