using System;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Articulos
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (TBArticulo.Text.Length > 0 && CBArticulo.SelectedIndex >= 0 && CBFamilia.SelectedIndex >= 0)
            {
                string ConnString = Clases.Variables.conexion;
                string SqlString = "Update Articulos set Descripcion='"+TBArticulo.Text+"', " +
                    "idfamilia=(select Id from Familia where descripcion='"+CBFamilia.SelectedItem+"'), " +
                    "IdTipoArticulo=(select id from TipoArticulo where descripcion='"+CBArticulo.SelectedItem+"') " +
                    " where Id = "+Clases.Variables.IdArticulo+"";
                bool resultado = Clases.Inserciones.Ejecucion(SqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Articulo modificado correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ha ocurrido un error inesperado \n");
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los datos");
            }
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            Clases.Articulos.CBArticulosFamilia(CBFamilia);
            Clases.Articulos.CBArticulosTipoArticulo(CBArticulo);
            int index = CBArticulo.FindString(Clases.Variables.ArticuloTipo);
            CBArticulo.SelectedIndex = index;
            index = CBFamilia.FindString(Clases.Variables.ArticuloFamilia);
            CBFamilia.SelectedIndex = index;
            TBArticulo.Text = Clases.Variables.ArticuloDescripcion;
        }
    }
}
