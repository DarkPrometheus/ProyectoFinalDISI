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
    public partial class CrearCita : UserControl
    {
        public CrearCita()
        {
            InitializeComponent();
            cbMedico.SelectedItem = cbMedico.Items[0];
            cbUsuario.SelectedItem = cbUsuario.Items[0];

            txtHoraCrearCita.Text = ClassPlaceholders.PlaceHoldersCrearCita[1];
            txtHoraCrearCita.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtHoraCrearCita.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            foreach (var item in SQLCommands.GetIDUsuario())
                cbUsuario.Items.Add(item);

            foreach (var item in SQLCommands.GetNombreEmpleado())
                cbMedico.Items.Add(item);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool medico = (cbMedico.Text != "Selecciona un medico"), usuario = (cbUsuario.Text != "Selecciona un usuario"), hora = (txtHoraCrearCita.Text != ""), especialidad = (cbEspecialidad.Text != "Selecciona una especialidad");
            if (medico && usuario && hora && especialidad)
                SQLCommands.InsertarCita(new string[] { cbEspecialidad.Text, cbUsuario.Text, cbMedico.Text, dateTimePicker.Text, txtHoraCrearCita.Text });
        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CrearCita_Load(object sender, EventArgs e)
        {

        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void cbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in SQLCommands.GetEspecialidadEmpleado(cbMedico.Text))
                cbEspecialidad.Items.Add(item);
        }

        // TODO: Registrar en la base de datos la cita nueva
    }
}
