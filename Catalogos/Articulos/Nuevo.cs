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
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
        }

        private void Nuevo_Load(object sender, EventArgs e)
        {
            Clases.Articulos.CBArticulosFamilia(CBFamilia);
            Clases.Articulos.CBArticulosTipoArticulo(CBArticulo);
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (TBArticulo.Text.Length > 0 && CBArticulo.SelectedIndex >= 0 && CBFamilia.SelectedIndex >= 0)
            {
                string ConnString = Clases.Variables.conexion;
                string SqlString = "insert into Articulos (Id,Descripcion,IdFamilia,IdTipoArticulo) " +
                    "values((SELECT MAX(Id) + 1 as Id FROM Articulos),'"+TBArticulo.Text+"', " +
                    "(select id from Familia where Familia.Descripcion = '"+CBFamilia.SelectedItem+"'), " +
                    "(select Id from TipoArticulo where TipoArticulo.Descripcion = '"+CBArticulo.SelectedItem+"'))";
                bool resultado = Clases.Inserciones.Ejecucion(SqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Articulo agregado correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ha ocurrido un error inesperado \n");
                 // MessageBox.Show("Ha ocurrido un error inesperado \n" + Clases.Variables.Error);
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los datos");
            }
        }
    }
}
