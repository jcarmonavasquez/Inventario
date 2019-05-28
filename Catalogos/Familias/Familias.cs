using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Familias
{
    public partial class Familias : Form
    {
        public Familias()
        {
            InitializeComponent();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Catalogos.Familias.Nuevo nuevo = new Catalogos.Familias.Nuevo();
            nuevo.ShowDialog();
            if (nuevo.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVFamilias, Clases.Variables.ConsultaBuscar, "Familias");
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Catalogos.Familias.Modificar modificar = new Catalogos.Familias.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVFamilias, Clases.Variables.ConsultaBuscar, "Familia");
        }

        private void Familias_Load(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "select Id, Descripcion from Familia";
            Clases.LLenadoGrids.llenarGrid(GVFamilias, Clases.Variables.ConsultaBuscar, "Familias");
        }

        private void GVFamilias_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Variables.IDFamilia = GVFamilias.CurrentRow.Cells[0].Value.ToString();
            Clases.Variables.DescripcionFamilia = GVFamilias.CurrentRow.Cells[1].Value.ToString();
        }

        private void GVFamilias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Catalogos.Familias.Modificar modificar = new Catalogos.Familias.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVFamilias, Clases.Variables.ConsultaBuscar, "Familia");
        }
    }
}
