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
            // TODO: Colocar placeholders
            InitializeComponent();
            foreach (var item in SQLCommands.GetNombreEmpleado())
                cbMedico.Items.Add(item);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
