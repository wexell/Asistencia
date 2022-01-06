using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace Asistencia
{
    public class sqlcon
    {
        String conexionstring = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        //String conexionstringOracle = ConfigurationManager.ConnectionStrings["conexion"].ConnectionStringOracle;

        public void conectar()
        {

            SqlConnection conexion = new SqlConnection(conexionstring);
            try
            {
                conexion.Open();
                System.Windows.Forms.MessageBox.Show("Conectado a BD");
            }

            catch (System.Exception excep)
            {
                System.Windows.Forms.MessageBox.Show("Fallo Conexion a la Base de Datos");
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();

            }
        }

        


    }
}
