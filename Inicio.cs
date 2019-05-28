using System;
using System.Windows.Forms;

namespace ProyectoInventario
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }
        private void formularios(object hijo)
        {
            if (this.PanelBase.Controls.Count > 0)
            {
                this.PanelBase.Controls.RemoveAt(0);
            }
            Form hi = hijo as Form;
            hi.TopLevel = false;
            hi.FormBorderStyle = FormBorderStyle.None;
            hi.Dock = DockStyle.Fill;
            this.PanelBase.Controls.Add(hi);
            this.PanelBase.Tag = hi;
            hi.Show();
        }
        private void EmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios(new Catalogos.Empleados.Empleados());
            this.Text = "Inventario - Empleados";
        }

        private void ArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios(new Catalogos.Articulos.Articulos());
            this.Text = "Inventario - Articulos";
        }

        private void FamiliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios(new Catalogos.Familias.Familias());
            this.Text = "Inventario - Familias";
        }

        private void MarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios(new Catalogos.Marcas.Marcas());
            this.Text = "Inventario - Marcas";
        }

        private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios(new Catalogos.Proveedores.Proveedores());
            this.Text = "Inventario - Proveedores";
        }

        private void Bienes_Click(object sender, EventArgs e)
        {
            formularios(new Inventario.Bienes.Bienes());
            this.Text = "Inventario - Bienes";
        }

        private void BienesBaja_Click(object sender, EventArgs e)
        {
            formularios(new Inventario.BienesdadosBaja.BienesdadosBaja());
            this.Text = "Inventario - Bienes dados de baja";
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            this.Text = "SISTEMA DE INVENTARIO";
        }

        private void ValorenBienes_Click(object sender, EventArgs e)
        {
            formularios(new Reportes.ValorBienes.ValorBienes());
            this.Text = "Inventario - Valor en Bienes";
        }

        private void ConfiguracionBD_Click(object sender, EventArgs e)
        {
            Configuracion.ConfiguracionBD configuracionBD = new Configuracion.ConfiguracionBD();
            configuracionBD.ShowDialog();
        }

        private void DepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularios(new Catalogos.Departamentos.Departamentos());
            this.Text = "Inventario - Departamentos";
        }

        private void InicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.PanelBase.Controls.Count > 0)
            {
                this.PanelBase.Controls.RemoveAt(0);
            }
            PanelBase.BackgroundImage = ProyectoInventario.Properties.Resources.fondo;
            this.Text = "SISTEMA DE INVENTARIO";
        }
    }
}
