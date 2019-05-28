using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Proveedores
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            Clases.Proveedores.CBBuscarNombre(comboBuscar);
        }

        private void RadioNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNombre.Checked == true)
                Clases.Proveedores.CBBuscarNombre(comboBuscar);
        }

        private void RadioRFC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRFC.Checked == true)
                Clases.Proveedores.CBBuscarRFC(comboBuscar);
        }

        private void MostrarTodo_Click(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "Select * from Proveedores";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Busscar_Click(object sender, EventArgs e)
        {
            if (radioNombre.Checked == true)
                Clases.Variables.ConsultaBuscar = "Select * from Proveedores where Nombre= '" + comboBuscar.Text + "'";
            if (radioRFC.Checked == true)
                Clases.Variables.ConsultaBuscar = "Select * from Proveedores where rfc= '" + comboBuscar.Text + "'";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
