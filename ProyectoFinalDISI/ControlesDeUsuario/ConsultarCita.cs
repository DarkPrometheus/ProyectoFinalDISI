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
    public partial class ConsultarCita : UserControl
    {
        public ConsultarCita()
        {
            // TODO: Colocar placesholders
            InitializeComponent();
            foreach (var item in SQLCommands.GetIDUsuario())
                cbUsuario.Items.Add(item);

            foreach (var item in SQLCommands.GetCitas())
                CrearFilaCita(item);
        }

        Dictionary<string, string[]> dictionaryNombresCita = new Dictionary<string, string[]>();
        Dictionary<string, Panel> dictionaryPanelesCita = new Dictionary<string, Panel>();
        void CrearFilaCita(string[] datos)
        {
            dictionaryNombresCita.Add(datos[0], datos);
            TableLayoutPanel panel = new TableLayoutPanel()
            {
                BackColor = Color.FromArgb(25, 25, 25),
                Height = 30,
                Width = plContenedor.Width,
                Dock = DockStyle.Top
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.3f));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.01f));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.01f));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.01f));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.01f));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.66f));
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
            Label lblEspecialidad = new Label()
            {
                Name = "Especialidad",
                Text = datos[1],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            Label lblUsuario = new Label()
            {
                Name = "Usuario",
                Text = datos[2],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            Label lblMedico = new Label()
            {
                Name = "Medico",
                Text = datos[3],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            Label lblFecha = new Label()
            {
                Name = "Fecha",
                Text = datos[4],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            Label lblHora = new Label()
            {
                Name = "Hora",
                Text = datos[5],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblid, 0, 0);
            panel.Controls.Add(lblEspecialidad, 1, 0);
            panel.Controls.Add(lblUsuario, 2, 0);
            panel.Controls.Add(lblMedico, 3, 0);
            panel.Controls.Add(lblFecha, 4, 0);
            panel.Controls.Add(lblHora, 5, 0);

            dictionaryPanelesCita.Add(datos[0], panel);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != "")
            {
                string[] datos;
                dictionaryNombresCita.TryGetValue(idSeleccionado, out datos);
                using (ActualizarCita actualizarCita = new ActualizarCita(datos[0], datos[3], datos[2], datos[4], datos[5], datos[1]))
                {
                    if (actualizarCita.ShowDialog() == DialogResult.OK)
                    {
                        plContenedor.Controls.Clear();

                        dictionaryNombresCita.Clear();
                        dictionaryPanelesCita.Clear();
                        foreach (var item in SQLCommands.GetCitas())
                            CrearFilaCita(item);
                        idSeleccionado = "";
                    }
                }
            }
            else
                MessageBox.Show("Selecciona una cita para modificar", "Error");
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
            dictionaryPanelesCita.TryGetValue(lbl.Text, out last);
            last.BackColor = Color.FromArgb(35, 35, 35);
            foreach (Control p in last.Controls)
                if (p.Name == "Id")
                    p.BackColor = Color.FromArgb(37, 37, 37);

            idSeleccionado = lbl.Text;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado != "")
            {
                string[] datos;
                dictionaryNombresCita.TryGetValue(idSeleccionado, out datos);
                using (Confirmacion.ConfirmacionEliminar confirmacion = new Confirmacion.ConfirmacionEliminar("Cita", idSeleccionado, datos[2]))
                {
                    if (confirmacion.ShowDialog() == DialogResult.OK)
                    {
                        dictionaryNombresCita.Remove(idSeleccionado);
                        Panel temp;
                        dictionaryPanelesCita.TryGetValue(idSeleccionado, out temp);
                        dictionaryPanelesCita.Remove(idSeleccionado);
                        plContenedor.Controls.Remove(temp);
                    }
                }
                idSeleccionado = "";
            }
            else
                MessageBox.Show("Selecciona una cita para modificar", "Error");
        }
    }
}
