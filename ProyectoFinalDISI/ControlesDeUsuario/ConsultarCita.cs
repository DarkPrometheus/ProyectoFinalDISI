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

        }

       

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            SQLCommands.GetUsuarioCitasAdmin(GridCitas, cbUsuario.Text);

     
            MessageBox.Show("Consulta Realizada");
        }

        private void ConsultarCita_Load(object sender, EventArgs e)
        {
            SQLCommands.GetTodasCitasAdmin(GridCitas);
        
        }

        private void BtnConsultarID_Click(object sender, EventArgs e)
        {
            SQLCommands.GetIDCitasAdmin(GridCitas, txtIdCitas.Text);
            txtIdCitas.Clear();
            MessageBox.Show("Consulta Realizada");
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            SQLCommands.GetTodasCitasAdmin(GridCitas);

        }
    }
}
