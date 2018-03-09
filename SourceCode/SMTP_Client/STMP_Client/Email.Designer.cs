namespace SMTP_Client
{
    partial class Email
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxIP1 = new System.Windows.Forms.TextBox();
            this.txtboxIP4 = new System.Windows.Forms.TextBox();
            this.txtboxIP2 = new System.Windows.Forms.TextBox();
            this.txtboxIP3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblConnected = new System.Windows.Forms.Label();
            this.txtboxFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtboxTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtboxEmail = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSent = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtboxSubject = new System.Windows.Forms.TextBox();
            this.btnAddTo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Server IP:";
            // 
            // txtboxIP1
            // 
            this.txtboxIP1.Location = new System.Drawing.Point(215, 18);
            this.txtboxIP1.Name = "txtboxIP1";
            this.txtboxIP1.Size = new System.Drawing.Size(39, 20);
            this.txtboxIP1.TabIndex = 1;
            // 
            // txtboxIP4
            // 
            this.txtboxIP4.Location = new System.Drawing.Point(416, 19);
            this.txtboxIP4.Name = "txtboxIP4";
            this.txtboxIP4.Size = new System.Drawing.Size(39, 20);
            this.txtboxIP4.TabIndex = 4;
            // 
            // txtboxIP2
            // 
            this.txtboxIP2.Location = new System.Drawing.Point(282, 19);
            this.txtboxIP2.Name = "txtboxIP2";
            this.txtboxIP2.Size = new System.Drawing.Size(39, 20);
            this.txtboxIP2.TabIndex = 2;
            // 
            // txtboxIP3
            // 
            this.txtboxIP3.Location = new System.Drawing.Point(349, 19);
            this.txtboxIP3.Name = "txtboxIP3";
            this.txtboxIP3.Size = new System.Drawing.Size(39, 20);
            this.txtboxIP3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(327, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(394, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = ".";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(478, 16);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnected.Location = new System.Drawing.Point(255, 52);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(0, 24);
            this.lblConnected.TabIndex = 9;
            // 
            // txtboxFrom
            // 
            this.txtboxFrom.Location = new System.Drawing.Point(131, 97);
            this.txtboxFrom.Name = "txtboxFrom";
            this.txtboxFrom.Size = new System.Drawing.Size(387, 20);
            this.txtboxFrom.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "From:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "To:";
            // 
            // txtboxTo
            // 
            this.txtboxTo.Location = new System.Drawing.Point(131, 135);
            this.txtboxTo.Name = "txtboxTo";
            this.txtboxTo.Size = new System.Drawing.Size(387, 20);
            this.txtboxTo.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "Email:";
            // 
            // txtboxEmail
            // 
            this.txtboxEmail.Location = new System.Drawing.Point(131, 230);
            this.txtboxEmail.Multiline = true;
            this.txtboxEmail.Name = "txtboxEmail";
            this.txtboxEmail.Size = new System.Drawing.Size(387, 256);
            this.txtboxEmail.TabIndex = 16;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(259, 502);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSent
            // 
            this.lblSent.AutoSize = true;
            this.lblSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSent.Location = new System.Drawing.Point(270, 538);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(0, 24);
            this.lblSent.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Subject:";
            // 
            // txtboxSubject
            // 
            this.txtboxSubject.Location = new System.Drawing.Point(131, 170);
            this.txtboxSubject.Name = "txtboxSubject";
            this.txtboxSubject.Size = new System.Drawing.Size(387, 20);
            this.txtboxSubject.TabIndex = 14;
            // 
            // btnAddTo
            // 
            this.btnAddTo.Location = new System.Drawing.Point(524, 134);
            this.btnAddTo.Name = "btnAddTo";
            this.btnAddTo.Size = new System.Drawing.Size(29, 23);
            this.btnAddTo.TabIndex = 20;
            this.btnAddTo.Text = "+";
            this.btnAddTo.UseVisualStyleBackColor = true;
            this.btnAddTo.Click += new System.EventHandler(this.button1_Click);
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 576);
            this.Controls.Add(this.btnAddTo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtboxSubject);
            this.Controls.Add(this.lblSent);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtboxEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtboxTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtboxFrom);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtboxIP3);
            this.Controls.Add(this.txtboxIP2);
            this.Controls.Add(this.txtboxIP4);
            this.Controls.Add(this.txtboxIP1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Email";
            this.Text = "Sending Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxIP1;
        private System.Windows.Forms.TextBox txtboxIP4;
        private System.Windows.Forms.TextBox txtboxIP2;
        private System.Windows.Forms.TextBox txtboxIP3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.TextBox txtboxFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtboxTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtboxEmail;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtboxSubject;
        private System.Windows.Forms.Button btnAddTo;
    }
}

