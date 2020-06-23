﻿namespace Sentinella.Forms {
    partial class frmConfigInterrupcoesProgramadas {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigInterrupcoesProgramadas));
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.cbxTempoInterrupcao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxMinuto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxHora = new System.Windows.Forms.ComboBox();
            this.dtInicial = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lvLista = new System.Windows.Forms.ListView();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ckboxAtivo = new System.Windows.Forms.CheckBox();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.White;
            this.pnlConteudo.Controls.Add(this.label13);
            this.pnlConteudo.Controls.Add(this.cbxTempoInterrupcao);
            this.pnlConteudo.Controls.Add(this.label3);
            this.pnlConteudo.Controls.Add(this.cbxMinuto);
            this.pnlConteudo.Controls.Add(this.label1);
            this.pnlConteudo.Controls.Add(this.cbxHora);
            this.pnlConteudo.Controls.Add(this.dtInicial);
            this.pnlConteudo.Controls.Add(this.txtID);
            this.pnlConteudo.Controls.Add(this.Label9);
            this.pnlConteudo.Controls.Add(this.PictureBox2);
            this.pnlConteudo.Controls.Add(this.label7);
            this.pnlConteudo.Controls.Add(this.Label10);
            this.pnlConteudo.Controls.Add(this.label6);
            this.pnlConteudo.Controls.Add(this.Label11);
            this.pnlConteudo.Controls.Add(this.txtMensagem);
            this.pnlConteudo.Controls.Add(this.label4);
            this.pnlConteudo.Controls.Add(this.lvLista);
            this.pnlConteudo.Controls.Add(this.PictureBox1);
            this.pnlConteudo.Controls.Add(this.Label12);
            this.pnlConteudo.Controls.Add(this.Label14);
            this.pnlConteudo.Controls.Add(this.Label5);
            this.pnlConteudo.Controls.Add(this.Label2);
            this.pnlConteudo.Controls.Add(this.ckboxAtivo);
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 57);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(1217, 625);
            this.pnlConteudo.TabIndex = 8;
            // 
            // cbxTempoInterrupcao
            // 
            this.cbxTempoInterrupcao.FormattingEnabled = true;
            this.cbxTempoInterrupcao.Items.AddRange(new object[] {
            "05 - MINUTOS",
            "10 - MINUTOS",
            "20 - MINUTOS",
            "60 - MINUTOS"});
            this.cbxTempoInterrupcao.Location = new System.Drawing.Point(135, 81);
            this.cbxTempoInterrupcao.Name = "cbxTempoInterrupcao";
            this.cbxTempoInterrupcao.Size = new System.Drawing.Size(258, 21);
            this.cbxTempoInterrupcao.TabIndex = 80;
            this.cbxTempoInterrupcao.Tag = "Hora Inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Tempo de Interrupção:";
            // 
            // cbxMinuto
            // 
            this.cbxMinuto.FormattingEnabled = true;
            this.cbxMinuto.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cbxMinuto.Location = new System.Drawing.Point(214, 54);
            this.cbxMinuto.Name = "cbxMinuto";
            this.cbxMinuto.Size = new System.Drawing.Size(59, 21);
            this.cbxMinuto.TabIndex = 78;
            this.cbxMinuto.Tag = "Hora Inicial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 77;
            this.label1.Text = ":";
            // 
            // cbxHora
            // 
            this.cbxHora.FormattingEnabled = true;
            this.cbxHora.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbxHora.Location = new System.Drawing.Point(135, 54);
            this.cbxHora.Name = "cbxHora";
            this.cbxHora.Size = new System.Drawing.Size(59, 21);
            this.cbxHora.TabIndex = 76;
            this.cbxHora.Tag = "Hora Inicial";
            // 
            // dtInicial
            // 
            this.dtInicial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtInicial.Location = new System.Drawing.Point(135, 28);
            this.dtInicial.Name = "dtInicial";
            this.dtInicial.Size = new System.Drawing.Size(258, 20);
            this.dtInicial.TabIndex = 75;
            this.dtInicial.Tag = "Data Inicial";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtID.Location = new System.Drawing.Point(965, 25);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 74;
            this.txtID.Visible = false;
            // 
            // Label9
            // 
            this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Location = new System.Drawing.Point(137, 600);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(39, 13);
            this.Label9.TabIndex = 44;
            this.Label9.Text = "Inativo";
            // 
            // PictureBox2
            // 
            this.PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(123, 598);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(18, 15);
            this.PictureBox2.TabIndex = 43;
            this.PictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(1003, 600);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "(Duplo clique para alterar as informações)";
            // 
            // Label10
            // 
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label10.AutoSize = true;
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(16, 600);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(60, 13);
            this.Label10.TabIndex = 42;
            this.Label10.Text = "Legenda:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Lista de Interrupções:";
            // 
            // Label11
            // 
            this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label11.AutoSize = true;
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Location = new System.Drawing.Point(89, 600);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(31, 13);
            this.Label11.TabIndex = 41;
            this.Label11.Text = "Ativo";
            // 
            // txtMensagem
            // 
            this.txtMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensagem.BackColor = System.Drawing.Color.Azure;
            this.txtMensagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMensagem.Location = new System.Drawing.Point(12, 132);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(1193, 93);
            this.txtMensagem.TabIndex = 69;
            this.txtMensagem.Tag = "Regra de Negócio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(14, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Mensagem:";
            // 
            // lvLista
            // 
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.BackColor = System.Drawing.Color.Azure;
            this.lvLista.HideSelection = false;
            this.lvLista.Location = new System.Drawing.Point(12, 251);
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(1193, 341);
            this.lvLista.TabIndex = 65;
            this.lvLista.Tag = "Lista de Registros";
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.DoubleClick += new System.EventHandler(this.lvLista_DoubleClick);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(72, 598);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(18, 15);
            this.PictureBox1.TabIndex = 40;
            this.PictureBox1.TabStop = false;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Location = new System.Drawing.Point(14, 57);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(63, 13);
            this.Label12.TabIndex = 62;
            this.Label12.Text = "Hora Inicial:";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Label14.Location = new System.Drawing.Point(157, 9);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(222, 13);
            this.Label14.TabIndex = 60;
            this.Label14.Text = "Quando ativa, está habilitada para execução.";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Location = new System.Drawing.Point(14, 11);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(34, 13);
            this.Label5.TabIndex = 59;
            this.Label5.Text = "Ativa:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(16, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 13);
            this.Label2.TabIndex = 58;
            this.Label2.Text = "Data Inicial:";
            // 
            // ckboxAtivo
            // 
            this.ckboxAtivo.AutoSize = true;
            this.ckboxAtivo.BackColor = System.Drawing.Color.Azure;
            this.ckboxAtivo.Location = new System.Drawing.Point(136, 8);
            this.ckboxAtivo.Name = "ckboxAtivo";
            this.ckboxAtivo.Size = new System.Drawing.Size(15, 14);
            this.ckboxAtivo.TabIndex = 57;
            this.ckboxAtivo.UseVisualStyleBackColor = false;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlFiltros.Controls.Add(this.label8);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1217, 57);
            this.pnlFiltros.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(688, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(526, 26);
            this.label8.TabIndex = 73;
            this.label8.Text = "# Configurações de Interrupções Programadas #";
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnIncluir);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 682);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBotoes.Size = new System.Drawing.Size(1217, 57);
            this.pnlBotoes.TabIndex = 6;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.Location = new System.Drawing.Point(965, 10);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(83, 30);
            this.btnExcluir.TabIndex = 73;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1122, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 30);
            this.btnCancelar.TabIndex = 68;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAlterar.Location = new System.Drawing.Point(1046, 10);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(83, 30);
            this.btnAlterar.TabIndex = 67;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(883, 10);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(83, 30);
            this.btnIncluir.TabIndex = 66;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(279, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(297, 13);
            this.label13.TabIndex = 81;
            this.label13.Text = "Menor tempo para programar uma interrupção é de 5 minutos.";
            // 
            // frmConfigInterrupcoesProgramadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 739);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "frmConfigInterrupcoesProgramadas";
            this.Text = ".: Interrupções Programadas :.";
            this.Load += new System.EventHandler(this.frmConfigInterrupcoesProgramadas_Load);
            this.pnlConteudo.ResumeLayout(false);
            this.pnlConteudo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.ComboBox cbxTempoInterrupcao;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxMinuto;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxHora;
        private System.Windows.Forms.DateTimePicker dtInicial;
        private System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtMensagem;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ListView lvLista;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.CheckBox ckboxAtivo;
        private System.Windows.Forms.Panel pnlFiltros;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlBotoes;
        internal System.Windows.Forms.Button btnExcluir;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAlterar;
        internal System.Windows.Forms.Button btnIncluir;
        internal System.Windows.Forms.Label label13;
    }
}