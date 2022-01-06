using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Asistencia.Properties;
using DevExpress.XtraReports.Parameters;





namespace Asistencia
{

    class Compensasiones
    {

        public static DataTable AbrirTabla(string strSQL)
        {

            DataTable dt = new DataTable();
            SqlConnection sqlCon = new SqlConnection(Settings.Default.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(strSQL, sqlCon);
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error : {0}", ex.Message));
            }
            return dt;

        }

        public static DataSet AbrirData(string strSQL)
        {

            DataSet ds = new DataSet();
            SqlConnection sqlCon = new SqlConnection(Settings.Default.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(strSQL, sqlCon);
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error : {0}", ex.Message));
            }
            return ds;

        }

        public static void Ejecutarcmd(string sqlStr)
        {

            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand(sqlStr, conexion);
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(String.Format("Error : {0}", ex.Message)); }
        }





        public static void cargaEmpleado(LookUpEdit cbo)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
            string strSQL = ("SELECT E.EMPLEADO, E.NOMBRE, P.DESCRIPCION as PUESTO, D.DESCRIPCION as GERENCIA FROM [192.168.10.30].Exactus.Centrolac3.EMPLEADO E "
                + " INNER JOIN ASISTENCIA.DBO.USERINFO I ON I.EDUCATION = E.EMPLEADO"
                + " LEFT OUTER JOIN [192.168.10.30].Exactus.Centrolac3.DEPARTAMENTO D ON E.DEPARTAMENTO=D.DEPARTAMENTO"
                + " LEFT OUTER JOIN [192.168.10.30].Exactus.Centrolac3.PUESTO P ON E.PUESTO=P.PUESTO WHERE E.ACTIVO = 'S' ORDER BY D.DESCRIPCION");
            SqlCommand cmd = new SqlCommand(strSQL, conexion);
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cbo.Properties.DataSource = dt;
            cbo.Properties.ValueMember = "EMPLEADO";
            cbo.Properties.DisplayMember = "EMPLEADO";
            cbo.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            cbo.Properties.SearchMode = SearchMode.AutoComplete;
            cbo.Properties.AutoSearchColumnIndex = 1;

        }
        public static void cboHorarios(LookUpEdit cbo)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
            string strSQL = ("Select Codigo,Descripcion as Horario from dbo.Horarios order by CodReg ");
            SqlCommand cmd = new SqlCommand(strSQL, conexion);
            conexion.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cbo.Properties.DataSource = dt;
            cbo.Properties.ValueMember = "Codigo";
            cbo.Properties.DisplayMember = "Horario";
            cbo.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            cbo.Properties.SearchMode = SearchMode.AutoComplete;
            cbo.Properties.AutoSearchColumnIndex = 1;

        }


        public static void buscarInfoEmpleado(string empleado, TextBox nombres, TextBox puesto, TextBox gerencia)
        {
            string strSQL = String.Format("SELECT E.EMPLEADO, E.NOMBRE, P.DESCRIPCION as PUESTO, D.DESCRIPCION as GERENCIA FROM [192.168.10.30].Exactus.Centrolac3.EMPLEADO E"
            + " INNER JOIN ASISTENCIA.DBO.USERINFO I ON I.EDUCATION = E.EMPLEADO"
            + " LEFT OUTER JOIN [192.168.10.30].Exactus.Centrolac3.DEPARTAMENTO D ON E.DEPARTAMENTO=D.DEPARTAMENTO"
            + " LEFT OUTER JOIN [192.168.10.30].Exactus.Centrolac3.PUESTO P ON E.PUESTO=P.PUESTO WHERE E.ACTIVO = 'S'"
            + " AND E.EMPLEADO ='" + empleado + "' ORDER BY D.DESCRIPCION");
            DataSet ds = AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                nombres.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                puesto.Text = ds.Tables[0].Rows[0]["Puesto"].ToString();
                gerencia.Text = ds.Tables[0].Rows[0]["Gerencia"].ToString();

            }
            else
            {
                ds.Dispose();

            }
        }


        public static bool buscarCompensaciones(GridControl grid, string fechaini, string fechafin)
        {
            string strSQL = String.Format(" exec dbo.sp_Buscar_Comp '" + fechaini + "', '" + fechafin + "'");
            DataSet ds = AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid.DataSource = ds;
                grid.DataMember = ds.Tables[0].ToString();
                return true;

            }
            else
            {
                ds.Dispose();
                return false;
            }
        }

        public static void buscarMarcacionFecha(DataGridView grid, string fecha, string empleado, string Turno, int comp)
        {
            string strSQL = String.Format("exec dbo.sp_DetallesFechas '" + fecha + "', '" + empleado + "', '" + Turno + "', '" + comp + "'");
            DataSet ds = AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid.DataSource = ds;
                grid.DataMember = ds.Tables[0].ToString();


            }
            else
            {
                ds.Dispose();

            }
        }

        public static void buscarDescripcionComp(TextBox desc, int comp)
        {
            string strSQL = String.Format("SELECT CODREG, Observacion from dbo.Compensacion where CodReg= " + comp + "");
            DataSet ds = AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                desc.Text = ds.Tables[0].Rows[0]["Observacion"].ToString();
            }
            else
            {
                ds.Dispose();

            }
        }



        public static void ModificarComp(int code, TextBox emp)
        {
            string strSQL = String.Format("SELECT c.Empleado,e.Nombre, p.Descripcion as Puesto,d.Descripcion as Gerencia FROM DBO.COMPENSACION c"
            + " Inner Join  [192.168.10.30].Exactus.Centrolac3.EMPLEADO e on c.Empleado = e.Empleado"
            + " Inner Join [192.168.10.30].Exactus.Centrolac3.Puesto p on e.Puesto = p.Puesto "
            + " Inner Join  [192.168.10.30].Exactus.Centrolac3.DEPARTAMENTO d on d.Departamento = e.Departamento"
            + " where CodReg = '" + code + "'");
            DataSet ds = AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                emp.Text = ds.Tables[0].Rows[0]["Empleado"].ToString();
                //nombres.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                //puesto.Text = ds.Tables[0].Rows[0]["Puesto"].ToString();
                //gerencia.Text = ds.Tables[0].Rows[0]["Gerencia"].ToString();

            }
            else
            {
                ds.Dispose();

            }
        }
        public static void Aprobar(int code, string usuario)
        {
            DialogResult result = MessageBox.Show("Aprobar Compensación? ", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
                    String CadenaSql = ("Update dbo.Compensacion set Estado = 'A', Aprobadopor = '" + usuario.ToUpper() + "' where CodReg = " + code + ""
                                   +"  Update dbo.Detalle_Comp set Estado ='A' where CodComp ="+code+"" );
                    SqlCommand cmd = new SqlCommand(CadenaSql, conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Compensacion Aprobada!","CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("ERROR EJECUTANDO LOS CAMBIOS: " + ex);


                }
            }
        }


        public static void Recibir(int code)
        {
            DialogResult result = MessageBox.Show("Recibir Compensación? ", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                try
                {
                    SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
                    String CadenaSql = ("Update dbo.Compensacion set Recibido = 'S' where CodReg = " + code + "");

                    SqlCommand cmd = new SqlCommand(CadenaSql, conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Compensacion Recibida!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("ERROR EJECUTANDO LOS CAMBIOS: " + ex);


                }
            }
        }

        public static bool validarTipoUsuario(string usuario)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);

            string strSQL = String.Format("SELECT Tipo from dbo.UserPrivilegios where Usuario ='" + usuario + "' and Tipo = 'A'");
            DataSet ds = Compensasiones.AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
                             
            }
            else
                ds.Dispose();
            return false;


        }


        public static bool buscarPrivilegio(string usuario, int menu)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);

            string strSQL = String.Format("SELECT IdUsuario FROM DBO.PERMISO p inner join dbo.UserPrivilegios u on p.IdUsuario = u.Usuario where IdUsuario ='" + usuario + "' and IdMenu= " + menu + " and Opcion = '1'");
            DataSet ds = Compensasiones.AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return true;
            }
            else
                ds.Dispose();
            return false;


        }
        public static void buscarHoras(string empleado, string fecha)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);

            string strSQL = String.Format("Select isnull(sum(d.Horas),0) Horas from dbo.compensacion  c "
           + " inner join dbo.Detalle_comp d on c.CodReg= d.CodComp "
           + " where c.Empleado ='" + empleado + "' and d.Fecha= '" + fecha + "'"
           +" and d.Estado not in ('C')");
            DataSet ds = Compensasiones.AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Valores.horas = Convert.ToDecimal(ds.Tables[0].Rows[0]["Horas"].ToString());
            }
            else { ds.Dispose(); }

        }
        public static void buscarSaldoHoras(string fecha, string empleado, string turno)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);

            string strSQL = String.Format("exec dbo.sp_SaldoHoras '" + fecha + "', '" + empleado + "','" + turno + "'");
            DataSet ds = AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Horas"].ToString() == "")
                {
                }
                else
                {
                    Valores.saldo = Convert.ToDecimal(ds.Tables[0].Rows[0]["Horas"].ToString());
                }

            }
            else { ds.Dispose(); }

        }

        public static void cancelarComp(int comp)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);
                String CadenaSql = ("Update dbo.Compensacion set Estado = 'C' where CodReg =" + comp + ""
                    + "Update dbo.Detalle_Comp set Estado = 'C' where codComp = " + comp + "");
                SqlCommand cmd = new SqlCommand(CadenaSql, conexion);
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Compensacion Anulada!!!","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR AL CANCELAR LA COMPENSACION: " + ex);


            }
            
        }

        public static bool buscarCompReporte(GridControl grid, string fechaini, string fechafin)
        {
            string strSQL = String.Format(" exec dbo.sp_Buscar_CompReporte '" + fechaini + "', '" + fechafin + "'");
            DataSet ds = AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid.DataSource = ds;
                grid.DataMember = ds.Tables[0].ToString();
                return true;

            }
            else
            {
                ds.Dispose();
                return false;
            }
        }
        public static void  obtenerMaxDias(string parametro)
        {
            string strSQL = String.Format("Select Valor from dbo.ParametrosAsistencia where Parametro= '" + parametro + "'");
            DataSet ds = AbrirData(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Valores.maxDias = Convert.ToDouble(ds.Tables[0].Rows[0]["Valor"].ToString());
            }
            else
            {
                ds.Dispose();

            }
        }

        public static void cbocargarEmpleados(System.Windows.Forms.ComboBox cbo)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConnectionString);

            string strSQL = String.Format("exec dbo.BuscarEmpleados");
            DataTable dt = Compensasiones.AbrirTabla(strSQL);
            if (dt.Rows.Count > 0)
            {
                cbo.DataSource = dt;
                cbo.DisplayMember = "Empleado";
                cbo.ValueMember = "Empleado";
            }
            else
            dt.Dispose();
     


        }
    
    
    
    
    }
}
