using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace ProyectoFinalDISI
{
    internal class SQLCommands
    {
        // La base de datos ahora se llama "ProyectoFinal"
        //private const string rutaBDD = @"C:\Users\Cristo\Documents\ProyectoFinalDISI\ProyectoFinal";
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

        // Leer datos SQLite
        //result.Add(new User
        //{
        //    Id = Convert.ToInt32(reader["id"].ToString()),
        //    Name = reader["Name"].ToString(),
        //    Lastname = reader["Lastname"].ToString(),
        //    Birthday = Convert.ToDateTime(reader["Birthday"]),
        //});

        public static int Login(string correo, string psd)
        {
            int valid = -1;
            bool boolCorreo = false, boolPsd = false;

            Queue correos = new Queue(), psds = new Queue();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Cuentas";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    correos.Enqueue(reader["Correo"].ToString());
                                    psds.Enqueue(reader["Psd"].ToString());
                                }
                            }
                        }
                    }
                }

                foreach (string item in correos)
                    if (item == correo)
                    {
                        boolCorreo = true;
                        break;
                    }

                foreach (string item in psds)
                    if (item == psd)
                    {
                        boolPsd = true;
                        break;
                    }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }

            return (boolCorreo && boolPsd) ? 1 : -1;
        }

        #region Inserciones
        public static void InsertarEmpleado(string[] datos)
        {
          try
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
                MessageBox.Show("Se ha ingresado " + datos[3] + " correctamente", "Sin errores");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }
        } 

        public static void InsertarCliente(string[] datos)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        Conexion.Open();
                        SQLiteCommand cmd = Conexion.CreateCommand();

                        cmd.CommandText = "INSERT INTO Cliente (" +
                            "NombreCliente, " +
                            "ApellidoPaterno, " +
                            "ApellidoMaterno, " +
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
                            "'" + datos[6] + "');";
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                }
                MessageBox.Show("Se ha creado la cuenta del cliente " + datos[0] + " correctamente", "Sin errores");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }
        }

        public static void InsertarCita(string[] datos)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        Conexion.Open();
                        SQLiteCommand cmd = Conexion.CreateCommand();

                        cmd.CommandText = "INSERT INTO Cita (" +
                            "id_cita, " +
                            "Especialiadad, " +
                            "Usuario, " +
                            "Medico, " +
                            "Fecha, " +
                            "Hora) VALUES(" +
                            "'" + datos[0] + "', " +
                            "'" + datos[1] + "', " +
                            "'" + datos[2] + "', " +
                            "'" + datos[3] + "', " +
                            "'" + datos[4] + "', " +
                            "'" + datos[5] + "');";
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                }
                MessageBox.Show("Se ha ingresado la cita " + datos[0] + " correctamente", "Sin errores");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }
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
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT NombreEspecialidad FROM Especialidad";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    Datos.Enqueue(reader["NombreEspecialidad"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }

            return Datos;
        }
        #endregion
    }
}
