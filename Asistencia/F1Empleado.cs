using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using Asistencia.Properties;
namespace Asistencia
{
    public partial class F1Empleado : Form
    {
        public string Empleado, Nombre, Puesto, Gerencia;
        public F1Empleado()

        {
            InitializeComponent();
        }

        private void F1Empleado_Load(object sender, EventArgs e)
        {
            findEmpleado("%");
        }


        private void findEmpleado(string valor)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
            String CadenaSql = ("Exec dbo.BuscarEmpleado '" + valor + "'");
            SqlCommand cmd = new SqlCommand(CadenaSql, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Adaptador = new SqlDataAdapter(CadenaSql, conexion);
            DataSet ds = new DataSet();
            conexion.Open();
            Adaptador.Fill(ds);
            conexion.Close();
            gridControl1.DataSource = ds.Tables[0];
            //gridView1.Columns["Empleado"].BestFit();
            gridView1.Columns[0].Width = 50;
           

        }

     
        private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (tbCodigo.TextLength == 0)
                   findEmpleado("%");
                else
                    findEmpleado(tbCodigo.Text);
            }
        }

        private void tbNombre_KeyDown(object sender, KeyEventArgs e)
        {
        if (e.KeyCode == Keys.Return)
            {
                if (tbNombre.TextLength == 0)
                   findEmpleado("t%");
                else
                    findEmpleado(tbNombre.Text);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show("Seleccione un Registro! ");
                return;
            }
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Empleado").ToString() != "")
            {

                Empleado = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Empleado").ToString();
                Nombre = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Nombre").ToString();
                Puesto = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Puesto").ToString();
                Gerencia = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Gerencia").ToString();
                DialogResult = DialogResult.OK;
            }
        }
        

    }
}
