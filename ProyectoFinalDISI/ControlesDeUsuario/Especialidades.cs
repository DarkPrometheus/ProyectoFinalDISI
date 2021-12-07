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
    public partial class Especialidades : UserControl
    {
        public Especialidades()
        {
            InitializeComponent();
            txtNombreEspecialidad.Text = ClassPlaceholders.PlaceHoldersServicios[1];
            txtNombreEspecialidad.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtNombreEspecialidad.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            foreach (string[] item in SQLCommands.GetEspecialidades())
                CrearFilaEspecialidad(item);
        }

        Dictionary<string, string> dictionaryNombresEspecialidades = new Dictionary<string, string>();
        Dictionary<string, Panel> dictionaryPanelesEspecialidades = new Dictionary<string, Panel>();
        void CrearFilaEspecialidad(string[] datos)
        {
            dictionaryNombresEspecialidades.Add(datos[0], datos[1]);
            TableLayoutPanel panel = new TableLayoutPanel()
            {
                BackColor = Color.FromArgb(25, 25, 25),
                Height = 30,
                Width = plContenedor.Width,
                Dock = DockStyle.Top
            };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85));
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
            lblid.Click += btnSeleccinarId_Click;
            panel.Controls.Add(lblid, 0, 0);

            Label lblEspecialidad = new Label()
            {
                Name = "Nombre",
                Text = datos[1],
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };
            panel.Controls.Add(lblEspecialidad, 1, 0);
            dictionaryPanelesEspecialidades.Add(datos[0], panel);
        }
        #region Eventos
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombreEspecialidad.Text != "" && txtNombreEspecialidad.Text != ClassPlaceholders.PlaceHoldersEspecialidades[0])
            {
                SQLCommands.InsertarEspecialidad(txtNombreEspecialidad.Text);
                plContenedor.Controls.Clear();
                dictionaryNombresEspecialidades.Clear();
                dictionaryPanelesEspecialidades.Clear();
                foreach (string[] item in SQLCommands.GetEspecialidades())
                    CrearFilaEspecialidad(item);
            }
            else
                MessageBox.Show("Ingresa algo en el nombre", "Nombre vacio");
            txtNombreEspecialidad.Text = ClassPlaceholders.PlaceHoldersEspecialidades[0];
        }

        private void btnSeleccinarId_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            string especialidad;
            dictionaryNombresEspecialidades.TryGetValue(lbl.Text, out especialidad);
            txtEditarEspecialidad.Text = especialidad;
            lblId.Text = lbl.Text;
        }
        #endregion

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lblId.Text != "Esperando")
            {
                string nombre;
                dictionaryNombresEspecialidades.TryGetValue(lblId.Text, out nombre);
                using (Confirmacion.ConfirmacionEliminar confirmacion = new Confirmacion.ConfirmacionEliminar("Especialidad", lblId.Text, nombre))
                {
                    if (confirmacion.ShowDialog() == DialogResult.OK)
                    {
                        dictionaryNombresEspecialidades.Remove(lblId.Text);
                        Panel temp;
                        dictionaryPanelesEspecialidades.TryGetValue(lblId.Text, out temp);
                        dictionaryPanelesEspecialidades.Remove(lblId.Text);
                        plContenedor.Controls.Remove(temp);
                        txtEditarEspecialidad.Clear();
                        lblId.Text = "Esperando";
                    }
                }
            }
            else
                MessageBox.Show("No se ha seleccionado ningun registro", "Error");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblId.Text != "Esperando")
            {
                SQLCommands.UpdateEspecialidades(lblId.Text, txtEditarEspecialidad.Text);
                Panel temp;
                dictionaryPanelesEspecialidades.TryGetValue(lblId.Text, out temp);
                foreach (Control p in temp.Controls)
                    if (p.Name == "Nombre")
                        p.Text = txtEditarEspecialidad.Text;

                txtEditarEspecialidad.Text = "";
                lblId.Text = "Esperando";
                MessageBox.Show("Se ha actualizado el registro correctamente", "Actualizacion completada");
            }
            else
                MessageBox.Show("No se ha seleccionado ningun registro", "Error");
        }
    }
}
