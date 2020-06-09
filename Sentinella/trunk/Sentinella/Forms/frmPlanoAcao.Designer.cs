namespace Sentinella.Forms {
    partial class frmPlanoAcao {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanoAcao));
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.lvPlanoAcao = new System.Windows.Forms.ListView();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEmailDestinatario = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEmailTitulo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lbFiltroPorStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pbVerdeConcluido = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pbAzulForaPeriodo = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pbAmareloFerias = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPretoAfastado = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbVermelhoPendente = new System.Windows.Forms.PictureBox();
            this.pnlConteudo.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerdeConcluido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAzulForaPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAmareloFerias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPretoAfastado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVermelhoPendente)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.White;
            this.pnlConteudo.Controls.Add(this.txtEmailTitulo);
            this.pnlConteudo.Controls.Add(this.label15);
            this.pnlConteudo.Controls.Add(this.label7);
            this.pnlConteudo.Controls.Add(this.txtMensagem);
            this.pnlConteudo.Controls.Add(this.label13);
            this.pnlConteudo.Controls.Add(this.txtEmailDestinatario);
            this.pnlConteudo.Controls.Add(this.label14);
            this.pnlConteudo.Controls.Add(this.lvPlanoAcao);
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 71);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(1261, 480);
            this.pnlConteudo.TabIndex = 5;
            // 
            // lvPlanoAcao
            // 
            this.lvPlanoAcao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPlanoAcao.BackColor = System.Drawing.Color.White;
            this.lvPlanoAcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvPlanoAcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPlanoAcao.HideSelection = false;
            this.lvPlanoAcao.Location = new System.Drawing.Point(12, 235);
            this.lvPlanoAcao.Name = "lvPlanoAcao";
            this.lvPlanoAcao.Size = new System.Drawing.Size(1237, 239);
            this.lvPlanoAcao.TabIndex = 6;
            this.lvPlanoAcao.UseCompatibleStateImageBehavior = false;
            this.lvPlanoAcao.View = System.Windows.Forms.View.SmallIcon;
            this.lvPlanoAcao.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvPlanoAcao_ColumnClick);
            this.lvPlanoAcao.DoubleClick += new System.EventHandler(this.lvPlanoAcao_DoubleClick);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.AutoScroll = true;
            this.pnlFiltros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlFiltros.Controls.Add(this.label1);
            this.pnlFiltros.Controls.Add(this.dtpInicial);
            this.pnlFiltros.Controls.Add(this.dtpFinal);
            this.pnlFiltros.Controls.Add(this.label23);
            this.pnlFiltros.Controls.Add(this.label2);
            this.pnlFiltros.Controls.Add(this.btBuscar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1261, 71);
            this.pnlFiltros.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 77;
            this.label1.Text = "Data Inicial:";
            // 
            // dtpInicial
            // 
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(103, 14);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.ShowUpDown = true;
            this.dtpInicial.Size = new System.Drawing.Size(93, 20);
            this.dtpInicial.TabIndex = 0;
            this.dtpInicial.Tag = "Data da Ocorrência";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(103, 35);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.ShowUpDown = true;
            this.dtpFinal.Size = new System.Drawing.Size(93, 20);
            this.dtpFinal.TabIndex = 1;
            this.dtpFinal.Tag = "Data da Ocorrência";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(1039, 42);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(219, 26);
            this.label23.TabIndex = 74;
            this.label23.Text = "# Planos de Ação #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Final:";
            // 
            // btBuscar
            // 
            this.btBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btBuscar.Image")));
            this.btBuscar.Location = new System.Drawing.Point(202, 14);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(90, 41);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "&Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.lbFiltroPorStatus);
            this.pnlBotoes.Controls.Add(this.label12);
            this.pnlBotoes.Controls.Add(this.pbVerdeConcluido);
            this.pnlBotoes.Controls.Add(this.label8);
            this.pnlBotoes.Controls.Add(this.pbAzulForaPeriodo);
            this.pnlBotoes.Controls.Add(this.label6);
            this.pnlBotoes.Controls.Add(this.pbAmareloFerias);
            this.pnlBotoes.Controls.Add(this.label3);
            this.pnlBotoes.Controls.Add(this.pbPretoAfastado);
            this.pnlBotoes.Controls.Add(this.label4);
            this.pnlBotoes.Controls.Add(this.label5);
            this.pnlBotoes.Controls.Add(this.pbVermelhoPendente);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 551);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBotoes.Size = new System.Drawing.Size(1261, 57);
            this.pnlBotoes.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(1112, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 39);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Canelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(991, 6);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 39);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "&Enviar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(15, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(316, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Dê um duplo click para carregar informações para envio do e-mail";
            // 
            // txtMensagem
            // 
            this.txtMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensagem.Location = new System.Drawing.Point(12, 106);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(1237, 105);
            this.txtMensagem.TabIndex = 60;
            this.txtMensagem.Tag = "Mensagem";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Mensagem:";
            // 
            // txtEmailDestinatario
            // 
            this.txtEmailDestinatario.Location = new System.Drawing.Point(12, 23);
            this.txtEmailDestinatario.Name = "txtEmailDestinatario";
            this.txtEmailDestinatario.Size = new System.Drawing.Size(593, 20);
            this.txtEmailDestinatario.TabIndex = 58;
            this.txtEmailDestinatario.Tag = "E-mail Destinatário";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 13);
            this.label14.TabIndex = 57;
            this.label14.Text = "E-mail Destinatário:";
            // 
            // txtEmailTitulo
            // 
            this.txtEmailTitulo.Location = new System.Drawing.Point(12, 65);
            this.txtEmailTitulo.Name = "txtEmailTitulo";
            this.txtEmailTitulo.Size = new System.Drawing.Size(593, 20);
            this.txtEmailTitulo.TabIndex = 75;
            this.txtEmailTitulo.Tag = "E-mail Destinatário";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 74;
            this.label15.Text = "Título do E-mail:";
            // 
            // lbFiltroPorStatus
            // 
            this.lbFiltroPorStatus.AutoSize = true;
            this.lbFiltroPorStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbFiltroPorStatus.ForeColor = System.Drawing.Color.Red;
            this.lbFiltroPorStatus.Location = new System.Drawing.Point(504, 19);
            this.lbFiltroPorStatus.Name = "lbFiltroPorStatus";
            this.lbFiltroPorStatus.Size = new System.Drawing.Size(207, 13);
            this.lbFiltroPorStatus.TabIndex = 85;
            this.lbFiltroPorStatus.Text = "(Clique sobre o item da legenda para filtrar)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(442, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 84;
            this.label12.Text = "Concluído";
            // 
            // pbVerdeConcluido
            // 
            this.pbVerdeConcluido.BackColor = System.Drawing.Color.Transparent;
            this.pbVerdeConcluido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbVerdeConcluido.Image = ((System.Drawing.Image)(resources.GetObject("pbVerdeConcluido.Image")));
            this.pbVerdeConcluido.Location = new System.Drawing.Point(428, 17);
            this.pbVerdeConcluido.Name = "pbVerdeConcluido";
            this.pbVerdeConcluido.Size = new System.Drawing.Size(18, 15);
            this.pbVerdeConcluido.TabIndex = 83;
            this.pbVerdeConcluido.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(279, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 82;
            this.label8.Text = "Fora do Período de Cobrança";
            // 
            // pbAzulForaPeriodo
            // 
            this.pbAzulForaPeriodo.BackColor = System.Drawing.Color.Transparent;
            this.pbAzulForaPeriodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbAzulForaPeriodo.Image = ((System.Drawing.Image)(resources.GetObject("pbAzulForaPeriodo.Image")));
            this.pbAzulForaPeriodo.Location = new System.Drawing.Point(265, 17);
            this.pbAzulForaPeriodo.Name = "pbAzulForaPeriodo";
            this.pbAzulForaPeriodo.Size = new System.Drawing.Size(18, 15);
            this.pbAzulForaPeriodo.TabIndex = 81;
            this.pbAzulForaPeriodo.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(157, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 80;
            this.label6.Text = "Férias";
            // 
            // pbAmareloFerias
            // 
            this.pbAmareloFerias.BackColor = System.Drawing.Color.Transparent;
            this.pbAmareloFerias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbAmareloFerias.Image = ((System.Drawing.Image)(resources.GetObject("pbAmareloFerias.Image")));
            this.pbAmareloFerias.Location = new System.Drawing.Point(143, 17);
            this.pbAmareloFerias.Name = "pbAmareloFerias";
            this.pbAmareloFerias.Size = new System.Drawing.Size(18, 15);
            this.pbAmareloFerias.TabIndex = 79;
            this.pbAmareloFerias.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(212, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Afastado";
            // 
            // pbPretoAfastado
            // 
            this.pbPretoAfastado.BackColor = System.Drawing.Color.Transparent;
            this.pbPretoAfastado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPretoAfastado.Image = ((System.Drawing.Image)(resources.GetObject("pbPretoAfastado.Image")));
            this.pbPretoAfastado.Location = new System.Drawing.Point(198, 17);
            this.pbPretoAfastado.Name = "pbPretoAfastado";
            this.pbPretoAfastado.Size = new System.Drawing.Size(18, 15);
            this.pbPretoAfastado.TabIndex = 77;
            this.pbPretoAfastado.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Legenda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(91, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 75;
            this.label5.Text = "Pendente";
            // 
            // pbVermelhoPendente
            // 
            this.pbVermelhoPendente.BackColor = System.Drawing.Color.Transparent;
            this.pbVermelhoPendente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbVermelhoPendente.Image = ((System.Drawing.Image)(resources.GetObject("pbVermelhoPendente.Image")));
            this.pbVermelhoPendente.Location = new System.Drawing.Point(74, 17);
            this.pbVermelhoPendente.Name = "pbVermelhoPendente";
            this.pbVermelhoPendente.Size = new System.Drawing.Size(18, 15);
            this.pbVermelhoPendente.TabIndex = 74;
            this.pbVermelhoPendente.TabStop = false;
            // 
            // frmPlanoAcao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 608);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "frmPlanoAcao";
            this.Text = ".: Planos de Ação :.";
            this.Load += new System.EventHandler(this.frmPlanoAcao_Load);
            this.pnlConteudo.ResumeLayout(false);
            this.pnlConteudo.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerdeConcluido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAzulForaPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAmareloFerias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPretoAfastado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVermelhoPendente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.ListView lvPlanoAcao;
        private System.Windows.Forms.Panel pnlFiltros;
        internal System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEmailDestinatario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmailTitulo;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label lbFiltroPorStatus;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.PictureBox pbVerdeConcluido;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.PictureBox pbAzulForaPeriodo;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.PictureBox pbAmareloFerias;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.PictureBox pbPretoAfastado;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.PictureBox pbVermelhoPendente;
    }
}