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
    public partial class Servicios : UserControl
    {


        public Servicios()
        {
            InitializeComponent();

            txtClaveServicio.Text = ClassPlaceholders.PlaceHoldersServicios[0];
            txtClaveServicio.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtClaveServicio.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtNombreServicio.Text = ClassPlaceholders.PlaceHoldersServicios[1];
            txtNombreServicio.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtNombreServicio.LostFocus += new EventHandler(ClassPlaceholders.AddText);

            txtDescripcion.Text = ClassPlaceholders.PlaceHoldersServicios[2];
            txtDescripcion.GotFocus += new EventHandler(ClassPlaceholders.RemoveText);
            txtDescripcion.LostFocus += new EventHandler(ClassPlaceholders.AddText);
        }
    }
}
