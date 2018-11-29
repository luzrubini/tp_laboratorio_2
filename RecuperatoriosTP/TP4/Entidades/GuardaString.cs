using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClasesPrincipales
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            Boolean retorno = false;
            StreamWriter auxGuardado;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo + ".txt";

            if ((auxGuardado = new StreamWriter(path, true)) != null)
            {
                auxGuardado.WriteLine(texto);
                retorno = true;
            }

            auxGuardado.Close();
            return retorno;
        }
    }

}
