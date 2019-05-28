using System;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Articulos
{
    public partial class Articulos : Form
    {
        public Articulos()
        {
            InitializeComponent();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Catalogos.Articulos.Nuevo nuevo = new Catalogos.Articulos.Nuevo();
            nuevo.ShowDialog();
            if (nuevo.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVArticulos, Clases.Variables.ConsultaBuscar, "Articulos");
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Catalogos.Articulos.Modificar modificar = new Catalogos.Articulos.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVArticulos, Clases.Variables.ConsultaBuscar, "Articulos");
        }
        private void GVArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Catalogos.Articulos.Modificar modificar = new Catalogos.Articulos.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVArticulos, Clases.Variables.ConsultaBuscar, "Articulos");
        }
        private void Buscar_Click(object sender, EventArgs e)
        {
            Catalogos.Articulos.Buscar buscar = new Catalogos.Articulos.Buscar();
            buscar.ShowDialog();
            if (buscar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVArticulos, Clases.Variables.ConsultaBuscar, "Articulos");
        }

        private void Articulos_Load(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "select Articulos.Id, Articulos.Descripcion as Articulo, Familia.Descripcion as Familia, " +
                "TipoArticulo.Descripcion as Tipo " +
                "from Articulos inner join Familia on Familia.Id = Articulos.IdFamilia inner " +
                "join TipoArticulo on TipoArticulo.id = Articulos.IdTipoArticulo";
            Clases.LLenadoGrids.llenarGrid(GVArticulos, Clases.Variables.ConsultaBuscar,"Articulos");
        }

        private void GVArticulos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Variables.IdArticulo = GVArticulos.CurrentRow.Cells[0].Value.ToString();
            Clases.Variables.ArticuloDescripcion = GVArticulos.CurrentRow.Cells[1].Value.ToString();
            Clases.Variables.ArticuloFamilia = GVArticulos.CurrentRow.Cells[2].Value.ToString();
            Clases.Variables.ArticuloTipo = GVArticulos.CurrentRow.Cells[3].Value.ToString();
        }

        
    }
}
