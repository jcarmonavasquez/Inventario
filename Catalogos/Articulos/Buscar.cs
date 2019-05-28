using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Articulos
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            Clases.Articulos.CBBuscarArticulo(comboBox1);   
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (RBArticulo.Checked == true)
                Clases.Variables.ConsultaBuscar = "select Articulos.Id, Articulos.Descripcion as Articulo, Familia.Descripcion as Familia, " +
                    "TipoArticulo.Descripcion as Tipo " +
                    "from Articulos inner join Familia on Familia.Id = Articulos.IdFamilia inner join " +
                    "TipoArticulo on TipoArticulo.id = Articulos.IdTipoArticulo where Articulos.Descripcion = '"+comboBox1.Text+"' order by id";
            else if (RBFamilia.Checked == true)
                Clases.Variables.ConsultaBuscar = "select Articulos.Id, Articulos.Descripcion as Articulo, Familia.Descripcion as Familia, " +
                    "TipoArticulo.Descripcion as Tipo " +
                    "from Articulos inner join Familia on Familia.Id = Articulos.IdFamilia inner join " +
                    "TipoArticulo on TipoArticulo.id = Articulos.IdTipoArticulo where familia.Descripcion = '" + comboBox1.Text + "' order by id";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MostrarTodo_Click(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "select Articulos.Id, Articulos.Descripcion as Articulo, Familia.Descripcion as Familia, " +
                "TipoArticulo.Descripcion as Tipo " +
                "from Articulos inner join Familia on Familia.Id=Articulos.IdFamilia inner join TipoArticulo on TipoArticulo.id=Articulos.IdTipoArticulo";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RBArticulo_CheckedChanged(object sender, EventArgs e)
        {
            if (RBArticulo.Checked == true)
                Clases.Articulos.CBBuscarArticulo(comboBox1);
        }

        private void RBFamilia_CheckedChanged(object sender, EventArgs e)
        {
            if (RBFamilia.Checked == true)
                Clases.Articulos.CBArticulosFamilia(comboBox1);
        }
    }
}
