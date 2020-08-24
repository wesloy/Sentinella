namespace Sentinella.Forms {
    partial class frmLocalizarGestoresGrupos {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dgvInfoAssociados = new System.Windows.Forms.DataGridView();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.cbxTipoBusca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoAssociados)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInfoAssociados
            // 
            this.dgvInfoAssociados.BackgroundColor = System.Drawing.Color.White;
            this.dgvInfoAssociados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInfoAssociados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoAssociados.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvInfoAssociados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfoAssociados.GridColor = System.Drawing.Color.PaleTurquoise;
            this.dgvInfoAssociados.Location = new System.Drawing.Point(0, 62);
            this.dgvInfoAssociados.Name = "dgvInfoAssociados";
            this.dgvInfoAssociados.Size = new System.Drawing.Size(1071, 388);
            this.dgvInfoAssociados.TabIndex = 10;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.AutoScroll = true;
            this.pnlFiltros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlFiltros.Controls.Add(this.lbTotal);
            this.pnlFiltros.Controls.Add(this.cbxTipoBusca);
            this.pnlFiltros.Controls.Add(this.label3);
            this.pnlFiltros.Controls.Add(this.btnCancelar);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1071, 62);
            this.pnlFiltros.TabIndex = 11;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(468, 36);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(76, 13);
            this.lbTotal.TabIndex = 10;
            this.lbTotal.Text = "Total listado: 0";
            // 
            // cbxTipoBusca
            // 
            this.cbxTipoBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoBusca.FormattingEnabled = true;
            this.cbxTipoBusca.Items.AddRange(new object[] {
            "NÃO É GESTOR",
            "GESTOR 1",
            "GESTOR 2",
            "GESTOR 3",
            "GESTOR 4",
            "GESTOR 5"});
            this.cbxTipoBusca.Location = new System.Drawing.Point(119, 4);
            this.cbxTipoBusca.Name = "cbxTipoBusca";
            this.cbxTipoBusca.Size = new System.Drawing.Size(269, 21);
            this.cbxTipoBusca.TabIndex = 9;
            this.cbxTipoBusca.Tag = "Tipo de Busca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nível Hierarquico:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(238, 31);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(313, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmLocalizarGestoresGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 450);
            this.Controls.Add(this.dgvInfoAssociados);
            this.Controls.Add(this.pnlFiltros);
            this.Name = "frmLocalizarGestoresGrupos";
            this.Text = "frmLocalizarGestoresGrupos";
            this.Load += new System.EventHandler(this.frmLocalizarGestoresGrupos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoAssociados)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInfoAssociados;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.ComboBox cbxTipoBusca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lbTotal;
    }
}