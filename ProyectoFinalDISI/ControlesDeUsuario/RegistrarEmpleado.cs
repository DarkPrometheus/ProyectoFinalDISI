using System;
using System.Collections;
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

            foreach (var item in SQLCommands.GetEspecialidades())
                cbEspecialidades.Items.Add(item);
        }

        private void RegistrarEmpleado_Load(object sender, EventArgs e)
        {
            Queue Especialidades = SQLCommands.GetEspecialidades();



        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

    SQLCommands.InsertarEmpleado(new string[]{cbEspecialidades.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtNombre.Text, cbGenero.Text, dateTimePicker.Text, txtCorreo.Text, txtPassword.Text });

        }

        private void cbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // TODO: Registrar en la base de datos el empleado nuevo
    }
}
