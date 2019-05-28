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
    public partial class BienesBaja : Form
    {
        public BienesBaja()
        {
            InitializeComponent();
        }

        private void BienesBaja_Load(object sender, EventArgs e)
        {
            Etiqueta.Text = Clases.Variables.BienesEtiqueta;
            Empleado.Text = Clases.Variables.BienesEmpleado;
            Articulo.Text = Clases.Variables.BienesDescripcionArticulo;
            Precio.Text = Clases.Variables.BienesTotal;
            Clases.Bienes.BajaLabels(Modelo, Serie, Marca);
            Clases.Variables.MotivoBaja = "NO FUNCIONA";
        }
        public void FechaC(DateTimePicker fecha)
        {
            SqlCommand cmd;
            SqlDataReader dr;
            SqlConnection cn = new SqlConnection(Clases.Variables.conexion);
            try
            {
                cn.Open();
                cmd = new SqlCommand("Select FechaCompra AS Fecha from bienes where Etiqueta=" + Etiqueta.Text, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fecha.Value = Convert.ToDateTime(dr["Fecha"].ToString());
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar :" + ex.ToString());
            }
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            DateTimePicker fechac = new DateTimePicker();
            FechaC(fechac);
            string ConnString = Clases.Variables.conexion;
            string SqlString;
            if (Clases.Variables.MotivoBaja != "ERROR")
            {
                SqlString = "Insert Into BienesBaja values ((select MAX(Id)+1 from BienesBaja)," + Etiqueta.Text + "," + Clases.Variables.BienesOrdenCompra + ", " +
                    "'" + Clases.Variables.BienesFactura + "'," + Precio.Text + ",'" + Articulo.Text + "','"+Clases.Variables.BienesDepartamento+"','" + Empleado.Text + "'," +
                    "(SELECT CONVERT(datetime, '" + fechac.Value.Day + "-" + fechac.Value.Month + "-" + fechac.Value.Year + "'))," +
                    "(select convert(datetime,'"+DateTime.Today.Day+"-"+DateTime.Today.Month+"-"+DateTime.Today.Year+"')),'" + Marca.Text + "','" + Serie.Text + "','" + Modelo.Text + "','" + Clases.Variables.MotivoBaja + "','"+Observaciones.Text+"')";
                try
                {
                    SqlConnection conn = new SqlConnection(ConnString);
                    SqlCommand cmd = new SqlCommand(SqlString, conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    SqlString = "Delete from bienes where Etiqueta=" + Etiqueta.Text;
                    cmd = new SqlCommand(SqlString, conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("La baja se realizo de manera correcta.");
                    this.Close();
                    this.DialogResult = DialogResult.OK;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al dar de baja el bien: \n" + ex.ToString());
                }
            }
            else
            {
                SqlString = "Insert Into BienesBaja_Error values ((select MAX(Id)+1 from BienesBaja_Error)," + Etiqueta.Text + "," + Clases.Variables.BienesOrdenCompra + ", " +
                    "'" + Clases.Variables.BienesFactura + "'," + Precio.Text + ",'" + Articulo.Text + "','" + Clases.Variables.BienesDepartamento + "','" + Empleado.Text + "'," +
                    "(SELECT CONVERT(datetime, '" + fechac.Value.Day + "-" + fechac.Value.Month + "-" + fechac.Value.Year + "'))," +
                    "(select convert(datetime,'" + DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + "')),'" + Marca.Text + "','" + Serie.Text + "','" + Modelo.Text + "','" + Clases.Variables.MotivoBaja + "','"+Observaciones.Text+"')";
                try
                {
                    SqlConnection conn = new SqlConnection(ConnString);
                    SqlCommand cmd = new SqlCommand(SqlString, conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    SqlString = "Delete from bienes where Etiqueta=" + Etiqueta.Text;
                    cmd = new SqlCommand(SqlString, conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("La baja se realizo de manera correcta.");
                    this.Close();
                    this.DialogResult = DialogResult.OK;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al dar de baja el bien: \n" + ex.ToString());
                }
            }
        }

        private void NoFunciona_CheckedChanged(object sender, EventArgs e)
        {
            if (NoFunciona.Checked == true)
                Clases.Variables.MotivoBaja = "NO FUNCIONA";
        }

        private void Robo_CheckedChanged(object sender, EventArgs e)
        {
            if (Robo.Checked == true)
                Clases.Variables.MotivoBaja = "ROBO";
        }

        private void Extravio_CheckedChanged(object sender, EventArgs e)
        {
            if (Extravio.Checked == true)
                Clases.Variables.MotivoBaja = "EXTRAVIO";
        }

        private void Donacion_CheckedChanged(object sender, EventArgs e)
        {
            if (Donacion.Checked == true)
                Clases.Variables.MotivoBaja = "DONACION";
        }

        private void Error_CheckedChanged(object sender, EventArgs e)
        {
            if (Error.Checked == true)
                Clases.Variables.MotivoBaja = "ERROR";
        }

    }
}
