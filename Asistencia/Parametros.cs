using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Sql;
using System.Data.SqlClient;
using Asistencia.Properties;


namespace Asistencia
{
    public partial class Parametros : Form
    {
        SqlDataAdapter sQlda;
        SqlCommandBuilder sQlcmb;
        DataTable dt;
        public Parametros()
        {
            InitializeComponent();
        }

        private void Parametros_Load(object sender, EventArgs e)
        {
            cargaParametros(gridView1);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            sQlcmb = new SqlCommandBuilder(sQlda);
            sQlda.Update(dt);
            MessageBox.Show("Registro Actualizado");
            cargaParametros(gridView1);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargaParametros(gridView1);
        }

        public void cargaParametros(DataGridView grid)
        {
            SqlConnection SQLCon = new SqlConnection(Settings.Default.ConnectionString);
            string strSQL = String.Format("SELECT Codigo, Descripcion,Valor from dbo.ParametrosAsistencia");
            sQlda = new SqlDataAdapter(strSQL, SQLCon);
            dt = new DataTable();
            sQlda.Fill(dt);
            grid.DataSource = dt;
          
        }
    }
}
