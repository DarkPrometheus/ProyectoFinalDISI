using System;
using System.Windows.Forms;

namespace ProyectoFinalDISI
{
    internal class ClassPlaceholders
    {
        // Clase para gestionar todos los placeholders
        // Se almacenan los placeholders en un arreglo por pantalla
        public static string[] PlaceHoldersRegistroUsuarios = new string[7] {
            "Ingresa el nombre",
            "Ingresa el apellido paterno",
            "Ingresa el apellido materno",
            "Ingresa el nombre",
            "Ingresa el correo",
            "Ingresa la contraseña",
            "Confirma la contraseña"
        },
        PlaceHoldersServicios = new string[3] {
            "Ingresa la clave",
            "Ingresa el nombre",
            "Ingresa la descripcion"
        },
        PlaceHoldersCrearCita = new string[2] {
            "Ingresa el id de la cita",
            "Ingresa la hora"
        },
        PlaceHoldersEspecialidades = new string[1] {
            "Ingresa el nombre"
        };

        public static void RemoveText(object sender, EventArgs e)
        {
            // Borra el texto de la caja de texto para escribir en ella
            TextBox textBox = sender as TextBox;
            switch (textBox.Name)
            {
                // Registro usuarios
                case "txtNumeroCliente":
                    if (textBox.Text == PlaceHoldersRegistroUsuarios[0])
                        textBox.Text = "";
                    break;
                case "txtApellidoPaterno":
                    if (textBox.Text == PlaceHoldersRegistroUsuarios[1])
                        textBox.Text = "";
                    break;
                case "txtApellidoMaterno":
                    if (textBox.Text == PlaceHoldersRegistroUsuarios[2])
                        textBox.Text = "";
                    break;
                case "txtNombre":
                    if (textBox.Text == PlaceHoldersRegistroUsuarios[3])
                        textBox.Text = "";
                    break;
                case "txtCorreo":
                    if (textBox.Text == PlaceHoldersRegistroUsuarios[4])
                        textBox.Text = "";
                    break;
                case "txtPassword":
                    if (textBox.Text == PlaceHoldersRegistroUsuarios[5])
                        textBox.Text = "";
                    break;
                case "txtConfirmPassword":
                    if (textBox.Text == PlaceHoldersRegistroUsuarios[6])
                        textBox.Text = "";
                    break;
                    // Servicios
                case "txtClaveServicio":
                    if (textBox.Text == PlaceHoldersServicios[0])
                        textBox.Text = "";
                    break;
                case "txtNombreServicio":
                    if (textBox.Text == PlaceHoldersServicios[1])
                        textBox.Text = "";
                    break;
                case "txtDescripcion":
                    if (textBox.Text == PlaceHoldersServicios[2])
                        textBox.Text = "";
                    break;
                case "txtIdCitas":
                    // Crear citas
                    if (textBox.Text == PlaceHoldersCrearCita[0])
                        textBox.Text = "";
                    break;
                case "txtHoraCrearCita":
                    if (textBox.Text == PlaceHoldersCrearCita[1])
                        textBox.Text = "";
                    break;
                    // Especialidades
                case "txtNombreEspecialidad":
                    if (textBox.Text == PlaceHoldersEspecialidades[0])
                        textBox.Text = "";
                    break;
                default:
                    break;
            }
        }

        public static void AddText(object sender, EventArgs e)
        {
            // Añade el placeholder a la caja de texto
            TextBox textBox = sender as TextBox;
            switch (textBox.Name)
            {
                // Registro usuarios
                case "txtNumeroCliente":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersRegistroUsuarios[0];
                    break;
                case "txtApellidoPaterno":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersRegistroUsuarios[1];
                    break;
                case "txtApellidoMaterno":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersRegistroUsuarios[2];
                    break;
                case "txtNombre":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersRegistroUsuarios[3];
                    break;
                case "txtCorreo":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersRegistroUsuarios[4];
                    break;
                case "txtPassword":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersRegistroUsuarios[5];
                    break;
                case "txtConfirmPassword":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersRegistroUsuarios[6];
                    break;
                // Servicios
                case "txtClaveServicio":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersServicios[0];
                    break;
                case "txtNombreServicio":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersServicios[1];
                    break;
                case "txtDescripcion":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersServicios[2];
                    break;
                // Crear citas
                case "txtIdCitas":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersCrearCita[0];
                    break;
                case "txtHoraCrearCita":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersCrearCita[1];
                    break;
                // Especialidades
                case "txtNombreEspecialidad":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        textBox.Text = PlaceHoldersEspecialidades[0];
                    break;
                default:
                    break;
            }
        }
    }
}
