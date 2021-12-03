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

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            // Dependiento de que tipo de usuario se redirecciona al correspondiente
            //int usuario = SQLCommands.Login(txtEmail.Text, txtPassword.Text);
            //if (usuario != -1)
            //{
            //    if (usuario == 1)
            //    {
            //        Hide();
            //        Pantallas_principales.Dashboard dashboard = new Pantallas_principales.Dashboard();
            //        dashboard.Show();

            //    }
            //    else
            //        if (usuario == 2)
            //    {
            //        Hide();
            //        PantallasPrincipales.DashboardCliente dashboard = new PantallasPrincipales.DashboardCliente();
            //        dashboard.Show();
            //    }

            //}
            //else
            //{
            //    txtEmail.Clear();
            //    txtPassword.Clear();
            //    txtEmail.Focus();
            //    MessageBox.Show("Usuario o contraseña incorrecto", "Error");
            //}
            Hide();
            Pantallas_principales.Dashboard dashboard = new Pantallas_principales.Dashboard();
            dashboard.Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
