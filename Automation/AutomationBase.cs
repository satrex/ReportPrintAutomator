using FNF.WindowController;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Automation
{
    public abstract class AutomationBase
    {
        #region const
        public const int SEC = 1000;
        public const int MIN = 60 * SEC;
        #endregion

        internal Process theProcess;
        internal Window theWindow;

        FileTraceListener listener;
        FileTraceListener Listener
        {
            get
            {
                if (listener == null) listener = new FileTraceListener();
                listener.TraceOutputOptions = TraceOptions.Callstack | TraceOptions.DateTime | TraceOptions.Timestamp;

                return listener;
            }
        }
        public AutomationBase()
        {
            if(Trace.Listeners.Contains(this.Listener))
                Trace.Listeners.Add(this.Listener);
        }

        internal void AnswerDialogOK()
        {
            try
            {
                Window.BreakKey = KBtn.ESCAPE;

                Thread.Sleep(2000);
                Process P01 = theProcess;

                Window dialog = Window.GetTopChild(P01.Id, "#32770", "PDF出力");
                Window okButton = dialog.GetChild("Button", "OK");

                okButton.MouseMove(PointMode.LeftTop, 39, 7, 216);
                okButton.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 39, 6);
                okButton.MouseMove(PointMode.LeftTop, 39, 7, 187);
                okButton.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 39, 7);

            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }

        }

 
        public abstract void Open();
        public abstract void Close();
        public List<KBtn> numKeys =
        new List<KBtn>{
            KBtn.No0,
            KBtn.No1,
            KBtn.No2,
            KBtn.No3,
            KBtn.No4,
            KBtn.No5,
            KBtn.No6,
            KBtn.No7,
            KBtn.No8,
            KBtn.No9,
        };
        
        /// <summary>
        /// メニュー画面が開いていることを確認し、開いていない場合は新規に開きます。
        /// </summary>
        internal void DisplayMenuWindow()
        {
            Process[] processes = Process.GetProcessesByName("MNU0003S");
            while (processes.Length == 0)
            {
                Process.Start(new ProcessStartInfo(@"C:\HONBU\bin\MNU0003S"));
                Thread.Sleep(2000);
                processes = Process.GetProcessesByName("MNU0003S");
            }
        }


    }

    public static class Keys{
        private static Dictionary<char, KBtn> keys = new Dictionary<char, KBtn>()
        {
            {'0', KBtn.No0},
            {'1', KBtn.No1},
            {'2', KBtn.No2},
            {'3', KBtn.No3},
            {'4', KBtn.No4},
            {'5', KBtn.No5},
            {'6', KBtn.No6},
            {'7', KBtn.No7},
            {'8', KBtn.No8},
            {'9', KBtn.No9},
            {'a', KBtn.A},
            {'b', KBtn.B},
            {'c', KBtn.C},
            {'d', KBtn.D},
            {'e', KBtn.E},
            {'f', KBtn.F},
            {'g', KBtn.G},
            {'h', KBtn.H},
            {'i', KBtn.I},
            {'j', KBtn.J},
            {'k', KBtn.K},
            {'l', KBtn.L},
            {'m', KBtn.M},
            {'n', KBtn.N},
            {'o', KBtn.O},
            {'p', KBtn.P},
            {'q', KBtn.Q},
            {'r', KBtn.R},
            {'s', KBtn.S},
            {'t', KBtn.T},
            {'u', KBtn.U},
            {'v', KBtn.V},
            {'w', KBtn.W},
            {'x', KBtn.X},
            {'y', KBtn.Y},
            {'z', KBtn.Z},
        };

        /// <summary>
        /// 文字に対応したキーを取得します。
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static KBtn Get(char chr)
        {
            if (!keys.ContainsKey(chr))
                return KBtn.SPACE;
            else
                return keys[chr];
        }
    }

    public static class WindowExtender
    {
        public static void PushKey(this Window window, KBtn key)
        {
            window.KeyE(KType.Down, key); 
            System.Threading.Thread.Sleep(50);
            window.KeyE(KType.Up, key);
        }
        public static void InputText(this Window window, string text)
        {
            window.SetFocus();
            for (int i = 0; i < text.Length; i++)
            {
                char chr = text[i];

                window.PushKey(Keys.Get(chr));
            }
        }
    }
}
