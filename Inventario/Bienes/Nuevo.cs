using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Inventario.Bienes
{
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
        }

        private void NArt_Click(object sender, EventArgs e)
        {
            Catalogos.Articulos.Nuevo nuevo = new Catalogos.Articulos.Nuevo();
            nuevo.ShowDialog();
        }

        private void NPro_Click(object sender, EventArgs e)
        {
            Catalogos.Proveedores.Nuevo nuevo = new Catalogos.Proveedores.Nuevo();
            nuevo.ShowDialog();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (CBArticulo.SelectedIndex >= 0 && CBConservacion.SelectedIndex >= 0 && CBEmpleado.SelectedIndex >= 0 && CBProveedor.SelectedIndex >= 0 && CBMarca.SelectedIndex >= 0 && TBFactura.Text.Length > 0 && TBNoOrden.Text.Length > 0 && TBPrecio.Text.Length > 0)
            {
                int etiqueta = int.Parse(llenaretiqueta());
                string ConnString = Clases.Variables.conexion;
                string SqlString = "Insert Into bienes (Id,Etiqueta,NoOrden,NoFactura,Precio,IdArticulo,Observacion, " +
                    "NoEmpleado,IdProveedor,FechaCompra,IdMarca,Serie,Modelo,Color,Estado) " +
                    "values ((SELECT MAX(Id)+1 as Id FROM BIENES)," + etiqueta.ToString() + "," + TBNoOrden.Text + ",'" +
                    TBFactura.Text + "'," + TBPrecio.Text + ",(select id from Articulos where descripcion='" + CBArticulo.SelectedItem + "'),'" + TBObservaciones.Text + "', " +
                    "(SELECT NoEmp FROM empleados where Nombre='" + CBEmpleado.SelectedItem + "'),(select id from proveedores where nombre='" + CBProveedor.SelectedItem + "'), " +
                    "(SELECT CONVERT(datetime, '"+TimeFecha.Value.Year+"-"+TimeFecha.Value.Month+"-"+TimeFecha.Value.Day+"')), " +
                    "(select Id from Marcas where descripcion='"+CBMarca.SelectedItem+"'),'" + TBSerie.Text + "','" + TBModelo.Text + "','" + TBColor.Text +
                    "','" + CBConservacion.SelectedItem + "')";
                Clases.Inserciones.BEjecucion(SqlString);
                etiqueta = etiqueta + 1;
                if (Clases.Variables.ErrorB == false)
                { 
                    MessageBox.Show("Bien agregado correctamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("No fue posible agregar los bienes.");
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los espacios que contengan un (*)");
            }
        }

        private void Nuevo_Load(object sender, EventArgs e)
        {
            TBEtiqueta.Text = llenaretiqueta();
            Clases.Empleados.CBNombreSB(CBEmpleado);
            Clases.Articulos.CBBuscarArticulo(CBArticulo);
            Clases.Bienes.CBMarca(CBMarca);
            Clases.Bienes.CBProveedor(CBProveedor);
        }

        private string llenaretiqueta()
        {
            string etiqueta = "";
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = new SqlConnection(Clases.Variables.conexion);
            try
            {
                cn.Open();
                cmd = new SqlCommand("SELECT MAX(ETIQUETA)+1 as etiqueta FROM BIENES", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    etiqueta = dr["etiqueta"].ToString();
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
            return etiqueta;
        }

        private void CBEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = new SqlConnection(Clases.Variables.conexion);
            try
            {
                cn.Open();
                cmd = new SqlCommand("select departamento from empleados where Nombre='" + CBEmpleado.SelectedItem + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LBDepartamento.Text = dr["departamento"].ToString();
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }

        private void CBArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = new SqlConnection(Clases.Variables.conexion);
            try
            {
                cn.Open();
                cmd = new SqlCommand("select Familia.Descripcion as familia from Articulos,Familia where Familia.Id=Articulos.IdFamilia and Articulos.Descripcion='" + CBArticulo.SelectedItem + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LBFamilia.Text = dr["familia"].ToString();
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }

        private void CBProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = new SqlConnection(Clases.Variables.conexion);
            try
            {
                cn.Open();
                cmd = new SqlCommand("select direccion,rfc from proveedores where Nombre='" + CBProveedor.SelectedItem + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LBDomicilio.Text = dr["direccion"].ToString();
                    LBRFC.Text = dr["rfc"].ToString();
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }

        private void TBNoOrden_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TBPrecio_Leave(object sender, EventArgs e)
        {
            decimal numero = default(decimal);
            bool bln = decimal.TryParse(TBPrecio.Text, out numero);
            if ((!(bln)) && TBPrecio.Text.Length > 0)
            {
                TBPrecio.Clear();
                MessageBox.Show("Precio Incorrecto");
            }
        }
    }
}
