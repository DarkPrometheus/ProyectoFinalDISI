using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDISI.PantallasPrincipales
{
    public partial class DashboardEmpleados : Form
    {
        public DashboardEmpleados()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            LogIn.instance.Show();
        }


        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("RegistrarEmpleado");
        }

        private void btnCrearCitas_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("CrearCita");
        }

        private void btnConsultarCitas_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("ConsultarCita");
        }

        void DesplegarPantalla(string pantalla)
        {   // Metodo para desplegar las distintas pantallas principales de la aplicacion
            plMain.Controls.Clear();
            ResetearWidth();
            int widthBoton = 195;
            switch (pantalla)
            {
                case "RegistrarEmpleado":
                    btnRegistrarCliente.Width = widthBoton;
                    ControlesDeUsuario.RegistrarCliente registro = new ControlesDeUsuario.RegistrarCliente();
                    registro.Dock = DockStyle.Fill;
                    AddControlToMainPanel(registro);
                    break;
                case "CrearCita":
                    btnCrearCitas.Width = widthBoton;
                    ControlesDeUsuario.CrearCitaEmpleado cita = new ControlesDeUsuario.CrearCitaEmpleado();
                    cita.Dock = DockStyle.Fill;
                    AddControlToMainPanel(cita);
                    break;
                case "ConsultarCita":
                    btnConsultarCitas.Width = widthBoton;
                    ControlesDeUsuario.ConsultarCita consultarCita = new ControlesDeUsuario.ConsultarCita();
                    consultarCita.Dock = DockStyle.Fill;
                    AddControlToMainPanel(consultarCita);
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
            int width = 185;
            btnRegistrarCliente.Width = width;
            btnConsultarCitas.Width = width;
            btnCrearCitas.Width = width;
        }
    }
}
