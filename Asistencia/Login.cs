using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Asistencia.Properties;

namespace Asistencia
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (Buscar_Usuario(tbUsuario.Text, tbContraseña.Text) == true)
            {
                Valores.mUsuario = tbUsuario.Text;
                Valores.mClave = tbContraseña.Text;
                this.DialogResult = DialogResult.OK;
            
            }
            else
            {
                MessageBox.Show("Credenciales Invalidas");
            }
        }


        private bool Buscar_Usuario(string Codigo, string clave)
        {
            //Conexion
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);

            try
            {
                string strSQL = String.Format("select * from dbo.UserPrivilegios where usuario = '" + Codigo + "' and contraseña = '" + clave + "'");
                DataSet ds = Compensasiones.AbrirData(strSQL);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    //MessageBox.Show("El usuario no Existe! ");
                    ds.Dispose();
                    return false;
                }
                else
                    return true;

            }
            catch (Exception e)
            {
                return false;

            }
        }

        private void tbContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Buscar_Usuario(tbUsuario.Text, tbContraseña.Text) == true)
                {
                    Valores.mUsuario = tbUsuario.Text;
                    Valores.mClave = tbContraseña.Text;
                    this.DialogResult = DialogResult.OK;
                   
                }
                else
                {
                    MessageBox.Show("Credenciales Invalidas");
                }
            }
        }
    }
}
