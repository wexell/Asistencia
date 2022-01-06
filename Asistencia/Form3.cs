using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;


namespace Asistencia
{
    public partial class Form3 : Form
    {
        public string lCodigo, lNombre;
        SqlCommand OCommand = new SqlCommand();
        SqlConnection OConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        SqlDataAdapter SqlAdapter;
        DataSet ds = new System.Data.DataSet();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Buscar_EmpleadoERP("%");
            GroupColumns(gridView1);
        }


        private void GroupColumns(GridView gv)
        {
            gv.BeginSort();
            try
            {
                gv.ClearGrouping();
                // gv.Columns["ID"].GroupIndex = 0;
                gridView1.Columns["CODIGO"].BestFit();
                gridView1.Columns["NOMBRES"].BestFit();
                gv.OptionsBehavior.AutoExpandAllGroups = true;

            }
            finally
            {
                gv.EndSort();
            }
        }



        private void Buscar_EmpleadoERP(string valor)
        {
            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();

            //Crear Consulta 
            String CadenaSql = ("EXEC Asistencia.[DBO].[BuscarEmpleadoERP] '" + valor + "'");

            //Adaptador
            SqlAdapter = new SqlDataAdapter(CadenaSql, conexion);

            //DataSet
            DataSet ds = new DataSet();

            //Llenar el Dataset
            SqlAdapter.Fill(ds);
            //Contar Registros
            conexion.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Dispose();

            }
            else
            {
                //Llenar el Dataset
                gridControl2.DataSource = ds;
                gridControl2.DataMember = ds.Tables[0].ToString();
                ds.Dispose();

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (textBox1.TextLength == 0)
                    Buscar_EmpleadoERP("%");

                else
                    Buscar_EmpleadoERP(textBox1.Text);
                GroupColumns(gridView1);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (textBox2.TextLength == 0)
                    Buscar_EmpleadoERP("%");
                else
                    Buscar_EmpleadoERP(textBox2.Text);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("Seleccione un Registro Valido");
                return;
            }
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODIGO").ToString() != "")
            {

                lCodigo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODIGO").ToString();
                lNombre = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOMBRES").ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("Seleccione un Registro Valido");
                return;
            }
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODIGO").ToString() != "")
            {

                lCodigo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CODIGO").ToString();
                lNombre = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOMBRES").ToString();
                DialogResult = DialogResult.OK;
            }
        }



    }
}
