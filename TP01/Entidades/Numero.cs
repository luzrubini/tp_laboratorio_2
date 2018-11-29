using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #region Constructores
        public Numero():this(0)
        {
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            double numDecimal = 0 ;
            int bandera = 0;
            int bl = binario.Length;
            foreach (char b in binario)
            {
                if (b != '0' && b != '1')
                {
                    bandera = 1;
                }
            }
            if (bandera == 0)
            {
                for (int i = 1; i <= bl; i++)
                {
                    byte n = byte.Parse(binario.Substring(bl - i, 1));
                    if (n == 1)
                    {
                        numDecimal += System.Math.Pow(2, i - 1);
                    }
                }
                retorno = "" + numDecimal;
            }
            else
            {
                retorno = "Valor invalido";
            }
            
            return retorno;
        }
        public string DecimalBinario(double numero)
        {
            string binario = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }
                    numero = (int)numero / 2;
                }
            }
            else
            {
                if (numero == 0)
                {
                    binario = "0";
                }
                else
                {
                    binario = "Numero Invalido";
                }
            }
            return binario;
        }
        public string DecimalBinario(string numero)
        {
            string binario = "";
            double auxNumero = 0;
            auxNumero = double.Parse(numero);
            binario = DecimalBinario(auxNumero);
            return binario;
            
        }
        private static double ValidarNumero(string strNumero)
        {
            bool TryParse = false;
            double numero = 0, auxNumero;
            TryParse = double.TryParse(strNumero,out auxNumero);
            if (TryParse == true)
            {
                numero = auxNumero;
            }

            return numero;
        }
        #region operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        #endregion
    }
}
