
namespace buttonClick
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textX = new System.Windows.Forms.TextBox();
            this.textY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textMs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonFunctionRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textX
            // 
            this.textX.Location = new System.Drawing.Point(42, 12);
            this.textX.Name = "textX";
            this.textX.Size = new System.Drawing.Size(72, 23);
            this.textX.TabIndex = 0;
            // 
            // textY
            // 
            this.textY.Location = new System.Drawing.Point(42, 41);
            this.textY.Name = "textY";
            this.textY.Size = new System.Drawing.Size(72, 23);
            this.textY.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "X軸";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y軸";
            // 
            // textMs
            // 
            this.textMs.Location = new System.Drawing.Point(42, 70);
            this.textMs.Name = "textMs";
            this.textMs.Size = new System.Drawing.Size(72, 23);
            this.textMs.TabIndex = 5;
            this.textMs.Text = "500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "延遲";
            // 
            // buttonFunctionRead
            // 
            this.buttonFunctionRead.Location = new System.Drawing.Point(129, 12);
            this.buttonFunctionRead.Name = "buttonFunctionRead";
            this.buttonFunctionRead.Size = new System.Drawing.Size(76, 23);
            this.buttonFunctionRead.TabIndex = 7;
            this.buttonFunctionRead.Text = "功能列表";
            this.buttonFunctionRead.UseVisualStyleBackColor = true;
            this.buttonFunctionRead.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 109);
            this.Controls.Add(this.buttonFunctionRead);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textMs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.textX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "ClickTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonFunctionRead;
    }
}

