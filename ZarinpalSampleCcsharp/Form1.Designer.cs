namespace ZarinpalSampleCcsharp
{
    partial class Form1
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
            this.btnrequest = new System.Windows.Forms.Button();
            this.lblrequest = new System.Windows.Forms.Label();
            this.btnverify = new System.Windows.Forms.Button();
            this.lblverify = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnrequest
            // 
            this.btnrequest.Location = new System.Drawing.Point(26, 12);
            this.btnrequest.Name = "btnrequest";
            this.btnrequest.Size = new System.Drawing.Size(75, 23);
            this.btnrequest.TabIndex = 0;
            this.btnrequest.Text = "request";
            this.btnrequest.UseVisualStyleBackColor = true;
            this.btnrequest.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblrequest
            // 
            this.lblrequest.AutoSize = true;
            this.lblrequest.Location = new System.Drawing.Point(23, 57);
            this.lblrequest.Name = "lblrequest";
            this.lblrequest.Size = new System.Drawing.Size(70, 13);
            this.lblrequest.TabIndex = 2;
            this.lblrequest.Text = "request result";
            // 
            // btnverify
            // 
            this.btnverify.Location = new System.Drawing.Point(270, 12);
            this.btnverify.Name = "btnverify";
            this.btnverify.Size = new System.Drawing.Size(75, 23);
            this.btnverify.TabIndex = 3;
            this.btnverify.Text = "verify";
            this.btnverify.UseVisualStyleBackColor = true;
            this.btnverify.Click += new System.EventHandler(this.btnverify_Click);
            // 
            // lblverify
            // 
            this.lblverify.AutoSize = true;
            this.lblverify.Location = new System.Drawing.Point(267, 110);
            this.lblverify.Name = "lblverify";
            this.lblverify.Size = new System.Drawing.Size(32, 13);
            this.lblverify.TabIndex = 4;
            this.lblverify.Text = "verify";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 336);
            this.Controls.Add(this.lblverify);
            this.Controls.Add(this.btnverify);
            this.Controls.Add(this.lblrequest);
            this.Controls.Add(this.btnrequest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnrequest;
        private System.Windows.Forms.Label lblrequest;
        private System.Windows.Forms.Button btnverify;
        private System.Windows.Forms.Label lblverify;
    }
}

