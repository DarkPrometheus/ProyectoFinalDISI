using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDISI.ControlesDeUsuario
{
    public partial class HorarioNuevo : UserControl
    {
        public HorarioNuevo()
        {
            InitializeComponent();

            cbMedico.SelectedItem = cbMedico.Items[0];
            cbHoraEntrada.SelectedItem = cbHoraEntrada.Items[0];
            cbHoraSalida.SelectedItem = cbHoraSalida.Items[0];
            foreach (var item in SQLCommands.GetNombreEmpleado())
                cbMedico.Items.Add(item);

            foreach (string[] item in SQLCommands.GetHorarios())
                CrearFilaHorario(item);
        }

        Dictionary<string, string[]> dictionaryDatosHorario = new Dictionary<string, string[]>();
        Dictionary<string, Panel> dictionaryPanelesHorarios = new Dictionary<string, Panel>();
        void CrearFilaHorario(string[] datos)
        {
            dictionaryDatosHorario.Add(datos[0], datos);
            TableLayoutPanel panel = new TableLayoutPanel()
            {
                BackColor = Color.FromArgb(25, 25, 25),
                Height = 30,
                Width = plContenedor.Width,
                Dock = DockStyle.Top
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            plContenedor.Controls.Add(panel);

            Label lblid = new Label()
            {
                Name = "Id",
                BackColor = Color.FromArgb(27, 27, 27),
                Text = datos[0],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            lblid.Click += btnSeleccionar_Click;

            Label lblMedico = new Label()
            {
                Name = "Medico",
                Text = datos[1],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            Label lblEntrada = new Label()
            {
                Name = "Entrada",
                Text = datos[2],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            Label lblSalida = new Label()
            {
                Name = "Salida",
                Text = datos[3],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblid, 0, 0);
            panel.Controls.Add(lblMedico, 1, 0);
            panel.Controls.Add(lblEntrada, 2, 0);
            panel.Controls.Add(lblSalida, 3, 0);

            dictionaryPanelesHorarios.Add(datos[0], panel);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbMedico.Text != "Selecciona un medico" && cbHoraEntrada.Text != "Selecciona una hora de entrada" && cbHoraSalida.Text != "Selecciona una hora de salida")
            {
                SQLCommands.InsertarHorario(cbMedico.Text, cbHoraEntrada.Text, cbHoraSalida.Text);
                dictionaryDatosHorario.Clear();
                dictionaryPanelesHorarios.Clear();
                plContenedor.Controls.Clear();
                foreach (string[] item in SQLCommands.GetHorarios())
                    CrearFilaHorario(item);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != "")
            {
                string[] datos;
                dictionaryDatosHorario.TryGetValue(idSeleccionado, out datos);
                using (Confirmacion.ConfirmacionEliminar confirmacion = new Confirmacion.ConfirmacionEliminar("Horario", idSeleccionado, datos[1]))
                {
                    if (confirmacion.ShowDialog() == DialogResult.OK)
                    {
                        dictionaryDatosHorario.Remove(idSeleccionado);
                        Panel temp;
                        dictionaryPanelesHorarios.TryGetValue(idSeleccionado, out temp);
                        dictionaryPanelesHorarios.Remove(idSeleccionado);
                        plContenedor.Controls.Remove(temp);
                        cbMedico.SelectedItem = cbMedico.Items[0];
                        cbHoraEntrada.SelectedItem = cbHoraEntrada.Items[0];
                        cbHoraSalida.SelectedItem = cbHoraSalida.Items[0];
                    }
                }
                idSeleccionado = "";
            }
            else
                MessageBox.Show("No se ha seleccionado ningun registro", "Error");
        }

        Panel last = new Panel();
        string idSeleccionado;
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            last.BackColor = Color.FromArgb(25, 25, 25);
            foreach (Control p in last.Controls)
                if (p.Name == "Id")
                    p.BackColor = Color.FromArgb(27, 27, 27);

            Label lbl = sender as Label;
            dictionaryPanelesHorarios.TryGetValue(lbl.Text, out last);
            last.BackColor = Color.FromArgb(35, 35, 35);
            foreach (Control p in last.Controls)
                if (p.Name == "Id")
                    p.BackColor = Color.FromArgb(37, 37, 37);

            idSeleccionado = lbl.Text;
        }
    }
}
