namespace Sentinella.Forms {
    partial class frmLocalizarInformacoesAD {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalizarInformacoesAD));
            this.dgvInfoAD = new System.Windows.Forms.DataGridView();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.tb_selecaoFuncao = new System.Windows.Forms.TabControl();
            this.tpInformacoesAD = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorPersonalizado = new System.Windows.Forms.TextBox();
            this.cbxCampoPersonalizado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtInfoOU = new System.Windows.Forms.TextBox();
            this.tpGAP = new System.Windows.Forms.TabPage();
            this.cbxValorBuscaGAP = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxCampoFiltroGAP = new System.Windows.Forms.ComboBox();
            this.cbxPastas = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoAD)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.tb_selecaoFuncao.SuspendLayout();
            this.tpInformacoesAD.SuspendLayout();
            this.tpGAP.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInfoAD
            // 
            this.dgvInfoAD.BackgroundColor = System.Drawing.Color.White;
            this.dgvInfoAD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInfoAD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfoAD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvInfoAD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfoAD.GridColor = System.Drawing.Color.PaleTurquoise;
            this.dgvInfoAD.Location = new System.Drawing.Point(0, 195);
            this.dgvInfoAD.Name = "dgvInfoAD";
            this.dgvInfoAD.Size = new System.Drawing.Size(1114, 439);
            this.dgvInfoAD.TabIndex = 8;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.AutoScroll = true;
            this.pnlFiltros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlFiltros.Controls.Add(this.tb_selecaoFuncao);
            this.pnlFiltros.Controls.Add(this.btnCancelar);
            this.pnlFiltros.Controls.Add(this.btnBuscar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1114, 195);
            this.pnlFiltros.TabIndex = 9;
            // 
            // tb_selecaoFuncao
            // 
            this.tb_selecaoFuncao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_selecaoFuncao.Controls.Add(this.tpInformacoesAD);
            this.tb_selecaoFuncao.Controls.Add(this.tpGAP);
            this.tb_selecaoFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_selecaoFuncao.Location = new System.Drawing.Point(0, 12);
            this.tb_selecaoFuncao.Name = "tb_selecaoFuncao";
            this.tb_selecaoFuncao.SelectedIndex = 0;
            this.tb_selecaoFuncao.Size = new System.Drawing.Size(1114, 148);
            this.tb_selecaoFuncao.TabIndex = 42;
            this.tb_selecaoFuncao.SelectedIndexChanged += new System.EventHandler(this.tb_selecaoFuncao_SelectedIndexChanged);
            // 
            // tpInformacoesAD
            // 
            this.tpInformacoesAD.Controls.Add(this.label7);
            this.tpInformacoesAD.Controls.Add(this.label6);
            this.tpInformacoesAD.Controls.Add(this.txtValorPersonalizado);
            this.tpInformacoesAD.Controls.Add(this.cbxCampoPersonalizado);
            this.tpInformacoesAD.Controls.Add(this.label5);
            this.tpInformacoesAD.Controls.Add(this.label4);
            this.tpInformacoesAD.Controls.Add(this.label3);
            this.tpInformacoesAD.Controls.Add(this.label2);
            this.tpInformacoesAD.Controls.Add(this.label1);
            this.tpInformacoesAD.Controls.Add(this.txtMatricula);
            this.tpInformacoesAD.Controls.Add(this.txtNomeUsuario);
            this.tpInformacoesAD.Controls.Add(this.txtCPF);
            this.tpInformacoesAD.Controls.Add(this.txtInfoOU);
            this.tpInformacoesAD.Location = new System.Drawing.Point(4, 22);
            this.tpInformacoesAD.Name = "tpInformacoesAD";
            this.tpInformacoesAD.Padding = new System.Windows.Forms.Padding(3);
            this.tpInformacoesAD.Size = new System.Drawing.Size(1106, 122);
            this.tpInformacoesAD.TabIndex = 0;
            this.tpInformacoesAD.Text = ".: Informações AD :.";
            this.tpInformacoesAD.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Campo Personalizado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Valor";
            // 
            // txtValorPersonalizado
            // 
            this.txtValorPersonalizado.Location = new System.Drawing.Point(471, 74);
            this.txtValorPersonalizado.Name = "txtValorPersonalizado";
            this.txtValorPersonalizado.Size = new System.Drawing.Size(193, 20);
            this.txtValorPersonalizado.TabIndex = 44;
            // 
            // cbxCampoPersonalizado
            // 
            this.cbxCampoPersonalizado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCampoPersonalizado.FormattingEnabled = true;
            this.cbxCampoPersonalizado.Location = new System.Drawing.Point(123, 73);
            this.cbxCampoPersonalizado.Name = "cbxCampoPersonalizado";
            this.cbxCampoPersonalizado.Size = new System.Drawing.Size(300, 21);
            this.cbxCampoPersonalizado.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(670, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "{Separados por  vírgula}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Matrícula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "CPF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Informações OU";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(297, 47);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(126, 20);
            this.txtMatricula.TabIndex = 41;
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.Location = new System.Drawing.Point(471, 47);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.Size = new System.Drawing.Size(193, 20);
            this.txtNomeUsuario.TabIndex = 42;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(123, 47);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(110, 20);
            this.txtCPF.TabIndex = 40;
            // 
            // txtInfoOU
            // 
            this.txtInfoOU.Location = new System.Drawing.Point(123, 21);
            this.txtInfoOU.Name = "txtInfoOU";
            this.txtInfoOU.Size = new System.Drawing.Size(541, 20);
            this.txtInfoOU.TabIndex = 39;
            // 
            // tpGAP
            // 
            this.tpGAP.Controls.Add(this.cbxValorBuscaGAP);
            this.tpGAP.Controls.Add(this.label10);
            this.tpGAP.Controls.Add(this.label9);
            this.tpGAP.Controls.Add(this.cbxCampoFiltroGAP);
            this.tpGAP.Controls.Add(this.cbxPastas);
            this.tpGAP.Location = new System.Drawing.Point(4, 22);
            this.tpGAP.Name = "tpGAP";
            this.tpGAP.Padding = new System.Windows.Forms.Padding(3);
            this.tpGAP.Size = new System.Drawing.Size(1106, 122);
            this.tpGAP.TabIndex = 1;
            this.tpGAP.Text = ".: Grupo AD X Associados X Pastas :.";
            this.tpGAP.UseVisualStyleBackColor = true;
            // 
            // cbxValorBuscaGAP
            // 
            this.cbxValorBuscaGAP.FormattingEnabled = true;
            this.cbxValorBuscaGAP.Location = new System.Drawing.Point(115, 41);
            this.cbxValorBuscaGAP.Name = "cbxValorBuscaGAP";
            this.cbxValorBuscaGAP.Size = new System.Drawing.Size(300, 21);
            this.cbxValorBuscaGAP.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(75, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Valor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Campo a ser filtrado:";
            // 
            // cbxCampoFiltroGAP
            // 
            this.cbxCampoFiltroGAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCampoFiltroGAP.FormattingEnabled = true;
            this.cbxCampoFiltroGAP.Items.AddRange(new object[] {
            "NOME DO GRUPO",
            "NOME DO ASSOCIADO",
            "DISCO",
            "DIRETORIO",
            "PASTA"});
            this.cbxCampoFiltroGAP.Location = new System.Drawing.Point(115, 16);
            this.cbxCampoFiltroGAP.Name = "cbxCampoFiltroGAP";
            this.cbxCampoFiltroGAP.Size = new System.Drawing.Size(300, 21);
            this.cbxCampoFiltroGAP.TabIndex = 49;
            this.cbxCampoFiltroGAP.SelectionChangeCommitted += new System.EventHandler(this.cbxCampoFiltroGAP_SelectionChangeCommitted);
            // 
            // cbxPastas
            // 
            this.cbxPastas.AutoSize = true;
            this.cbxPastas.Location = new System.Drawing.Point(115, 68);
            this.cbxPastas.Name = "cbxPastas";
            this.cbxPastas.Size = new System.Drawing.Size(89, 17);
            this.cbxPastas.TabIndex = 47;
            this.cbxPastas.Text = "Incluir Pastas";
            this.cbxPastas.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(960, 162);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(1035, 162);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 27);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmLocalizarInformacoesAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 634);
            this.Controls.Add(this.dgvInfoAD);
            this.Controls.Add(this.pnlFiltros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocalizarInformacoesAD";
            this.Text = ".: Localizar Informações AD :.";
            this.Load += new System.EventHandler(this.frmLocalizarInformacoesAD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLocalizarInformacoesAD_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfoAD)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.tb_selecaoFuncao.ResumeLayout(false);
            this.tpInformacoesAD.ResumeLayout(false);
            this.tpInformacoesAD.PerformLayout();
            this.tpGAP.ResumeLayout(false);
            this.tpGAP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInfoAD;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabControl tb_selecaoFuncao;
        private System.Windows.Forms.TabPage tpInformacoesAD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValorPersonalizado;
        private System.Windows.Forms.ComboBox cbxCampoPersonalizado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtInfoOU;
        private System.Windows.Forms.TabPage tpGAP;
        private System.Windows.Forms.ComboBox cbxValorBuscaGAP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxCampoFiltroGAP;
        private System.Windows.Forms.CheckBox cbxPastas;
    }
}