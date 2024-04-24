
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textF11Ms = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonF11FunctionRead = new System.Windows.Forms.Button();
            this.comboF11Function = new System.Windows.Forms.ComboBox();
            this.comboF11HotKey = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetMpNow = new System.Windows.Forms.Button();
            this.comboCheckMPRatio = new System.Windows.Forms.ComboBox();
            this.comboTO_sec = new System.Windows.Forms.ComboBox();
            this.comboTO_Min = new System.Windows.Forms.ComboBox();
            this.comboTO_Hour = new System.Windows.Forms.ComboBox();
            this.checkTimeClose = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboDefHotKey = new System.Windows.Forms.ComboBox();
            this.comboHotKeyMP = new System.Windows.Forms.ComboBox();
            this.checkMP = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOpenNumFunc = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelNumDisplay = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxSkillMode = new System.Windows.Forms.ComboBox();
            this.labelSkillMode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSkillMode = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkPetSupport = new System.Windows.Forms.CheckBox();
            this.comboPetSup_Master = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "X軸";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y軸";
            // 
            // textF11Ms
            // 
            this.textF11Ms.Location = new System.Drawing.Point(68, 114);
            this.textF11Ms.Name = "textF11Ms";
            this.textF11Ms.Size = new System.Drawing.Size(66, 23);
            this.textF11Ms.TabIndex = 5;
            this.textF11Ms.Text = "500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "延遲";
            // 
            // buttonF11FunctionRead
            // 
            this.buttonF11FunctionRead.Location = new System.Drawing.Point(6, 260);
            this.buttonF11FunctionRead.Name = "buttonF11FunctionRead";
            this.buttonF11FunctionRead.Size = new System.Drawing.Size(76, 23);
            this.buttonF11FunctionRead.TabIndex = 7;
            this.buttonF11FunctionRead.Text = "功能列表";
            this.buttonF11FunctionRead.UseVisualStyleBackColor = true;
            this.buttonF11FunctionRead.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboF11Function
            // 
            this.comboF11Function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboF11Function.FormattingEnabled = true;
            this.comboF11Function.Location = new System.Drawing.Point(67, 22);
            this.comboF11Function.Name = "comboF11Function";
            this.comboF11Function.Size = new System.Drawing.Size(124, 23);
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
            this.groupBox1.Controls.Add(this.comboPetSup_Master);
            this.groupBox1.Controls.Add(this.checkPetSupport);
            this.groupBox1.Controls.Add(this.btnGetMpNow);
            this.groupBox1.Controls.Add(this.comboCheckMPRatio);
            this.groupBox1.Controls.Add(this.comboTO_sec);
            this.groupBox1.Controls.Add(this.comboTO_Min);
            this.groupBox1.Controls.Add(this.comboTO_Hour);
            this.groupBox1.Controls.Add(this.checkTimeClose);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboDefHotKey);
            this.groupBox1.Controls.Add(this.comboHotKeyMP);
            this.groupBox1.Controls.Add(this.checkMP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonF11FunctionRead);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textF11Ms);
            this.groupBox1.Controls.Add(this.comboF11HotKey);
            this.groupBox1.Controls.Add(this.comboF11Function);
            this.groupBox1.Location = new System.Drawing.Point(9, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 289);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "F11 循環功能設定";
            // 
            // btnGetMpNow
            // 
            this.btnGetMpNow.Location = new System.Drawing.Point(108, 260);
            this.btnGetMpNow.Name = "btnGetMpNow";
            this.btnGetMpNow.Size = new System.Drawing.Size(80, 23);
            this.btnGetMpNow.TabIndex = 21;
            this.btnGetMpNow.Text = "魔量檢查";
            this.btnGetMpNow.UseVisualStyleBackColor = true;
            this.btnGetMpNow.Click += new System.EventHandler(this.btnGetMpNow_Click);
            // 
            // comboCheckMPRatio
            // 
            this.comboCheckMPRatio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCheckMPRatio.FormattingEnabled = true;
            this.comboCheckMPRatio.Location = new System.Drawing.Point(86, 143);
            this.comboCheckMPRatio.Name = "comboCheckMPRatio";
            this.comboCheckMPRatio.Size = new System.Drawing.Size(40, 23);
            this.comboCheckMPRatio.TabIndex = 23;
            // 
            // comboTO_sec
            // 
            this.comboTO_sec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTO_sec.FormattingEnabled = true;
            this.comboTO_sec.Location = new System.Drawing.Point(140, 181);
            this.comboTO_sec.Name = "comboTO_sec";
            this.comboTO_sec.Size = new System.Drawing.Size(48, 23);
            this.comboTO_sec.TabIndex = 22;
            // 
            // comboTO_Min
            // 
            this.comboTO_Min.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTO_Min.FormattingEnabled = true;
            this.comboTO_Min.Location = new System.Drawing.Point(86, 181);
            this.comboTO_Min.Name = "comboTO_Min";
            this.comboTO_Min.Size = new System.Drawing.Size(48, 23);
            this.comboTO_Min.TabIndex = 21;
            // 
            // comboTO_Hour
            // 
            this.comboTO_Hour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTO_Hour.FormattingEnabled = true;
            this.comboTO_Hour.Location = new System.Drawing.Point(34, 181);
            this.comboTO_Hour.Name = "comboTO_Hour";
            this.comboTO_Hour.Size = new System.Drawing.Size(48, 23);
            this.comboTO_Hour.TabIndex = 20;
            // 
            // checkTimeClose
            // 
            this.checkTimeClose.AutoSize = true;
            this.checkTimeClose.Location = new System.Drawing.Point(10, 185);
            this.checkTimeClose.Name = "checkTimeClose";
            this.checkTimeClose.Size = new System.Drawing.Size(15, 14);
            this.checkTimeClose.TabIndex = 19;
            this.checkTimeClose.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "鞭炮熱鍵";
            // 
            // comboDefHotKey
            // 
            this.comboDefHotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDefHotKey.FormattingEnabled = true;
            this.comboDefHotKey.Location = new System.Drawing.Point(67, 80);
            this.comboDefHotKey.Name = "comboDefHotKey";
            this.comboDefHotKey.Size = new System.Drawing.Size(67, 23);
            this.comboDefHotKey.TabIndex = 14;
            // 
            // comboHotKeyMP
            // 
            this.comboHotKeyMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHotKeyMP.FormattingEnabled = true;
            this.comboHotKeyMP.Location = new System.Drawing.Point(132, 143);
            this.comboHotKeyMP.Name = "comboHotKeyMP";
            this.comboHotKeyMP.Size = new System.Drawing.Size(51, 23);
            this.comboHotKeyMP.TabIndex = 13;
            // 
            // checkMP
            // 
            this.checkMP.AutoSize = true;
            this.checkMP.Location = new System.Drawing.Point(9, 145);
            this.checkMP.Name = "checkMP";
            this.checkMP.Size = new System.Drawing.Size(74, 19);
            this.checkMP.TabIndex = 12;
            this.checkMP.Text = "魔力檢查";
            this.checkMP.UseVisualStyleBackColor = true;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "抓取視窗";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGteWindowsInfor);
            // 
            // btnOpenNumFunc
            // 
            this.btnOpenNumFunc.Location = new System.Drawing.Point(6, 22);
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
            this.label6.Location = new System.Drawing.Point(86, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "小鍵功能";
            // 
            // labelNumDisplay
            // 
            this.labelNumDisplay.AutoSize = true;
            this.labelNumDisplay.ForeColor = System.Drawing.Color.Red;
            this.labelNumDisplay.Location = new System.Drawing.Point(147, 26);
            this.labelNumDisplay.Name = "labelNumDisplay";
            this.labelNumDisplay.Size = new System.Drawing.Size(31, 15);
            this.labelNumDisplay.TabIndex = 13;
            this.labelNumDisplay.Text = "關閉";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenNumFunc);
            this.groupBox2.Controls.Add(this.labelNumDisplay);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(569, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 54);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "小鍵盤功能";
            // 
            // comboBoxSkillMode
            // 
            this.comboBoxSkillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSkillMode.FormattingEnabled = true;
            this.comboBoxSkillMode.Location = new System.Drawing.Point(6, 53);
            this.comboBoxSkillMode.Name = "comboBoxSkillMode";
            this.comboBoxSkillMode.Size = new System.Drawing.Size(74, 23);
            this.comboBoxSkillMode.TabIndex = 17;
            // 
            // labelSkillMode
            // 
            this.labelSkillMode.AutoSize = true;
            this.labelSkillMode.ForeColor = System.Drawing.Color.Red;
            this.labelSkillMode.Location = new System.Drawing.Point(147, 28);
            this.labelSkillMode.Name = "labelSkillMode";
            this.labelSkillMode.Size = new System.Drawing.Size(31, 15);
            this.labelSkillMode.TabIndex = 16;
            this.labelSkillMode.Text = "關閉";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "練技模式";
            // 
            // btnSkillMode
            // 
            this.btnSkillMode.Location = new System.Drawing.Point(6, 24);
            this.btnSkillMode.Name = "btnSkillMode";
            this.btnSkillMode.Size = new System.Drawing.Size(74, 23);
            this.btnSkillMode.TabIndex = 14;
            this.btnSkillMode.Text = "練技模式";
            this.btnSkillMode.UseVisualStyleBackColor = true;
            this.btnSkillMode.Click += new System.EventHandler(this.btnSkillMode_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxSkillMode);
            this.groupBox3.Controls.Add(this.labelSkillMode);
            this.groupBox3.Controls.Add(this.btnSkillMode);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(569, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 85);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "練技模式";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelY);
            this.groupBox4.Controls.Add(this.labelX);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(9, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 102);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "座標";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(43, 49);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(97, 15);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "<Label Y Coor>";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(43, 26);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(98, 15);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "<Label X Coor>";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(474, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "測試功能";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnTestFuction);
            // 
            // checkPetSupport
            // 
            this.checkPetSupport.AutoSize = true;
            this.checkPetSupport.Location = new System.Drawing.Point(10, 220);
            this.checkPetSupport.Name = "checkPetSupport";
            this.checkPetSupport.Size = new System.Drawing.Size(74, 19);
            this.checkPetSupport.TabIndex = 24;
            this.checkPetSupport.Text = "寵物輔助";
            this.checkPetSupport.UseVisualStyleBackColor = true;
            // 
            // comboPetSup_Master
            // 
            this.comboPetSup_Master.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPetSup_Master.FormattingEnabled = true;
            this.comboPetSup_Master.Location = new System.Drawing.Point(86, 218);
            this.comboPetSup_Master.Name = "comboPetSup_Master";
            this.comboPetSup_Master.Size = new System.Drawing.Size(48, 23);
            this.comboPetSup_Master.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 408);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "ClickTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textF11Ms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonF11FunctionRead;
        private System.Windows.Forms.ComboBox comboF11Function;
        private System.Windows.Forms.ComboBox comboF11HotKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOpenNumFunc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelNumDisplay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelSkillMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSkillMode;
        private System.Windows.Forms.ComboBox comboBoxSkillMode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboHotKeyMP;
        private System.Windows.Forms.CheckBox checkMP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboDefHotKey;
        private System.Windows.Forms.CheckBox checkTimeClose;
        private System.Windows.Forms.ComboBox comboTO_Min;
        private System.Windows.Forms.ComboBox comboTO_Hour;
        private System.Windows.Forms.ComboBox comboTO_sec;
        private System.Windows.Forms.ComboBox comboCheckMPRatio;
        private System.Windows.Forms.Button btnGetMpNow;
        private System.Windows.Forms.ComboBox comboPetSup_Master;
        private System.Windows.Forms.CheckBox checkPetSupport;
    }
}

