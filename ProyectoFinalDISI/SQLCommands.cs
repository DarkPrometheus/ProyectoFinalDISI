using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ProyectoFinalDISI
{
    internal class SQLCommands
    {
        private const string rutaBDD = @"C:\Users\Emmanuel\Documents\PuntoVenta";
        //private const string rutaBDD = @"C:\Users\Emmanuel\Documents\ProyectoCitas";
        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", rutaBDD)
            );

            db.Open();

            return db;
        }

        public static int Login(string nombre, string psd)
        {
            int valid = -1;
            using (var ctx = GetInstance())
            {
                using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                {
                    Conexion.Open();
                    SQLiteCommand cmd = Conexion.CreateCommand();

                    cmd.CommandText = "select isAdmin from Empleados WHERE nombreEmpleado='" + nombre + "' AND password='" + psd + "'";
                    SQLiteDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        valid = Convert.ToInt32(dr[0]);
                    }
                    else
                        valid = -1;

                    dr.Close();
                    cmd.Dispose();
                }
            }

            return valid;
        }
    }
}
