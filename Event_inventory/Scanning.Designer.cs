
namespace Event_inventory
{
    partial class Scanning
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
            this.txtScannedBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartScanning = new System.Windows.Forms.Button();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.cboCamera = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // txtScannedBarcode
            // 
            this.txtScannedBarcode.Location = new System.Drawing.Point(73, 173);
            this.txtScannedBarcode.Name = "txtScannedBarcode";
            this.txtScannedBarcode.Size = new System.Drawing.Size(196, 22);
            this.txtScannedBarcode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scanned Barcode";
            // 
            // btnStartScanning
            // 
            this.btnStartScanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartScanning.Location = new System.Drawing.Point(73, 231);
            this.btnStartScanning.Name = "btnStartScanning";
            this.btnStartScanning.Size = new System.Drawing.Size(196, 34);
            this.btnStartScanning.TabIndex = 2;
            this.btnStartScanning.Text = "Start";
            this.btnStartScanning.UseVisualStyleBackColor = true;
            this.btnStartScanning.Click += new System.EventHandler(this.btnStartScanning_Click);
            // 
            // picCamera
            // 
            this.picCamera.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picCamera.Location = new System.Drawing.Point(330, 74);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(492, 236);
            this.picCamera.TabIndex = 3;
            this.picCamera.TabStop = false;
            // 
            // cboCamera
            // 
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(73, 101);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(196, 24);
            this.cboCamera.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Camera";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(73, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Scanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(916, 419);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCamera);
            this.Controls.Add(this.picCamera);
            this.Controls.Add(this.btnStartScanning);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScannedBarcode);
            this.Name = "Scanning";
            this.Text = "Scanning";
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtScannedBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartScanning;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.ComboBox cboCamera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}