using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace ProyectoFinalDISI
{
    internal class SQLCommands
    {
        // La base de datos ahora se llama "ProyectoFinal"
        //public const string rutaBDD = @"C:\Users\Cristo\Documents\ProyectoFinalDISI\ProyectoFinal";
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

        public static Stack<string[]> GetEspecialidades()
        {
            Stack<string[]> datos = new Stack<string[]>();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Especialidad";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string[] temp = new string[2];
                                    temp[0] = reader["idEspecialidad"].ToString();
                                    temp[1] = reader["NombreEspecialidad"].ToString();
                                    datos.Push(temp);
                                }
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

            return datos;
        }

        public static void DeleteEspecialidades(string id)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "Delete FROM Especialidad WHERE idEspecialidad='" + id + "'";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al cargar la especialidad");
                throw;
            }
        }

        public static void UpdateEspecialidades(string id, string nombre)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "Update Especialidad set NombreEspecialidad='" + nombre + "' WHERE idEspecialidad='" + id + "'";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al cargar la especialidad");
                throw;
            }
        }

        public static Queue GetEspecialidadEmpleado(string medico)
        {
            Queue Datos = new Queue();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Empleado where NombreEmpleado= '" + medico + "'";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    Datos.Enqueue(reader["Especialidad"].ToString());
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
        #endregion

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

        public static Queue GetNombreEmpleadoLogin(string correo)
        {
            Queue Datos = new Queue();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT Correo FROM Empleado";
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

        public static void  GetTodasCitasAdmin(DataGridView grid)
        {
            try
            {
 
                  using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD)) 
                    { 
                Conexion.Open(); 
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("Select * From Cita",Conexion);  
                DataSet dset = new DataSet();
                adapter.Fill(dset, "info");
                grid.DataSource = dset.Tables[0];
                Conexion.Close();
                    }
             
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al cargar ls citas");
                throw;
            }
        }


        public static void GetUsuarioCitasAdmin(DataGridView grid,string Usuario)
        {
            try
            {

                using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                {
                    Conexion.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("Select * From Cita Where Usuario='" + Usuario + "'", Conexion);
                    DataSet dset = new DataSet();
                    adapter.Fill(dset, "info");
                    grid.DataSource = dset.Tables[0];
                    Conexion.Close();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al cargar ls citas");
                throw;
            }
        }


        public static void GetIDCitasAdmin(DataGridView grid, string id)
        {
            try
            {

                using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                {
                    Conexion.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter("Select * From Cita Where id_cita='" + id + "'", Conexion);
                    DataSet dset = new DataSet();
                    adapter.Fill(dset, "info");
                    grid.DataSource = dset.Tables[0];
                    Conexion.Close();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al cargar ls citas");
                throw;
            }
        }
    }
}
