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
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            int baja = 0;
            if (checkBaja.Checked == false)
            {
                baja = 1;
                
            }
            else
            {
                baja = 0;
            }
            if (textBox1.Text.Length > 0 && comboDepto.SelectedIndex >= 0)
            {
                string ConnString = Clases.Variables.conexion;
                string SqlString = "Update empleados set Nombre='" + textBox1.Text + "',Departamento='" + comboDepto.SelectedItem + "',Baja="+baja+" " +
                    "where NoEmp=" + Clases.Variables.IdEmpleados + "";

                bool resultado = Clases.Inserciones.Ejecucion(SqlString);
                if (resultado == true)
                {
                    MessageBox.Show("Empleado modificado correctamente");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ha ocurrido un error inesperado");
            }
            else
                MessageBox.Show("Todos los campos deben contener un valor valido");
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            if (Clases.Variables.EmpleadosBaja == "True")
            {
                checkBaja.Checked = false;
            }
            else
            {
                checkBaja.Visible = false;
            }
               
            textBox1.Text = Clases.Variables.EmpleadosNombre;
            Clases.Empleados.CBDeptos(comboDepto);
            int index = comboDepto.FindString(Clases.Variables.EmpleadosDepto);
            comboDepto.SelectedIndex = index;
        }
    }
}
