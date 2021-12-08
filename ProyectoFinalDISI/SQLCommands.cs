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

        public static string[] Login(string correo, string psd)
        {
            Queue<String> queueCorreos = new Queue<String>(), queuePsds = new Queue<String>(), queueTipoUsuario = new Queue<String>(), queueIdUsuario = new Queue<string>();
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
                                    queueIdUsuario.Enqueue(reader["idCuenta"].ToString());
                                }
                            }
                        }
                    }
                }
                String[] arrCorreos = queueCorreos.ToArray(), arrPsds = queuePsds.ToArray(), arrTipoUsuario = queueTipoUsuario.ToArray(), arrIdUsuario = queueIdUsuario.ToArray();

                string tempCorreo, tempPsd;
                string[] datos = new string[3]
                {
                    "Error",
                    "",
                    ""
                };
                for (int i = 0; i < arrCorreos.Length; i++)
                {
                    tempCorreo = arrCorreos[i].ToString();
                    tempPsd = arrPsds[i].ToString();
                    if (tempCorreo == correo && tempPsd == psd)
                    {
                        datos[0] = arrTipoUsuario[i];
                        datos[1] = arrIdUsuario[i];
                        datos[2] = arrCorreos[i];
                        i = arrCorreos.Length;
                    }
                }

                return datos;
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
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        Conexion.Open();
                        SQLiteCommand cmd = Conexion.CreateCommand();

                        cmd.CommandText = "INSERT INTO Cuentas (" +
                            "Correo, " +
                            "TipoUsuario, " +
                            "Psd) VALUES('" + datos[5] + "', 'Cliente', '" + datos[6] + "');";
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

        public static string GetEspecialidadEmpleado(string medico)
        {
            string especialidad = "";
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
                                    especialidad = reader["Especialidad"].ToString();
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

            return especialidad;
        }
        #endregion

        #region Citas
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
                            "Especialidad, " +
                            "Usuario, " +
                            "Medico, " +
                            "Fecha, " +
                            "Hora) VALUES(" +
                            "'" + datos[0] + "', " +
                            "'" + datos[1] + "', " +
                            "'" + datos[2] + "', " +
                            "'" + datos[3] + "', " +
                            "'" + datos[4] + "');";
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                }
                MessageBox.Show("Se ha ingresado la cita correctamente", "Sin errores");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }
        }

        public static Stack<string[]> GetCitas()
        {
            Stack<string[]> datos = new Stack<string[]>();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Cita";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string[] temp = new string[6];
                                    temp[0] = reader["id_cita"].ToString();
                                    temp[1] = reader["Especialidad"].ToString();
                                    temp[2] = reader["Usuario"].ToString();
                                    temp[3] = reader["Medico"].ToString();
                                    temp[4] = reader["Fecha"].ToString();
                                    temp[5] = reader["Hora"].ToString();
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

        public static int GetHoraCitaMedico(string medico, string hora, string fecha)
        {
            int horario = 0;
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT id_cita FROM Cita where Medico='" + medico + "' and Hora='" + hora + "' and Fecha='" + fecha + "'";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    horario = 1;
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

            return horario;
        }

        public static Stack<string[]> GetCitasUsuario(string usuario)
        {
            Stack<string[]> datos = new Stack<string[]>();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Cita where Usuario='" + usuario + "'";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string[] temp = new string[6];
                                    temp[0] = reader["id_cita"].ToString();
                                    temp[1] = reader["Especialidad"].ToString();
                                    temp[2] = reader["Usuario"].ToString();
                                    temp[3] = reader["Medico"].ToString();
                                    temp[4] = reader["Fecha"].ToString();
                                    temp[5] = reader["Hora"].ToString();
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

        public static void DeleteCita(string id)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "Delete FROM Cita WHERE id_cita='" + id + "'";
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

        public static void UpdateCitas(string id, string medico, string usuario, string date, string hora, string especialidad)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "Update Cita SET Especialiadad='" + especialidad + "', Usuario='" + usuario + "', Medico='" + medico + "', Fecha='" + date + "', Hora='" + hora + "'  WHERE id_cita='" + id + "'";
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
        #endregion

        #region Horarios
        public static void InsertarHorario(string medico, string horaEntrada, string horaSalida)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        Conexion.Open();
                        SQLiteCommand cmd = Conexion.CreateCommand();

                        cmd.CommandText = "INSERT INTO Horarios (" +
                            "Medico, " +
                            "HoraEntrada, " +
                            "HoraSalida) VALUES(" +
                            "'" + medico + "', " +
                            "'" + horaEntrada + "', " +
                            "'" + horaSalida + "');";
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                    }
                }
                MessageBox.Show("Se ha ingresado el nuevo horario correctamente", "Sin errores");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                throw;
            }
        }

        public static Stack<string[]> GetHorarios()
        {
            Stack<string[]> datos = new Stack<string[]>();
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Horarios";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string[] temp = new string[6];
                                    temp[0] = reader["idHorario"].ToString();
                                    temp[1] = reader["Medico"].ToString();
                                    temp[2] = reader["HoraEntrada"].ToString();
                                    temp[3] = reader["HoraSalida"].ToString();
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

        public static string[] GetHorariosMedicos(string medico)
        {
            string[] datos = new string[2];
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "SELECT * FROM Horarios WHERE Medico='" + medico + "'";
                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    datos[0] = reader["HoraEntrada"].ToString();
                                    datos[1] = reader["HoraSalida"].ToString();
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

        public static void DeleteHorario(string id)
        {
            try
            {
                using (var ctx = GetInstance())
                {
                    using (SQLiteConnection Conexion = new SQLiteConnection("Data source = " + rutaBDD))
                    {
                        string query = "Delete FROM Horarios WHERE idHorario='" + id + "'";
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
    }
}
