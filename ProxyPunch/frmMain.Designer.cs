namespace ProxyPunch
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.btnBind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSocksIP = new System.Windows.Forms.TextBox();
            this.lblSocksPort = new System.Windows.Forms.Label();
            this.txtSocksPort = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBind
            // 
            this.btnBind.Location = new System.Drawing.Point(511, 10);
            this.btnBind.Name = "btnBind";
            this.btnBind.Size = new System.Drawing.Size(75, 23);
            this.btnBind.TabIndex = 0;
            this.btnBind.Text = "Bind";
            this.btnBind.UseVisualStyleBackColor = true;
            this.btnBind.Click += new System.EventHandler(this.btnBind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Socks IP";
            // 
            // txtSocksIP
            // 
            this.txtSocksIP.Location = new System.Drawing.Point(64, 12);
            this.txtSocksIP.Name = "txtSocksIP";
            this.txtSocksIP.Size = new System.Drawing.Size(100, 20);
            this.txtSocksIP.TabIndex = 2;
            // 
            // lblSocksPort
            // 
            this.lblSocksPort.AutoSize = true;
            this.lblSocksPort.Location = new System.Drawing.Point(170, 15);
            this.lblSocksPort.Name = "lblSocksPort";
            this.lblSocksPort.Size = new System.Drawing.Size(59, 13);
            this.lblSocksPort.TabIndex = 3;
            this.lblSocksPort.Text = "Socks Port";
            // 
            // txtSocksPort
            // 
            this.txtSocksPort.Location = new System.Drawing.Point(235, 12);
            this.txtSocksPort.Name = "txtSocksPort";
            this.txtSocksPort.Size = new System.Drawing.Size(65, 20);
            this.txtSocksPort.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "to 127.0.0.1:";
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(379, 12);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(65, 20);
            this.txtLocalPort.TabIndex = 6;
            // 
            // txtOutput
            // 
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(13, 39);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(573, 210);
            this.txtOutput.TabIndex = 7;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnBind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 261);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSocksPort);
            this.Controls.Add(this.lblSocksPort);
            this.Controls.Add(this.txtSocksIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBind);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(614, 300);
            this.MinimumSize = new System.Drawing.Size(614, 300);
            this.Name = "frmMain";
            this.Text = "ProxyPunch by SILO GROUP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSocksIP;
        private System.Windows.Forms.Label lblSocksPort;
        private System.Windows.Forms.TextBox txtSocksPort;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.TextBox txtOutput;
    }
}

