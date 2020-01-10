namespace Sentinella.Forms {
    partial class frmCategorizacao {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategorizacao));
            this.cbFinalizacao = new System.Windows.Forms.ComboBox();
            this.cbSubFinalizacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbNomeFila = new System.Windows.Forms.Label();
            this.txtValorEnvolvido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbFinalizacao
            // 
            this.cbFinalizacao.BackColor = System.Drawing.Color.Azure;
            this.cbFinalizacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFinalizacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFinalizacao.FormattingEnabled = true;
            this.cbFinalizacao.Location = new System.Drawing.Point(154, 64);
            this.cbFinalizacao.Name = "cbFinalizacao";
            this.cbFinalizacao.Size = new System.Drawing.Size(331, 21);
            this.cbFinalizacao.TabIndex = 0;
            this.cbFinalizacao.Leave += new System.EventHandler(this.cbFinalizacao_Leave);
            // 
            // cbSubFinalizacao
            // 
            this.cbSubFinalizacao.BackColor = System.Drawing.Color.Azure;
            this.cbSubFinalizacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSubFinalizacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubFinalizacao.FormattingEnabled = true;
            this.cbSubFinalizacao.Location = new System.Drawing.Point(154, 91);
            this.cbSubFinalizacao.Name = "cbSubFinalizacao";
            this.cbSubFinalizacao.Size = new System.Drawing.Size(331, 21);
            this.cbSubFinalizacao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Finalização:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SubFinalização:";
            // 
            // txtObservacao
            // 
            this.txtObservacao.BackColor = System.Drawing.Color.Azure;
            this.txtObservacao.Location = new System.Drawing.Point(154, 144);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(331, 142);
            this.txtObservacao.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Observação:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(199, 296);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(118, 45);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(323, 296);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 45);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbNomeFila
            // 
            this.lbNomeFila.AutoSize = true;
            this.lbNomeFila.BackColor = System.Drawing.Color.Transparent;
            this.lbNomeFila.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomeFila.Location = new System.Drawing.Point(26, 19);
            this.lbNomeFila.Name = "lbNomeFila";
            this.lbNomeFila.Size = new System.Drawing.Size(135, 24);
            this.lbNomeFila.TabIndex = 8;
            this.lbNomeFila.Text = "Nome da Fila";
            // 
            // txtValorEnvolvido
            // 
            this.txtValorEnvolvido.Location = new System.Drawing.Point(154, 118);
            this.txtValorEnvolvido.Name = "txtValorEnvolvido";
            this.txtValorEnvolvido.Size = new System.Drawing.Size(331, 20);
            this.txtValorEnvolvido.TabIndex = 2;
            this.txtValorEnvolvido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorEnvolvido_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Valor Envolvido (r$):";
            // 
            // frmCategorizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 383);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtValorEnvolvido);
            this.Controls.Add(this.lbNomeFila);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSubFinalizacao);
            this.Controls.Add(this.cbFinalizacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCategorizacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Categorização :.";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCategorizacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFinalizacao;
        private System.Windows.Forms.ComboBox cbSubFinalizacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbNomeFila;
        private System.Windows.Forms.TextBox txtValorEnvolvido;
        private System.Windows.Forms.Label label4;
    }
}