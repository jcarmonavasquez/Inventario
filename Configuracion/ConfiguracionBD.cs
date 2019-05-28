using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Configuracion
{
    public partial class ConfiguracionBD : Form
    {
        public ConfiguracionBD()
        {
            InitializeComponent();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            Configuracion.ConfiramarBD confiramarBD = new ConfiramarBD();
            confiramarBD.ShowDialog();
            if (confiramarBD.DialogResult == DialogResult.OK)
            {
                Clases.Variables.conexion = ConBD.Text;
                MessageBox.Show("Cadena de texto modificada correctamente");
                Application.Restart();
            }
        }

        private void ConfiguracionBD_Load(object sender, EventArgs e)
        {
            ConBD.Text = Clases.Variables.conexion;
        }
    }
}
