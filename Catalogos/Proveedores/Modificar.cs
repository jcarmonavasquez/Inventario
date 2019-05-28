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
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            Nombre.Text = Clases.Variables.ProveedoresNombre;
            Direccion.Text = Clases.Variables.ProveedoresDireccion;
            RFC.Text = Clases.Variables.ProveedoresRFC;
            Fax.Text = Clases.Variables.ProveedoresFax;
            Ciudad.Text = Clases.Variables.ProveedoresCiudad;
            CURP.Text = Clases.Variables.ProveedoresCURP;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Nombre.Text.Length > 0)
            {
                string ConnString = Clases.Variables.conexion;
                string SqlString = "Update Proveedores  set Nombre='" + Nombre.Text + "',Direccion='" + Direccion.Text + "',Rfc='" + RFC.Text +
                    "', Fax='" + Fax.Text + "', Ciudad='" + Ciudad.Text + "',Curp='" + CURP.Text + "'" +
                    " where Id=" + Clases.Variables.IdProveedores + "";
                bool resultado = Clases.Inserciones.Ejecucion(SqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Proveedor modificado correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ha ocurrido un error inesperado");
            }
            else
                MessageBox.Show("Al menos el campo Nombre debe contener un valor");
        }
    }
}
