using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoInventario.Inventario.Bienes
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void NArt_Click(object sender, EventArgs e)
        {
            Catalogos.Articulos.Nuevo nuevo = new Catalogos.Articulos.Nuevo();
            nuevo.ShowDialog();
        }

        private void NPor_Click(object sender, EventArgs e)
        {
            Catalogos.Proveedores.Nuevo nuevo = new Catalogos.Proveedores.Nuevo();
            nuevo.ShowDialog();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            Clases.Articulos.CBBuscarArticulo(Articulo);
            Clases.Bienes.CBProveedor(Proveedor);
            Clases.Bienes.CBMarca(Marca);
            Clases.Bienes.Modificar(Orden, Fecha, Factura, Articulo, Familia, Marca, Serie, Conservacion,
                Modelo, Color, Proveedor, Domicilio, RFC, Observaciones);

        }
       
        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Orden.Text.Length > 0 && Factura.Text.Length > 0 && Orden.Text.Length > 0 && Articulo.SelectedIndex >= 0 &&
                Marca.SelectedIndex >= 0 && Conservacion.SelectedIndex >= 0 && Proveedor.SelectedIndex >= 0)
            {
                string ConnString = Clases.Variables.conexion;
                string SqlString = "Update bienes set NoOrden=" + Orden.Text + ",NoFactura='" + Factura.Text + "'," +
                    "IdArticulo=(select id from articulos where descripcion='" + Articulo.SelectedItem + "'),Observacion='" + Observaciones.Text + "', " +
                    "IdProveedor=(select id from proveedores where nombre='" + Proveedor.SelectedItem + "'), " +
                    "FechaCompra=(SELECT CONVERT(datetime, '" + Fecha.Value.Day + "-" + Fecha.Value.Month + "-" + Fecha.Value.Year + "'))," +
                    "IdMarca=(select id from marcas where descripcion='" + Marca.SelectedItem + "')," + "Serie='" + Serie.Text + "',Modelo='" + Modelo.Text + "',Color='" + Color.Text + "', " +
                    "Estado='" + Conservacion.SelectedItem.ToString() + "' where Id=" + Clases.Variables.IdBienes + "";
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Bien modificado correctamente.");
                            this.Close();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El valor insertado no es valido. \n" + ex.ToString());
                }
            }
            else
                MessageBox.Show("Los campos obligatorios(*) deben contener algun valor");
        }

        private void Orden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
