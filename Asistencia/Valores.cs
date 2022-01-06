using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asistencia
{
    class Valores
    {

        public static string mUsuario { get; set; }
        public static string mClave { get; set; }

        public static string user = "erpadmin";
        public static string pass = "exerpadmin";

        public static string employe { get; set; }
        public static int codigo { get; set; }
        public static string estado { get; set; }
        public static decimal horas { get; set; }
        public static decimal saldo { get; set; }
        public static double maxDias { get; set; }
        public static string tipoUser { get; set; }
    
        //public static void Initializar(string Usuario, string Clave)
        //{
        //    mUsuario = Usuario;
        //    mClave = Clave;

        //}
        public static void Initializar(string Emplead, int code, string estate, string Usuario, string Clave, decimal saldoh)
        {
           employe = Emplead;
           codigo = code;
           estado = estate;
           mUsuario = Usuario;
           mClave = Clave;
           saldo = saldoh;
    

           

        }
       
    }
}
