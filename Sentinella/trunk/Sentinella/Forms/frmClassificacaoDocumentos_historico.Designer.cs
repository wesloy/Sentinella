namespace Sentinella.Forms {
    partial class frmClassificacaoDocumentos_historico {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassificacaoDocumentos_historico));
            this.dtgvHistoricoClassificacaoDocumentos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHistoricoClassificacaoDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvHistoricoClassificacaoDocumentos
            // 
            this.dtgvHistoricoClassificacaoDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHistoricoClassificacaoDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvHistoricoClassificacaoDocumentos.Location = new System.Drawing.Point(0, 0);
            this.dtgvHistoricoClassificacaoDocumentos.Name = "dtgvHistoricoClassificacaoDocumentos";
            this.dtgvHistoricoClassificacaoDocumentos.Size = new System.Drawing.Size(800, 450);
            this.dtgvHistoricoClassificacaoDocumentos.TabIndex = 1;
            // 
            // frmClassificacaoDocumentos_historico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgvHistoricoClassificacaoDocumentos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClassificacaoDocumentos_historico";
            this.Text = ".: Histórico Análises Classificação :.";
            this.Load += new System.EventHandler(this.frmClassificacaoDocumentos_historico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHistoricoClassificacaoDocumentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvHistoricoClassificacaoDocumentos;
    }
}