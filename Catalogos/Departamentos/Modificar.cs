using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Departamentos
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            Descripcion.Text = Clases.Variables.DescripcionDeptos;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Descripcion.Text.Length > 0)
            {
                string ConnString = Clases.Variables.conexion;
                string sqlString = "update Departamentos set descripcion='"+Descripcion.Text+"' where id="+Clases.Variables.IdDeptos+"";
                bool resultado = Clases.Inserciones.Ejecucion(sqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Departamento modificado correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error al actualizar el departamento");
                }
            }
            else
            {
                MessageBox.Show("Favor de llenar el departamento");
            }
        }
    }
}
