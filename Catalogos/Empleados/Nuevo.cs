using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Catalogos.Empleados
{
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (Nombre.Text.Length > 0  && comboDepto.SelectedIndex >= 0 && Paterno.Text.Length > 0 && Materno.Text.Length > 0)
            {   
                string nombres = Nombre.Text;
                string paterno = Paterno.Text;
                string materno = Materno.Text;
                string NombreEmpleado = nombres + " " + paterno + " " + materno;
                string SqlString = "Insert Into empleados (NoEmp,Nombre,Departamento, Baja) " +
                    "values ((select MAX(NoEmp)+1 as NomEmp from empleados),'" + NombreEmpleado + "','" + comboDepto.SelectedItem.ToString() + "',0)";

                bool resultado = Clases.Inserciones.Ejecucion(SqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Empleado agregado correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ha ocurrido un error inesperado  ");
            }
            else
                MessageBox.Show("Todos los campos deben contener un valor valido");
        }

        private void Nuevo_Load(object sender, EventArgs e)
        {
            Clases.Empleados.CBDeptos(comboDepto);
        }
    }
}
