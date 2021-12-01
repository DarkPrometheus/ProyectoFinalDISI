using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using System.Windows.Forms;

namespace ProyectoFinalDISI
{
    internal class SQLCommands
    {
        // La base de datos ahora se llama "ProyectoFinal"
        //private const string rutaBDD = @"C:\Users\Cristo\Documents\ProyectoFinalDISI\PuntoVenta";
        //private const string rutaBDD = @"C:\Users\Briseño\Documents\PuntoVenta";
        private const string rutaBDD = @"C:\Users\Emmanuel\Documents\ProyectoFinal";
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

                    cmd.CommandText = "SELECT isAdmin FROM Empleado WHERE nombreEmpleado='" + nombre + "' AND password='" + psd + "'";
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

        #region Inserciones
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
                        "'" + datos[0] + "', " +
                        "'" + datos[1] + "', " +
                        "'" + datos[2] + "', " +
                        "'" + datos[3] + "', " +
                        "'" + datos[4] + "', " +
                        "'" + datos[5] + "', " +
                        "'" + datos[6] + "', " +
                        "'" + datos[7] + "');";
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
        #endregion

        #region Especialidades
        public static void InsertarEspecialidad(string espcialidad)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        Conexion.Open();
                        SQLiteCommand cmd = Conexion.CreateCommand();

                        cmd.CommandText = "INSERT INTO Especialidad(NombreEspecialidad) VALUES('" + espcialidad + "');";
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                }
                MessageBox.Show("Se ha ingresado " + espcialidad + " correctamente", "Sin errores");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }
        }

        public static Queue GetEspecialidades()
        {
            Queue Datos = new Queue();
            using (var ctx = GetInstance())
            {
                using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                {
                    Conexion.Open();
                    SQLiteCommand cmd = Conexion.CreateCommand();

                    cmd.CommandText = "SELECT NombreEspecialidad FROM Especialidad";
                    SQLiteDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                        Datos.Enqueue(Convert.ToString(dr));

                    dr.Close();
                    cmd.Dispose();
                }
            }

            return Datos;
        }
        #endregion
    }
}
