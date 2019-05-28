using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Marcas
{
    public partial class Marcas : Form
    {
        public Marcas()
        {
            InitializeComponent();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Catalogos.Marcas.Nuevo nuevo = new Catalogos.Marcas.Nuevo();
            nuevo.ShowDialog();
            if (nuevo.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVMarcas, Clases.Variables.ConsultaBuscar, "marca");
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Catalogos.Marcas.Modificar modificar = new Catalogos.Marcas.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVMarcas, Clases.Variables.ConsultaBuscar, "marca");
        }

        private void Marcas_Load(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "select * from marcas ";
            Clases.LLenadoGrids.llenarGrid(GVMarcas, Clases.Variables.ConsultaBuscar, "marca");
        }

        private void GVMarcas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Variables.IDMarcas = GVMarcas.CurrentRow.Cells[0].Value.ToString();
            Clases.Variables.DescripcionMarcas = GVMarcas.CurrentRow.Cells[1].Value.ToString();
        }

        private void GVMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Catalogos.Marcas.Modificar modificar = new Catalogos.Marcas.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVMarcas, Clases.Variables.ConsultaBuscar, "marca");
        }
    }
}
