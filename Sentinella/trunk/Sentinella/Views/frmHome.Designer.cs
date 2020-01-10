namespace Sentinella.Forms
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.lnkGoogle = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkCalculadora = new System.Windows.Forms.LinkLabel();
            this.lnkNotepad = new System.Windows.Forms.LinkLabel();
            this.linkGTH = new System.Windows.Forms.LinkLabel();
            this.linkAlgarNet = new System.Windows.Forms.LinkLabel();
            this.linkExcel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lnkGoogle
            // 
            this.lnkGoogle.AutoSize = true;
            this.lnkGoogle.BackColor = System.Drawing.Color.Transparent;
            this.lnkGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkGoogle.Location = new System.Drawing.Point(49, 129);
            this.lnkGoogle.Name = "lnkGoogle";
            this.lnkGoogle.Size = new System.Drawing.Size(54, 17);
            this.lnkGoogle.TabIndex = 3;
            this.lnkGoogle.TabStop = true;
            this.lnkGoogle.Text = "Google";
            this.lnkGoogle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGoogle_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Links Úteis";
            // 
            // lnkCalculadora
            // 
            this.lnkCalculadora.AutoSize = true;
            this.lnkCalculadora.BackColor = System.Drawing.Color.Transparent;
            this.lnkCalculadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCalculadora.Location = new System.Drawing.Point(234, 88);
            this.lnkCalculadora.Name = "lnkCalculadora";
            this.lnkCalculadora.Size = new System.Drawing.Size(83, 17);
            this.lnkCalculadora.TabIndex = 4;
            this.lnkCalculadora.TabStop = true;
            this.lnkCalculadora.Text = "Calculadora";
            this.lnkCalculadora.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCalculadora_LinkClicked);
            // 
            // lnkNotepad
            // 
            this.lnkNotepad.AutoSize = true;
            this.lnkNotepad.BackColor = System.Drawing.Color.Transparent;
            this.lnkNotepad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNotepad.Location = new System.Drawing.Point(234, 170);
            this.lnkNotepad.Name = "lnkNotepad";
            this.lnkNotepad.Size = new System.Drawing.Size(62, 17);
            this.lnkNotepad.TabIndex = 5;
            this.lnkNotepad.TabStop = true;
            this.lnkNotepad.Text = "Notepad";
            this.lnkNotepad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNotepad_LinkClicked);
            // 
            // linkGTH
            // 
            this.linkGTH.AutoSize = true;
            this.linkGTH.BackColor = System.Drawing.Color.Transparent;
            this.linkGTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkGTH.Location = new System.Drawing.Point(49, 170);
            this.linkGTH.Name = "linkGTH";
            this.linkGTH.Size = new System.Drawing.Size(38, 17);
            this.linkGTH.TabIndex = 6;
            this.linkGTH.TabStop = true;
            this.linkGTH.Text = "GTH";
            this.linkGTH.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGTH_LinkClicked);
            // 
            // linkAlgarNet
            // 
            this.linkAlgarNet.AutoSize = true;
            this.linkAlgarNet.BackColor = System.Drawing.Color.Transparent;
            this.linkAlgarNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAlgarNet.Location = new System.Drawing.Point(49, 88);
            this.linkAlgarNet.Name = "linkAlgarNet";
            this.linkAlgarNet.Size = new System.Drawing.Size(67, 17);
            this.linkAlgarNet.TabIndex = 7;
            this.linkAlgarNet.TabStop = true;
            this.linkAlgarNet.Text = "Algar Net";
            this.linkAlgarNet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAlgarNet_LinkClicked);
            // 
            // linkExcel
            // 
            this.linkExcel.AutoSize = true;
            this.linkExcel.BackColor = System.Drawing.Color.Transparent;
            this.linkExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkExcel.Location = new System.Drawing.Point(234, 129);
            this.linkExcel.Name = "linkExcel";
            this.linkExcel.Size = new System.Drawing.Size(41, 17);
            this.linkExcel.TabIndex = 8;
            this.linkExcel.TabStop = true;
            this.linkExcel.Text = "Excel";
            this.linkExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkExcel_LinkClicked);
            // 
            // frmHoma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(895, 413);
            this.Controls.Add(this.linkExcel);
            this.Controls.Add(this.linkAlgarNet);
            this.Controls.Add(this.linkGTH);
            this.Controls.Add(this.lnkNotepad);
            this.Controls.Add(this.lnkCalculadora);
            this.Controls.Add(this.lnkGoogle);
            this.Controls.Add(this.label1);
            this.Name = "frmHoma";
            this.Text = "frmHoma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkGoogle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkCalculadora;
        private System.Windows.Forms.LinkLabel lnkNotepad;
        private System.Windows.Forms.LinkLabel linkGTH;
        private System.Windows.Forms.LinkLabel linkAlgarNet;
        private System.Windows.Forms.LinkLabel linkExcel;
    }
}