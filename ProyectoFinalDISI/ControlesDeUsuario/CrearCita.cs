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

            txtIdCitas.Text = ClassPlaceholders.PlaceHoldersCrearCita[0];
            txtIdCitas.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtIdCitas.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtHoraCrearCita.Text = ClassPlaceholders.PlaceHoldersCrearCita[1];
            txtHoraCrearCita.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtHoraCrearCita.LostFocus += new EventHandler(ClassPlaceholders.AddText);
        }
    }
}
