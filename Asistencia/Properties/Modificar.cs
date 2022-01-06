using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using Asistencia.Properties;
using System.Data.SqlClient;

namespace Asistencia
{
    public partial class Modificar : UserControl
    {
        public string emp;
        public int codrg;
        public string estado;
        public Modificar(string empleado, int cod, string est)
        {
            InitializeComponent();
            emp = empleado;
            codrg = cod;
            estado = est;

        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            tbEmpleado.Text = emp;
            tbNombres.Text = codrg.ToString();
            Compensasiones.ModificarComp(codrg, tbEmpleado);
          
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

              
        private void actualizarReg(int cod,string empleado, string fecha, decimal horas, decimal dias)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea Actualizar este Registro? ", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
                    String CadenaSql = ("Update dbo.Compensacion set Fecha = '" + fecha + "', Horas ='" + horas + "', Dias = '" + dias + "' where CodReg = "+cod+"");
                    SqlCommand cmd = new SqlCommand(CadenaSql, conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();

                    MessageBox.Show("Registros Actualizados! ");

                    btnUpdate.Enabled = false;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL GUARDAR LOS REGISTROS: " + ex);
                   

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime fecha = Fecha.Value;
            actualizarReg(codrg, tbEmpleado.Text, fecha.ToString("yyyy-MM-dd 00:00:00", CultureInfo.InvariantCulture), uphoras.Value, updias.Value);
        }



    }
}
