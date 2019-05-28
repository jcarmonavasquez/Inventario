using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Inventario.BienesdadosBaja
{
    public partial class BienesdadosBaja : Form
    {
        public BienesdadosBaja()
        {
            InitializeComponent();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Inventario.BienesdadosBaja.Modificar modificar = new Inventario.BienesdadosBaja.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVBienesBaja, Clases.Variables.ConsultaBuscar, "bienesBaja");
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            Inventario.BienesdadosBaja.Buscar buscar = new Buscar();
            buscar.ShowDialog();
            if (buscar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVBienesBaja, Clases.Variables.ConsultaBuscar, "bienesbaja");
        }

        private void BienesdadosBaja_Load(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "SELECT Id, Etiqueta, NoOrden,NoFactura, Precio, " +
               "Articulo, Departamento,Empleado," +
               " FechaCompra,FechaBaja, Marca, Serie, Modelo,MotivoBaja,Observacion FROM BienesBaja";
            Clases.LLenadoGrids.llenarGrid(GVBienesBaja, Clases.Variables.ConsultaBuscar, "BienesBaja");
        }

        private void GVBienesBaja_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Variables.IdBienesB = GVBienesBaja.CurrentRow.Cells[0].Value.ToString();
            Clases.Variables.BienesBMotivoBaja = GVBienesBaja.CurrentRow.Cells[13].Value.ToString();
            Clases.Variables.BienesBObservacion = GVBienesBaja.CurrentRow.Cells[14].Value.ToString();
        }

        private void GVBienesBaja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventario.BienesdadosBaja.Modificar modificar = new Inventario.BienesdadosBaja.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVBienesBaja, Clases.Variables.ConsultaBuscar, "bienesBaja");
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            Clases.Excel.GridViewExcel(GVBienesBaja);
        }
    }
}
