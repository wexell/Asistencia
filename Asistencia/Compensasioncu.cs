using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using Asistencia.Properties;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Asistencia
{
    public partial class Compensasioncu : UserControl
    {
       
        public Compensasioncu()
        {
          
            InitializeComponent();
        }
        public DataTable table = new DataTable();
        public DataRow row;
        public int codComp;
        public bool fechaIgual;
      

        private void Compensasioncu_Load(object sender, EventArgs e)
        {
            Compensasiones.cboHorarios(cboHorario);
            btnGuardar.Enabled = false;
            MakeDataTableAndDisplay();
            Compensasiones.cbocargarEmpleados(cboEmpleado);                  
     
        }

        private void MakeDataTableAndDisplay()
        {

            // Declare DataColumn and DataRow variables.
            DataColumn column;
            DataView view;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Fecha";
            table.Columns.Add(column);

            // Create Tercer column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Decimal");
            column.ColumnName = "Horas";
            table.Columns.Add(column);

            // Create Tercer column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Turno";
            table.Columns.Add(column);
        }
        public int guardarReg(string empleado, string obs, string fechacomp)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "dbo.[sp_ins_Compensacion]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Empleado", SqlDbType.VarChar).Value = empleado;
            cmd.Parameters.Add("FechaComp", SqlDbType.VarChar).Value = fechacomp;
            cmd.Parameters.Add("Observacion", SqlDbType.VarChar).Value = obs;
            cmd.Parameters.Add("User", SqlDbType.VarChar).Value = Valores.mUsuario.ToUpper();
            cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            cmd.ExecuteNonQuery();
            codComp = Convert.ToInt32(cmd.Parameters["@Id"].Value.ToString());
            conexion.Close();

            return codComp;


        }


        private void guardarDetalle_Reg(int comp, string empleado, string fecha, decimal horas, string turno)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
                String CadenaSql = ("Insert into dbo.Detalle_Comp(CodComp,Empleado,Fecha,Horas, Turno ) values ('" + comp + "','" + empleado + "', '" + fecha + "', '" + horas + "', '" + turno + "')");
                SqlCommand cmd = new SqlCommand(CadenaSql, conexion);
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL GUARDAR LOS REGISTROS: " + ex);


            }

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;

        }


        private void saldoDias(DataGridView data)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string horagrid = row.Cells[0].Value.ToString();
                string horain = Fecha.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                 if (horagrid == horain)
                {
                    fechaIgual = true;

                }
                else
                {
                    fechaIgual = false;

                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tbEmpleado.Text == "" || cboHorario.Text == "" || uphoras.Value == 0 || dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Seleccione Datos de Empleado y Horarios válidos","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult result = MessageBox.Show("Esta seguro que desea Grabar este Registro? ", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DateTime dtfecha = Fecha.Value;
                    DateTime dtfecha2 = dtFechaC.Value;

                    guardarReg(tbEmpleado.Text, tbObservacion.Text, dtfecha2.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string fecha = row.Cells["Fecha"].Value.ToString();
                        decimal horas = Convert.ToDecimal(row.Cells["Horas"].Value.ToString());
                        string turno = row.Cells["Turno"].Value.ToString();
                        guardarDetalle_Reg(codComp, tbEmpleado.Text, fecha, horas, turno);
                    }

                    LimpiarControles();
                    MessageBox.Show("Registros Grabados Existosamente!","",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

            }
        }



        private void datagridFit(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView.Columns[dataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void dtAgregar(DataGridView dataGrid)
        {
            row = table.NewRow();
            row["Fecha"] = Fecha.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            row["Horas"] = uphoras.Value.ToString("0.00", CultureInfo.InvariantCulture);
            row["Turno"] = cboHorario.EditValue;
            table.Rows.Add(row);
            table.AcceptChanges();
            dataGrid.DataSource = table;
            datagridFit(dataGridView1);

            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
        }

        private void fechasIguales(DataGridView data)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string horagrid = row.Cells[0].Value.ToString();
                string horain = Fecha.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
       
                if (horagrid == horain)
                {
                    fechaIgual = true;

                }
                else
                {
                    fechaIgual = false;

                }
            }



        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DateTime quinceDiasAtras = DateTime.Now;
            Compensasiones.obtenerMaxDias("Maxdias");
            quinceDiasAtras = quinceDiasAtras.AddDays(- Valores.maxDias);
            TimeSpan maximodias = quinceDiasAtras - Fecha.Value;
            int dias = maximodias.Days;
            if (Fecha.Value < quinceDiasAtras)
            {

                MessageBox.Show("La fecha a Compensar debe estar dentro de los últimos 15 Dias: " + dias.ToString(), "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
            else
            {

                if (uphoras.Value == 0 || cboHorario.Text == "[Vacío]" || cboHorario.Text == "[EditValue is null]")
                {
                    MessageBox.Show("Ingrese una Cantidad de Horas y Turno Válido", "Advertencia!!!", MessageBoxButtons.OK,
                       MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (dataGridView1.Rows.Count == 0)
                    {
                        Valores.saldo = 0;
                        Compensasiones.buscarSaldoHoras(Fecha.Value.ToString("yyyyMMdd", CultureInfo.InvariantCulture), tbEmpleado.Text, cboHorario.EditValue.ToString());
                        Valores.horas = 0;
                        DateTime fecha1 = Fecha.Value;
                        Compensasiones.buscarHoras(tbEmpleado.Text, fecha1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));

                        Decimal disponibleHoras;

                        if (Valores.saldo <= Valores.horas)
                        {
                            disponibleHoras = Valores.saldo;
                        }
                        else
                        {
                            disponibleHoras = Valores.saldo - Valores.horas;
                        }
                        Decimal totalHoras = Valores.horas + Convert.ToDecimal(uphoras.Value);

                        if (totalHoras <= Valores.saldo)
                        {
                            dtAgregar(dataGridView1);
                        }
                        else
                        {
                            MessageBox.Show("La cantidad de horas a compensar es mayor que la Cantidad de Horas: "+Valores.saldo.ToString()+" o el Saldo Disponible: "+ disponibleHoras.ToString(),
                                        "Advertencia!!!", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        }



                    }
                    else
                    {

                        fechasIguales(dataGridView1);
                        if (fechaIgual == true)
                        {
                            MessageBox.Show("Hay Fechas Iguales", "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        else
                        {
                            Valores.saldo = 0;
                            Compensasiones.buscarSaldoHoras(Fecha.Value.ToString("yyyyMMdd", CultureInfo.InvariantCulture), tbEmpleado.Text, cboHorario.EditValue.ToString());
                            Valores.horas = 0;
                            DateTime fecha1 = Fecha.Value;
                            Compensasiones.buscarHoras(tbEmpleado.Text, fecha1.ToString("yyyyMMdd", CultureInfo.InvariantCulture));

                            Decimal disponibleHoras;

                            if (Valores.saldo <= Valores.horas)
                            {
                                disponibleHoras = Valores.saldo;
                            }
                            else
                            {
                                disponibleHoras = Valores.saldo - Valores.horas;
                            }
                            Decimal totalHoras = Valores.horas + Convert.ToDecimal(uphoras.Value);

                            if (totalHoras <= Valores.saldo)
                            {
                                dtAgregar(dataGridView1);
                            }
                            else
                            {
                                MessageBox.Show("La cantidad de horas a compensar es mayor que la Cantidad de Horas: " + Valores.saldo.ToString() + " o el Saldo Disponible: " + disponibleHoras.ToString(),
                                         "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }

                    }
                }
            }
        }
        private void tbEmpleado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Compensasiones.buscarPrivilegio(Valores.mUsuario, 1) == true)
            {


                F1Empleado frm = new F1Empleado();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LimpiarControles();
                    tbEmpleado.Text = frm.Empleado;
                    tbNombres.Text = frm.Nombre;
                    tbPuesto.Text = frm.Puesto;
                    tbGerencia.Text = frm.Gerencia;
                }

            }
            else { MessageBox.Show("Usted no tiene Acceso a esta Opcion, Inicie sesion con su Usuario y Contraseña ",
                      "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

        }

        private void LimpiarControles()
        {
            tbEmpleado.Text = "";
            cboHorario.EditValue = null;
            cboHorario.Text = "";
            dataGridView1.DataSource = null;
            table.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataBindings.Clear();
            tbNombres.Text = "";
            tbPuesto.Text = "";
            tbGerencia.Text = "";
            uphoras.Value = 0;
            tbObservacion.Text = "";
        }

      

       
        
    }

}