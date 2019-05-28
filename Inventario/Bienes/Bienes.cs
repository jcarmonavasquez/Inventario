using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Inventario.Bienes
{
    public partial class Bienes : Form
    {
        public Bienes()
        {
            InitializeComponent();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Inventario.Bienes.Nuevo Nuevo = new Inventario.Bienes.Nuevo();
            Nuevo.ShowDialog();
            if (Nuevo.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVBienes, Clases.Variables.ConsultaBuscar, "bienes");
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Inventario.Bienes.Modificar modificar = new Inventario.Bienes.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVBienes, Clases.Variables.ConsultaBuscar, "bienes");
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            Inventario.Bienes.Buscar buscar = new Inventario.Bienes.Buscar();
            buscar.ShowDialog();
            if (buscar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVBienes, Clases.Variables.ConsultaBuscar, "bienes");
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            Inventario.Bienes.BienesBaja baja = new BienesBaja();
            baja.ShowDialog();
            if (baja.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVBienes, Clases.Variables.ConsultaBuscar, "bienes");
        }

        private void Bienes_Load(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.Precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado, " +
                "empleados.Departamento, Proveedores.Nombre AS Proveedor,bienes.Observacion AS Observacion " +
                "FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id LEFT OUTER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id LEFT OUTER JOIN Proveedores on bienes.IdProveedor = Proveedores.Id";
            Clases.LLenadoGrids.llenarGrid(GVBienes, Clases.Variables.ConsultaBuscar, "bienes");
        }

        private void GVBienes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Variables.IdBienes = GVBienes.CurrentRow.Cells[0].Value.ToString();
            Clases.Variables.BienesEtiqueta = GVBienes.CurrentRow.Cells[1].Value.ToString();
            Clases.Variables.BienesOrdenCompra = GVBienes.CurrentRow.Cells[2].Value.ToString();
            Clases.Variables.BienesFactura = GVBienes.CurrentRow.Cells[3].Value.ToString();
            Clases.Variables.BienesSerie = GVBienes.CurrentRow.Cells[4].Value.ToString();
            Clases.Variables.BienesTotal = GVBienes.CurrentRow.Cells[5].Value.ToString();
            Clases.Variables.BienesFamilia= GVBienes.CurrentRow.Cells[6].Value.ToString();
            Clases.Variables.BienesDescripcionArticulo = GVBienes.CurrentRow.Cells[7].Value.ToString();
            Clases.Variables.BienesEmpleado = GVBienes.CurrentRow.Cells[8].Value.ToString();
            Clases.Variables.BienesDepartamento= GVBienes.CurrentRow.Cells[9].Value.ToString();
            Clases.Variables.BienesProveedor= GVBienes.CurrentRow.Cells[10].Value.ToString();
            Clases.Variables.BienesObservacion = GVBienes.CurrentRow.Cells[11].Value.ToString();
           
        }

        private void GVBienes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventario.Bienes.Modificar modificar = new Inventario.Bienes.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVBienes, Clases.Variables.ConsultaBuscar, "bienes");
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            Clases.Excel.GridViewExcel(GVBienes);
        }
    }
}
