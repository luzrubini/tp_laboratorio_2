using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesPrincipales
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        #region Metodos
        public static bool Insert(Paquete p)
        {
            Boolean retorno = false;

            try
            {
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando = new SqlCommand("INSERT into [correo-sp-2017].[dbo].[Paquetes]([direccionEntrega],[trackingID],[alumno]) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Rubini Luz')", PaqueteDAO.conexion);

                int registrosAfectados = PaqueteDAO.comando.ExecuteNonQuery();

                if (registrosAfectados > 0)
                { retorno = true; }
            }
            catch (Exception e)
            { throw e; }
            finally
            { PaqueteDAO.conexion.Close(); }

            return retorno;
        }
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(ClasesPrincipales.Properties.Settings.Default.conexion);
        }
        #endregion
    }
}
