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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Catalogos.Proveedores.Nuevo nuevo = new Catalogos.Proveedores.Nuevo();
            nuevo.ShowDialog();
            if (nuevo.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVProveedores, Clases.Variables.ConsultaBuscar, "Proveedores");
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Catalogos.Proveedores.Modificar modificar = new Catalogos.Proveedores.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVProveedores, Clases.Variables.ConsultaBuscar, "Proveedores");
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            Catalogos.Proveedores.Buscar buscar = new Catalogos.Proveedores.Buscar();
            buscar.ShowDialog();
            if (buscar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVProveedores, Clases.Variables.ConsultaBuscar, "Proveedores");
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "SELECT * FROM Proveedores";
            Clases.LLenadoGrids.llenarGrid(GVProveedores, Clases.Variables.ConsultaBuscar, "Proveedores");
        }

        private void GVProveedores_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Variables.IdProveedores = GVProveedores.CurrentRow.Cells[0].Value.ToString();
            Clases.Variables.ProveedoresNombre = GVProveedores.CurrentRow.Cells[1].Value.ToString();
            Clases.Variables.ProveedoresDireccion = GVProveedores.CurrentRow.Cells[2].Value.ToString();
            Clases.Variables.ProveedoresRFC = GVProveedores.CurrentRow.Cells[3].Value.ToString();
            Clases.Variables.ProveedoresFax = GVProveedores.CurrentRow.Cells[4].Value.ToString();
            Clases.Variables.ProveedoresCiudad = GVProveedores.CurrentRow.Cells[5].Value.ToString();
            Clases.Variables.ProveedoresCURP = GVProveedores.CurrentRow.Cells[6].Value.ToString();
        }

        private void GVProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Catalogos.Proveedores.Modificar modificar = new Catalogos.Proveedores.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVProveedores, Clases.Variables.ConsultaBuscar, "Proveedores");
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            Clases.Excel.GridViewExcel(GVProveedores);
        }
    }
}
