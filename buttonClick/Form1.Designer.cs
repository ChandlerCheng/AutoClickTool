
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
            this.textF11Ms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonFunctionRead = new System.Windows.Forms.Button();
            this.comboF11Function = new System.Windows.Forms.ComboBox();
            this.comboF11HotKey = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenNumFunc = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelNumDisplay = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            // textF11Ms
            // 
            this.textF11Ms.Location = new System.Drawing.Point(68, 80);
            this.textF11Ms.Name = "textF11Ms";
            this.textF11Ms.Size = new System.Drawing.Size(66, 23);
            this.textF11Ms.TabIndex = 5;
            this.textF11Ms.Text = "500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 83);
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
            // comboF11Function
            // 
            this.comboF11Function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboF11Function.FormattingEnabled = true;
            this.comboF11Function.Location = new System.Drawing.Point(67, 22);
            this.comboF11Function.Name = "comboF11Function";
            this.comboF11Function.Size = new System.Drawing.Size(170, 23);
            this.comboF11Function.TabIndex = 8;
            // 
            // comboF11HotKey
            // 
            this.comboF11HotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboF11HotKey.FormattingEnabled = true;
            this.comboF11HotKey.Location = new System.Drawing.Point(67, 51);
            this.comboF11HotKey.Name = "comboF11HotKey";
            this.comboF11HotKey.Size = new System.Drawing.Size(67, 23);
            this.comboF11HotKey.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textF11Ms);
            this.groupBox1.Controls.Add(this.comboF11HotKey);
            this.groupBox1.Controls.Add(this.comboF11Function);
            this.groupBox1.Location = new System.Drawing.Point(9, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 115);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "F11 循環功能設定";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "使用熱鍵";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "功能選擇";
            // 
            // btnOpenNumFunc
            // 
            this.btnOpenNumFunc.Location = new System.Drawing.Point(130, 41);
            this.btnOpenNumFunc.Name = "btnOpenNumFunc";
            this.btnOpenNumFunc.Size = new System.Drawing.Size(74, 22);
            this.btnOpenNumFunc.TabIndex = 11;
            this.btnOpenNumFunc.Text = "開啟小鍵";
            this.btnOpenNumFunc.UseVisualStyleBackColor = true;
            this.btnOpenNumFunc.Click += new System.EventHandler(this.btnOpenNumFunc_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "小鍵功能";
            // 
            // labelNumDisplay
            // 
            this.labelNumDisplay.AutoSize = true;
            this.labelNumDisplay.ForeColor = System.Drawing.Color.Red;
            this.labelNumDisplay.Location = new System.Drawing.Point(190, 73);
            this.labelNumDisplay.Name = "labelNumDisplay";
            this.labelNumDisplay.Size = new System.Drawing.Size(31, 15);
            this.labelNumDisplay.TabIndex = 13;
            this.labelNumDisplay.Text = "關閉";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 219);
            this.Controls.Add(this.labelNumDisplay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOpenNumFunc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonFunctionRead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textY);
            this.Controls.Add(this.textX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "ClickTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textF11Ms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonFunctionRead;
        private System.Windows.Forms.ComboBox comboF11Function;
        private System.Windows.Forms.ComboBox comboF11HotKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpenNumFunc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelNumDisplay;
    }
}

