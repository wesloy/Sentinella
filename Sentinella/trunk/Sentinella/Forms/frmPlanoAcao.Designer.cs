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
            this.label10 = new System.Windows.Forms.Label();
            this.lbFiltroAplicado = new System.Windows.Forms.Label();
            this.txtEmailTitulo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEmailDestinatario = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lvPlanoAcao = new System.Windows.Forms.ListView();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label23 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.nao_classificado_14_texto = new System.Windows.Forms.Label();
            this.nao_classificado_14 = new System.Windows.Forms.PictureBox();
            this.lbFiltroPorStatus = new System.Windows.Forms.Label();
            this.finalizado_1_texto = new System.Windows.Forms.Label();
            this.finalizado_1 = new System.Windows.Forms.PictureBox();
            this.dentro_prazo_4_texto = new System.Windows.Forms.Label();
            this.dentro_prazo_4 = new System.Windows.Forms.PictureBox();
            this.plano_vencido_2_texto = new System.Windows.Forms.Label();
            this.plano_vencido_2 = new System.Windows.Forms.PictureBox();
            this.plano_vencido_maior28_5_texto = new System.Windows.Forms.Label();
            this.plano_vencido_maior28_5 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.plano_vencido_maior7_3_texto = new System.Windows.Forms.Label();
            this.plano_vencido_maior7_3 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pnlConteudo.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nao_classificado_14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalizado_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentro_prazo_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plano_vencido_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plano_vencido_maior28_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plano_vencido_maior7_3)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.White;
            this.pnlConteudo.Controls.Add(this.label10);
            this.pnlConteudo.Controls.Add(this.lbFiltroAplicado);
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
            this.pnlConteudo.Size = new System.Drawing.Size(1261, 452);
            this.pnlConteudo.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(337, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 77;
            this.label10.Text = "Filtro aplicado:";
            // 
            // lbFiltroAplicado
            // 
            this.lbFiltroAplicado.AutoSize = true;
            this.lbFiltroAplicado.BackColor = System.Drawing.Color.Transparent;
            this.lbFiltroAplicado.ForeColor = System.Drawing.Color.Red;
            this.lbFiltroAplicado.Location = new System.Drawing.Point(434, 219);
            this.lbFiltroAplicado.Name = "lbFiltroAplicado";
            this.lbFiltroAplicado.Size = new System.Drawing.Size(45, 13);
            this.lbFiltroAplicado.TabIndex = 76;
            this.lbFiltroAplicado.Text = "TODOS";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
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
            this.lvPlanoAcao.Size = new System.Drawing.Size(1237, 211);
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
            this.pnlBotoes.Controls.Add(this.nao_classificado_14_texto);
            this.pnlBotoes.Controls.Add(this.nao_classificado_14);
            this.pnlBotoes.Controls.Add(this.lbFiltroPorStatus);
            this.pnlBotoes.Controls.Add(this.finalizado_1_texto);
            this.pnlBotoes.Controls.Add(this.finalizado_1);
            this.pnlBotoes.Controls.Add(this.dentro_prazo_4_texto);
            this.pnlBotoes.Controls.Add(this.dentro_prazo_4);
            this.pnlBotoes.Controls.Add(this.plano_vencido_2_texto);
            this.pnlBotoes.Controls.Add(this.plano_vencido_2);
            this.pnlBotoes.Controls.Add(this.plano_vencido_maior28_5_texto);
            this.pnlBotoes.Controls.Add(this.plano_vencido_maior28_5);
            this.pnlBotoes.Controls.Add(this.label4);
            this.pnlBotoes.Controls.Add(this.plano_vencido_maior7_3_texto);
            this.pnlBotoes.Controls.Add(this.plano_vencido_maior7_3);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnSalvar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 523);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBotoes.Size = new System.Drawing.Size(1261, 85);
            this.pnlBotoes.TabIndex = 3;
            // 
            // nao_classificado_14_texto
            // 
            this.nao_classificado_14_texto.AutoSize = true;
            this.nao_classificado_14_texto.BackColor = System.Drawing.Color.Transparent;
            this.nao_classificado_14_texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nao_classificado_14_texto.Location = new System.Drawing.Point(282, 38);
            this.nao_classificado_14_texto.Name = "nao_classificado_14_texto";
            this.nao_classificado_14_texto.Size = new System.Drawing.Size(86, 13);
            this.nao_classificado_14_texto.TabIndex = 87;
            this.nao_classificado_14_texto.Text = "Não Classificado";
            this.nao_classificado_14_texto.Click += new System.EventHandler(this.nao_classificado_14_texto_Click);
            // 
            // nao_classificado_14
            // 
            this.nao_classificado_14.BackColor = System.Drawing.Color.Transparent;
            this.nao_classificado_14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nao_classificado_14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nao_classificado_14.Image = ((System.Drawing.Image)(resources.GetObject("nao_classificado_14.Image")));
            this.nao_classificado_14.Location = new System.Drawing.Point(268, 36);
            this.nao_classificado_14.Name = "nao_classificado_14";
            this.nao_classificado_14.Size = new System.Drawing.Size(18, 14);
            this.nao_classificado_14.TabIndex = 86;
            this.nao_classificado_14.TabStop = false;
            this.nao_classificado_14.Click += new System.EventHandler(this.nao_classificado_14_Click);
            // 
            // lbFiltroPorStatus
            // 
            this.lbFiltroPorStatus.AutoSize = true;
            this.lbFiltroPorStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbFiltroPorStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbFiltroPorStatus.ForeColor = System.Drawing.Color.Red;
            this.lbFiltroPorStatus.Location = new System.Drawing.Point(72, 60);
            this.lbFiltroPorStatus.Name = "lbFiltroPorStatus";
            this.lbFiltroPorStatus.Size = new System.Drawing.Size(207, 13);
            this.lbFiltroPorStatus.TabIndex = 85;
            this.lbFiltroPorStatus.Text = "(Clique sobre o item da legenda para filtrar)";
            this.lbFiltroPorStatus.Click += new System.EventHandler(this.lbFiltroPorStatus_Click);
            // 
            // finalizado_1_texto
            // 
            this.finalizado_1_texto.AutoSize = true;
            this.finalizado_1_texto.BackColor = System.Drawing.Color.Transparent;
            this.finalizado_1_texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finalizado_1_texto.Location = new System.Drawing.Point(89, 6);
            this.finalizado_1_texto.Name = "finalizado_1_texto";
            this.finalizado_1_texto.Size = new System.Drawing.Size(59, 13);
            this.finalizado_1_texto.TabIndex = 84;
            this.finalizado_1_texto.Text = "Finalizados";
            this.finalizado_1_texto.Click += new System.EventHandler(this.finalizado_1_texto_Click);
            // 
            // finalizado_1
            // 
            this.finalizado_1.BackColor = System.Drawing.Color.Transparent;
            this.finalizado_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.finalizado_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finalizado_1.Image = ((System.Drawing.Image)(resources.GetObject("finalizado_1.Image")));
            this.finalizado_1.Location = new System.Drawing.Point(75, 4);
            this.finalizado_1.Name = "finalizado_1";
            this.finalizado_1.Size = new System.Drawing.Size(18, 15);
            this.finalizado_1.TabIndex = 83;
            this.finalizado_1.TabStop = false;
            this.finalizado_1.Click += new System.EventHandler(this.finalizado_1_Click);
            // 
            // dentro_prazo_4_texto
            // 
            this.dentro_prazo_4_texto.AutoSize = true;
            this.dentro_prazo_4_texto.BackColor = System.Drawing.Color.Transparent;
            this.dentro_prazo_4_texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dentro_prazo_4_texto.Location = new System.Drawing.Point(89, 22);
            this.dentro_prazo_4_texto.Name = "dentro_prazo_4_texto";
            this.dentro_prazo_4_texto.Size = new System.Drawing.Size(84, 13);
            this.dentro_prazo_4_texto.TabIndex = 82;
            this.dentro_prazo_4_texto.Text = "Dentro do Prazo";
            this.dentro_prazo_4_texto.Click += new System.EventHandler(this.dentro_prazo_4_texto_Click);
            // 
            // dentro_prazo_4
            // 
            this.dentro_prazo_4.BackColor = System.Drawing.Color.Transparent;
            this.dentro_prazo_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dentro_prazo_4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dentro_prazo_4.Image = ((System.Drawing.Image)(resources.GetObject("dentro_prazo_4.Image")));
            this.dentro_prazo_4.Location = new System.Drawing.Point(75, 20);
            this.dentro_prazo_4.Name = "dentro_prazo_4";
            this.dentro_prazo_4.Size = new System.Drawing.Size(18, 15);
            this.dentro_prazo_4.TabIndex = 81;
            this.dentro_prazo_4.TabStop = false;
            this.dentro_prazo_4.Click += new System.EventHandler(this.dentro_prazo_4_Click);
            // 
            // plano_vencido_2_texto
            // 
            this.plano_vencido_2_texto.AutoSize = true;
            this.plano_vencido_2_texto.BackColor = System.Drawing.Color.Transparent;
            this.plano_vencido_2_texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plano_vencido_2_texto.Location = new System.Drawing.Point(89, 38);
            this.plano_vencido_2_texto.Name = "plano_vencido_2_texto";
            this.plano_vencido_2_texto.Size = new System.Drawing.Size(105, 13);
            this.plano_vencido_2_texto.TabIndex = 80;
            this.plano_vencido_2_texto.Text = "Plano Vencido - D<7";
            this.plano_vencido_2_texto.Click += new System.EventHandler(this.plano_vencido_2_texto_Click);
            // 
            // plano_vencido_2
            // 
            this.plano_vencido_2.BackColor = System.Drawing.Color.Transparent;
            this.plano_vencido_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.plano_vencido_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plano_vencido_2.Image = ((System.Drawing.Image)(resources.GetObject("plano_vencido_2.Image")));
            this.plano_vencido_2.Location = new System.Drawing.Point(75, 36);
            this.plano_vencido_2.Name = "plano_vencido_2";
            this.plano_vencido_2.Size = new System.Drawing.Size(18, 15);
            this.plano_vencido_2.TabIndex = 79;
            this.plano_vencido_2.TabStop = false;
            this.plano_vencido_2.Click += new System.EventHandler(this.plano_vencido_2_Click);
            // 
            // plano_vencido_maior28_5_texto
            // 
            this.plano_vencido_maior28_5_texto.AutoSize = true;
            this.plano_vencido_maior28_5_texto.BackColor = System.Drawing.Color.Transparent;
            this.plano_vencido_maior28_5_texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plano_vencido_maior28_5_texto.Location = new System.Drawing.Point(282, 22);
            this.plano_vencido_maior28_5_texto.Name = "plano_vencido_maior28_5_texto";
            this.plano_vencido_maior28_5_texto.Size = new System.Drawing.Size(111, 13);
            this.plano_vencido_maior28_5_texto.TabIndex = 78;
            this.plano_vencido_maior28_5_texto.Text = "Plano Vencido - D28+";
            this.plano_vencido_maior28_5_texto.Click += new System.EventHandler(this.plano_vencido_maior28_5_texto_Click);
            // 
            // plano_vencido_maior28_5
            // 
            this.plano_vencido_maior28_5.BackColor = System.Drawing.Color.Transparent;
            this.plano_vencido_maior28_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.plano_vencido_maior28_5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plano_vencido_maior28_5.Image = ((System.Drawing.Image)(resources.GetObject("plano_vencido_maior28_5.Image")));
            this.plano_vencido_maior28_5.Location = new System.Drawing.Point(268, 20);
            this.plano_vencido_maior28_5.Name = "plano_vencido_maior28_5";
            this.plano_vencido_maior28_5.Size = new System.Drawing.Size(18, 15);
            this.plano_vencido_maior28_5.TabIndex = 77;
            this.plano_vencido_maior28_5.TabStop = false;
            this.plano_vencido_maior28_5.Click += new System.EventHandler(this.plano_vencido_maior28_5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Legenda:";
            // 
            // plano_vencido_maior7_3_texto
            // 
            this.plano_vencido_maior7_3_texto.AutoSize = true;
            this.plano_vencido_maior7_3_texto.BackColor = System.Drawing.Color.Transparent;
            this.plano_vencido_maior7_3_texto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plano_vencido_maior7_3_texto.Location = new System.Drawing.Point(282, 6);
            this.plano_vencido_maior7_3_texto.Name = "plano_vencido_maior7_3_texto";
            this.plano_vencido_maior7_3_texto.Size = new System.Drawing.Size(333, 13);
            this.plano_vencido_maior7_3_texto.TabIndex = 75;
            this.plano_vencido_maior7_3_texto.Text = "Plano Vencido - D7+ || Plano Vencido - D14+ || Plano Vencido - D21+";
            this.plano_vencido_maior7_3_texto.Click += new System.EventHandler(this.plano_vencido_maior7_3_texto_Click);
            // 
            // plano_vencido_maior7_3
            // 
            this.plano_vencido_maior7_3.BackColor = System.Drawing.Color.Transparent;
            this.plano_vencido_maior7_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.plano_vencido_maior7_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plano_vencido_maior7_3.Image = ((System.Drawing.Image)(resources.GetObject("plano_vencido_maior7_3.Image")));
            this.plano_vencido_maior7_3.Location = new System.Drawing.Point(268, 4);
            this.plano_vencido_maior7_3.Name = "plano_vencido_maior7_3";
            this.plano_vencido_maior7_3.Size = new System.Drawing.Size(18, 15);
            this.plano_vencido_maior7_3.TabIndex = 74;
            this.plano_vencido_maior7_3.TabStop = false;
            this.plano_vencido_maior7_3.Click += new System.EventHandler(this.plano_vencido_maior7_3_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(1121, 20);
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
            this.btnSalvar.Location = new System.Drawing.Point(1000, 20);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 39);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "&Enviar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.nao_classificado_14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.finalizado_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dentro_prazo_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plano_vencido_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plano_vencido_maior28_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plano_vencido_maior7_3)).EndInit();
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
        internal System.Windows.Forms.Label finalizado_1_texto;
        internal System.Windows.Forms.PictureBox finalizado_1;
        internal System.Windows.Forms.Label dentro_prazo_4_texto;
        internal System.Windows.Forms.PictureBox dentro_prazo_4;
        internal System.Windows.Forms.Label plano_vencido_2_texto;
        internal System.Windows.Forms.PictureBox plano_vencido_2;
        internal System.Windows.Forms.Label plano_vencido_maior28_5_texto;
        internal System.Windows.Forms.PictureBox plano_vencido_maior28_5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label plano_vencido_maior7_3_texto;
        internal System.Windows.Forms.PictureBox plano_vencido_maior7_3;
        internal System.Windows.Forms.Label nao_classificado_14_texto;
        internal System.Windows.Forms.PictureBox nao_classificado_14;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label lbFiltroAplicado;
    }
}