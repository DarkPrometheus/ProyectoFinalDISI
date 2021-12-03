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
        //private const string rutaBDD = @"C:\Users\Briseño\Documents\ProyectoFinal";
        private const string rutaBDD = @"C:\Users\Emmanuel\Desktop\Clases universidad\9no\Desarrollo e Implementación de Sistemas de Información\ProyectoFinalDISI\ProyectoFinal";
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

        public static string Login(string correo, string psd)
        {
            Queue<String> queueCorreos = new Queue<String>(), queuePsds = new Queue<String>(), queueTipoUsuario = new Queue<String>();
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
                                    queueCorreos.Enqueue(reader["Correo"].ToString());
                                    queuePsds.Enqueue(reader["Psd"].ToString());
                                    queueTipoUsuario.Enqueue(reader["TipoUsuario"].ToString());
                                }
                            }
                        }
                    }
                }
                String[] arrCorreos = queueCorreos.ToArray(), arrPsds = queuePsds.ToArray(), arrTipoUsuario = queueTipoUsuario.ToArray();

                string tempCorreo, tempPsd, tipoUsuario = "Error";
                for (int i = 0; i < arrCorreos.Length; i++)
                {
                    tempCorreo = arrCorreos[i].ToString();
                    tempPsd = arrPsds[i].ToString();
                    if (tempCorreo == correo && tempPsd == psd)
                    {
                        tipoUsuario = arrTipoUsuario[i];
                        i = arrCorreos.Length;
                    }
                }

                return tipoUsuario;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }
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
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        Conexion.Open();
                        SQLiteCommand cmd = Conexion.CreateCommand();

                        cmd.CommandText = "INSERT INTO Cuentas (" +
                            "Correo, " +
                            "TipoUsuario, " +
                            "Psd) VALUES('" + datos[6] + "', '" + datos[8] + "', '" + datos[7] + "');";
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
                MessageBox.Show(e.Message, "Error al cargar la especialidad");
                throw;
            }

            return Datos;
        }


        public static Queue GetIDUsuario()
        {
            Queue Datos = new Queue();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT idUsuario FROM Cliente";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    Datos.Enqueue(reader["idUsuario"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "No se encontro el usuario");
                throw;
            }

            return Datos;
        }

        public static Queue GetNombreEmpleado()
        {
            Queue Datos = new Queue();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT NombreEmpleado FROM Empleado";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    Datos.Enqueue(reader["NombreEmpleado"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "No se encontro el medico");
                throw;
            }

            return Datos;
        }




        #endregion
    }
}
