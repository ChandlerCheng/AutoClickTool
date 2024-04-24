﻿using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Threading;

namespace buttonClick
{
    enum DefineKey
    {
        F11 = 1,
        F12,
        Num0,
        Num1,
        Num2,
        Num3,
        Num4,
        Num5,
        Num6,
        Num7,
        Num8,
        Num9,
        Num0_Skill,
        Decimal_Skill
    }

    public partial class Form1 : Form
    {
        private Thread actionThread;
        private bool continueAction = false; // 追蹤是否應該繼續執行動作
        private bool bIsNumKeyOn = false;
        private bool bIsSkillModeOn = false;
        private int actionF11Type = 0;
        private int pollingEnemyIndex = 0;
        private byte actionF11HotKey = (byte)Keys.F5;
        private byte actionDefHotKey = (byte)Keys.F6;
        private byte actionMPHotKey = (byte)Keys.F9;
        private byte actionSkillHotKey = (byte)Keys.F5;
        private int actionX = 0;
        private int actionY = 0;
        private int actionDelay = 1000;
        private double checkMpRatioSel = 0.5;
#if DEBUG
        private int registerHK_MainRoop = (int)Keys.F1;
        private int registerHK_GetCoordinate = (int)Keys.F2;
#else 
        private int registerHK_MainRoop = (int)Keys.F11;
        private int registerHK_GetCoordinate = (int)Keys.F10;
#endif
        private long totalTimeoutSecondsTarget = 0;
        private long totalTimeoutSecondsNow = 0;
        Stopwatch stopwatch = new Stopwatch();

        private void ActionLoop()
        {
            if (checkTimeClose.Checked)
                stopwatch.Start();
            // 定義循環運行的方法
            while (continueAction)
            {
                if (checkTimeClose.Checked)
                    stopwatch.Restart();

                switch (actionF11Type)
                {
                    case 0:
                        {
                            // 施放法術
                            if (GameFunction.BattleCheck() == false)
                            {
                                // 檢查是否需要檢查補魔
                                if (checkMP.Checked == true)
                                {
                                    if (GameFunction.IsNeedReplenishMP(checkMpRatioSel) && GameFunction.NormalCheck())
                                    {
                                        // 需要符合抓取魔力條低於40%與抓的到升級按鈕兩個條件
                                        GameFunction.hotKeyPress(actionMPHotKey, 1000);
                                    }
                                }
                            }
                            else
                            {
                                GameFunction.castSpellOnTarget(actionX, actionY, actionF11HotKey, actionDelay);
                            }
                        }
                        break;
                    case 1:
                        {
                            if (GameFunction.BattleCheck() == false)
                            {
                                // 檢查是否需要檢查補魔
                                if (checkMP.Checked == true)
                                {
                                    if (GameFunction.IsNeedReplenishMP(checkMpRatioSel) && GameFunction.NormalCheck())
                                    {
                                        // 需要符合抓取魔力條低於40%與抓的到升級按鈕兩個條件
                                        GameFunction.hotKeyPress(actionMPHotKey, 1000);
                                    }
                                }
                            }
                            else
                            {
                                //循環施放法術(敵方)                                
                                GameFunction.castSpellOnTarget(Coordinate.Enemy[pollingEnemyIndex, 0], Coordinate.Enemy[pollingEnemyIndex,1], actionF11HotKey, actionDelay);
 
                                /* 直接循環施法 , 最差頂多讀條一半 */
                                pollingEnemyIndex++;
                                if (pollingEnemyIndex > 9)
                                    pollingEnemyIndex = 0;
                            }
                        }
                        break;
                    case 2:
                        {
                            if (GameFunction.BattleCheck() == false)
                            {
                                // 檢查是否需要檢查補魔
                                if (checkMP.Checked == true)
                                {
                                    if (GameFunction.IsNeedReplenishMP(checkMpRatioSel) && GameFunction.NormalCheck())
                                    {
                                        // 需要符合抓取魔力條低於40%與抓的到升級按鈕兩個條件
                                        GameFunction.hotKeyPress(actionMPHotKey, 1000);
                                    }
                                }
                                // 非戰鬥中 , 持續招怪
                                GameFunction.hotKeyPress(actionF11HotKey, actionDelay);
                            }
                            else
                            {
                                // 戰鬥中 , 持續鞭炮
                                GameFunction.hotKeyPress(actionDefHotKey, actionDelay);
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (checkTimeClose.Checked)
                    stopwatch.Stop();


                // 線程計時器
                if (checkTimeClose.Checked)
                {
                    // 累加实际经过的秒数
                    totalTimeoutSecondsNow += stopwatch.ElapsedMilliseconds;

                    if (totalTimeoutSecondsNow >= totalTimeoutSecondsTarget)
                    {
                        MessageBox.Show("Task completed!"); // 在窗体加载时显示消息框

                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Text = "時間到 , 已關閉";
                        });
                        totalTimeoutSecondsNow = 0;
                        continueAction = false;
                        break;
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form1載入時註冊熱鍵

            SystemFuction.RegisterHotKey(this.Handle, 1, 0, registerHK_MainRoop); // 主循環功能啟動/關閉
            SystemFuction.RegisterHotKey(this.Handle, 2, 0, registerHK_GetCoordinate); // 抓取座標

            actionThread = new Thread(ActionLoop);

            // 加入功能選擇
            for (int i = 0; i < GameFunction.GameFunctionList.Length; i++)
                comboF11Function.Items.Add(GameFunction.GameFunctionList[i]);
            for (int i = 0; i < KeyboardSimulator.HotKeyList.Length; i++)
                comboF11HotKey.Items.Add(KeyboardSimulator.HotKeyList[i]);
            for (int i = 0; i < KeyboardSimulator.HotKeyList.Length; i++)
                comboBoxSkillMode.Items.Add(KeyboardSimulator.HotKeyList[i]);
            for (int i = 0; i < KeyboardSimulator.HotKeyList.Length; i++)
                comboDefHotKey.Items.Add(KeyboardSimulator.HotKeyList[i]);
            for (int i = 0; i < KeyboardSimulator.HotKeyList.Length; i++)
                comboHotKeyMP.Items.Add(KeyboardSimulator.HotKeyList[i]);
            for (int hour = 0; hour < 24; hour++)
            {
                string timeString = $"{hour.ToString("00")}";
                comboTO_Hour.Items.Add(timeString);
            }
            for (int minute = 0; minute < 60; minute++)
            {
                string timeString = $"{minute.ToString("00")}";
                comboTO_Min.Items.Add(timeString);
            }
            for (int second = 0; second < 60; second++)
            {
                string timeString = $"{second.ToString("00")}";
                comboTO_sec.Items.Add(timeString);
            }
            for (int i = 0; i < GameFunction.CheckMpRatio.Length; i++)
                comboCheckMPRatio.Items.Add(GameFunction.CheckMpRatio[i]);
            for (int i = 0; i < GameFunction.PetSupport_Master.Length; i++)
                comboPetSup_Master.Items.Add(GameFunction.PetSupport_Master[i]);


            comboF11Function.SelectedIndex = 0;
            comboF11HotKey.SelectedIndex = 0;
            comboBoxSkillMode.SelectedIndex = 0;
            comboDefHotKey.SelectedIndex = 1;
            comboHotKeyMP.SelectedIndex = 2;
            comboTO_Hour.SelectedIndex = 0;
            comboTO_Min.SelectedIndex = 0;
            comboTO_sec.SelectedIndex = 0;
            comboCheckMPRatio.SelectedIndex = 0;

            labelX.ForeColor = System.Drawing.Color.Red;
            labelX.Text = "未指定";

            labelY.ForeColor = System.Drawing.Color.Red;
            labelY.Text = "未指定";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form1關閉時取消註冊熱鍵
            SystemFuction.UnregisterHotKey(this.Handle, 1);
            SystemFuction.UnregisterHotKey(this.Handle, 2);

            if (bIsNumKeyOn)
            {
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num0);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num1);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num2);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num3);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num4);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num5);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num6);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num7);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num8);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num9);
            }
            else if (bIsSkillModeOn == true)
            {
                bIsSkillModeOn = false;
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num0_Skill);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Decimal_Skill);
            }
            continueAction = false;
            actionThread.Join();
        }
        protected override void WndProc(ref Message m)
        {
            // 熱鍵消息處理
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                if (m.WParam.ToInt32() == 1) //取得座標 , 並將座標帶入迴圈程序中
                {
                    int x, y, delay;
                    if (continueAction)
                    {
                        continueAction = false; // 停止執行動作                        
                        actionThread.Join(); // 等待線程結束
                        this.Text = "已關閉";
                        return;
                    }
                    totalTimeoutSecondsNow = 0;
                    if (checkTimeClose.Checked)
                    {
                        // 解析文本框中的值
                        int hours = int.Parse(comboTO_Hour.SelectedItem.ToString());
                        int minutes = int.Parse(comboTO_Min.SelectedItem.ToString());
                        int seconds = int.Parse(comboTO_sec.SelectedItem.ToString());
                        totalTimeoutSecondsTarget = (hours * 3600 + minutes * 60 + seconds) * 1000;
                    }
                    if (checkMP.Checked)
                    {
                        checkMpRatioSel = double.Parse(comboCheckMPRatio.SelectedItem.ToString());
                    }

                    if (int.TryParse(labelY.Text, out int number1) == false || int.TryParse(labelX.Text, out int number2) == false)
                    {
                        MessageBox.Show("未抓取座標", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (bIsSkillModeOn == true || bIsNumKeyOn == true)
                    {
                        MessageBox.Show("請先關閉所有小鍵盤上的功能", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (textF11Ms.Text.Length == 0)
                    {
                        MessageBox.Show("延遲輸入有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    x = int.Parse(labelX.Text);
                    y = int.Parse(labelY.Text);

                    delay = int.Parse(textF11Ms.Text);
                    if (CheckFunction.CheckDelayError(delay))
                    {
                        MessageBox.Show("延遲範圍有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    actionX = x;
                    actionY = y;
                    actionDelay = delay;
                    actionF11Type = comboF11Function.SelectedIndex;

                    bool areDifferent = comboF11HotKey.SelectedIndex != comboHotKeyMP.SelectedIndex &&
                                                    comboF11HotKey.SelectedIndex != comboDefHotKey.SelectedIndex &&
                                                    comboHotKeyMP.SelectedIndex != comboDefHotKey.SelectedIndex;

                    if (!areDifferent)
                    {
                        MessageBox.Show("熱鍵請勿有任二相同的部分", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    switch (comboF11HotKey.SelectedIndex)
                    {
                        case 0:
                            actionF11HotKey = (byte)Keys.F5;
                            break;
                        case 1:
                            actionF11HotKey = (byte)Keys.F6;
                            break;
                        case 2:
                            actionF11HotKey = (byte)Keys.F7;
                            break;
                        case 3:
                            actionF11HotKey = (byte)Keys.F8;
                            break;
                        case 4:
                            actionF11HotKey = (byte)Keys.F9;
                            break;
                        default:
                            actionF11HotKey = (byte)Keys.F5;
                            break;
                    }

                    switch (comboHotKeyMP.SelectedIndex)
                    {
                        case 0:
                            actionMPHotKey = (byte)Keys.F5;
                            break;
                        case 1:
                            actionMPHotKey = (byte)Keys.F6;
                            break;
                        case 2:
                            actionMPHotKey = (byte)Keys.F7;
                            break;
                        case 3:
                            actionMPHotKey = (byte)Keys.F8;
                            break;
                        case 4:
                            actionMPHotKey = (byte)Keys.F9;
                            break;
                        default:
                            actionMPHotKey = (byte)Keys.F5;
                            break;
                    }

                    switch (comboDefHotKey.SelectedIndex)
                    {
                        case 0:
                            actionDefHotKey = (byte)Keys.F5;
                            break;
                        case 1:
                            actionDefHotKey = (byte)Keys.F6;
                            break;
                        case 2:
                            actionDefHotKey = (byte)Keys.F7;
                            break;
                        case 3:
                            actionDefHotKey = (byte)Keys.F8;
                            break;
                        case 4:
                            actionDefHotKey = (byte)Keys.F9;
                            break;
                        default:
                            actionDefHotKey = (byte)Keys.F5;
                            break;
                    }

                    // 確保在開始新線程之前先停止舊線程
                    if (actionThread.IsAlive)
                    {
                        continueAction = false; // 停止舊線程
                        actionThread.Join(); // 等待舊線程結束
                    }
                    // 開始執行動作
                    continueAction = true;
                    this.Text = "啟動中....";
                    actionThread = new Thread(ActionLoop);
                    actionThread.Start();
                }
                else if (m.WParam.ToInt32() == 2) // 取得x,y軸座標並直接套入Text中以供使用
                {
                    // 按下 F9 時，抓取滑鼠當前位置並顯示在 TextBox 中
                    Point cursor = Cursor.Position;
                    labelX.Text = cursor.X.ToString();
                    labelY.Text = cursor.Y.ToString();

                    labelX.ForeColor = System.Drawing.Color.Green;
                    labelY.ForeColor = System.Drawing.Color.Green;
                    Coordinate.IsGetWindows = false;
                    //Coordinate.CalculateAllEnemy(cursor.X, cursor.Y);
                    Coordinate.CalculateAllFriends(cursor.X, cursor.Y);
                }
                else if (m.WParam.ToInt32() >= 3 || m.WParam.ToInt32() < 15)
                {
                    DefineKey i = (DefineKey)m.WParam.ToInt32();
                    switch (i)
                    {
                        /*case DefineKey.Num0: // Num 0 = 10
                            GameFunction.castSpellOnTarget(Coordinate.Enemy10[0], Coordinate.Enemy10[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num1:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy1[0], Coordinate.Enemy1[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num2:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy2[0], Coordinate.Enemy2[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num3:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy3[0], Coordinate.Enemy3[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num4:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy4[0], Coordinate.Enemy4[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num5:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy5[0], Coordinate.Enemy5[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num6:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy6[0], Coordinate.Enemy6[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num7:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy7[0], Coordinate.Enemy7[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num8:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy8[0], Coordinate.Enemy8[1], actionF11HotKey, actionDelay);
                            break;
                        case DefineKey.Num9:
                            GameFunction.castSpellOnTarget(Coordinate.Enemy9[0], Coordinate.Enemy9[1], actionF11HotKey, actionDelay);
                            break;*/
                        case DefineKey.Num0_Skill:
                            {
                                int x, y;

                                if (int.TryParse(labelY.Text, out int number1) == false || int.TryParse(labelX.Text, out int number2) == false)
                                {
                                    MessageBox.Show("未抓取座標", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                x = int.Parse(labelX.Text);
                                y = int.Parse(labelY.Text);

                                actionX = x;
                                actionY = y;
                                GameFunction.castSpellOnTarget(actionX, actionY, actionF11HotKey, actionDelay);
                            }
                            break;
                        case DefineKey.Decimal_Skill:
                            switch (comboBoxSkillMode.SelectedIndex)
                            {
                                case 0:
                                    actionSkillHotKey = (byte)Keys.F5;
                                    break;
                                case 1:
                                    actionSkillHotKey = (byte)Keys.F6;
                                    break;
                                case 2:
                                    actionSkillHotKey = (byte)Keys.F7;
                                    break;
                                case 3:
                                    actionSkillHotKey = (byte)Keys.F8;
                                    break;
                                case 4:
                                    actionSkillHotKey = (byte)Keys.F9;
                                    break;
                                default:
                                    actionSkillHotKey = (byte)Keys.F5;
                                    break;
                            }
                            KeyboardSimulator.KeyPress(actionSkillHotKey);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // 功能說明
            string instructionsText = "功能說明：\n\n" +
                                      "- F10 : 抓取x,y軸座標。\n" +
                                      "  (若使用小鍵功能, 請抓\n" +
                                      "    前排中間)\n" +
                                      "- F11 : 功能啟動/暫停。\n\n";
            // 显示消息框
            MessageBox.Show(instructionsText, "功能說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpenNumFunc_Click(object sender, EventArgs e)
        {
            if (bIsNumKeyOn == true)
            {
                bIsNumKeyOn = false;
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num0);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num1);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num2);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num3);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num4);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num5);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num6);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num7);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num8);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num9);
                labelNumDisplay.ForeColor = System.Drawing.Color.Red;
                labelNumDisplay.Text = "關閉";
            }
            else
            {
                if (bIsSkillModeOn == false && bIsNumKeyOn == false)
                {
                    bIsNumKeyOn = true;
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num0, 0, (int)Keys.NumPad0);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num1, 0, (int)Keys.NumPad1);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num2, 0, (int)Keys.NumPad2);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num3, 0, (int)Keys.NumPad3);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num4, 0, (int)Keys.NumPad4);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num5, 0, (int)Keys.NumPad5);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num6, 0, (int)Keys.NumPad6);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num7, 0, (int)Keys.NumPad7);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num8, 0, (int)Keys.NumPad8);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num9, 0, (int)Keys.NumPad9);
                    labelNumDisplay.ForeColor = System.Drawing.Color.Green;
                    labelNumDisplay.Text = "開啟";
                }
                else if (continueAction == true)
                {
                    MessageBox.Show("禁止在主迴圈功能執行下使用", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("請先關閉練技功能", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnSkillMode_Click(object sender, EventArgs e)
        {
            if (bIsSkillModeOn == true)
            {
                bIsSkillModeOn = false;
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Num0_Skill);
                SystemFuction.UnregisterHotKey(this.Handle, (int)DefineKey.Decimal_Skill);
                labelSkillMode.ForeColor = System.Drawing.Color.Red;
                labelSkillMode.Text = "關閉";
            }
            else
            {
                if (bIsSkillModeOn == false && bIsNumKeyOn == false)
                {
                    bIsSkillModeOn = true;
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Num0_Skill, 0, (int)Keys.NumPad0);
                    SystemFuction.RegisterHotKey(this.Handle, (int)DefineKey.Decimal_Skill, 0, (int)Keys.Decimal);
                    labelSkillMode.ForeColor = System.Drawing.Color.Green;
                    labelSkillMode.Text = "開啟";
                }
                else if (continueAction == true)
                {
                    MessageBox.Show("禁止在主迴圈功能執行下使用", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("請先關閉小鍵功能", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnGteWindowsInfor(object sender, EventArgs e)
        {
            // 抓取視窗位置 & 視窗長寬數值
            if (!SystemFuction.GetWindowCoordinates("FairyLand"))
            {
                MessageBox.Show("抓取視窗錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Coordinate.IsGetWindows = true;
            /* 
               中心怪物位置會位於 800x600中的 275,290的位置
               遊戲本體800x600
               視窗總長816x638
               視窗邊框約8
               視窗標題列約30

                友軍前排3號位529,387
                敵軍前排3號位275,290
             */
            int x_enemy3, y_enemy3;
            int xOffset_enemy3 = Coordinate.windowBoxLineOffset + 275;
            int yOffset_enemy3 = Coordinate.windowHOffset + 290;

            x_enemy3 = Coordinate.windowTop[0] + xOffset_enemy3;
            y_enemy3 = Coordinate.windowTop[1] + yOffset_enemy3;

            Coordinate.CalculateAllEnemy(x_enemy3, y_enemy3);

            int x_friends3, y_friends3;
            int xOffset_friends3 = Coordinate.windowBoxLineOffset + 529;
            int yOffset_friends3 = Coordinate.windowHOffset + 387;

            x_friends3 = Coordinate.windowTop[0] + xOffset_friends3;
            y_friends3 = Coordinate.windowTop[1] + yOffset_friends3;

            Coordinate.CalculateAllFriends(x_friends3, y_friends3);

            labelX.Text = x_enemy3.ToString();
            labelY.Text = y_enemy3.ToString();

            labelX.ForeColor = System.Drawing.Color.Green;
            labelY.ForeColor = System.Drawing.Color.Green;
        }

        private void btnTestFuction(object sender, EventArgs e)
        {

        }
        private void btnGetMpNow_Click(object sender, EventArgs e)
        {
            if (GameFunction.BattleCheck() == false && GameFunction.NormalCheck() == true)
            {
                int x, y;
                int xOffset = Coordinate.windowBoxLineOffset + 18;
                int yOffset = Coordinate.windowHOffset + 1 + 22;

                x = Coordinate.windowTop[0] + xOffset;
                y = Coordinate.windowTop[1] + yOffset;
                // 從畫面上擷取指定區域的圖像
                Bitmap screenshot = BitmapImage.CaptureScreen(x, y, 92, 1);
                Color FullColor = Color.FromArgb(73, 163, 254);
                Color NotFullColor = Color.FromArgb(73, 206, 254);
                // 計算目標顏色的佔據比例
                double FullColorCom = BitmapImage.CalculateColorRatio(screenshot, FullColor);
                double NotFullColorCom = BitmapImage.CalculateColorRatio(screenshot, NotFullColor);

                MessageBox.Show($"滿魔比例檢測為 '{FullColorCom * 100}' %的)\n" + $"非滿魔比例檢測為 '{NotFullColorCom * 100}' %的)\n");
            }
        }
    }
    public class GameFunction
    {
        public static string[] GameFunctionList = { "施放法術", "循環施放法術(敵)", "循環招怪與鞭炮" };
        public static string[] CheckMpRatio = { "0.5", "0.4", "0.3", "0.2", "0.1" };
        public static string[] PetSupport_Master = { "1號位", "2號位", "3號位", "4號位", "5號位" };
        public static void castSpellOnTarget(int x, int y, byte keyCode, int delay)
        {
            /*
                滑鼠移動到指定座標後 , 按下指定熱鍵 , 點下左鍵
             */
            Cursor.Position = new System.Drawing.Point(x, y);
            KeyboardSimulator.KeyPress(keyCode);
            Thread.Sleep(500);
            MouseSimulator.LeftMousePress(x, y);
            Thread.Sleep(delay);
        }
        public static bool NormalCheck()
        {

            int x_LU, y_LU;
            int xOffset_LU = Coordinate.windowBoxLineOffset + 129;
            int yOffset_LU = Coordinate.windowHOffset;
            x_LU = Coordinate.windowTop[0] + xOffset_LU;
            y_LU = Coordinate.windowTop[1] + yOffset_LU;

            Bitmap levelUpBMP = Properties.Resources.levelup;

            // 從畫面上擷取指定區域的圖像
            Bitmap screenshot_LevelUp = BitmapImage.CaptureScreen(x_LU, y_LU, 50, 43);

            // 比對圖像
            double Final_LU = BitmapImage.CompareImages(screenshot_LevelUp, levelUpBMP);

            if (Final_LU > 50)
                return true;
            else
                return false;
        }
        public static bool BattleCheck()
        {
            int x_key, y_key;
            int xOffset_key = Coordinate.windowBoxLineOffset + 757;
            int yOffset_key = Coordinate.windowHOffset;

            x_key = Coordinate.windowTop[0] + xOffset_key;
            y_key = Coordinate.windowTop[1] + yOffset_key;

            Bitmap fight_keybarBMP = Properties.Resources.fighting_keybar;
            // 從畫面上擷取指定區域的圖像
            Bitmap screenshot_keyBar = BitmapImage.CaptureScreen(x_key, y_key, 44, 313);

            // 比對圖像
            double Final_KeyBar = BitmapImage.CompareImages(screenshot_keyBar, fight_keybarBMP);

            if (Final_KeyBar > 35)
                return true;
            else
                return false;
        }
        public static bool IsNeedReplenishMP(double NeedRatio)
        {
            int x, y;
            int xOffset = Coordinate.windowBoxLineOffset + 18;
            int yOffset = Coordinate.windowHOffset + 1 + 22;

            x = Coordinate.windowTop[0] + xOffset;
            y = Coordinate.windowTop[1] + yOffset;
            // 從畫面上擷取指定區域的圖像
            Bitmap screenshot = BitmapImage.CaptureScreen(x, y, 92, 1);
            Color FullColor = Color.FromArgb(73, 163, 254);
            Color NotFullColor = Color.FromArgb(73, 206, 254);
            // 計算目標顏色的佔據比例
            double FullColorCom = BitmapImage.CalculateColorRatio(screenshot, FullColor);
            double NotFullColorCom = BitmapImage.CalculateColorRatio(screenshot, NotFullColor);

            if (FullColorCom > 0)
            {
                // 滿魔狀態的顏色與非滿魔狀態不同
                return false;
            }
            else if (NotFullColorCom < NeedRatio)
            {
                return true;
            }
            return false;
        }
        public static void hotKeyPress(byte keyCode, int delay)
        {
            KeyboardSimulator.KeyPress(keyCode);
            if (delay > 0)
                Thread.Sleep(delay);
        }
    }
    public class Coordinate
    {
        // 視窗資訊
        public static int[] windowTop = new int[2];
        public static int[] windowBottom = new int[2];
        public static int windowHeigh = 0;
        public static int windowWidth = 0;
        public static int windowHOffset = 30;
        public static int windowBoxLineOffset = 8;
        public static bool IsGetWindows = false;
        /*
                敵方座標(目視)
                67890
                12345
                
                陣列值
                56789
                01234
         */
        public static int[,] Enemy = new int[10, 2];
        /*
               我方座標(目視)
               12345
               67890

               陣列值
               01234
               56789
        */
        public static int[,] Friends = new int[10, 2];
        public static void CalculateAllEnemy(int x, int y)
        {
            // 計算第三號敵人的座標 (陣列索引為2)
            Enemy[2, 0] = x;
            Enemy[2, 1] = y;

            // 計算其他敵人的座標
            CalculateTargetCoordinate(Enemy, 2, 1, -68, 56);
            CalculateTargetCoordinate(Enemy, 1, 0, -68, 56);
            CalculateTargetCoordinate(Enemy, 2, 3, 68, -56);
            CalculateTargetCoordinate(Enemy, 3, 4, 68, -56);

            CalculateTargetCoordinate(Enemy, 0, 5, -73, -61);
            CalculateTargetCoordinate(Enemy, 1, 6, -73, -61);
            CalculateTargetCoordinate(Enemy, 2, 7, -73, -61);
            CalculateTargetCoordinate(Enemy, 3, 8, -73, -61);
            CalculateTargetCoordinate(Enemy, 4, 9, -73, -61);
        }
        public static void CalculateAllFriends(int x, int y)
        {
            // 計算第三號敵人的座標 (陣列索引為2)
            Friends[2, 0] = x;
            Friends[2, 1] = y;
            // 計算其他的座標
            CalculateTargetCoordinate(Friends, 2, 1, -68, 56);
            CalculateTargetCoordinate(Friends, 1, 0, -68, 56);
            CalculateTargetCoordinate(Friends, 2, 3, 68, -56);
            CalculateTargetCoordinate(Friends, 3, 4, 68, -56);

            CalculateTargetCoordinate(Friends, 0, 5, 73, 61);
            CalculateTargetCoordinate(Friends, 1, 6, 73, 61);
            CalculateTargetCoordinate(Friends, 2, 7, 73, 61);
            CalculateTargetCoordinate(Friends, 3, 8, 73, 61);
            CalculateTargetCoordinate(Friends, 4, 9, 73, 61);
        }
        // 計算目標的座標
        private static void CalculateTargetCoordinate(int[,] enemyArray, int fromIndex, int toIndex, int xOffset, int yOffset)
        {
            // 获取源坐标的值
            int fromX = enemyArray[fromIndex, 0];
            int fromY = enemyArray[fromIndex, 1];

            // 计算目标坐标并赋值给目标索引
            enemyArray[toIndex, 0] = fromX + xOffset;
            enemyArray[toIndex, 1] = fromY + yOffset;
        }
    }
    public class BitmapImage
    {
        public static double CalculateColorRatio(Bitmap bitmap, Color targetColor)
        {
            // 獲取圖像的寬度和高度
            int width = bitmap.Width;
            int height = bitmap.Height;

            // 初始化目標顏色像素數量
            int targetColorCount = 0;

            // 遍歷圖像的每個像素，計算目標顏色的像素數量
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    if (pixelColor.R == targetColor.R && pixelColor.G == targetColor.G && pixelColor.B == targetColor.B)
                    {
                        targetColorCount++;
                    }
                }
            }
            // 計算目標顏色的佔據比例
            double targetColorRatio = (double)targetColorCount / (width * height);

            return targetColorRatio;
        }
        public static Bitmap CaptureScreen(int x, int y, int width, int height)
        {
            // 建立與畫面相同大小的圖像
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // 將畫面的內容繪製到圖像上
                graphics.CopyFromScreen(x, y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }
            return bitmap;
        }
        public static double CompareImages(Bitmap image1, Bitmap image2)
        {
            if (image1.Size != image2.Size)
                throw new ArgumentException("圖像大小不一致");

            int width = image1.Width;
            int height = image1.Height;

            // 計算相似度
            double difference = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel1 = image1.GetPixel(x, y);
                    Color pixel2 = image2.GetPixel(x, y);

                    if (Math.Abs(pixel1.R - pixel2.R) > 10 || Math.Abs(pixel1.G - pixel2.G) > 10 || Math.Abs(pixel1.B - pixel2.B) > 10)
                        difference++;
                }
            }

            double totalPixels = width * height;
            double percentageSimilarity = (totalPixels - difference) / totalPixels * 100;

            return percentageSimilarity;
        }
    }
    public class MouseSimulator
    {
        // 匯入User32.dll中的函數
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        // 模擬滑鼠左鍵按下及釋放
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        // 模擬滑鼠右鍵按下及釋放
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        public static void LeftMousePress(int x, int y)
        {
            // 模擬滑鼠左鍵按下
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x, y, 0, UIntPtr.Zero);
            // 延遲一段時間
            Thread.Sleep(100);
            // 模擬滑鼠左鍵釋放
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x, y, 0, UIntPtr.Zero);
        }
        public static void RightMousePress(int x, int y)
        {
            // 模擬滑鼠左鍵按下
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_ABSOLUTE, x, y, 0, UIntPtr.Zero);
            // 延遲一段時間
            Thread.Sleep(100);
            // 模擬滑鼠左鍵釋放
            mouse_event(MOUSEEVENTF_RIGHTUP | MOUSEEVENTF_ABSOLUTE, x, y, 0, UIntPtr.Zero);
        }
    }
    public class KeyboardSimulator
    {
        /*
            SendKeys.Send("{F5}");
            SendKeys.SendWait("{F5}");
            原先使用的兩種方法 , 會導致它的執行與 UI 執行緒之間的競爭條件。
         */
        // 匯入 user32.dll 中的 keybd_event 函數
        public static string[] HotKeyList = { "F5", "F6", "F7", "F8", "F9" };

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        // 定義按鍵事件的標誌
        private const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const int KEYEVENTF_KEYUP = 0x0002;
        // 模擬按下按鍵
        public static void KeyDown(byte keyCode)
        {
            keybd_event(keyCode, 0, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);
        }

        // 模擬釋放按鍵
        public static void KeyUp(byte keyCode)
        {
            keybd_event(keyCode, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, UIntPtr.Zero);
        }
        // 模擬按下並釋放按鍵
        public static void KeyPress(byte keyCode)
        {
            KeyDown(keyCode);
            Thread.Sleep(50); // 可調整延遲時間
            KeyUp(keyCode);
        }
    }
    public class CheckFunction
    {
        public static bool CheckDelayError(int delay)
        {
            //if ((x > 1920 || y > 1080) || (x < 0 || y < 0))
            if (delay < 0)
                return true;

            return false;
        }
    }
    public class SystemFuction
    {
        // 匯入User32.dll中的RegisterHotKey和UnregisterHotKey函數
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        // 匯入 User32.dll 中的 FindWindow 和 GetWindowRect 函數
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        // 定義 RECT 結構
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        // 獲取指定名稱視窗的座標
        public static bool GetWindowCoordinates(string windowTitle)
        {
            IntPtr windowHandle = FindWindow(null, windowTitle);
            if (windowHandle != IntPtr.Zero)
            {
                if (GetWindowRect(windowHandle, out RECT GameWindowsInfor))
                {
                    /*
                        遊戲本體800x600
                        視窗總長816x638
                        視窗邊框約8
                     */
                    Coordinate.windowTop[0] = GameWindowsInfor.Left;
                    Coordinate.windowTop[1] = GameWindowsInfor.Top;
                    Coordinate.windowBottom[0] = GameWindowsInfor.Right;
                    Coordinate.windowBottom[1] = GameWindowsInfor.Bottom;
                    Coordinate.windowHeigh = GameWindowsInfor.Bottom - GameWindowsInfor.Top;
                    Coordinate.windowWidth = GameWindowsInfor.Right - GameWindowsInfor.Left;
                    /*MessageBox.Show($"視窗 '{windowTitle}' 的左邊頂點座標為：({GameWindowsInfor.Left}, {GameWindowsInfor.Top})\n" +
                    $"右邊底部座標為：({GameWindowsInfor.Right}, {GameWindowsInfor.Bottom})\n" +
                    $"視窗長寬：({GameWindowsInfor.Right - GameWindowsInfor.Left}, {GameWindowsInfor.Bottom - GameWindowsInfor.Top})\n");*/
                    return true;
                }
                else
                {
                    //MessageBox.Show($"無法獲取視窗 '{windowTitle}' 的座標");
                    return false;
                }
            }
            else
            {
                //MessageBox.Show($"找不到名稱為 '{windowTitle}' 的視窗");
                return false;
            }
        }
    }
}