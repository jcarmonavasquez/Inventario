using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Familias
{
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Desccripcion.Text.Length > 0)
            {
                string ConnString = Clases.Variables.conexion;
                string SqlString = "INSERT INTO familia (id,Descripcion) " +
                    "values ((SELECT MAX(id)+1 as Id FROM familia),'" + Desccripcion.Text +"')";
                bool resultado = Clases.Inserciones.Ejecucion(SqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Familia agregada correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ha ocurrido un error inesperado");
            }
            else
                MessageBox.Show("Los campos deben contener un valor");
        }
    }
}
