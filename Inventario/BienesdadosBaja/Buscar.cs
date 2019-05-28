using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInventario.Inventario.BienesdadosBaja
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Factura.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT Id, Etiqueta, NoOrden,NoFactura, Precio, Articulo, Departamento,Empleado," +
            " FechaCompra,FechaBaja, Marca, Serie, Modelo, MotivoBaja,Observacion FROM BienesBaja where NoFactura = '" + CBBuscar.Text + "'";
            else if (Etiqueta.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT Id, Etiqueta, NoOrden,NoFactura, Precio, Articulo, Departamento,Empleado," +
            " FechaCompra,FechaBaja, Marca, Serie, Modelo, MotivoBaja,Observacion FROM BienesBaja where Etiqueta = '" + CBBuscar.Text + "'";
            else if (Empleado.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT Id, Etiqueta, NoOrden,NoFactura, Precio, Articulo, Departamento,Empleado," +
            " FechaCompra,FechaBaja, Marca, Serie, Modelo, MotivoBaja,Observacion FROM BienesBaja where Empleado = '" + CBBuscar.Text + "'";
            else if (Motivo.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT Id, Etiqueta, NoOrden,NoFactura, Precio, Articulo, Departamento,Empleado," +
            " FechaCompra,FechaBaja, Marca, Serie, Modelo, MotivoBaja,Observacion FROM BienesBaja where MotivoBaja = '" + CBBuscar.Text + "'";
            else if (Articulo.Checked == true)
                Clases.Variables.ConsultaBuscar = "SELECT Id, Etiqueta, NoOrden,NoFactura, Precio, Articulo, Departamento,Empleado," +
            " FechaCompra,FechaBaja, Marca, Serie, Modelo, MotivoBaja,Observacion FROM BienesBaja where Articulo = '" + CBBuscar.Text + "'";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Todo_Click(object sender, EventArgs e)
        {
            Clases.Variables.ConsultaBuscar = "SELECT Id, Etiqueta, NoOrden,NoFactura, Precio, Articulo, Departamento,Empleado," +
            " FechaCompra,FechaBaja, Marca, Serie, Modelo, MotivoBaja,Observacion FROM BienesBaja";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Etiqueta_CheckedChanged(object sender, EventArgs e)
        {
            if (Etiqueta.Checked == true)
                Clases.BienesBaja.CBEtiqueta(CBBuscar);
        }

        private void Articulo_CheckedChanged(object sender, EventArgs e)
        {
            if (Articulo.Checked == true)
                Clases.BienesBaja.CBArticulo(CBBuscar);
        }

        private void Empleado_CheckedChanged(object sender, EventArgs e)
        {
            if (Empleado.Checked == true)
                Clases.BienesBaja.CBEmleado(CBBuscar);
        }

        private void Motivo_CheckedChanged(object sender, EventArgs e)
        {
            if (Motivo.Checked == true)
                Clases.BienesBaja.CBMotivo(CBBuscar);
        }

        private void Factura_CheckedChanged(object sender, EventArgs e)
        {
            if (Factura.Checked == true)
                Clases.BienesBaja.CBFactura(CBBuscar);
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            Clases.BienesBaja.CBEtiqueta(CBBuscar);
        }
    }
}
