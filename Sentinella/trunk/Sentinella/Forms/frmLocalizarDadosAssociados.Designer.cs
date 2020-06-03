namespace Sentinella.Forms {
    partial class frmLocalizarDadosAssociados {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalizarDadosAssociados));
            this.dgvInfoAssociados = new System.Windows.Forms.DataGridView();
            this.txtValorBusca = new System.Windows.Forms.TextBox();
            this.cbxTipoBusca = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlConteudo = new System.Windows.Forms.Panel();
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
            this.dgvInfoAssociados.Location = new System.Drawing.Point(0, 74);
            this.dgvInfoAssociados.Name = "dgvInfoAssociados";
            this.dgvInfoAssociados.Size = new System.Drawing.Size(940, 429);
            this.dgvInfoAssociados.TabIndex = 2;
            // 
            // txtValorBusca
            // 
            this.txtValorBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorBusca.Location = new System.Drawing.Point(118, 26);
            this.txtValorBusca.Name = "txtValorBusca";
            this.txtValorBusca.Size = new System.Drawing.Size(270, 20);
            this.txtValorBusca.TabIndex = 1;
            this.txtValorBusca.Tag = "Valor de Busca";
            // 
            // cbxTipoBusca
            // 
            this.cbxTipoBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoBusca.FormattingEnabled = true;
            this.cbxTipoBusca.Items.AddRange(new object[] {
            "CPF",
            "MATRÍCULA",
            "NOME ASSOCIADO"});
            this.cbxTipoBusca.Location = new System.Drawing.Point(118, 4);
            this.cbxTipoBusca.Name = "cbxTipoBusca";
            this.cbxTipoBusca.Size = new System.Drawing.Size(269, 21);
            this.cbxTipoBusca.TabIndex = 0;
            this.cbxTipoBusca.Tag = "Tipo de Busca";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(313, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(238, 48);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.AutoScroll = true;
            this.pnlFiltros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlFiltros.Controls.Add(this.label1);
            this.pnlFiltros.Controls.Add(this.label3);
            this.pnlFiltros.Controls.Add(this.btnCancelar);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(940, 74);
            this.pnlFiltros.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Valor de busca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo de busca:";
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.White;
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 74);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(940, 429);
            this.pnlConteudo.TabIndex = 8;
            // 
            // frmLocalizarDadosAssociados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(940, 503);
            this.Controls.Add(this.cbxTipoBusca);
            this.Controls.Add(this.txtValorBusca);
            this.Controls.Add(this.dgvInfoAssociados);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlFiltros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocalizarDadosAssociados";
            this.Text = ".: Localizar Informações de Associações :.";
            this.Load += new System.EventHandler(this.frmLocalizarDadosAssociados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoAssociados)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInfoAssociados;
        private System.Windows.Forms.TextBox txtValorBusca;
        private System.Windows.Forms.ComboBox cbxTipoBusca;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}