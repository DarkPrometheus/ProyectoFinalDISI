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
    public partial class Especialidades : UserControl
    {
        public Especialidades()
        {
            InitializeComponent();
            txtNombreEspecialidad.Text = ClassPlaceholders.PlaceHoldersServicios[1];
            txtNombreEspecialidad.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtNombreEspecialidad.LostFocus += new EventHandler(ClassPlaceholders.AddText);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombreEspecialidad.Text != "" && txtNombreEspecialidad.Text != ClassPlaceholders.PlaceHoldersEspecialidades[0])
                SQLCommands.InsertarEspecialidad(txtNombreEspecialidad.Text);
            else
                MessageBox.Show("Ingresa algo en el nombre", "Nombre vacio");
            txtNombreEspecialidad.Text = ClassPlaceholders.PlaceHoldersEspecialidades[0];
        }

        // TODO: Registrar en la base de datos la especialidad
    }
}
