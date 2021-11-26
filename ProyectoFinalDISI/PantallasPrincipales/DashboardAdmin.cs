using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDISI.Pantallas_principales
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        #region Botones
        // Dependiendo del texto en el boton se agrega una pantala u otra
        private void btnRegistrarUsuarios_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("RegistrarEmpleado");
        }

        private void btnServicos_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("Servicios");
        }

        private void btnCrearCitas_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("CrearCitas");
        }

        private void btnConsultarCitas_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("ConsultarCitas");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("Salir");
        }
        #endregion

        void DesplegarPantalla(string pantalla)
        {   // Metodo para desplegar las distintas pantallas principales de la aplicacion
            plMain.Controls.Clear();
            ResetearWidth();
            int widthBoton = 190;
            switch (pantalla)
            {
                case "RegistrarUsuario":
                    btnRegistrarUsuarios.Width = widthBoton;
                    ControlesDeUsuario.RegistrarUsuario registro = new ControlesDeUsuario.RegistrarUsuario();
                    registro.Dock = DockStyle.Fill;
                    AddControlToMainPanel(registro);
                    break;
                case "Registrarcliente":
                    // TODO
                    break;
                case "Servicios":
                    btnServicos.Width = widthBoton;
                    ControlesDeUsuario.Servicios servicios = new ControlesDeUsuario.Servicios();
                    servicios.Dock = DockStyle.Fill;
                    AddControlToMainPanel(servicios);
                    break;
                case "CrearCitas":
                    btnCrearCitas.Width = widthBoton;
                    ControlesDeUsuario.CrearCita crearCita = new ControlesDeUsuario.CrearCita();
                    crearCita.Dock = DockStyle.Fill;
                    AddControlToMainPanel(crearCita);
                    break;
                case "ConsultarCitas":
                    btnConsultarCitas.Width = widthBoton;
                    break;
                case "Salir":
                    // Se llama a la instancia ya creada de la pantalla de log in para regresar a ella
                    Close();
                    LogIn.instance.Show();
                    break;
                default:
                    break;
            }
        }
        
        // Agrega un control de usuario al panel principal - recibe un control de usuario
        void AddControlToMainPanel(Control control)
        {
            plMain.Controls.Clear();
            plMain.Controls.Add(control);
        }

        // Reestablece el tamaño de los botones que agregan los controles de usuario
        void ResetearWidth()
        {
            int width = 180;
            btnRegistrarUsuarios.Width = width;
            btnServicos.Width = width;
            btnCrearCitas.Width = width;
            btnConsultarCitas.Width = width;
        }
    }
}
