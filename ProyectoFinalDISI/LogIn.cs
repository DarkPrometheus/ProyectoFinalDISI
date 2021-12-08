using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDISI
{
    public partial class LogIn : Form
    {
        // Se hace publica la instancia de esta forma para poder regresar a ella desde otra forma
        public static LogIn instance;
        public LogIn()
        {
            InitializeComponent();
            instance = this;
        }

        public void btnLogIn_Click(object sender, EventArgs e)
        {
            // Dependiento de que tipo de usuario se redirecciona al correspondiente
            string[] datos = SQLCommands.Login(txtEmail.Text, txtPassword.Text);
            if (datos[0] != "Error")
            {
                Hide();
                if (datos[0] == "Admin")
                {
                    Pantallas_principales.Dashboard dashboardAdmin = new Pantallas_principales.Dashboard(datos[1]);
                    dashboardAdmin.Show();
                }
                else if (datos[0] == "Empleado")
                {
                    PantallasPrincipales.DashboardEmpleados dashboardEmpleados = new PantallasPrincipales.DashboardEmpleados(datos[1], datos[2]);
                    dashboardEmpleados.Show();
                }
                else if (datos[0] == "Cliente")
                {
                    PantallasPrincipales.DashboardCliente dashboardCliente = new PantallasPrincipales.DashboardCliente(datos[1], datos[2]);
                    dashboardCliente.Show();
                }
                txtEmail.Clear();
                txtPassword.Clear();
                txtEmail.Focus();
            }
            else
                MessageBox.Show("Usuario o contraseña incorrecto", "Error");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
