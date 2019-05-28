namespace ProyectoInventario.Reportes.ValorBienes
{
    partial class ValorBienes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Buscar = new System.Windows.Forms.ToolStripButton();
            this.Excel = new System.Windows.Forms.ToolStripButton();
            this.GVBienesValor = new System.Windows.Forms.DataGridView();
            this.LBTotalBienes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVBienesValor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Buscar,
            this.Excel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(800, 45);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Buscar
            // 
            this.Buscar.AutoSize = false;
            this.Buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Buscar.Image = global::ProyectoInventario.Properties.Resources.buscar;
            this.Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(50, 50);
            this.Buscar.Text = "toolStripButton1";
            this.Buscar.ToolTipText = "Buscar";
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // Excel
            // 
            this.Excel.AutoSize = false;
            this.Excel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Excel.Image = global::ProyectoInventario.Properties.Resources.excel;
            this.Excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Excel.Name = "Excel";
            this.Excel.Size = new System.Drawing.Size(50, 50);
            this.Excel.Text = "toolStripButton2";
            this.Excel.ToolTipText = "Importar a Excel";
            this.Excel.Click += new System.EventHandler(this.Excel_Click);
            // 
            // GVBienesValor
            // 
            this.GVBienesValor.AllowUserToAddRows = false;
            this.GVBienesValor.AllowUserToDeleteRows = false;
            this.GVBienesValor.AllowUserToOrderColumns = true;
            this.GVBienesValor.AllowUserToResizeColumns = false;
            this.GVBienesValor.AllowUserToResizeRows = false;
            this.GVBienesValor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.GVBienesValor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GVBienesValor.BackgroundColor = System.Drawing.Color.White;
            this.GVBienesValor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GVBienesValor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVBienesValor.Location = new System.Drawing.Point(0, 48);
            this.GVBienesValor.Name = "GVBienesValor";
            this.GVBienesValor.ReadOnly = true;
            this.GVBienesValor.Size = new System.Drawing.Size(800, 470);
            this.GVBienesValor.TabIndex = 11;
            this.GVBienesValor.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVBienesValor_CellEnter);
            // 
            // LBTotalBienes
            // 
            this.LBTotalBienes.AutoSize = true;
            this.LBTotalBienes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTotalBienes.Location = new System.Drawing.Point(510, 580);
            this.LBTotalBienes.Name = "LBTotalBienes";
            this.LBTotalBienes.Size = new System.Drawing.Size(0, 19);
            this.LBTotalBienes.TabIndex = 14;
            this.LBTotalBienes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, 580);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Total de bienes :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 580);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Total en bienes :";
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.Location = new System.Drawing.Point(137, 580);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(0, 19);
            this.Total.TabIndex = 15;
            // 
            // ValorBienes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 608);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.LBTotalBienes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GVBienesValor);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ValorBienes";
            this.Text = "ValorBienes";
            this.Load += new System.EventHandler(this.ValorBienes_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVBienesValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Buscar;
        private System.Windows.Forms.ToolStripButton Excel;
        private System.Windows.Forms.DataGridView GVBienesValor;
        private System.Windows.Forms.Label LBTotalBienes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Total;
    }
}