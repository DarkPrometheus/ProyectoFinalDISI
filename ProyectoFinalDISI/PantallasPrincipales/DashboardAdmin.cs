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
        private void btnRegistrarEmpleado_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("RegistrarEmpleado");
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("RegistrarCliente");
        }

        private void btnServicos_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("Especialidades");
        }

        private void btnCrearCitas_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("CrearCitas");
        }

        private void btnConsultarCitas_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("ConsultarCita");
        }

        private void btnHorarioNuevo_Click(object sender, EventArgs e)
        {
            DesplegarPantalla("HorarioNuevo");
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
            int widthBoton = 195;
            switch (pantalla)
            {
                case "RegistrarEmpleado":
                    btnRegistrarEmpleado.Width = widthBoton;
                    ControlesDeUsuario.RegistrarEmpleado registro = new ControlesDeUsuario.RegistrarEmpleado();
                    registro.Dock = DockStyle.Fill;
                    AddControlToMainPanel(registro);
                    break;
                case "RegistrarCliente":
                    btnRegistrarCliente.Width = widthBoton;
                    ControlesDeUsuario.RegistrarCliente registroe = new ControlesDeUsuario.RegistrarCliente();
                    registroe.Dock = DockStyle.Fill;
                    AddControlToMainPanel(registroe);
                    break;
                case "Especialidades":
                    btnServicos.Width = widthBoton;
                    ControlesDeUsuario.Especialidades servicios = new ControlesDeUsuario.Especialidades();
                    servicios.Dock = DockStyle.Fill;
                    AddControlToMainPanel(servicios);
                    break;
                case "CrearCitas":
                    btnCrearCitas.Width = widthBoton;
                    ControlesDeUsuario.CrearCita crearCita = new ControlesDeUsuario.CrearCita();
                    crearCita.Dock = DockStyle.Fill;
                    AddControlToMainPanel(crearCita);
                    break;
                case "ConsultarCita":
                    btnConsultarCitas.Width = widthBoton;
                    ControlesDeUsuario.ConsultarCita consultarCita = new ControlesDeUsuario.ConsultarCita();
                    consultarCita.Dock = DockStyle.Fill;
                    AddControlToMainPanel(consultarCita);
                    break;
                case "HorarioNuevo":
                    btnHorarioNuevo.Width = widthBoton;
                    ControlesDeUsuario.HorarioNuevo horarioNuevo = new ControlesDeUsuario.HorarioNuevo();
                    horarioNuevo.Dock = DockStyle.Fill;
                    AddControlToMainPanel(horarioNuevo);
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
            btnRegistrarEmpleado.Width = width;
            btnRegistrarCliente.Width = width;
            btnServicos.Width = width;
            btnCrearCitas.Width = width;
            btnConsultarCitas.Width = width;
            btnHorarioNuevo.Width = width;
           
        }

      
    }
}
