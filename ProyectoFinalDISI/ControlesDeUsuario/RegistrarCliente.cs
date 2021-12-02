using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDISI.ControlesDeUsuario
{
    public partial class RegistrarCliente : UserControl
    {
        public RegistrarCliente()
        {
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SQLCommands.InsertarCliente(new string[] { txtApellidoPaterno.Text,txtApellidoMaterno.Text, txtNombre.Text, cbGenero.Text, dateTimePicker.Text, txtCorreo.Text, txtPassword.Text });
        }

        private void plContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
