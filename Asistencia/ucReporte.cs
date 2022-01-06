using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using Asistencia.Properties;
using System.Data.SqlClient;



namespace Asistencia
{
    public partial class ucReporte : UserControl
    {
        //public static string FFini;
        //public static string FFfin;
        //public ReportDocument docc;
        //public string CadenaCn = Settings.Default.ConnectionString;
        public ucReporte()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
            
        private void ucReporte_Load(object sender, EventArgs e)
        {
            //TableLogOnInfo crTableLogOnInfo = new TableLogOnInfo();
            //ConnectionInfo crConnectionInfo = new ConnectionInfo();
            //CrystalDecisions.CrystalReports.Engine.Database crDataBase;
            //CrystalDecisions.CrystalReports.Engine.Tables crTables;

            //docc = new ReportDocument();
            //string NombreArchivo = "C:\\REPORTE\\CompensacionesRep.rpt";
            
            //docc.Load(NombreArchivo);
            //crConnectionInfo.ServerName = "192.168.10.34";
            //crConnectionInfo.DatabaseName = "Asistencia";
            //crConnectionInfo.UserID = "erpadmin";
            //crConnectionInfo.Password = "exerpadmin";
            //crConnectionInfo.Type = ConnectionInfoType.SQL;
            //crConnectionInfo.IntegratedSecurity = false;
            //crDataBase = docc.Database;
            //crTables = crDataBase.Tables;

            //SqlConnection conexion = new SqlConnection();
            //conexion.ConnectionString = CadenaCn;
            ////Crear Consulta 
            //String CadenaSql = ("EXEC sp_Buscar_CompReporte'" + FFini + "', '"+FFfin+"'");
            
            ////Crear Comando
            //SqlCommand comando = conexion.CreateCommand();
            //comando.CommandType = CommandType.StoredProcedure;

            ////Ejecutar la consulta de Accion
            //SqlDataAdapter Adaptador = new SqlDataAdapter(CadenaSql, conexion);
       
            ////DataSet
            //DataSet ds = new DataSet();
            ////Llenar el Dataset
            //conexion.Open();
            //Adaptador.Fill(ds);
            
            //foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
            //{
            //    crTableLogOnInfo = crTable.LogOnInfo;
            //    crTableLogOnInfo.ConnectionInfo = crConnectionInfo;
            //    crTable.ApplyLogOnInfo(crTableLogOnInfo);
            //}


            //docc.SetDataSource(ds.Tables[0]);

            ////ParameterFields paramFields = new ParameterFields();
            ////ParameterField paramField = new ParameterField();
            ////ParameterField paramField2 = new ParameterField();
            ////ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            ////paramField.Name = "@FechaIni";
            ////paramField2.Name= "@FechaFin";

            ////paramDiscreteValue.Value = FFini.ToString();
            ////paramDiscreteValue.Value = FFfin.ToString();
            ////paramField.CurrentValues.Add(paramDiscreteValue);
            ////paramFields.Add(paramField);
            ////paramFields.Add(paramField2);

            //conexion.Close();

            ////crystalReportViewer1.ParameterFieldInfo = paramFields;
            ////docc.Subreports[0].ParameterFields.Add(paramFields);
            //crystalReportViewer1.ReportSource = docc;
            //crystalReportViewer1.Refresh();
            //this.crystalReportViewer1.RefreshReport();
        }

    }
}
