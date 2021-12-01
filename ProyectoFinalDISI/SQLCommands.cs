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
        //private const string rutaBDD = @"C:\Users\Cristo\Documents\ProyectoFinalDISI\PuntoVenta";
        //private const string rutaBDD = @"C:\Users\Briseño\Documents\PuntoVenta";
        private const string rutaBDD = @"C:\Users\Briseño\Documents\PuntoVenta";
        public static SQLiteConnection GetInstance()
        {
            // Devuelve una instancia de la base de datos
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", rutaBDD)
            );

            db.Open();

            return db;
        }

        // TODO: Crear base de datos si no existe y crear un super usuario

        public static int Login(string nombre, string psd)
        {
            int valid = -1;
            using (var ctx = GetInstance())
            {
                using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                {
                    Conexion.Open();
                    SQLiteCommand cmd = Conexion.CreateCommand();

                    cmd.CommandText = "SELECT isAdmin FROM Empleados WHERE nombreEmpleado='" + nombre + "' AND password='" + psd + "'";
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
        
        public static void InsertarEmpleado(string[] datos)
        {
            using (var ctx = GetInstance())
            {
                using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                {
                    Conexion.Open();
                    SQLiteCommand cmd = Conexion.CreateCommand();

                    cmd.CommandText = "INSERT INTO Empleado (" +
                        "Especialidad, " +
                        "ApellidoPaterno, " +
                        "ApellidoMaterno, " +
                        "NombreEmpleado, " +
                        "Genero, " +
                        "FechaNacimiento, " +
                        "Correo, " +
                        "Contraseña) VALUES(" +
                        datos[0] + ", " +
                        datos[1] + ", " +
                        datos[2] + ", " +
                        datos[3] + ", " +
                        datos[4] + ", " +
                        datos[5] + ", " +
                        datos[6] + ", " +
                        datos[7] + ");";
                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
            }
        }

        public static void InsertarCliente()
        {
            // TODO
        }

        public static void InsertarCita()
        {
            // TODO
        }

        public static void InsertarHorario()
        {
            // TODO
        }

        public static void InsertarEspecialidad()
        {
            // TODO
        }
    }
}
