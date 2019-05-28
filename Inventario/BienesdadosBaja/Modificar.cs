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

namespace ProyectoInventario.Inventario.BienesdadosBaja
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            int index = Motivo.FindString(Clases.Variables.BienesBMotivoBaja);
            Motivo.SelectedIndex = index;
            Observaciones.Text = Clases.Variables.BienesBObservacion;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            string ConnString = Clases.Variables.conexion;
            string SqlString = "Update BienesBaja set MotivoBaja='" + Motivo.SelectedItem + "',Observacion='" +
                Observaciones.Text + "' where id=" + Clases.Variables.IdBienesB + "";
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
    }
}
