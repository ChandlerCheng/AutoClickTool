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
        // 匯入User32.dll中的函數
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
        private Thread actionThread;
        // 模擬滑鼠左鍵按下及釋放
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        // 模擬滑鼠右鍵按下及釋放
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        private bool continueAction = false; // 追蹤是否應該繼續執行動作
        public int actionX = 0;
        public int actionY = 0;
        public int actionDelay = 1000;

        // 定義循環運行的方法
        private void ActionLoop()
        {
            while (continueAction)
            {
                KeyF5AndClickLeftMouse(actionX, actionY);
                Thread.Sleep(actionDelay); // 執行間隔，可以根據需要調整
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        // Form1載入時註冊熱鍵
        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, 1, 0, (int)Keys.F11); // 啟動
            RegisterHotKey(this.Handle, 2, 0, (int)Keys.F10); // 關閉
            RegisterHotKey(this.Handle, 3, 0, (int)Keys.F9); // 關閉
            actionThread = new Thread(ActionLoop);
        }

        // Form1關閉時取消註冊熱鍵
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
            UnregisterHotKey(this.Handle, 3);
            continueAction = false; // 確保循環結束
            actionThread.Join(); // 等待線程結束
        }

        // 熱鍵消息處理
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                if (m.WParam.ToInt32() == 1) //取得座標 , 並將座標帶入迴圈程序中
                {
                    int x, y, delay;
                    if (textY.Text.Length == 0 || textY.Text.Length == 0)
                    {
                        MessageBox.Show("座標輸入範圍有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (textMs.Text.Length == 0)
                    {
                        MessageBox.Show("延遲輸入有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (continueAction)
                        return;

                    x = int.Parse(textX.Text);
                    y = int.Parse(textY.Text);
                    delay = int.Parse(textMs.Text);

                    if ((x > 1920 || y > 1080) || (x < 0 || y < 0))
                    {
                        MessageBox.Show("座標輸入範圍有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (delay < 0 || delay > 5000)
                    {
                        MessageBox.Show("延遲範圍有誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    actionX = x;
                    actionY = y;
                    actionDelay = delay;

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
                    // 指定座標 (x, y)     
                }
                else if (m.WParam.ToInt32() == 2) // 關閉程序迴圈
                {
                    continueAction = false; // 停止執行動作
                    this.Text = "已關閉";
                    actionThread.Join(); // 等待線程結束                    
                }
                else if (m.WParam.ToInt32() == 3) // 取得x,y軸座標並直接套入Text中以供使用
                {
                    // 按下 F9 時，抓取滑鼠當前位置並顯示在 TextBox 中
                    Point cursor = Cursor.Position;
                    textX.Text = cursor.X.ToString();
                    textY.Text = cursor.Y.ToString();
                }
            }
        }
        // 模擬滑鼠左鍵點擊
        private void KeyF5AndClickLeftMouse(int x, int y)
        {
            // 將滑鼠移動到指定座標
            Cursor.Position = new System.Drawing.Point(x, y);
            // 模擬按下F5
            KeyboardSimulator.KeyPress((byte)Keys.F5);
            // 模擬滑鼠左鍵按下
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x, y, 0, UIntPtr.Zero);
            // 延遲一段時間
            Thread.Sleep(100);
            // 模擬滑鼠左鍵釋放
            mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x, y, 0, UIntPtr.Zero);
        }

        // 匯入User32.dll中的RegisterHotKey和UnregisterHotKey函數
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
    public class KeyboardSimulator
    {
        /*
            SendKeys.Send("{F5}");
            SendKeys.SendWait("{F5}");
            原先使用的兩種方法 , 會導致它的執行與 UI 執行緒之間的競爭條件。
         */
        // 匯入 user32.dll 中的 keybd_event 函數
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

   
}