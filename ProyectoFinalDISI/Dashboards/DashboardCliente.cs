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
    public partial class DashboardCliente : Form
    {
        public DashboardCliente()
        {
            InitializeComponent();
        }


        
        
        private void btnCrearCitas_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("CrearCitas");
        }
        private void btnConsultarCitas_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("ConsultarCita");
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("Salir");
        }

        void DesplegarPantalla(string pantalla)
        {   // Metodo para desplegar las distintas pantallas principales de la aplicacion
            plMain.Controls.Clear();
            ResetearWidth();
            int widthBoton = 195;
            switch (pantalla)
            {
               
                case "CrearCitas":
                    btnCrearCitas.Width = widthBoton;
                    ControlesDeUsuario.CrearCitaCliente crearCita = new ControlesDeUsuario.CrearCitaCliente();
                    crearCita.Dock = DockStyle.Fill;
                    AddControlToMainPanel(crearCita);
                    break;
                case "ConsultarCita":
                    btnConsultarCitas.Width = widthBoton;
                    ControlesDeUsuario.ConsultarCita__Clientes consultarCita = new ControlesDeUsuario.ConsultarCita__Clientes();
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
            btnCrearCitas.Width = width;
            btnConsultarCitas.Width = width;

        }

        
    }
}
