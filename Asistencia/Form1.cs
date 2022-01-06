using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.IO;

using System.Data.SqlClient;
using System.Collections.Specialized;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Asistencia.Properties;
using System.Globalization;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;


namespace Asistencia
{
    public partial class Form1 : Form
    {
        public Form1 m_frm;
        Compensasioncu  usctl = new Compensasioncu();
        Modificar cu = new Modificar(Valores.employe, Valores.codigo, Valores.estado);
        public static String FECHA;
        public static String FECHA2;

        SqlCommand OCommand = new SqlCommand();
        SqlConnection OConnection = new SqlConnection(Settings.Default.ConnectionString);
        SqlDataAdapter SqlAdapter;
        DataSet ds = new System.Data.DataSet();


        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetComboArea();
            panel5.Controls.Clear();
            Compensasioncu Control = new Compensasioncu();
            Control.Dock = DockStyle.Fill;
            panel5.Controls.Add(Control);
            panel6.Visible = false;
            btnConfig.Enabled = false;
            
                    
        }

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new Form1());
            }
            catch (Exception excep)  //you can put a breakpoint here
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void GroupColumns(GridView gv)
        {
            gv.BeginSort();
            try
            {
                gv.ClearGrouping();
               // gv.Columns["ID"].GroupIndex = 0;
                gridView1.Columns["PIN"].BestFit();
                gridView1.Columns["EMPLEADO"].BestFit();
                gridView1.Columns["Departamento"].BestFit();
                gridView1.Columns["DepDescripcion"].BestFit();
                gridView1.Columns["Puesto"].BestFit();
                //gridView1.Columns["Hora_Entrada"].DisplayFormat.FormatString = "MMM/dd/yyyy hh:mm tt";
                //gridView1.Columns["Hora_Salida"].DisplayFormat.FormatString = "MMM/dd/yyyy hh:mm tt";
                gv.OptionsBehavior.AutoExpandAllGroups = true;

            }
            finally
            {
                gv.EndSort();
            }
        }


        private void GroupColumns2(GridView gv)
        {
            gv.BeginSort();
            try
            {
                gv.ClearGrouping();
                gv.Columns["Compensacion"].BestFit();
                gv.Columns["Nombre"].BestFit();
                gv.Columns["Empleado"].BestFit();
                gv.Columns["Depto"].BestFit();
                gv.Columns["Fecha"].BestFit();
                gv.Columns["Horas"].BestFit();
                gv.Columns["Turno"].BestFit();
                gv.Columns["Estado"].BestFit();
                gv.Columns["Recibido"].BestFit();
                gv.Columns["AprobadoPor"].BestFit();
                
            }
            finally
            {
                gv.EndSort();
            }
        }

        private void GroupColumns3(GridView gv)
        {
            gv.BeginSort();
            try
            {
                gv.ClearGrouping();
                gv.Columns["Observacion"].GroupIndex = 1;
                gv.Columns["Compensacion"].BestFit();
                gv.Columns["Empleado"].BestFit();
                gv.Columns["Depto"].BestFit();
                gv.Columns["Fecha"].BestFit();
                gv.Columns["Horas"].BestFit();
                gv.Columns["Turno"].BestFit();
                gv.Columns["Estado"].BestFit();
                gv.Columns["Recibido"].BestFit();
                gv.Columns["AprobadoPor"].BestFit();
                gv.OptionsBehavior.AutoExpandAllGroups = true;

            }
            finally
            {
                gv.EndSort();
            }
        }

      
        public DataSet CargarDataset(string OString, string tabla)
        {
            SqlAdapter = new SqlDataAdapter(OString, OConnection);
            SqlCommandBuilder Oracmd = new SqlCommandBuilder(SqlAdapter);
            ds.Clear();
            SqlAdapter.Fill(ds, tabla);
            return ds;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridControl1.Visible = true;
            FECHA = dtFechaini.Text;
            FECHA2 = dtFechafin.Text;
            lbRegistros.Text = "";
            gridView1.Columns.Clear();

            if (cboxMarcas.Checked == true)
            {
                if (cbArea.Text == "")
                {
                    if (buscar_marcas_fecha(FECHA, FECHA2) == true)
                    {
                        //GroupColumns(gridView1);
                        lbNombres.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("No Existen Registros!");
                    }


                }
                else
                {
                    if (buscar_marcas_area_all(FECHA, FECHA2, cbArea.EditValue.ToString()) == true)
                    {

                        lbNombres.Text = "";
                        gridView1.Columns["Hora"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gridView1.Columns["Hora"].DisplayFormat.FormatString = "hh:mm:ss tt";
                    }
                    else
                    {
                        MessageBox.Show("No Existen Registros!");
                    }


                }
            }
            else
            {
                if (cbArea.Text == "")
                {
                    if (buscar_marcas_fecha(FECHA, FECHA2) == true)
                    {
                        GroupColumns(gridView1);
                        lbNombres.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("No Existen Registros!");
                    }


                }
                else
                {
                    if (buscar_marcas_area(FECHA, FECHA2, cbArea.EditValue.ToString()) == true)
                    {
                        GroupColumns(gridView1);
                        lbNombres.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No Existen Registros!");
                    }


                }

            }
        }

       
        private void teCodigo_DoubleClick(object sender, EventArgs e)
        {
            Codigo frm = new Codigo();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                teCodigo.Text = frm.lCodigo;
                lbNombres.Text = frm.lNombre;
            }
        }

        private void teEmpleado_DoubleClick(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                teEmpleado.Text = frm.lCodigo;
                lbNombres.Text = frm.lNombre;
            }
        }
        
        private void GetComboArea()
        {

            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();
            //Crear Consulta 
            String CadenaSql = ("Select DEPARTAMENTO, case when DESCRIPCION= 'NO DEFINIDA' THEN ''ELSE DESCRIPCION END DESCRIPCION from [192.168.10.30].Exactus.Centrolac3.DEPARTAMENTO");
            //Adaptador
            SqlAdapter = new SqlDataAdapter(CadenaSql, conexion);
            conexion.Close();
            DataTable dt = new DataTable();
            
            SqlAdapter.Fill(dt);

            //Valor a Mostrar en el Cuadro de Texto
            cbArea.Properties.DataSource = dt;
            cbArea.Properties.DisplayMember = "DESCRIPCION";

            //Campo a clave a seleccionar cuando se seleccione un registro.
            cbArea.Properties.ValueMember = "DEPARTAMENTO";

            //Auto ajustar el tamaño del Listado
            cbArea.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            //Preseleccionar el primer item
            //cbArea.EditValue = 1;

            //Columna Personalizada
            cbArea.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEPARTAMENTO", 50, "Departamento"));
            cbArea.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DESCRIPCION", 50, "Descripcion"));


        }
        
        private bool buscar_marcas_fecha(string fecha1, string fecha2)
        {
            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();

            //Crear Consulta 
            String CadenaSql = (" EXEC ASISTENCIA.DBO.MARCAS_FECHA '"+fecha1+"','"+fecha2+"'" );

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
                return false;  //El registro no se encontró
            }
            else
            {
                //Llenar el Dataset
                gridControl1.DataSource = ds;
                gridControl1.DataMember = ds.Tables[0].ToString();
                ds.Dispose();
                return true; //El registro Existe
            }

        }
        
        private bool buscar_marcas_area(string fecha1, string fecha2, string area)
        {
            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();

            //Crear Consulta 
            String CadenaSql = (" EXEC ASISTENCIA.DBO.MARCAS_FECHA_AREA '" + fecha1 + "','" + fecha2 + "','"+area+"'");

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
                return false;  //El registro no se encontró
            }
            else
            {
                //Llenar el Dataset
                gridControl1.DataSource = ds;
                gridControl1.DataMember = ds.Tables[0].ToString();
                ds.Dispose();
                return true; //El registro Existe
            }

        }

        private bool buscar_marcas_area_all(string fecha1, string fecha2, string area)
        {
            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();

            //Crear Consulta 
            String CadenaSql = (" EXEC ASISTENCIA.DBO.MARCAS_FECHA_AREA_ALL '" + fecha1 + "','" + fecha2 + "','" + area + "'");

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
                return false;  //El registro no se encontró
            }
            else
            {
                //Llenar el Dataset
                gridControl1.DataSource = ds;
                gridControl1.DataMember = ds.Tables[0].ToString();
                ds.Dispose();
                return true; //El registro Existe
            }

        }

        private bool buscar_marcas()
        {
            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();

            //Crear Consulta 
            String CadenaSql = ("SELECT PIN AS CODIGO, EDUCATION AS EMPLEADO, UI.NAME AS Nombres,LASTNAME as Apellidos, E.Departamento, D.Descripcion as DepDescripcion,P.DESCRIPCION as Puesto, MIN(Time) Hora_Entrada, MAX(Time) Hora_Salida"
            +" FROM Asistencia.dbo.acc_monitor_log ML "
            +"INNER JOIN ASISTENCIA.DBO.USERINFO UI ON ML.PIN = UI.Badgenumber COLLATE DATABASE_DEFAULT LEFT OUTER JOIN  [192.168.10.30].Exactus.Centrolac3.EMPLEADO E ON UI.EDUCATION=E.EMPLEADO "
            +"LEFT OUTER JOIN [192.168.10.30].Exactus.Centrolac3.DEPARTAMENTO D ON E.DEPARTAMENTO=D.DEPARTAMENTO "
            +"LEFT OUTER JOIN [192.168.10.30].Exactus.Centrolac3.PUESTO P ON E.PUESTO=P.PUESTO  WHERE PIN <>'' group by Pin, Education, Name, Lastname, E.departamento, D.Descripcion, P.Descripcion order by E.Departamento asc");

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
                return false;  //El registro no se encontró
            }
            else
            {
                //Llenar el Dataset
                gridControl1.DataSource = ds;
                gridControl1.DataMember = ds.Tables[0].ToString();
                ds.Dispose();

                return true; //El registro Existe
            }

        }
                
        private void exportarAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdRuta.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXls(sfdRuta.FileName);
            }
        }


        private bool buscar_marcas_codigo(string fecha1, string fecha2, string codigo)
        {
            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();

            //Crear Consulta 
            String CadenaSql = (" EXEC ASISTENCIA.DBO.MARCAS_FECHA_CODIGO '" + fecha1 + "','" + fecha2 + "', '" +codigo+ "'");

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
                return false;  //El registro no se encontró
            }
            else
            {
                //Llenar el Dataset
                gridControl1.DataSource = ds;
                gridControl1.DataMember = ds.Tables[0].ToString();
                ds.Dispose();
                                      
                return true; //El registro Existe
            }

        }
                
        private bool buscar_marcas_empleado(string fecha1, string fecha2, string empleado)
        {
            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();

            //Crear Consulta 
            String CadenaSql = (" EXEC ASISTENCIA.DBO.MARCAS_FECHA_EMPLEADO '" + fecha1 + "','" + fecha2 + "','" + empleado + "'");

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
                return false;  //El registro no se encontró
            }
            else
            {
                //Llenar el Dataset
                gridControl1.DataSource = ds;
                gridControl1.DataMember = ds.Tables[0].ToString();
                ds.Dispose();
                
                           

                return true; //El registro Existe
            }

        }
        private void teEmpleado_EditValueChanged(object sender, EventArgs e)
        {
            teCodigo.Text = "";
        }
     
        private  void findDetalleMarcas(string fechaini, string fechafin, string pin)
        {
            //Conexion
            SqlConnection conexion = OConnection;
            conexion.Open();

            //Crear Consulta 
            String CadenaSql = ("EXEC Asistencia.DBO.MARCAS_FECHA_CODIGO '"+fechaini+"', '"+fechafin+"','"+pin+"'");

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
                gridView2.Columns["Hora"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView2.Columns["Hora"].DisplayFormat.FormatString = "hh:mm:ss tt";
                ds.Dispose();
                string cont = this.gridView2.RowCount.ToString();
                lbRegistros.Text = cont;

               
            }

        }
                               
        private void btnBuscarComp_Click(object sender, EventArgs e)
        {
            gridControl1.Visible = true;

        }
        
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
       
            FECHA = dtFechaini.Text;
            FECHA2 = dtFechafin.Text;
            if (gridView1.FocusedRowHandle < 0)
            {
                return;
            }
            else
            {
                findDetalleMarcas(FECHA, FECHA2, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PIN").ToString());
            }
        
        }
        
        private void btnNewComp_Click(object sender, EventArgs e)
        {
            
            if (Compensasiones.buscarPrivilegio(Valores.mUsuario,1) == true){
            panel5.Controls.Clear();
            Compensasioncu Control = new Compensasioncu();
            Control.Dock = DockStyle.Left;
            panel5.Controls.Add(Control);
            Control.btnGuardar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Usted no tiene Acceso a esta Opción!!!",
                "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           }                
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            gridView4.Columns.Clear();
            buscarComp();
    

        }
        public void buscarComp()
        {
            DateTime dateini = dtFechaini2.Value;
            DateTime datefin = dtFechafin2.Value;
            if (Compensasiones.buscarCompensaciones(gridControl3, dateini.ToString("yyyyMMdd 00:00:00", CultureInfo.InvariantCulture), datefin.ToString("yyyyMMdd 00:00:00", CultureInfo.InvariantCulture)) == true)
            {
                GroupColumns2(gridView4);
            }
            else { }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (gridView4.FocusedRowHandle < 0)
            {
                return;
            }
            else
            {
               if (Compensasiones.buscarPrivilegio(Valores.mUsuario,2) == true){
               string aprobada = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Estado").ToString();
               if (aprobada == "N")
               {
                   panel5.Controls.Clear();
                   Valores.employe = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Empleado").ToString();
                   //Valores.codigo = Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Comp").ToString());
                   //Valores.estado = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Estado").ToString();

                   Modificar cu = new Modificar(Valores.employe, Valores.codigo, Valores.estado);
                   cu.Dock = DockStyle.Left;
                   panel5.Controls.Add(cu);
               }
               else { MessageBox.Show("Esta Compensación ya fue Aprobada!"); }
               }
               else
               {
                   MessageBox.Show("Usted no tiene Acceso a esta Opcion!!!",
                    "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

               }
               
            }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
             
            if (gridView4.FocusedRowHandle < 0)
            {
                return;
            }
            else
            {
                if (Compensasiones.buscarPrivilegio(Valores.mUsuario,3) == true){
                string recibido = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Recibido").ToString();
                string Estado = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Estado").ToString();
                if (recibido == "N" && Estado =="N")    
                {
                    Compensasiones.Aprobar(Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Compensacion").ToString()), Valores.mUsuario);
                    buscarComp();
                }else if (Estado == "C")
                   {
                       MessageBox.Show("Esta Compensación ya Fue Anulada!!!","Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                   }
                   else if(Estado =="A" && recibido =="N")
                   {
                       MessageBox.Show("Esta Compensación ya fue Aprobada!!!", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                   }
                else MessageBox.Show("Esta Compensación ya fue Recibida!!!", "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
               }
               else
               {
                   MessageBox.Show("Usted no tiene Acceso a esta Opción!!!",
                   "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
               
            }

         }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            if (gridView4.FocusedRowHandle < 0)
            {
                return;
            }
            else
            {
                if (Compensasiones.buscarPrivilegio(Valores.mUsuario, 4) == true)
                {
                    string Estado = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Estado").ToString();
                    string Recibido = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Recibido").ToString();
                    if (Estado == "A" && Recibido =="N")
                    {
                        string emp = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Empleado").ToString();
                        DateTime Fechax = Convert.ToDateTime(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Fecha").ToString());
                        Compensasiones.Recibir(Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Compensacion").ToString()));
                        buscarComp();
                    }
                    else if (Estado == "C")
                    {
                        MessageBox.Show("Esta Compensación Ya fue Cancelada!", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Recibido == "S") { MessageBox.Show("Esta Compensacion Ya fue Recibida!!!", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }

                    else{MessageBox.Show("Esta Compensación No ha sido Aprobada!", "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                }else
                {
                    MessageBox.Show("Usted no tiene Acceso a esta Opción!!!",
                    "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                login.Close();
                this.Text = "USUARIO ["+Valores.mUsuario.ToUpper()+"]";
                panel5.Controls.Clear();
                Compensasioncu Control = new Compensasioncu();
                Control.Dock = DockStyle.Fill;
                panel5.Controls.Add(Control);
                Control.btnGuardar.Enabled = true;
                lbUsuario.Text = Valores.mUsuario.ToUpper();
                              
            }
        }

        //private void timerHora_Tick(object sender, EventArgs e)
        //{
        //    //lbHora.Text = DateTime.Now.ToString("hh:mm:ss");
        //    //lbFecha.Text = DateTime.Now.ToShortDateString();

        //}

        

       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (gridView4.FocusedRowHandle < 0)
            {
                MessageBox.Show("Debe Seleccionar Un Registro Válido", "Seleccionar Registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (Compensasiones.buscarPrivilegio(Valores.mUsuario, 5) == true)
                {

                    string Recibida = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Recibido").ToString();
                    if (Recibida != "S")
                    {
                        DialogResult result = MessageBox.Show("Esta Por Cancelar o Anular esta Compensación? ", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            Compensasiones.cancelarComp(Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Compensacion").ToString()));
                            buscarComp();
                        }
                        else { }
                    }
                    else { MessageBox.Show("Esta Compensación Ya fue Recibida!!!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else
                {
                    MessageBox.Show("Usted no tiene Acceso a esta Opción!!!",
                    "Advertencia!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (sfdRuta.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXls(sfdRuta.FileName);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
        private void gridView4_RowClick(object sender, RowClickEventArgs e)
        {
       
            
            if (gridView4.FocusedRowHandle < 0)
            {
                return;
            }
            else
            {
                DateTime Fechaz = Convert.ToDateTime(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Fecha").ToString());
                string emp = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Empleado").ToString();
                string turno = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Turno").ToString();
                int comp =  Convert.ToInt32(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "Compensacion").ToString());
                dataGridView1.Columns.Clear();
                Compensasiones.buscarMarcacionFecha(dataGridView1, Fechaz.ToString("yyyyMMdd", CultureInfo.InvariantCulture),emp,turno, comp );
                Compensasiones.buscarDescripcionComp(DescripcionComp, comp);
                datagridFit(dataGridView1);
            }
        
        }

        private void btnExcell_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 2019 Format (*.xls)|*.xls";
            sfd.FileName = string.Format("Compensaciones_Rep_{0}-{1}-{2}.xls", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
            string path = sfd.FileName;
            sfd.FilterIndex = 1;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridControl4.ExportToXls(path);
                Process.Start(path);
            }
        }
               

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 2019 Format (*.xls)|*.xls";
            sfd.FileName = string.Format("Compensaciones_Rep_{0}-{1}-{2}.xls", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());
            string path = sfd.FileName;
            sfd.FilterIndex = 1;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridControl4.ExportToXls(path);
                Process.Start(path);
            }                  
        }
        
        private void btnReporteView_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void btnReporteGraph_Click(object sender, EventArgs e)
        {
            DateTime dateini = dtFInicio.Value;
            DateTime datefin = dtFFin.Value;
            SqlConnection conn = new SqlConnection(Settings.Default.ConnectionString);
            conn.Open();
            string parameter1 = dateini.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string parameter2 = datefin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            mostrar(conn, parameter1, parameter2, "C:\\Reporte\\CompensacionesRep.rpt");
        }


        public void mostrar(SqlConnection conexionbd, string fecha1, string fecha2, string docc)
        {
            ReportDocument repdocc = new ReportDocument();
            repdocc.Load(docc);
            repdocc.SetParameterValue(0, fecha1);
            repdocc.SetParameterValue(1, fecha2);
            repdocc.SetDatabaseLogon("sa", "#centrolac01#");
            RepCompensaciones visor = new RepCompensaciones();
            visor.crystalReportViewer1.ReportSource = repdocc;
            visor.crystalReportViewer1.Zoom(100);
            visor.ShowDialog();
        }
        
        private void btnBuscarCmp_Click(object sender, EventArgs e)
        {
            DateTime dateini = dtFInicio.Value;
            DateTime datefin = dtFFin.Value;
            string fullimagepath = Path.Combine(Application.StartupPath, @"Reportecomp.rpt");
          
            Compensasiones.buscarCompReporte(gridControl4, dateini.ToString("yyyyMMdd 00:00:00", CultureInfo.InvariantCulture), datefin.ToString("yyyyMMdd 00:00:00", CultureInfo.InvariantCulture));
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (Compensasiones.validarTipoUsuario(Valores.mUsuario) == true)
            {

            }
            Parametros win = new Parametros();
            win.ShowDialog();
                   
        }

        private void gridView4_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedColumn.FieldName == "XXX")
            {
                e.Cancel = false;
            }
            else { e.Cancel = true; }
        }

        private void lbUsuario_TextChanged(object sender, EventArgs e)
        {
            if(Compensasiones.validarTipoUsuario(Valores.mUsuario) == true )
            {
                btnConfig.Enabled = true;
            }else btnConfig.Enabled = false;
        }

        

        

        

      
            
           




    }


    
}
