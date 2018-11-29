using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClasesPrincipales
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Paquete> paquetes;
        private List<Thread> mockPaquetes;
        #endregion
        #region Propiedades
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion
        #region Constructor
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion
        #region Metodos
        public void FinEntregas()
        {
            foreach (Thread threadA in this.mockPaquetes)
            { threadA.Abort(); }

            this.mockPaquetes.Clear();
        }
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Paquete item in ((Correo)elemento).paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2}) \n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString()));

            }

            return sb.ToString();
        }
        #endregion
        #region Sobrecargas
        public static Correo operator +(Correo c, Paquete p)
        {
            {

                foreach (Paquete item in c.paquetes)
                {
                    if (item == p)
                    {
                        throw new TrackingIDRepetidoException("El Tracking ID " + item.TrackingID + " ya figura en la lista de envios.");
                    }
                }

                c.paquetes.Add(p);

                Thread nuevoThread = new Thread(p.MockCicloDeVida);

                c.mockPaquetes.Add(nuevoThread);

                nuevoThread.Start();

                return c;
            }
        }
        #endregion
    }
}
