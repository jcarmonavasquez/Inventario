using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Proveedores
{
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Nombre.Text.Length > 0 && Fax.Text.Length > 0 && Ciudad.Text.Length > 0)
            {
                string ConnString = Clases.Variables.conexion;
                string SqlString = "Insert Into Proveedores (id,Nombre,Direccion,Rfc,Fax,Ciudad,Curp) " +
                    "values ((SELECT MAX(id)+1 as Id FROM Proveedores)," +
                    "'" + Nombre.Text + "','" + Direccion.Text + "','" + RFC.Text + "','" + Fax.Text + "','" + Ciudad.Text + "','" + CURP.Text + "')";
                bool resultado = Clases.Inserciones.Ejecucion(SqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Proveedor agregado correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ha ocurrido un error inesperado");
            }
            else
            {
                MessageBox.Show("Favor de llenar los campos que contengan un (*) con un valor valido");
            }
        }
    }
}
