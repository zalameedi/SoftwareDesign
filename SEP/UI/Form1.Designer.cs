namespace UI
{
    partial class LocalEatery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalEatery));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Table5_Order = new System.Windows.Forms.Button();
            this.Table2_Order = new System.Windows.Forms.Button();
            this.Table3_Order = new System.Windows.Forms.Button();
            this.Table4_Order = new System.Windows.Forms.Button();
            this.Table1_Order = new System.Windows.Forms.Button();
            this.Table3_Status = new System.Windows.Forms.Label();
            this.Table4_Status = new System.Windows.Forms.Label();
            this.Table5_Status = new System.Windows.Forms.Label();
            this.Table2_Status = new System.Windows.Forms.Label();
            this.Table1_Status = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Table5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.OrderQueue = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 415);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.OrderQueue);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(826, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cook";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(826, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manager";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Table5_Order);
            this.tabPage3.Controls.Add(this.Table2_Order);
            this.tabPage3.Controls.Add(this.Table3_Order);
            this.tabPage3.Controls.Add(this.Table4_Order);
            this.tabPage3.Controls.Add(this.Table1_Order);
            this.tabPage3.Controls.Add(this.Table3_Status);
            this.tabPage3.Controls.Add(this.Table4_Status);
            this.tabPage3.Controls.Add(this.Table5_Status);
            this.tabPage3.Controls.Add(this.Table2_Status);
            this.tabPage3.Controls.Add(this.Table1_Status);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.Table5);
            this.tabPage3.Controls.Add(this.pictureBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(826, 389);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Waiter";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Table5_Order
            // 
            this.Table5_Order.BackColor = System.Drawing.Color.SkyBlue;
            this.Table5_Order.Location = new System.Drawing.Point(718, 335);
            this.Table5_Order.Name = "Table5_Order";
            this.Table5_Order.Size = new System.Drawing.Size(61, 29);
            this.Table5_Order.TabIndex = 16;
            this.Table5_Order.Text = "Order";
            this.Table5_Order.UseVisualStyleBackColor = false;
            // 
            // Table2_Order
            // 
            this.Table2_Order.BackColor = System.Drawing.Color.SkyBlue;
            this.Table2_Order.Location = new System.Drawing.Point(718, 83);
            this.Table2_Order.Name = "Table2_Order";
            this.Table2_Order.Size = new System.Drawing.Size(61, 29);
            this.Table2_Order.TabIndex = 15;
            this.Table2_Order.Text = "Order";
            this.Table2_Order.UseVisualStyleBackColor = false;
            // 
            // Table3_Order
            // 
            this.Table3_Order.BackColor = System.Drawing.Color.SkyBlue;
            this.Table3_Order.Location = new System.Drawing.Point(578, 213);
            this.Table3_Order.Name = "Table3_Order";
            this.Table3_Order.Size = new System.Drawing.Size(61, 29);
            this.Table3_Order.TabIndex = 14;
            this.Table3_Order.Text = "Order";
            this.Table3_Order.UseVisualStyleBackColor = false;
            // 
            // Table4_Order
            // 
            this.Table4_Order.BackColor = System.Drawing.Color.SkyBlue;
            this.Table4_Order.Location = new System.Drawing.Point(436, 335);
            this.Table4_Order.Name = "Table4_Order";
            this.Table4_Order.Size = new System.Drawing.Size(61, 29);
            this.Table4_Order.TabIndex = 13;
            this.Table4_Order.Text = "Order";
            this.Table4_Order.UseVisualStyleBackColor = false;
            // 
            // Table1_Order
            // 
            this.Table1_Order.BackColor = System.Drawing.Color.SkyBlue;
            this.Table1_Order.Location = new System.Drawing.Point(436, 83);
            this.Table1_Order.Name = "Table1_Order";
            this.Table1_Order.Size = new System.Drawing.Size(61, 29);
            this.Table1_Order.TabIndex = 12;
            this.Table1_Order.Text = "Order";
            this.Table1_Order.UseVisualStyleBackColor = false;
            this.Table1_Order.Click += new System.EventHandler(this.Table1_Order_Click);
            // 
            // Table3_Status
            // 
            this.Table3_Status.AutoSize = true;
            this.Table3_Status.BackColor = System.Drawing.Color.Chartreuse;
            this.Table3_Status.Location = new System.Drawing.Point(589, 188);
            this.Table3_Status.Name = "Table3_Status";
            this.Table3_Status.Size = new System.Drawing.Size(38, 13);
            this.Table3_Status.TabIndex = 11;
            this.Table3_Status.Text = "Ready";
            // 
            // Table4_Status
            // 
            this.Table4_Status.AutoSize = true;
            this.Table4_Status.BackColor = System.Drawing.Color.Chartreuse;
            this.Table4_Status.Location = new System.Drawing.Point(451, 307);
            this.Table4_Status.Name = "Table4_Status";
            this.Table4_Status.Size = new System.Drawing.Size(38, 13);
            this.Table4_Status.TabIndex = 10;
            this.Table4_Status.Text = "Ready";
            // 
            // Table5_Status
            // 
            this.Table5_Status.AutoSize = true;
            this.Table5_Status.BackColor = System.Drawing.Color.Chartreuse;
            this.Table5_Status.Location = new System.Drawing.Point(728, 307);
            this.Table5_Status.Name = "Table5_Status";
            this.Table5_Status.Size = new System.Drawing.Size(38, 13);
            this.Table5_Status.TabIndex = 9;
            this.Table5_Status.Text = "Ready";
            // 
            // Table2_Status
            // 
            this.Table2_Status.AutoSize = true;
            this.Table2_Status.BackColor = System.Drawing.Color.Chartreuse;
            this.Table2_Status.Location = new System.Drawing.Point(728, 53);
            this.Table2_Status.Name = "Table2_Status";
            this.Table2_Status.Size = new System.Drawing.Size(38, 13);
            this.Table2_Status.TabIndex = 8;
            this.Table2_Status.Text = "Ready";
            // 
            // Table1_Status
            // 
            this.Table1_Status.AutoSize = true;
            this.Table1_Status.BackColor = System.Drawing.Color.Chartreuse;
            this.Table1_Status.Location = new System.Drawing.Point(451, 53);
            this.Table1_Status.Name = "Table1_Status";
            this.Table1_Status.Size = new System.Drawing.Size(38, 13);
            this.Table1_Status.TabIndex = 7;
            this.Table1_Status.Text = "Ready";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(436, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Table 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(578, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Table 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(715, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Table 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(436, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Table 4";
            // 
            // Table5
            // 
            this.Table5.AutoSize = true;
            this.Table5.BackColor = System.Drawing.Color.Gainsboro;
            this.Table5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Table5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Table5.Location = new System.Drawing.Point(715, 281);
            this.Table5.Name = "Table5";
            this.Table5.Size = new System.Drawing.Size(61, 16);
            this.Table5.TabIndex = 2;
            this.Table5.Text = "Table 5";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(361, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(462, 386);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // OrderQueue
            // 
            this.OrderQueue.FormattingEnabled = true;
            this.OrderQueue.Location = new System.Drawing.Point(454, 0);
            this.OrderQueue.Name = "OrderQueue";
            this.OrderQueue.Size = new System.Drawing.Size(372, 379);
            this.OrderQueue.TabIndex = 1;
            // 
            // LocalEatery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 418);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LocalEatery";
            this.Text = "LocalEatery";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label Table3_Status;
        private System.Windows.Forms.Label Table4_Status;
        private System.Windows.Forms.Label Table5_Status;
        private System.Windows.Forms.Label Table2_Status;
        private System.Windows.Forms.Label Table1_Status;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Table5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Table5_Order;
        private System.Windows.Forms.Button Table2_Order;
        private System.Windows.Forms.Button Table3_Order;
        private System.Windows.Forms.Button Table4_Order;
        private System.Windows.Forms.Button Table1_Order;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckedListBox OrderQueue;
    }
}

