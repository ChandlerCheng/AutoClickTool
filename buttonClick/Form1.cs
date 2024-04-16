using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Threading;

namespace buttonClick
{
    public partial class Form1 : Form
    {
        private Thread actionThread;
        private bool continueAction = false; // 追蹤是否應該繼續執行動作
        private bool bIsNumKeyOn = false;
        private int actionF11Type = 0;
        private byte actionF11HotKey = (byte)Keys.F5;
        private int actionX = 0;
        private int actionY = 0;
        private int actionDelay = 1000;

        private void ActionLoop()
        {
            // 定義循環運行的方法
            while (continueAction)
            {
                switch (actionF11Type)
                {
                    case 0:
                        {
                            GameFunction.castSpellOnTarget(actionX, actionY, actionF11HotKey, actionDelay);
                        }
                        break;
                    case 1:
                        {

                        }
                        break;
                    default:
                        break;
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
            SystemFuction.RegisterHotKey(this.Handle, 1, 0, (int)Keys.F11); // 啟動/關閉
            SystemFuction.RegisterHotKey(this.Handle, 2, 0, (int)Keys.F10); // 抓取座標

            actionThread = new Thread(ActionLoop);

            // 加入功能選擇
            for (int i = 0; i < GameFunction.GameFunctionList.Length; i++)
                comboF11Function.Items.Add(GameFunction.GameFunctionList[i]);
            for (int i = 0; i < KeyboardSimulator.HotKeyList.Length; i++)
                comboF11HotKey.Items.Add(KeyboardSimulator.HotKeyList[i]);

            comboF11Function.SelectedIndex = 0;
            comboF11HotKey.SelectedIndex = 0;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form1關閉時取消註冊熱鍵
            SystemFuction.UnregisterHotKey(this.Handle, 1);
            SystemFuction.UnregisterHotKey(this.Handle, 2);

            if (bIsNumKeyOn)
            {
                SystemFuction.UnregisterHotKey(this.Handle, 3);
                SystemFuction.UnregisterHotKey(this.Handle, 4);
                SystemFuction.UnregisterHotKey(this.Handle, 5);
                SystemFuction.UnregisterHotKey(this.Handle, 6);
                SystemFuction.UnregisterHotKey(this.Handle, 7);
                SystemFuction.UnregisterHotKey(this.Handle, 8);
                SystemFuction.UnregisterHotKey(this.Handle, 9);
                SystemFuction.UnregisterHotKey(this.Handle, 10);
                SystemFuction.UnregisterHotKey(this.Handle, 11);
                SystemFuction.UnregisterHotKey(this.Handle, 12);
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
                        this.Text = "已關閉";
                        actionThread.Join(); // 等待線程結束      
                        return;
                    }

                    if (textY.Text.Length == 0 || textY.Text.Length == 0)
                    {
                        MessageBox.Show("座標輸入範圍有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (textF11Ms.Text.Length == 0)
                    {
                        MessageBox.Show("延遲輸入有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    x = int.Parse(textX.Text);
                    y = int.Parse(textY.Text);
                    if (CheckFunction.CheckCoordinateError(x, y))
                    {
                        MessageBox.Show("座標輸入範圍有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    delay = int.Parse(textF11Ms.Text);
                    if (CheckFunction.CheckDelayError(delay))
                    {
                        MessageBox.Show("延遲範圍有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    actionX = x;
                    actionY = y;
                    actionDelay = delay;

                    // 選擇循環功能
                    if (comboF11Function.SelectedIndex == -1)
                    {
                        MessageBox.Show("請選擇循環功能", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        actionF11Type = comboF11Function.SelectedIndex;
                    }
                    // 若有熱鍵 , 選擇功能使用的熱鍵
                    if (comboF11HotKey.SelectedIndex == -1)
                    {
                        MessageBox.Show("請選擇熱鍵", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
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
                    textX.Text = cursor.X.ToString();
                    textY.Text = cursor.Y.ToString();

                    EnemyXY.CalculateAllEnemy(cursor.X, cursor.Y);
                }
                else if (m.WParam.ToInt32()>=3|| m.WParam.ToInt32()<12)
                {
                    int i = m.WParam.ToInt32();
                    switch (i)
                    {
                        case 3: // Num 0 = 10
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy10[0], EnemyXY.Enemy10[1], actionF11HotKey, actionDelay);
                            break;
                        case 4:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy1[0], EnemyXY.Enemy1[1], actionF11HotKey, actionDelay);
                            break;
                        case 5:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy2[0], EnemyXY.Enemy2[1], actionF11HotKey, actionDelay);
                            break;
                        case 6:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy3[0], EnemyXY.Enemy3[1], actionF11HotKey, actionDelay);
                            break;
                        case 7:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy4[0], EnemyXY.Enemy4[1], actionF11HotKey, actionDelay);
                            break;
                        case 8:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy5[0], EnemyXY.Enemy5[1], actionF11HotKey, actionDelay);
                            break;
                        case 9:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy6[0], EnemyXY.Enemy6[1], actionF11HotKey, actionDelay);
                            break;
                        case 10:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy7[0], EnemyXY.Enemy7[1], actionF11HotKey, actionDelay);
                            break;
                        case 11:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy8[0], EnemyXY.Enemy8[1], actionF11HotKey, actionDelay);
                            break;
                        case 12:
                            GameFunction.castSpellOnTarget(EnemyXY.Enemy9[0], EnemyXY.Enemy9[1], actionF11HotKey, actionDelay);
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
                                      "- F11 : 功能啟動/暫停。\n" +
                                      "- Num0 ~ 9 : 開啟小鍵功\n" +
                                      " 能後 , 移動到對應敵人\n" +
                                      " 處施放熱鍵。\n\n";

            // 显示消息框
            MessageBox.Show(instructionsText, "功能說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpenNumFunc_Click(object sender, EventArgs e)
        {
            if (bIsNumKeyOn == true)
            {
                bIsNumKeyOn = false;
                SystemFuction.UnregisterHotKey(this.Handle, 3);
                SystemFuction.UnregisterHotKey(this.Handle, 4);
                SystemFuction.UnregisterHotKey(this.Handle, 5);
                SystemFuction.UnregisterHotKey(this.Handle, 6);
                SystemFuction.UnregisterHotKey(this.Handle, 7);
                SystemFuction.UnregisterHotKey(this.Handle, 8);
                SystemFuction.UnregisterHotKey(this.Handle, 9);
                SystemFuction.UnregisterHotKey(this.Handle, 10);
                SystemFuction.UnregisterHotKey(this.Handle, 11);
                SystemFuction.UnregisterHotKey(this.Handle, 12);
                labelNumDisplay.ForeColor = System.Drawing.Color.Red;
                labelNumDisplay.Text = "關閉";
            }
            else
            {
                bIsNumKeyOn = true;
                SystemFuction.RegisterHotKey(this.Handle, 3, 0, (int)Keys.NumPad0);
                SystemFuction.RegisterHotKey(this.Handle, 4, 0, (int)Keys.NumPad1);
                SystemFuction.RegisterHotKey(this.Handle, 5, 0, (int)Keys.NumPad2);
                SystemFuction.RegisterHotKey(this.Handle, 6, 0, (int)Keys.NumPad3);
                SystemFuction.RegisterHotKey(this.Handle, 7, 0, (int)Keys.NumPad4);
                SystemFuction.RegisterHotKey(this.Handle, 8, 0, (int)Keys.NumPad5);
                SystemFuction.RegisterHotKey(this.Handle, 9, 0, (int)Keys.NumPad6);
                SystemFuction.RegisterHotKey(this.Handle, 10, 0, (int)Keys.NumPad7);
                SystemFuction.RegisterHotKey(this.Handle, 11, 0, (int)Keys.NumPad8);
                SystemFuction.RegisterHotKey(this.Handle, 12, 0, (int)Keys.NumPad9);                
                labelNumDisplay.ForeColor = System.Drawing.Color.Green;
                labelNumDisplay.Text = "開啟";
            }
        }
    }
    public class GameFunction
    {
        public static string[] GameFunctionList = { "熱鍵後點擊目標(滑鼠左鍵)" };
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

        public static void hotKeyPress(byte keyCode, int delay)
        {
            KeyboardSimulator.KeyPress(keyCode);
            if (delay > 0)
                Thread.Sleep(delay);
        }
    }
    public class EnemyXY
    {
        // 敵方座標
        public static int[] Enemy1 = new int[2];
        public static int[] Enemy2 = new int[2];
        public static int[] Enemy3 = new int[2];
        public static int[] Enemy4 = new int[2];
        public static int[] Enemy5 = new int[2];
        public static int[] Enemy6 = new int[2];
        public static int[] Enemy7 = new int[2];
        public static int[] Enemy8 = new int[2];
        public static int[] Enemy9 = new int[2];
        public static int[] Enemy10 = new int[2];

        // 計算所有敵人的座標
        public static void CalculateAllEnemy(int x, int y)
        {
            // 計算第三號敵人的座標
            Enemy3[0] = x;
            Enemy3[1] = y;

            // 計算其他敵人的座標
            CalculateEnemy(Enemy3, Enemy2, -68, 56);
            CalculateEnemy(Enemy2, Enemy1, -68, 56);
            CalculateEnemy(Enemy3, Enemy4, 68, -56);
            CalculateEnemy(Enemy4, Enemy5, 68, -56);

            CalculateEnemy(Enemy1, Enemy6, -73, -61);
            CalculateEnemy(Enemy2, Enemy7, -73, -61);
            CalculateEnemy(Enemy3, Enemy8, -73, -61);
            CalculateEnemy(Enemy4, Enemy9, -73, -61);
            CalculateEnemy(Enemy5, Enemy10, -73, -61);
        }

        // 計算敵人的座標
        private static void CalculateEnemy(int[] from, int[] to, int xOffset, int yOffset)
        {
            to[0] = from[0] + xOffset;
            to[1] = from[1] + yOffset;
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
        public static bool CheckCoordinateError(int x, int y)
        {
            //if ((x > 1920 || y > 1080) || (x < 0 || y < 0))
            if ((x < 0 || y < 0))
                return true;

            return false;
        }
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
    }
}