namespace Sentinella.Forms {
    partial class frmRFPs {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRFPs));
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtClienteFinal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lvRFPs = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.dtpDataEnvioResposta = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpTempoTotalAnalise = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.rbLuva = new System.Windows.Forms.RadioButton();
            this.rbEmail = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDemandante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFiltros.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.pnlConteudo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.AutoScroll = true;
            this.pnlFiltros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlFiltros.Controls.Add(this.label23);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(976, 57);
            this.pnlFiltros.TabIndex = 27;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(720, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(253, 26);
            this.label23.TabIndex = 74;
            this.label23.Text = "# Controles de RFPs #";
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnIncluir);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 751);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBotoes.Size = new System.Drawing.Size(976, 57);
            this.pnlBotoes.TabIndex = 28;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.Location = new System.Drawing.Point(715, 15);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(83, 30);
            this.btnExcluir.TabIndex = 1;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(881, 15);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAlterar.Location = new System.Drawing.Point(798, 15);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(83, 30);
            this.btnAlterar.TabIndex = 2;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(632, 15);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(83, 30);
            this.btnIncluir.TabIndex = 0;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIncluir.UseVisualStyleBackColor = true;
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.White;
            this.pnlConteudo.Controls.Add(this.label11);
            this.pnlConteudo.Controls.Add(this.txtClienteFinal);
            this.pnlConteudo.Controls.Add(this.label10);
            this.pnlConteudo.Controls.Add(this.lvRFPs);
            this.pnlConteudo.Controls.Add(this.label9);
            this.pnlConteudo.Controls.Add(this.txtObservacao);
            this.pnlConteudo.Controls.Add(this.label8);
            this.pnlConteudo.Controls.Add(this.txtResponsavel);
            this.pnlConteudo.Controls.Add(this.dtpDataEnvioResposta);
            this.pnlConteudo.Controls.Add(this.label7);
            this.pnlConteudo.Controls.Add(this.dtpTempoTotalAnalise);
            this.pnlConteudo.Controls.Add(this.label6);
            this.pnlConteudo.Controls.Add(this.rbLuva);
            this.pnlConteudo.Controls.Add(this.rbEmail);
            this.pnlConteudo.Controls.Add(this.label5);
            this.pnlConteudo.Controls.Add(this.txtTitulo);
            this.pnlConteudo.Controls.Add(this.label3);
            this.pnlConteudo.Controls.Add(this.cbxTipoDocumento);
            this.pnlConteudo.Controls.Add(this.dtpData);
            this.pnlConteudo.Controls.Add(this.label4);
            this.pnlConteudo.Controls.Add(this.dtpHora);
            this.pnlConteudo.Controls.Add(this.label2);
            this.pnlConteudo.Controls.Add(this.txtDemandante);
            this.pnlConteudo.Controls.Add(this.label1);
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 0);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(976, 808);
            this.pnlConteudo.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Cliente Final:";
            // 
            // txtClienteFinal
            // 
            this.txtClienteFinal.Location = new System.Drawing.Point(8, 236);
            this.txtClienteFinal.Name = "txtClienteFinal";
            this.txtClienteFinal.Size = new System.Drawing.Size(303, 20);
            this.txtClienteFinal.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(322, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Histórico RFPs:";
            // 
            // lvRFPs
            // 
            this.lvRFPs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRFPs.HideSelection = false;
            this.lvRFPs.Location = new System.Drawing.Point(325, 156);
            this.lvRFPs.Name = "lvRFPs";
            this.lvRFPs.Size = new System.Drawing.Size(629, 547);
            this.lvRFPs.TabIndex = 47;
            this.lvRFPs.UseCompatibleStateImageBehavior = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 529);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Observações:";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtObservacao.Location = new System.Drawing.Point(8, 547);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(303, 156);
            this.txtObservacao.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 481);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(183, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Responsável Segurança Informação:";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Location = new System.Drawing.Point(8, 497);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(303, 20);
            this.txtResponsavel.TabIndex = 43;
            // 
            // dtpDataEnvioResposta
            // 
            this.dtpDataEnvioResposta.Location = new System.Drawing.Point(8, 454);
            this.dtpDataEnvioResposta.Name = "dtpDataEnvioResposta";
            this.dtpDataEnvioResposta.Size = new System.Drawing.Size(303, 20);
            this.dtpDataEnvioResposta.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 438);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Data de Envio da Resposta:";
            // 
            // dtpTempoTotalAnalise
            // 
            this.dtpTempoTotalAnalise.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTempoTotalAnalise.Location = new System.Drawing.Point(8, 409);
            this.dtpTempoTotalAnalise.Name = "dtpTempoTotalAnalise";
            this.dtpTempoTotalAnalise.Size = new System.Drawing.Size(303, 20);
            this.dtpTempoTotalAnalise.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Tempo Total Gasto na Análise:";
            // 
            // rbLuva
            // 
            this.rbLuva.AutoSize = true;
            this.rbLuva.Location = new System.Drawing.Point(12, 113);
            this.rbLuva.Name = "rbLuva";
            this.rbLuva.Size = new System.Drawing.Size(49, 17);
            this.rbLuva.TabIndex = 38;
            this.rbLuva.TabStop = true;
            this.rbLuva.Text = "Luva";
            this.rbLuva.UseVisualStyleBackColor = true;
            // 
            // rbEmail
            // 
            this.rbEmail.AutoSize = true;
            this.rbEmail.Location = new System.Drawing.Point(12, 90);
            this.rbEmail.Name = "rbEmail";
            this.rbEmail.Size = new System.Drawing.Size(53, 17);
            this.rbEmail.TabIndex = 37;
            this.rbEmail.TabStop = true;
            this.rbEmail.Text = "E-mail";
            this.rbEmail.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Título do e-mail / Luva:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(8, 156);
            this.txtTitulo.Multiline = true;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(303, 58);
            this.txtTitulo.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tipo de Documento:";
            // 
            // cbxTipoDocumento
            // 
            this.cbxTipoDocumento.FormattingEnabled = true;
            this.cbxTipoDocumento.Location = new System.Drawing.Point(8, 278);
            this.cbxTipoDocumento.Name = "cbxTipoDocumento";
            this.cbxTipoDocumento.Size = new System.Drawing.Size(303, 21);
            this.cbxTipoDocumento.TabIndex = 33;
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(8, 322);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(217, 20);
            this.dtpData.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Data/Hora Recebimento:";
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(231, 322);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(80, 20);
            this.dtpHora.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Demandante:";
            // 
            // txtDemandante
            // 
            this.txtDemandante.Location = new System.Drawing.Point(8, 365);
            this.txtDemandante.Name = "txtDemandante";
            this.txtDemandante.Size = new System.Drawing.Size(303, 20);
            this.txtDemandante.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Meio de Entrada:";
            // 
            // frmRFPs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 808);
            this.Controls.Add(this.pnlBotoes);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlConteudo);
            this.Name = "frmRFPs";
            this.Text = "frmRFPs";
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlConteudo.ResumeLayout(false);
            this.pnlConteudo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlFiltros;
        internal System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel pnlBotoes;
        internal System.Windows.Forms.Button btnExcluir;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAlterar;
        internal System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtClienteFinal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvRFPs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.DateTimePicker dtpDataEnvioResposta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpTempoTotalAnalise;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbLuva;
        private System.Windows.Forms.RadioButton rbEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxTipoDocumento;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDemandante;
        private System.Windows.Forms.Label label1;
    }
}