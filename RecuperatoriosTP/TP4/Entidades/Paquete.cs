using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClasesPrincipales
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion
        #region Propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion
        #region Constructor
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion
        #region Metodos
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado.Invoke(this, new EventArgs());
            } while (this.Estado != EEstado.Entregado);

            try
            { PaqueteDAO.Insert(this); }
            catch (Exception e) { }
        }
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }
        #region Sobrecargas
        public static Boolean operator ==(Paquete p1, Paquete p2)
        {
            Boolean retorno = false;

            if (p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }

            return retorno;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        public override string ToString()
        {
            return ((IMostrar<Paquete>)this).MostrarDatos(this);
        }

        #endregion
        #endregion
        #region Delegados
        public delegate void DelegadoEstado(object sender, EventArgs e);

        #endregion
        #region Eventos
        public event DelegadoEstado InformaEstado;
        #endregion
        
    }
}
