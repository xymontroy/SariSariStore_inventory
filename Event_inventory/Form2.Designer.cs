
namespace Event_inventory
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnScanBarcode_Click = new System.Windows.Forms.Button();
            this.pictureBoxScannedBarcode = new System.Windows.Forms.PictureBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtStockSales = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.newbutton = new System.Windows.Forms.Button();
            this.expirationDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScannedBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "POINT OF SALES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Product Name";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(37, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(242, 22);
            this.txtName.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(37, 140);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(242, 22);
            this.txtPrice.TabIndex = 6;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(37, 194);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(242, 22);
            this.txtQuantity.TabIndex = 8;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(37, 247);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(242, 22);
            this.txtBarcode.TabIndex = 10;
            // 
            // btnScanBarcode_Click
            // 
            this.btnScanBarcode_Click.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnScanBarcode_Click.BackgroundImage")));
            this.btnScanBarcode_Click.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScanBarcode_Click.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScanBarcode_Click.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanBarcode_Click.Location = new System.Drawing.Point(136, 406);
            this.btnScanBarcode_Click.Name = "btnScanBarcode_Click";
            this.btnScanBarcode_Click.Size = new System.Drawing.Size(219, 31);
            this.btnScanBarcode_Click.TabIndex = 12;
            this.btnScanBarcode_Click.Text = "Scan";
            this.btnScanBarcode_Click.UseVisualStyleBackColor = true;
            this.btnScanBarcode_Click.Click += new System.EventHandler(this.btnScanBarcode_Click_Click);
            // 
            // pictureBoxScannedBarcode
            // 
            this.pictureBoxScannedBarcode.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxScannedBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxScannedBarcode.Location = new System.Drawing.Point(41, 13);
            this.pictureBoxScannedBarcode.Name = "pictureBoxScannedBarcode";
            this.pictureBoxScannedBarcode.Size = new System.Drawing.Size(326, 87);
            this.pictureBoxScannedBarcode.TabIndex = 13;
            this.pictureBoxScannedBarcode.TabStop = false;
            this.pictureBoxScannedBarcode.Click += new System.EventHandler(this.pictureBoxBarcode_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(37, 84);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(242, 22);
            this.txtDescription.TabIndex = 14;
            // 
            // txtStockSales
            // 
            this.txtStockSales.Location = new System.Drawing.Point(38, 367);
            this.txtStockSales.Name = "txtStockSales";
            this.txtStockSales.Size = new System.Drawing.Size(241, 22);
            this.txtStockSales.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(136, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 31);
            this.button1.TabIndex = 18;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // newbutton
            // 
            this.newbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newbutton.BackgroundImage")));
            this.newbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newbutton.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newbutton.Location = new System.Drawing.Point(136, 452);
            this.newbutton.Name = "newbutton";
            this.newbutton.Size = new System.Drawing.Size(219, 31);
            this.newbutton.TabIndex = 19;
            this.newbutton.Text = "Clear";
            this.newbutton.UseVisualStyleBackColor = true;
            this.newbutton.Click += new System.EventHandler(this.newbutton_Click);
            // 
            // expirationDate
            // 
            this.expirationDate.Location = new System.Drawing.Point(37, 308);
            this.expirationDate.Name = "expirationDate";
            this.expirationDate.Size = new System.Drawing.Size(242, 22);
            this.expirationDate.TabIndex = 22;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(326, 134);
            this.dataGridView1.TabIndex = 24;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Location = new System.Drawing.Point(267, 267);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(100, 17);
            this.lblTotalAmount.TabIndex = 25;
            this.lblTotalAmount.Text = "Total Amount..";
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Location = new System.Drawing.Point(136, 310);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(219, 22);
            this.txtAmountPaid.TabIndex = 26;
            // 
            // btnPay
            // 
            this.btnPay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPay.BackgroundImage")));
            this.btnPay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Location = new System.Drawing.Point(136, 358);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(219, 31);
            this.btnPay.TabIndex = 27;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(38, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Cash Amount";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BackgroundImage = global::Event_inventory.Properties.Resources.btn3;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnPay);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.newbutton);
            this.panel1.Controls.Add(this.txtAmountPaid);
            this.panel1.Controls.Add(this.pictureBoxScannedBarcode);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Controls.Add(this.btnScanBarcode_Click);
            this.panel1.Location = new System.Drawing.Point(474, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 574);
            this.panel1.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 21);
            this.label6.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(191, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "Product Expiration Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 20);
            this.label11.TabIndex = 34;
            this.label11.Text = "Product Barcode";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(39, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "Product Stock";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(34, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 20);
            this.label13.TabIndex = 32;
            this.label13.Text = "Product Price";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(34, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(160, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "Product Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gadugi", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Product Solds";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.BackgroundImage = global::Event_inventory.Properties.Resources.btn3;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.expirationDate);
            this.panel2.Controls.Add(this.txtStockSales);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.txtBarcode);
            this.panel2.Controls.Add(this.txtQuantity);
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Location = new System.Drawing.Point(36, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 412);
            this.panel2.TabIndex = 37;
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.Location = new System.Drawing.Point(91, 511);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(213, 138);
            this.pictureBoxQRCode.TabIndex = 38;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 652);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 25);
            this.label4.TabIndex = 39;
            this.label4.Text = "QrCode Receipt";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::Event_inventory.Properties.Resources._32549261;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(980, 707);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBoxQRCode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.Text = "POS";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScannedBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnScanBarcode_Click;
        private System.Windows.Forms.PictureBox pictureBoxScannedBarcode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtStockSales;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button newbutton;
        private System.Windows.Forms.DateTimePicker expirationDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private System.Windows.Forms.Label label4;
    }
}