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
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Descripcion.Text.Length > 0)
            {
                string ConnString = Clases.Variables.conexion;
                string sqlString = "insert into Departamentos (Id, Descripcion) " +
                    "values ((select MAX(Id) +1 AS Id from Departamentos),'"+Descripcion.Text+"')";
                bool resultado = Clases.Inserciones.Ejecucion(sqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Departamento agregado correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Hubo un error al agregar el departamento");
                }
            }
            else
            {
                MessageBox.Show("Favor de no dejar el campo en blanco");
            }
        }
    }
}
