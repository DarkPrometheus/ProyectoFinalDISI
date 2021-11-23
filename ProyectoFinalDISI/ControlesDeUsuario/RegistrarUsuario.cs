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
    public partial class RegistrarUsuario : UserControl
    {
        string[] PlaceHoldersRegistroUsuarios = new string[7] {
            "Ingresa el nombre",
            "Ingresa el apellido paterno",
            "Ingresa el apellido materno",
            "Ingresa el nombre",
            "Ingresa el correo",
            "Ingresa la contraseña",
            "Confirma la contraseña"
        };

        public RegistrarUsuario()
        {
            InitializeComponent();

            cbTipoUsuario.SelectedItem = cbTipoUsuario.Items[0];

            txtNumeroCliente.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[0];
            txtNumeroCliente.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtNumeroCliente.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtApellidoPaterno.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[1];
            txtApellidoPaterno.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtApellidoPaterno.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtApellidoMaterno.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[2];
            txtApellidoMaterno.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtApellidoMaterno.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtNombre.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[3];
            txtNombre.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtNombre.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtCorreo.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[4];
            txtCorreo.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtCorreo.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtPassword.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[5];
            txtPassword.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtPassword.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtConfirmPassword.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[6];
            txtConfirmPassword.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtConfirmPassword.LostFocus += new EventHandler(ClassPlaceholders.AddText);
        }
    }
}
