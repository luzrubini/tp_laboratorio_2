using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);
            if (operador == "+")
            {
                resultado = num1 + num2;
            }
            else
            {
                if (operador == "-")
                {
                    resultado = num1 - num2;
                }
                else
                {
                    if (operador == "/")
                    {
                        resultado = num1 / num2;
                    }
                    else
                    {
                        resultado = num1 * num2;
                    }
                }
            }
            return resultado;
        }
        private static string ValidarOperador(string operador)
        {
            if (operador != "-" && operador != "/" && operador != "*")
            {
                operador = "+";
            }
            return operador;
        }
    }
}
