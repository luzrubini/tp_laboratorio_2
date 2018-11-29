using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private double Operar(string numero1, string numero2, string operador)
        {

            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calculadora = new Calculadora();

            return calculadora.Operar(num1, num2, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string resultado = "";
            resultado = (Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperadores.Text)).ToString();
            this.lblResultado.Text = resultado;
        }

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperadores.ResetText();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
