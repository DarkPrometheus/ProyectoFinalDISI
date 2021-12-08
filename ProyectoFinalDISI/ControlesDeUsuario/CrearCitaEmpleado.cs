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
    public partial class CrearCitaEmpleado : UserControl
    {
        string gEspecialidad, gMedico, gIdEmpleado;
        int creado = 0;
        public CrearCitaEmpleado(string medico, string idEmpleado)
        {
            InitializeComponent();

            foreach (var item in SQLCommands.GetIDUsuario())
                cbUsuario.Items.Add(item);

            gEspecialidad = SQLCommands.GetEspecialidadEmpleado(medico);
            gMedico = medico;

            gIdEmpleado = idEmpleado;

            creado = 1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool hora = (cbHorarios.Text != "");
            if (hora)
            {
                SQLCommands.InsertarCita(new string[] { gEspecialidad, gIdEmpleado, gMedico, dateTimePicker.Text, cbHorarios.Text });
                cbHorarios.Items.Clear();
                cbHorarios.Items.Add("Selecciona un medico para ver horarios");
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (creado == 1)
            {
                cbHorarios.Items.Clear();

                string[] horas = SQLCommands.GetHorariosMedicos(gMedico);

                string entrada = horas[0][0].ToString() + horas[0][1].ToString();
                string salida = horas[1][0].ToString() + horas[1][1].ToString();

                for (int i = int.Parse(entrada); i <= int.Parse(salida); i++)
                {
                    if (i <= 9)
                    {
                        if (SQLCommands.GetHoraCitaMedico(gMedico, "0" + i + ":00", dateTimePicker.Text) != 1)
                            cbHorarios.Items.Add("0" + i + ":00");
                    }
                    else
                    {
                        if (SQLCommands.GetHoraCitaMedico(gMedico, "0" + i + ":00", dateTimePicker.Text) != 1)
                            cbHorarios.Items.Add(i + ":00");
                    }
                }
            }
        }
    }
}
