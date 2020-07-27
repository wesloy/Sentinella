namespace Sentinella.Forms {
    partial class frmTeste {
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
            this.gbSenhas = new System.Windows.Forms.GroupBox();
            this.btnDecriptar = new System.Windows.Forms.Button();
            this.btnEncypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaida = new System.Windows.Forms.TextBox();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.btnTesteConexao = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.gbSenhas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSenhas
            // 
            this.gbSenhas.Controls.Add(this.btnDecriptar);
            this.gbSenhas.Controls.Add(this.btnEncypt);
            this.gbSenhas.Controls.Add(this.label2);
            this.gbSenhas.Controls.Add(this.label1);
            this.gbSenhas.Controls.Add(this.txtSaida);
            this.gbSenhas.Controls.Add(this.txtEntrada);
            this.gbSenhas.Location = new System.Drawing.Point(12, 12);
            this.gbSenhas.Name = "gbSenhas";
            this.gbSenhas.Size = new System.Drawing.Size(200, 91);
            this.gbSenhas.TabIndex = 6;
            this.gbSenhas.TabStop = false;
            this.gbSenhas.Text = "Senhas";
            // 
            // btnDecriptar
            // 
            this.btnDecriptar.Location = new System.Drawing.Point(103, 61);
            this.btnDecriptar.Name = "btnDecriptar";
            this.btnDecriptar.Size = new System.Drawing.Size(75, 23);
            this.btnDecriptar.TabIndex = 11;
            this.btnDecriptar.Text = "Decriptar";
            this.btnDecriptar.UseVisualStyleBackColor = true;
            this.btnDecriptar.Click += new System.EventHandler(this.btnDecriptar_Click);
            // 
            // btnEncypt
            // 
            this.btnEncypt.Location = new System.Drawing.Point(22, 61);
            this.btnEncypt.Name = "btnEncypt";
            this.btnEncypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncypt.TabIndex = 10;
            this.btnEncypt.Text = "Encriptar";
            this.btnEncypt.UseVisualStyleBackColor = true;
            this.btnEncypt.Click += new System.EventHandler(this.btnEncypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Saída:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Entrada:";
            // 
            // txtSaida
            // 
            this.txtSaida.Location = new System.Drawing.Point(74, 35);
            this.txtSaida.Name = "txtSaida";
            this.txtSaida.Size = new System.Drawing.Size(120, 20);
            this.txtSaida.TabIndex = 7;
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(74, 16);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(120, 20);
            this.txtEntrada.TabIndex = 6;
            // 
            // btnTesteConexao
            // 
            this.btnTesteConexao.Location = new System.Drawing.Point(12, 137);
            this.btnTesteConexao.Name = "btnTesteConexao";
            this.btnTesteConexao.Size = new System.Drawing.Size(200, 23);
            this.btnTesteConexao.TabIndex = 12;
            this.btnTesteConexao.Text = "Teste de Conexão";
            this.btnTesteConexao.UseVisualStyleBackColor = true;
            this.btnTesteConexao.Click += new System.EventHandler(this.btnTesteConexao_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(258, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(921, 270);
            this.dataGridView1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Carregar Tabela";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 349);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnTesteConexao);
            this.Controls.Add(this.gbSenhas);
            this.Name = "frmTeste";
            this.Text = ".: TesTes :.";
            this.gbSenhas.ResumeLayout(false);
            this.gbSenhas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSenhas;
        private System.Windows.Forms.Button btnDecriptar;
        private System.Windows.Forms.Button btnEncypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaida;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Button btnTesteConexao;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}