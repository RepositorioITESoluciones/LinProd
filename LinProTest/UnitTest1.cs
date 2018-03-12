using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinPro.Negocio;
using LinPro.Entidades;

namespace LinProTest
{
    [TestClass]
    public class UnitTest1
    {


        //[TestMethod]
        //public void consultaPlacas() {
        //    PlacasElectronicas pe = new PlacasElectronicas();
        //    pe.consultaPlacas();
        //}


        //[TestMethod]
        //public void insertaPlaca() {
        //    String direccion = "Placa 1";
        //    String noSerie = "PL1234SENS3213";
        //    String fAlta = "20/07/2017";
        //    String fBaja = "07/02/2017";
        //    String ip = "11.152.23.66";
        //    int modelo = 1;
        //    String descripcion = "Descripción 1";
        //    PlacasElectronicas pe = new PlacasElectronicas();
        //    bool respuesta = pe.insertaPlaca(direccion, noSerie, fAlta, fBaja,
        //                                     ip, modelo, descripcion);
        //    Assert.IsTrue(respuesta);
        //}


        //[TestMethod]
        //public void actualizaPlaca() {
        //    int id = 2;
        //    String direccion = "Edit Placa 1";
        //    String noSerie = "PL1234SENS3212";
        //    String fAlta = "30/07/2017";
        //    String fBaja = "22/02/2017";
        //    String ip = "11.13.23.66";
        //    int modelo = 1;
        //    String descripcion = "Edit Descripción 1";
        //    PlacasElectronicas pe = new PlacasElectronicas();
        //    bool respuesta = pe.actualizaPlaca(id, direccion, noSerie, fAlta, fBaja,
        //                                     ip, modelo, descripcion);
        //    Assert.IsTrue(respuesta);
        //}

        [TestMethod]
        public void eliminaplaca() {
            int id = 2;
            PlacasElectronicas pe = new PlacasElectronicas();
            bool respuesta = pe.eliminaPlaca(id);
            Assert.IsTrue(respuesta);
        }
    }
}
