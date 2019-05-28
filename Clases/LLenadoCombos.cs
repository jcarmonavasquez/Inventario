using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoInventario.Clases
{
    class Articulos
    {
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static string conexion = Clases.Variables.conexion;
        static SqlConnection cn = new SqlConnection(conexion);

        public static void CBArticulosFamilia(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select Descripcion from familia", cn);
                dr = cmd.ExecuteReader();
                CB.Items.Clear();
                CB.Text = "";
                while (dr.Read())
                {
                    CB.Items.Add(dr["Descripcion"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBArticulosTipoArticulo(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select Descripcion from tipoarticulo", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CB.Items.Add(dr["Descripcion"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBBuscarArticulo(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select Descripcion from Articulos order by descripcion", cn);
                dr = cmd.ExecuteReader();
                CB.Items.Clear();
                CB.Text = "";
                while (dr.Read())
                {
                    CB.Items.Add(dr["Descripcion"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
    }
    class Empleados
    {
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static string conexion = Clases.Variables.conexion;
        static SqlConnection cn = new SqlConnection(conexion);

        public static void CBDeptos(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select DESCRIPCION from departamentos", cn);
                dr = cmd.ExecuteReader();
                CB.Items.Clear();
                CB.Text = "";
                while (dr.Read())
                {
                    CB.Items.Add(dr["DESCRIPCION"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBNombre(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select Nombre from empleados order by nombre", cn);
                dr = cmd.ExecuteReader();
                CB.Items.Clear();
                CB.Text = "";
                while (dr.Read())
                {
                    CB.Items.Add(dr["Nombre"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBNombreSB(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select Nombre from empleados where Baja=0 order by nombre", cn);
                dr = cmd.ExecuteReader();
                CB.Items.Clear();
                CB.Text = "";
                while (dr.Read())
                {
                    CB.Items.Add(dr["Nombre"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
    }
    class Proveedores
    {
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static string conexion = Clases.Variables.conexion;
        static SqlConnection cn = new SqlConnection(conexion);

        public static void CBBuscarNombre(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select nombre from proveedores order by nombre", cn);
                dr = cmd.ExecuteReader();
                CB.Items.Clear();
                CB.Text = "";
                while (dr.Read())
                {
                    CB.Items.Add(dr["nombre"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBBuscarRFC(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select rfc from proveedores order by rfc", cn);
                dr = cmd.ExecuteReader();
                CB.Items.Clear();
                CB.Text = "";
                while (dr.Read())
                {
                    CB.Items.Add(dr["rfc"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }

    }
    class Bienes
    {
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static string conexion = Clases.Variables.conexion;
        static SqlConnection cn = new SqlConnection(conexion);

        public static void CBMarca(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select Descripcion from marcas order by Descripcion", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CB.Items.Add(dr["Descripcion"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void Modificar(TextBox orden, DateTimePicker fecha, TextBox factura, ComboBox articulo,
            Label familia, ComboBox marca, TextBox serie, ComboBox conservacion, TextBox modelo, TextBox color, ComboBox proveedor,
            Label domicilio, Label rfc, TextBox observaciones)
        {
            try
            {
                int index;
                cn.Open();
                cmd = new SqlCommand("SELECT bienes.Id, bienes.NoOrden,bienes.FechaCompra, bienes.NoFactura," +
                    "bienes.Modelo,Bienes.Color,Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo," +
                    "Proveedores.Nombre AS Proveedor,bienes.Estado,Proveedores.Direccion AS Direccion," +
                    "Proveedores.Rfc AS RFC,bienes.Observacion,marcas.Descripcion as marca,bienes.Serie " +
                    "FROM bienes INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia " +
                    "ON Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id" +
                    " INNER JOIN marcas on bienes.IdMarca=marcas.Id where bienes.Id=" + Clases.Variables.IdBienes, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    orden.Text = dr["NoOrden"].ToString();
                    fecha.Value = Convert.ToDateTime(dr["FechaCompra"].ToString());
                    factura.Text = dr["NoFactura"].ToString();
                    articulo.SelectedIndex = articulo.FindString(dr["Articulo"].ToString());
                    familia.Text = dr["Familia"].ToString();
                    index = marca.FindString(dr["marca"].ToString());
                    marca.SelectedIndex = index;
                    serie.Text = dr["Serie"].ToString();
                    index = conservacion.FindString(dr["Estado"].ToString());
                    conservacion.SelectedIndex = index;
                    modelo.Text = dr["Modelo"].ToString();
                    color.Text = dr["Color"].ToString();
                    index = proveedor.FindString(dr["Proveedor"].ToString());
                    proveedor.SelectedIndex = index;
                    domicilio.Text = dr["Direccion"].ToString();
                    rfc.Text = dr["RFC"].ToString();
                    observaciones.Text = dr["Observacion"].ToString();
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBDeptos(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select DESCRIPCION from DEPARTAMENTOS", cn);
                dr = cmd.ExecuteReader();
                CB.Items.Clear();
                CB.Text = "";
                while (dr.Read())
                {
                    CB.Items.Add(dr["DESCRIPCION"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }

        public static void CBFactura(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select NoFactura from bienes order by NoFactura", cn);
                dr = cmd.ExecuteReader();
                CB.Text = "";
                CB.Items.Clear();
                while (dr.Read())
                {
                    CB.Items.Add(dr["NoFactura"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBProveedor(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select RTRIM(Nombre) as Nombre from Proveedores order by Nombre", cn);
                dr = cmd.ExecuteReader();
                CB.Text = "";
                CB.Items.Clear();
                while (dr.Read())
                {
                    CB.Items.Add(dr["Nombre"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }

        public static void BajaLabels(Label modelo, Label serie, Label marca)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("SELECT bienes.Id,bienes.Modelo,bienes.Serie,marcas.Descripcion as marca " +
                    "from bienes inner join marcas on bienes.IdMarca=marcas.Id where bienes.Id=" + Clases.Variables.IdBienes, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    modelo.Text = dr["Modelo"].ToString();
                    serie.Text = dr["Serie"].ToString();
                    marca.Text = dr["marca"].ToString();
                }
                cn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se a podido cargar los datos error: " + e.ToString());
            }
        }

        public static void Suma(Label Total)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select SUM(Precio) as Precio from bienes", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    decimal x = decimal.Parse(dr["Precio"].ToString());
                    Total.Text = x.ToString("C");
                    Clases.Variables.Total = Total.Text;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
    }
    class BienesBaja
    {
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static string conexion = Clases.Variables.conexion;
        static SqlConnection cn = new SqlConnection(conexion);

        public static void CBEtiqueta(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select Etiqueta from bienesbaja order by Etiqueta", cn);
                dr = cmd.ExecuteReader();
                CB.Text = "";
                CB.Items.Clear();
                while (dr.Read())
                {
                    CB.Items.Add(dr["Etiqueta"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBArticulo(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select DISTINCT Articulo from bienesbaja order by Articulo", cn);
                dr = cmd.ExecuteReader();
                CB.Text = "";
                CB.Items.Clear();
                while (dr.Read())
                {
                    CB.Items.Add(dr["Articulo"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBEmleado(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select DISTINCT Empleado from bienesbaja order by Empleado", cn);
                dr = cmd.ExecuteReader();
                CB.Text = "";
                CB.Items.Clear();
                while (dr.Read())
                {
                    CB.Items.Add(dr["Empleado"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBFactura(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select  DISTINCT NoFactura from bienesbaja", cn);
                dr = cmd.ExecuteReader();
                CB.Text = "";
                CB.Items.Clear();
                while (dr.Read())
                {
                    CB.Items.Add(dr["NoFactura"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        public static void CBMotivo(ComboBox CB)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("select DISTINCT MotivoBaja from bienesbaja", cn);
                dr = cmd.ExecuteReader();
                CB.Text = "";
                CB.Items.Clear();
                while (dr.Read())
                {
                    CB.Items.Add(dr["MotivoBaja"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
    }
}
