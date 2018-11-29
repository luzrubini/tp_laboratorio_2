using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesPrincipales;

namespace CorreoTestUnitario
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void CorreoListaInstanciada()
        {
            Correo correoAux = new Correo();

            if (correoAux.Paquetes == null)
            { Assert.Fail(); }
        }
        [TestMethod]
        public void PaqueteIDRepetido()
        {
            Correo correoAux = new Correo();
            Paquete paqueteAuxA = new Paquete("TestA", "TrackingA");
            Paquete paqueteAuxB = new Paquete("TestB", "TrackingA");

            correoAux += paqueteAuxA;

            try
            {
                correoAux += paqueteAuxB;
                Assert.Fail();
            }
            catch (TrackingIDRepetidoException trackingException) { }
        }
    }
}
