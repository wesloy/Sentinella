﻿namespace Sentinella.Forms {
    partial class frmConfigUsuarios {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigUsuarios));
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.cbPerfilAcesso = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lvLista = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtIdRede = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ckboxAtivo = new System.Windows.Forms.CheckBox();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveFiltro = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
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
            this.pnlConteudo.Controls.Add(this.cbPerfilAcesso);
            this.pnlConteudo.Controls.Add(this.Label9);
            this.pnlConteudo.Controls.Add(this.PictureBox2);
            this.pnlConteudo.Controls.Add(this.txtID);
            this.pnlConteudo.Controls.Add(this.Label10);
            this.pnlConteudo.Controls.Add(this.label7);
            this.pnlConteudo.Controls.Add(this.Label11);
            this.pnlConteudo.Controls.Add(this.label6);
            this.pnlConteudo.Controls.Add(this.lvLista);
            this.pnlConteudo.Controls.Add(this.label1);
            this.pnlConteudo.Controls.Add(this.PictureBox1);
            this.pnlConteudo.Controls.Add(this.Label12);
            this.pnlConteudo.Controls.Add(this.txtIdRede);
            this.pnlConteudo.Controls.Add(this.Label14);
            this.pnlConteudo.Controls.Add(this.txtNome);
            this.pnlConteudo.Controls.Add(this.Label5);
            this.pnlConteudo.Controls.Add(this.Label2);
            this.pnlConteudo.Controls.Add(this.ckboxAtivo);
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 57);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(1048, 468);
            this.pnlConteudo.TabIndex = 8;
            // 
            // cbPerfilAcesso
            // 
            this.cbPerfilAcesso.BackColor = System.Drawing.Color.Azure;
            this.cbPerfilAcesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPerfilAcesso.FormattingEnabled = true;
            this.cbPerfilAcesso.Location = new System.Drawing.Point(111, 81);
            this.cbPerfilAcesso.Name = "cbPerfilAcesso";
            this.cbPerfilAcesso.Size = new System.Drawing.Size(275, 21);
            this.cbPerfilAcesso.TabIndex = 3;
            this.cbPerfilAcesso.Tag = "Perfil de Acesso";
            // 
            // Label9
            // 
            this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Location = new System.Drawing.Point(232, 443);
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
            this.PictureBox2.Location = new System.Drawing.Point(218, 441);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(18, 15);
            this.PictureBox2.TabIndex = 43;
            this.PictureBox2.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtID.Location = new System.Drawing.Point(936, 84);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 74;
            this.txtID.Visible = false;
            // 
            // Label10
            // 
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label10.AutoSize = true;
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(111, 443);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(60, 13);
            this.Label10.TabIndex = 42;
            this.Label10.Text = "Legenda:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(834, 443);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "(Duplo clique para alterar as informações)";
            // 
            // Label11
            // 
            this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label11.AutoSize = true;
            this.Label11.BackColor = System.Drawing.Color.Transparent;
            this.Label11.Location = new System.Drawing.Point(184, 443);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(31, 13);
            this.Label11.TabIndex = 41;
            this.Label11.Text = "Ativo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Lista de Usuários:";
            // 
            // lvLista
            // 
            this.lvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLista.BackColor = System.Drawing.Color.Azure;
            this.lvLista.Location = new System.Drawing.Point(111, 108);
            this.lvLista.Name = "lvLista";
            this.lvLista.Size = new System.Drawing.Size(925, 332);
            this.lvLista.TabIndex = 4;
            this.lvLista.Tag = "Lista de Registros";
            this.lvLista.UseCompatibleStateImageBehavior = false;
            this.lvLista.DoubleClick += new System.EventHandler(this.lvLista_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Perfil de Acesso:";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(167, 441);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(18, 15);
            this.PictureBox1.TabIndex = 40;
            this.PictureBox1.TabStop = false;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.BackColor = System.Drawing.Color.Transparent;
            this.Label12.Location = new System.Drawing.Point(14, 58);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(63, 13);
            this.Label12.TabIndex = 62;
            this.Label12.Text = "Id de Rede:";
            // 
            // txtIdRede
            // 
            this.txtIdRede.BackColor = System.Drawing.Color.Azure;
            this.txtIdRede.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdRede.Location = new System.Drawing.Point(110, 55);
            this.txtIdRede.Name = "txtIdRede";
            this.txtIdRede.Size = new System.Drawing.Size(276, 20);
            this.txtIdRede.TabIndex = 2;
            this.txtIdRede.Tag = "Id de Rede";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.BackColor = System.Drawing.Color.Transparent;
            this.Label14.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Label14.Location = new System.Drawing.Point(130, 7);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(286, 13);
            this.Label14.TabIndex = 60;
            this.Label14.Text = "Quando inativo o usuário não consegue acessar o sistema.";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.Azure;
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(110, 29);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(276, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.Tag = "Nome";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Location = new System.Drawing.Point(14, 7);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(34, 13);
            this.Label5.TabIndex = 59;
            this.Label5.Text = "Ativa:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(14, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(38, 13);
            this.Label2.TabIndex = 58;
            this.Label2.Text = "Nome:";
            // 
            // ckboxAtivo
            // 
            this.ckboxAtivo.AutoSize = true;
            this.ckboxAtivo.BackColor = System.Drawing.Color.Azure;
            this.ckboxAtivo.Location = new System.Drawing.Point(109, 6);
            this.ckboxAtivo.Name = "ckboxAtivo";
            this.ckboxAtivo.Size = new System.Drawing.Size(15, 14);
            this.ckboxAtivo.TabIndex = 0;
            this.ckboxAtivo.UseVisualStyleBackColor = false;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlFiltros.Controls.Add(this.label8);
            this.pnlFiltros.Controls.Add(this.label3);
            this.pnlFiltros.Controls.Add(this.btnRemoveFiltro);
            this.pnlFiltros.Controls.Add(this.btnFiltrar);
            this.pnlFiltros.Controls.Add(this.txtFiltro);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1048, 57);
            this.pnlFiltros.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(688, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(339, 26);
            this.label8.TabIndex = 73;
            this.label8.Text = "# Configurações de Usuários #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Filtrar Usuário:";
            // 
            // btnRemoveFiltro
            // 
            this.btnRemoveFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveFiltro.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveFiltro.Image")));
            this.btnRemoveFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveFiltro.Location = new System.Drawing.Point(470, 12);
            this.btnRemoveFiltro.Name = "btnRemoveFiltro";
            this.btnRemoveFiltro.Size = new System.Drawing.Size(75, 30);
            this.btnRemoveFiltro.TabIndex = 2;
            this.btnRemoveFiltro.Text = "     Limpar";
            this.btnRemoveFiltro.UseVisualStyleBackColor = true;
            this.btnRemoveFiltro.Click += new System.EventHandler(this.btnRemoveFiltro_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(394, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 30);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "   Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.Color.Azure;
            this.txtFiltro.Location = new System.Drawing.Point(109, 18);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(277, 20);
            this.txtFiltro.TabIndex = 0;
            this.txtFiltro.Tag = "Filtro";
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.btnExcluir);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnAlterar);
            this.pnlBotoes.Controls.Add(this.btnIncluir);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 525);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBotoes.Size = new System.Drawing.Size(1048, 57);
            this.pnlBotoes.TabIndex = 6;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.Location = new System.Drawing.Point(787, 10);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(83, 30);
            this.btnExcluir.TabIndex = 1;
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
            this.btnCancelar.Location = new System.Drawing.Point(953, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 30);
            this.btnCancelar.TabIndex = 3;
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
            this.btnAlterar.Location = new System.Drawing.Point(870, 10);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(83, 30);
            this.btnAlterar.TabIndex = 2;
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
            this.btnIncluir.Location = new System.Drawing.Point(704, 10);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(83, 30);
            this.btnIncluir.TabIndex = 0;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // frmConfigUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 582);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlBotoes);
            this.Name = "frmConfigUsuarios";
            this.Text = "frmConfigUsuarios";
            this.Load += new System.EventHandler(this.frmConfigUsuarios_Load);
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
        private System.Windows.Forms.ComboBox cbPerfilAcesso;
        private System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ListView lvLista;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txtIdRede;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtNome;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.CheckBox ckboxAtivo;
        private System.Windows.Forms.Panel pnlFiltros;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnRemoveFiltro;
        internal System.Windows.Forms.Button btnFiltrar;
        internal System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Panel pnlBotoes;
        internal System.Windows.Forms.Button btnExcluir;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Button btnAlterar;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Button btnIncluir;
    }
}