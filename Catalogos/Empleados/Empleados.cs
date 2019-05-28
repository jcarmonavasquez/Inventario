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

namespace ProyectoInventario.Catalogos.Empleados
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "select NoEmp,Nombre,Departamento,Baja from empleados";
            Clases.LLenadoGrids.llenarGrid(GVEmpleados, Clases.Variables.ConsultaBuscar, "Empleados");
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Catalogos.Empleados.Nuevo nuevo = new Catalogos.Empleados.Nuevo();
            nuevo.ShowDialog();
            if (nuevo.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVEmpleados, Clases.Variables.ConsultaBuscar, "empleados");
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Catalogos.Empleados.Modificar modificar = new Catalogos.Empleados.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVEmpleados, Clases.Variables.ConsultaBuscar, "empleados");
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            Catalogos.Empleados.Buscar buscar = new Catalogos.Empleados.Buscar();
            buscar.ShowDialog();
            if (buscar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVEmpleados, Clases.Variables.ConsultaBuscar, "empleados");
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            Confirmar confirmacion = new Confirmar();
            confirmacion.ShowDialog();
            if (confirmacion.DialogResult == DialogResult.OK)
            {
                if (Clases.Variables.EmpleadosBaja == "False")
                {
                    string ConnString = Clases.Variables.conexion;
                    string SqlString = "Update empleados set Baja=1 where NoEmp=" + Clases.Variables.IdEmpleados;
                    try
                    {
                        SqlConnection conn = new SqlConnection(ConnString);
                        SqlCommand cmd = new SqlCommand(SqlString, conn);
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Empleado dado de baja correctamente.");
                        Clases.LLenadoGrids.llenarGrid(GVEmpleados, Clases.Variables.ConsultaBuscar, "empleados");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El valor seleccionado no es valido. \n" + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("El Empleado ya esta dado de baja");
                }

            }
        }

        private void GVEmpleados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.Variables.IdEmpleados = GVEmpleados.CurrentRow.Cells[0].Value.ToString();
            Clases.Variables.EmpleadosNombre = GVEmpleados.CurrentRow.Cells[1].Value.ToString();
            Clases.Variables.EmpleadosDepto = GVEmpleados.CurrentRow.Cells[2].Value.ToString();
            Clases.Variables.EmpleadosBaja = GVEmpleados.CurrentRow.Cells[3].Value.ToString();
        }

        private void GVEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Catalogos.Empleados.Modificar modificar = new Catalogos.Empleados.Modificar();
            modificar.ShowDialog();
            if (modificar.DialogResult == DialogResult.OK)
                Clases.LLenadoGrids.llenarGrid(GVEmpleados, Clases.Variables.ConsultaBuscar, "empleados");
        }
    }
}
