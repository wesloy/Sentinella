namespace Sentinella.Forms {
    partial class frmTrilhasSGI_detalhesSinergy {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrilhasSGI_detalhesSinergy));
            this.dtgvDetalhesSinergy = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetalhesSinergy)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvDetalhesSinergy
            // 
            this.dtgvDetalhesSinergy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDetalhesSinergy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDetalhesSinergy.Location = new System.Drawing.Point(0, 0);
            this.dtgvDetalhesSinergy.Name = "dtgvDetalhesSinergy";
            this.dtgvDetalhesSinergy.Size = new System.Drawing.Size(800, 450);
            this.dtgvDetalhesSinergy.TabIndex = 0;
            // 
            // frmTrilhasSGI_detalhesSinergy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgvDetalhesSinergy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrilhasSGI_detalhesSinergy";
            this.Text = ".: Detalhes Sinergy :.";
            this.Load += new System.EventHandler(this.frmTrilhasSGI_detalhesSinergy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDetalhesSinergy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvDetalhesSinergy;
    }
}