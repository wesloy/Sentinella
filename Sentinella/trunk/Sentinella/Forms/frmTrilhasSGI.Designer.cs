namespace Sentinella.Forms {
    partial class frmTrilhasSGI {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrilhasSGI));
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.lkDesmarcarTodos = new System.Windows.Forms.LinkLabel();
            this.lkMarcarTodos = new System.Windows.Forms.LinkLabel();
            this.btnImportar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmailDestinatario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvAssociados = new System.Windows.Forms.ListView();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.cbxCoordenador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.pnlBotoes = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.pnlConteudo.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.BackColor = System.Drawing.Color.White;
            this.pnlConteudo.Controls.Add(this.lkDesmarcarTodos);
            this.pnlConteudo.Controls.Add(this.lkMarcarTodos);
            this.pnlConteudo.Controls.Add(this.btnImportar);
            this.pnlConteudo.Controls.Add(this.label4);
            this.pnlConteudo.Controls.Add(this.txtMensagem);
            this.pnlConteudo.Controls.Add(this.label3);
            this.pnlConteudo.Controls.Add(this.txtEmailDestinatario);
            this.pnlConteudo.Controls.Add(this.label1);
            this.pnlConteudo.Controls.Add(this.lvAssociados);
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(0, 57);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(1051, 416);
            this.pnlConteudo.TabIndex = 5;
            // 
            // lkDesmarcarTodos
            // 
            this.lkDesmarcarTodos.AutoSize = true;
            this.lkDesmarcarTodos.Location = new System.Drawing.Point(409, 134);
            this.lkDesmarcarTodos.Name = "lkDesmarcarTodos";
            this.lkDesmarcarTodos.Size = new System.Drawing.Size(91, 13);
            this.lkDesmarcarTodos.TabIndex = 8;
            this.lkDesmarcarTodos.TabStop = true;
            this.lkDesmarcarTodos.Text = "Desmarcar Todos";
            this.lkDesmarcarTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkDesmarcarTodos_LinkClicked);
            // 
            // lkMarcarTodos
            // 
            this.lkMarcarTodos.AutoSize = true;
            this.lkMarcarTodos.Location = new System.Drawing.Point(330, 134);
            this.lkMarcarTodos.Name = "lkMarcarTodos";
            this.lkMarcarTodos.Size = new System.Drawing.Size(73, 13);
            this.lkMarcarTodos.TabIndex = 7;
            this.lkMarcarTodos.TabStop = true;
            this.lkMarcarTodos.Text = "Marcar Todos";
            this.lkMarcarTodos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkMarcarTodos_LinkClicked);
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.Location = new System.Drawing.Point(949, 9);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(90, 40);
            this.btnImportar.TabIndex = 6;
            this.btnImportar.Text = "Impor&tar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Selecionar os associados que serão listados no e-mail cobrança:";
            // 
            // txtMensagem
            // 
            this.txtMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensagem.Location = new System.Drawing.Point(12, 66);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(1027, 65);
            this.txtMensagem.TabIndex = 4;
            this.txtMensagem.Tag = "Mensagem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mensagem:";
            // 
            // txtEmailDestinatario
            // 
            this.txtEmailDestinatario.Location = new System.Drawing.Point(12, 25);
            this.txtEmailDestinatario.Name = "txtEmailDestinatario";
            this.txtEmailDestinatario.Size = new System.Drawing.Size(593, 20);
            this.txtEmailDestinatario.TabIndex = 2;
            this.txtEmailDestinatario.Tag = "E-mail Destinatário";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "E-mail Destinatário:";
            // 
            // lvAssociados
            // 
            this.lvAssociados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAssociados.HideSelection = false;
            this.lvAssociados.Location = new System.Drawing.Point(12, 150);
            this.lvAssociados.Name = "lvAssociados";
            this.lvAssociados.Size = new System.Drawing.Size(1027, 245);
            this.lvAssociados.TabIndex = 0;
            this.lvAssociados.UseCompatibleStateImageBehavior = false;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.AutoScroll = true;
            this.pnlFiltros.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlFiltros.Controls.Add(this.label23);
            this.pnlFiltros.Controls.Add(this.cbxCoordenador);
            this.pnlFiltros.Controls.Add(this.label2);
            this.pnlFiltros.Controls.Add(this.btnIniciar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1051, 57);
            this.pnlFiltros.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(747, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(292, 26);
            this.label23.TabIndex = 74;
            this.label23.Text = "# Cobranças Trilhas SGI #";
            // 
            // cbxCoordenador
            // 
            this.cbxCoordenador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCoordenador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCoordenador.FormattingEnabled = true;
            this.cbxCoordenador.Items.AddRange(new object[] {
            "Todas as Regras"});
            this.cbxCoordenador.Location = new System.Drawing.Point(12, 18);
            this.cbxCoordenador.Name = "cbxCoordenador";
            this.cbxCoordenador.Size = new System.Drawing.Size(323, 24);
            this.cbxCoordenador.TabIndex = 4;
            this.cbxCoordenador.Tag = "Fila de Trabalho";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coordenador: ";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciar.Image")));
            this.btnIniciar.Location = new System.Drawing.Point(354, 9);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(90, 40);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "&Iniciar";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // pnlBotoes
            // 
            this.pnlBotoes.BackColor = System.Drawing.Color.White;
            this.pnlBotoes.Controls.Add(this.label5);
            this.pnlBotoes.Controls.Add(this.btnCancelar);
            this.pnlBotoes.Controls.Add(this.btnEnviar);
            this.pnlBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotoes.Location = new System.Drawing.Point(0, 473);
            this.pnlBotoes.Name = "pnlBotoes";
            this.pnlBotoes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlBotoes.Size = new System.Drawing.Size(1051, 57);
            this.pnlBotoes.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(822, 39);
            this.label5.TabIndex = 6;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(902, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 39);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Canelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.Location = new System.Drawing.Point(781, 6);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(115, 39);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // frmTrilhasSGI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 530);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlBotoes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrilhasSGI";
            this.Text = ".: Cobranças Trilhas SGI :.";
            this.Load += new System.EventHandler(this.frmTrilhasSGI_Load);
            this.pnlConteudo.ResumeLayout(false);
            this.pnlConteudo.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlBotoes.ResumeLayout(false);
            this.pnlBotoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmailDestinatario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvAssociados;
        private System.Windows.Forms.Panel pnlFiltros;
        internal System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cbxCoordenador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Panel pnlBotoes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.LinkLabel lkDesmarcarTodos;
        private System.Windows.Forms.LinkLabel lkMarcarTodos;
    }
}