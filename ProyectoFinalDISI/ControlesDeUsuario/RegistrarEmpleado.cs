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
    public partial class RegistrarEmpleado : UserControl
    {
        public RegistrarEmpleado()
        {
            InitializeComponent();

            cbTipoUsuario.SelectedItem = cbTipoUsuario.Items[0];

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
        }

        // TODO: Registrar en la base de datos el empleado nuevo
    }
}
