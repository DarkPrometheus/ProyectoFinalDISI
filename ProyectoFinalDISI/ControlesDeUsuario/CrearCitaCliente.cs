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
    public partial class CrearCitaCliente : UserControl
    {
        string gEspecialidad = "", gIdCliente, gCorreo;
        int creado = 0;
        public CrearCitaCliente(string idCliente, string correo)
        {
            InitializeComponent();

            cbMedico.SelectedItem = cbMedico.Items[0];

            gIdCliente = idCliente;

            foreach (var item in SQLCommands.GetNombreEmpleado())
                cbMedico.Items.Add(item);
            creado = 1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool medico = (cbMedico.Text != "Selecciona un medico"), hora = (cbHorarios.Text != "");
            if (medico && hora)
            {
                SQLCommands.InsertarCita(new string[] { gEspecialidad, gIdCliente, cbMedico.Text, dateTimePicker.Text, cbHorarios.Text });
                cbMedico.SelectedIndex = 0;
                cbHorarios.Items.Clear();
                cbHorarios.Items.Add("Selecciona un medico para ver horarios");
            }
        }

        private void cbMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (creado == 1 && cbMedico.Text != "Selecciona un medico")
            {
                cbHorarios.Items.Clear();

                string[] horas = SQLCommands.GetHorariosMedicos(cbMedico.Text);

                string entrada = horas[0][0].ToString() + horas[0][1].ToString();
                string salida = horas[1][0].ToString() + horas[1][1].ToString();

                for (int i = int.Parse(entrada); i <= int.Parse(salida); i++)
                {
                    if (i <= 9)
                    {
                        string hora = "0" + i + ":00";
                        int resultado = SQLCommands.GetHoraCitaMedico(cbMedico.Text, hora, dateTimePicker.Text);
                        if (resultado != 1)
                            cbHorarios.Items.Add("0" + i + ":00");
                    }
                    else
                    {
                        string hora = i + ":00";
                        int resultado = SQLCommands.GetHoraCitaMedico(cbMedico.Text, hora, dateTimePicker.Text);
                        if (resultado != 1)
                            cbHorarios.Items.Add(i + ":00");
                    }
                }

                gEspecialidad = SQLCommands.GetEspecialidadEmpleado(cbMedico.Text);
            }
            if (cbMedico.Text == "Selecciona un medico")
            {
                cbHorarios.Items.Clear();
                cbHorarios.Items.Add("Selecciona un medico para ver horarios");
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (creado == 1 && cbMedico.Text != "Selecciona un medico")
            {
                cbHorarios.Items.Clear();

                string[] horas = SQLCommands.GetHorariosMedicos(cbMedico.Text);

                string entrada = horas[0][0].ToString() + horas[0][1].ToString();
                string salida = horas[1][0].ToString() + horas[1][1].ToString();

                for (int i = int.Parse(entrada); i <= int.Parse(salida); i++)
                {
                    if (i <= 9)
                    {
                        if (SQLCommands.GetHoraCitaMedico(cbMedico.Text, "0" + i + ":00", dateTimePicker.Text) != 1)
                            cbHorarios.Items.Add("0" + i + ":00");
                    }
                    else
                    {
                        if (SQLCommands.GetHoraCitaMedico(cbMedico.Text, "0" + i + ":00", dateTimePicker.Text) != 1)
                            cbHorarios.Items.Add(i + ":00");
                    }
                }

                gEspecialidad = SQLCommands.GetEspecialidadEmpleado(cbMedico.Text);
            }
            if (cbMedico.Text == "Selecciona un medico")
            {
                cbHorarios.Items.Clear();
                cbHorarios.Items.Add("Selecciona un medico para ver horarios");
            }
        }
    }
}
