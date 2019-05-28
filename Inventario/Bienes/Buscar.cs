using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Inventario.Bienes
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private void Etiqueta_CheckedChanged(object sender, EventArgs e)
        {
            if (Etiqueta.Checked == true)
            {
                CBBuscar.Items.Clear();
                CBBuscar.Text = "";
            }
        }

        private void Articulo_CheckedChanged(object sender, EventArgs e)
        {
            if (Articulo.Checked == true)
                Clases.Articulos.CBBuscarArticulo(CBBuscar);
        }

        private void Empleado_CheckedChanged(object sender, EventArgs e)
        {
            if (Empleado.Checked == true)
                Clases.Empleados.CBNombre(CBBuscar);
        }

        private void Familia_CheckedChanged(object sender, EventArgs e)
        {
            if (Familia.Checked == true)
                Clases.Articulos.CBArticulosFamilia(CBBuscar);
        }

        private void Proveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (Proveedor.Checked == true)
                Clases.Bienes.CBProveedor(CBBuscar);
        }

        private void Factura_CheckedChanged(object sender, EventArgs e)
        {
            if (Factura.Checked == true)
                Clases.Bienes.CBFactura(CBBuscar);
        }

        private void Departamento_CheckedChanged(object sender, EventArgs e)
        {
            if (Departamento.Checked == true)
                Clases.Bienes.CBDeptos(CBBuscar);
        }

        private void Orden_CheckedChanged(object sender, EventArgs e)
        {
            if (Orden.Checked == true)
            {
                CBBuscar.Items.Clear();
                CBBuscar.Text = "";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Etiqueta.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento, proveedores.nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id where bienes.Etiqueta = '" + CBBuscar.Text + "'";
            else if (Articulo.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento,Proveedores.Nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id where Articulos.Descripcion='" + CBBuscar.Text + "'";
            else if (Empleado.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento,Proveedores.Nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id where empleados.Nombre = '" + CBBuscar.Text + "'";
            else if (Departamento.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento, Proveedores.Nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id where empleados.Departamento = '" + CBBuscar.Text + "'";
            else if (Factura.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento, Proveedores.Nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id where bienes.NoFactura='" + CBBuscar.Text + "'";
            else if (Proveedor.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento,  Proveedores.Nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id where Proveedores.Nombre = '" + CBBuscar.Text + "'";
            else if (Familia.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento, Proveedores.Nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id where Familia.Descripcion = '" + CBBuscar.Text + "'";
            else if (Orden.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento, Proveedores.Nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id where NoOrden='" + CBBuscar.Text + "'";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Todo_Click(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "SELECT bienes.Id, bienes.Etiqueta, bienes.NoOrden, bienes.NoFactura,bienes.serie as Serie, " +
                "bienes.precio, Familia.Descripcion as Familia, Articulos.Descripcion AS Articulo, empleados.Nombre AS Empleado," +
                "empleados.Departamento,Proveedores.Nombre AS Proveedor,bienes." +
                "Observacion AS Observacion FROM bienes INNER JOIN empleados ON bienes.NoEmpleado = empleados.NoEmp " +
                "INNER JOIN Articulos ON bienes.IdArticulo = Articulos.Id INNER JOIN Familia ON " +
                "Articulos.IdFamilia = Familia.Id INNER JOIN Proveedores on bienes.IdProveedor=Proveedores.Id";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
