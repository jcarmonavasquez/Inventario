using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Departamentos
{
    public partial class Departamentos : Form
    {
        public Departamentos()
        {
            InitializeComponent();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Catalogos.Departamentos.Nuevo nuevo = new Catalogos.Departamentos.Nuevo();
            nuevo.ShowDialog();
            if (nuevo.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVDepartamentos, Clases.Variables.ConsultaBuscar, "Departamentos");
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Catalogos.Departamentos.Modificar modificar = new Catalogos.Departamentos.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVDepartamentos, Clases.Variables.ConsultaBuscar, "Departamentos");
        }

        private void Departamentos_Load(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "select * from Departamentos";
            Clases.LLenadoGrids.llenarGrid(GVDepartamentos, Clases.Variables.ConsultaBuscar, "Departamentos");
        }

        private void GVDepartamentos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Variables.IdDeptos = GVDepartamentos.CurrentRow.Cells[0].Value.ToString();
            Clases.Variables.DescripcionDeptos = GVDepartamentos.CurrentRow.Cells[1].Value.ToString();
        }

        private void GVDepartamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Catalogos.Departamentos.Modificar modificar = new Catalogos.Departamentos.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVDepartamentos, Clases.Variables.ConsultaBuscar, "Departamentos");
        }
    }
}
