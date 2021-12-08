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
    public partial class ActualizarCita : Form
    {
        public ActualizarCita(string id, string medico, string usuario, string date, string hora, string especialidad)
        {
            InitializeComponent();

            cbMedico.SelectedItem = cbMedico.Items[0];
            cbUsuario.SelectedItem = cbUsuario.Items[0];
            cbEspecialidad.SelectedItem = cbEspecialidad.Items[0];

            lblId.Text = id;
            txtDate.Text = date;
            txtHora.Text = hora;

            foreach (var item in SQLCommands.GetIDUsuario())
                cbUsuario.Items.Add(item);
            foreach (var item in SQLCommands.GetNombreEmpleado())
                cbMedico.Items.Add(item);
            foreach (string[] item in SQLCommands.GetEspecialidades())
                cbEspecialidad.Items.Add(item[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool medico = (cbMedico.Text != "Selecciona un medico"), usuario = (cbUsuario.Text != "Selecciona un usuario"), date = (txtDate.Text != ""), hora = (txtHora.Text != ""), especialidad = (cbEspecialidad.Text != "Selecciona una Especialidad");

            if (medico && usuario && date && hora && especialidad)
            {
                SQLCommands.UpdateCitas(lblId.Text, cbMedico.Text, cbUsuario.Text, txtDate.Text, txtHora.Text, cbEspecialidad.Text);
                MessageBox.Show("Se ha actualizado la cita de " + cbUsuario.Text, "Actualizacion completa");
                // Lo de las horas
            }
            else
                MessageBox.Show("Hay campos vacios", "Error");
        }
    }
}
