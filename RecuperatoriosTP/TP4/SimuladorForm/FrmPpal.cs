using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClasesPrincipales;


namespace SimuladorForm
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        #region Inicialización y manejo del Formulario
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.rtbMostrar.Enabled = false;
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        { this.correo.FinEntregas(); }
        #endregion
        #region Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete auxPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            auxPaquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformarEstado);

            try
            {
                this.correo += auxPaquete;
                this.ActualizarEstados();
            }
            catch (TrackingIDRepetidoException trackingIDRepetidoException)
            { MessageBox.Show(trackingIDRepetidoException.Message.ToString(), "Alerta", MessageBoxButtons.OK); }
        }
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        { this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo); }
        #endregion
        #region Otros controles
        private void mostrarToolStripMenuItem1_Click(object sender, EventArgs e)
        { this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem); }
        private void lstEstadoEntregado_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { this.mostrarToolStripMenuItem.Show(Cursor.Position.X, Cursor.Position.Y); }
        }
        private void ActualizarEstados()
        {
            foreach (Control controlA in this.gBoxPaquetes.Controls)
            {
                if (controlA is ListBox)
                { ((ListBox)controlA).Items.Clear(); }
            }

            foreach (Paquete paqueteA in this.correo.Paquetes)
            {
                switch (paqueteA.Estado)
                {
                    case EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paqueteA);
                        break;
                    case EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paqueteA);
                        break;
                    case EEstado.Entregado:
                        {
                            this.lstEstadoEntregado.Items.Add(paqueteA);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        void paq_InformarEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformarEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            { this.ActualizarEstados(); }
        }
        void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (((object)elemento) != null)
            {
                if (elemento is Correo)
                { this.rtbMostrar.Text = ((Correo)elemento).ToString(); }
                else if (elemento is Paquete)
                { this.rtbMostrar.Text = ((Paquete)elemento).ToString(); }

                this.rtbMostrar.Text.Guardar("salida");
            }
        }
        #endregion
    }
}
