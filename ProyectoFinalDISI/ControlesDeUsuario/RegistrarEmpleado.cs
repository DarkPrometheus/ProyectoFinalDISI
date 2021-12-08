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

            cbEspecialidades.SelectedItem = cbEspecialidades.Items[0];
            cbGenero.SelectedItem = cbGenero.Items[0];

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

            foreach (string[] item in SQLCommands.GetEspecialidades())
                cbEspecialidades.Items.Add(item[1]);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool especialidad = cbEspecialidades.Text != "Selecciona una especialidad", 
                apellidoPaterno = txtApellidoPaterno.Text != "" && txtApellidoPaterno.Text != ClassPlaceholders.PlaceHoldersRegistroUsuarios[1],
                apellidoMaterno = txtApellidoMaterno.Text != "" && txtApellidoMaterno.Text != ClassPlaceholders.PlaceHoldersRegistroUsuarios[2],
                nombre = txtNombre.Text != "" && txtNombre.Text != ClassPlaceholders.PlaceHoldersRegistroUsuarios[3],
                genero = cbGenero.Text != "Seleciona un genero",
                correo = txtCorreo.Text != "" && txtCorreo.Text != ClassPlaceholders.PlaceHoldersRegistroUsuarios[4],
                password = txtPassword.Text != "" && txtPassword.Text != ClassPlaceholders.PlaceHoldersRegistroUsuarios[5],
                entrada = cbHoraEntrada.Text != "Selecciona una hora de entrada",
                salida = cbHoraSalida.Text != "Selecciona una hora de salida";

            if (especialidad && apellidoPaterno && apellidoMaterno && nombre && genero && correo && password && entrada && salida)
            {
                string isAdmin = (checkBox1.Checked == true) ? "Admin" : "Empleado";
                SQLCommands.InsertarEmpleado(
                    new string[]{
                        cbEspecialidades.Text,
                        txtApellidoPaterno.Text,
                        txtApellidoMaterno.Text,
                        txtNombre.Text,
                        cbGenero.Text,
                        dateTimePicker.Text,
                        txtCorreo.Text,
                        txtPassword.Text,
                        isAdmin
                        });
                SQLCommands.InsertarHorario(txtNombre.Text, cbHoraEntrada.Text, cbHoraSalida.Text);

                cbEspecialidades.SelectedItem = cbEspecialidades.Items[0];
                txtApellidoPaterno.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[1];
                txtApellidoMaterno.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[2];
                txtNombre.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[3];
                cbGenero.SelectedItem = cbGenero.Items[0];
                dateTimePicker.Value = DateTime.Now;
                txtCorreo.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[4];
                txtPassword.Text = ClassPlaceholders.PlaceHoldersRegistroUsuarios[5];
            }
            else
                MessageBox.Show("Fantan datos por ingresar", "Falta datos");
        }

        private void cbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
