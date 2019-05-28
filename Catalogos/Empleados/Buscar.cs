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
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private void MostrarTodo_Click(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "select * from empleados";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void RadioNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNombre.Checked == true)
                Clases.Empleados.CBNombre(comboBuscar);
        }

        private void RadioDeptos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDeptos.Checked == true)
                Clases.Empleados.CBDeptos(comboBuscar);
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            Clases.Empleados.CBNombre(comboBuscar);
        }

        private void Buscarr_Click(object sender, EventArgs e)
        {
            if (radioNombre.Checked == true)
            {
                Clases.Variables.ConsultaBuscar = "select NoEmp, Nombre, Departamento,Baja " +
                            "from empleados where Nombre = '" + comboBuscar.Text + "'";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (radioDeptos.Checked == true)
            {
                Clases.Variables.ConsultaBuscar = "select NoEmp, Nombre, Departamento,Baja " +
                            "from empleados where departamento = '" + comboBuscar.Text + "'";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
