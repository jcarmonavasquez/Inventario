using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Reportes.ValorBienes
{
    public partial class ValorBienes : Form
    {
        public ValorBienes()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            Reportes.ValorBienes.Buscar buscar = new Buscar();
            buscar.ShowDialog();
            if (buscar.DialogResult == DialogResult.OK)
            {
                Clases.LLenadoGrids.llenarGrid(GVBienesValor, Clases.Variables.ConsultaBuscar, "bienes");
                decimal x = 0;
                foreach (DataGridViewRow row in GVBienesValor.Rows)
                {
                    x = x + decimal.Parse(row.Cells[5].Value.ToString());
                }
                Total.Text = x.ToString("C");
                Clases.Variables.Total = Total.Text;
                LBTotalBienes.Text = GVBienesValor.RowCount.ToString();
            }
        }

        private void GVBienesValor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ValorBienes_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(20, this.Height + 30);
            Total.Location = new Point(140, this.Height + 30);
            label2.Location = new Point(600,this.Height + 30);
            LBTotalBienes.Location = new Point(730, this.Height + 30);
            Clases.Variables.ConsultaBuscar = "SELECT bienes.Etiqueta, Articulos.Descripcion AS Articulo," +
               "Familia.Descripcion as Familia, empleados.Nombre AS Resguardo,bienes.FechaCompra,bienes.Precio " +
               "FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
               "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
               "Articulos.IdFamilia = Familia.Id order by Familia";
            Clases.LLenadoGrids.llenarGrid(GVBienesValor, Clases.Variables.ConsultaBuscar, "bienes");
            Clases.Bienes.Suma(Total);
            LBTotalBienes.Text = GVBienesValor.RowCount.ToString();
        }

        private void Excel_Click(object sender, EventArgs e)
        {
            Clases.Excel.GridViewExcel(GVBienesValor);
        }
    }
}
