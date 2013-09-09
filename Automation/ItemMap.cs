using FNF.WindowController;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Automation
{
    public class ItemMap: HonbuAutomation
    {
        List<Window> windows = new List<Window>();

        public void Output(string fileSuffix)
        {
            try
            {
                this.Open();
                this.Query();
                this.PrintPreview();
                this.SaveFile(fileSuffix);
                this.PrintOut();
                this.ClosePrintPreview();
                this.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }

        public override void Open()
        {
            Window.BreakKey = KBtn.ESCAPE;
            DisplayMenuWindow();


            var processes = Process.GetProcessesByName("HBH0003V");
            if (processes.Count() == 0)
            {
                Process P01 = Process.GetProcessesByName("MNU0003S")[0];
                Window menuWindow = Window.GetTopChild(P01.Id, "WindowsForms10.Window.8.app4", "服飾販売管理 本部システム");

                menuWindow.MouseMove(PointMode.LeftTop, 27, -10, 827);
                menuWindow.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 102, -5); Thread.Sleep(171);
                menuWindow.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 102, -5); Thread.Sleep(156);

                Window menu = Window.GetTopChild(P01.Id, "#32768", "");

                menu.MouseMove(PointMode.LeftTop, 71, 70, 936);
                menu.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 71, 70); Thread.Sleep(173);
                menu.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 71, 70); Thread.Sleep(173);
            }

            theProcess = Process.GetProcessesByName("HBH0003V")[0];

            theWindow = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app.0.378734a", "アイテム投入MAP");
            while (theWindow == null)
            {
                Thread.Sleep(1000);
                theWindow = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app.0.378734a", "アイテム投入MAP");
            }

            this.windows.Add(theWindow);
        }

        public void SetCriteriaDate(DateTime startDate, DateTime endDate)
        {
            Window startDatePicker = theWindow.GetChild("WindowsForms10.SysDateTimePick32.app.0.378734a", "", 1);

            startDatePicker.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 7, 8);
            Trace.WriteLine(string.Format("start date:{0}", startDate.ToString("yyyy/MM/dd")));
            startDatePicker.InputText(startDate.Year.ToString("0000"));
            startDatePicker.PushKey(KBtn.RIGHT);
            startDatePicker.InputText(startDate.Month.ToString("00"));
            startDatePicker.PushKey(KBtn.RIGHT);
            startDatePicker.InputText(startDate.Day.ToString("00"));
            startDatePicker.PushKey(KBtn.TAB);

            Thread.Sleep(400);
            Window endDatePicker = theWindow.GetChild("WindowsForms10.SysDateTimePick32.app.0.378734a", "", 0);

            endDatePicker.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 20, 13);
            endDatePicker.InputText(endDate.Year.ToString("0000"));
            endDatePicker.PushKey(KBtn.RIGHT);
            endDatePicker.InputText(endDate.Month.ToString("00"));
            endDatePicker.PushKey(KBtn.RIGHT);
            endDatePicker.InputText(endDate.Day.ToString("00"));
            endDatePicker.PushKey(KBtn.TAB);
        }

        protected override void Query()
        {
            Window.BreakKey = KBtn.ESCAPE;

            this.SetCriteriaDate(this.StartDate, this.EndDate);
            foreach (Action setting in this.CriteriaSettings)
            {
                setting.Invoke();
            }
            Window searchButton = theWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "検索");
            searchButton.MouseMove(PointMode.LeftTop, 44, 15, 250); Thread.Sleep(151);
            searchButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 44, 15);
            WaitForActive();
        }

        /// <summary>
        /// お待ちください画面が消えるのを待ちます。
        /// </summary>
        internal void WaitForActive()
        {
            Window waitForm = Window.GetTopChild("HBH0003V", "WindowsForms10.Window.8.app.0.378734a", "");
            while (waitForm != null && waitForm.IsExists())
            {
                Thread.Sleep(1000);
            }
        }


        public void SaveFile(string fileName)
        {
            this.WaitForActive();
            Window.BreakKey = KBtn.ESCAPE;
            Window previewWindow = null;
            int i = 0;
            while (previewWindow == null)
            {
                previewWindow = Window.GetTopChild("HBH0003V", "WindowsForms10.Window.8.app.0.378734a", "アイテム投入計画MAP 印刷プレビュー画面");
                Thread.Sleep(500);
                i++;
                if (10 < i)
                    throw new ApplicationException("プレビュー画面が表示されてません。印刷ボタンを押しそこなった可能性があります。");
            }

            Window pdfButton = null;
            while (pdfButton == null)
            {
                pdfButton = previewWindow.
                 GetChild("WindowsForms10.BUTTON.app.0.378734a", "PDF出力");
                Thread.Sleep(500);
            }
            pdfButton.WaitForActive(5000);
            pdfButton.MouseMove(PointMode.LeftTop, 41, 16, 51);
            pdfButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 41, 16); Thread.Sleep(347);

            Window saveDialog = Window.GetTopChild("HBH0003V", "#32770", "保存先を指定してください");
            Window saveButton = saveDialog.GetChild("Button", "保存(&S)");


            Window fileNameText = saveDialog.GetChild("DUIViewWndClassName", "").GetChild("DirectUIHWND", "").
                        GetChild("FloatNotifySink", "", 0).GetChild("ComboBox", "").GetChild("Edit", "");

            //fileNameText.MouseMove(PointMode.LeftTop, 223, 3, 407);
            //fileNameText.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 223, 3);

            Thread.Sleep(125);
            fileNameText.KeyE(KType.Click, KBtn.RIGHT); Thread.Sleep(338);
            fileNameText.KeyE(KType.Click, KBtn.LEFT, KBtn.LEFT, KBtn.LEFT, KBtn.LEFT); Thread.Sleep(338);
            fileNameText.KeyE(KType.Click, KBtn.BACK, KBtn.BACK, KBtn.BACK, KBtn.BACK); Thread.Sleep(87);
            fileNameText.KeyE(KType.Click, KBtn.BACK, KBtn.BACK); Thread.Sleep(197);
            fileNameText.InputText(fileName);

            saveButton.WaitForActive(5000);
            saveButton.MouseMove(PointMode.LeftTop, 31, 11, 146);
            saveButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 31, 11);
            AnswerDialogOK();
        }

        /// <summary>
        /// 印刷プレビュー画面から印刷ボタンをクリックします。
        /// </summary>
        public void PrintOut()
        {
            Window previewWindow = Window.GetTopChild("HBH0003V", "WindowsForms10.Window.8.app.0.378734a", "アイテム投入計画MAP 印刷プレビュー画面");
            Window printButton = previewWindow.GetChild("WindowsForms10.Window.8.app.0.378734a", "").GetChild("WindowsForms10.Window.8.app.0.378734a", "", 2);

            printButton.WaitForActive(5000);
            printButton.MouseMove(PointMode.LeftTop, 40, 18, 104);
            printButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 40, 18); Thread.Sleep(100);

            this.StartPrint();
        }

        /// <summary>
        /// 印刷プレビュー画面を閉じます。
        /// </summary>
        public void ClosePrintPreview()
        {
            Process P01 = theProcess;
            Window printPreviewWindow = Window.GetTopChild("HBH0003V", "WindowsForms10.Window.8.app.0.378734a", "アイテム投入計画MAP 印刷プレビュー画面");
            while (printPreviewWindow == null)
            {
                printPreviewWindow = Window.GetTopChild("HBH0003V", "WindowsForms10.Window.8.app.0.378734a", "アイテム投入計画MAP 印刷プレビュー画面");
                Thread.Sleep(500);
            }

            Window closeButton = printPreviewWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "閉じる");

            closeButton.MouseMove(PointMode.LeftTop, 32, 18, 307);
            closeButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 32, 18);

            Window listWindow = Window.GetTopChild(P01.Id, "WindowsForms10.Window.8.app.0.378734a", "アイテム投入MAP", 0);
            Window backButton = listWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "戻る");

            backButton.MouseMove(PointMode.LeftTop, 56, 19, 1358);
            backButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 56, 19);

        }


        /// <summary>
        /// 印刷プレビューを表示させます。
        /// </summary>
        /// <param name="saveFileName">保存するファイルの末尾につけるサフィックスを指定します。</param>
        public void PrintPreview()
        {
            Process P01 = theProcess;

            Trace.WriteLine("マップ画面を操作するよ");
            this.WaitForActive();
            //Window printPreviewButton = Window.GetTopChild(P01.Id, "WindowsForms10.Window.8.app.0.378734a", "売上ベストワースト分析").GetChild("WindowsForms10.BUTTON.app.0.378734a", "印刷");
            Window mapWindow = Window.GetTopChild("HBH0003V", "WindowsForms10.Window.8.app.0.378734a", "アイテム投入MAP", 0);
            while (!mapWindow.IsExists() || !mapWindow.IsEnabled())
            {
                mapWindow = mapWindow.WaitForActive(1000);
                Trace.WriteLine("マップ画面が取れないよ");
            }
            Trace.WriteLine("マップ画面が取れたよ");

            Window printPreviewButton = mapWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "印刷");
            while (!printPreviewButton.IsExists() || !printPreviewButton.IsEnabled())
            {
                printPreviewButton = printPreviewButton.WaitForActive(1000);
                Trace.WriteLine("印刷ボタンが取れないよ");
            }
            Trace.WriteLine("印刷ボタンが取れたよ");

            Thread.Sleep(10000);
            printPreviewButton.MouseMove(PointMode.LeftTop, 55, 18, 340);
            printPreviewButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 55, 18); Thread.Sleep(4774);
            Trace.WriteLine("印刷ボタンを押したよ");

        }


        public void StartPrint()
        {
            Window.BreakKey = KBtn.ESCAPE;
            Process P01 = theProcess;

            Window printDialog = Window.GetTopChild(P01.Id, "#32770", "印刷");
            while (printDialog == null)
            {
                Thread.Sleep(1000);
                printDialog = Window.GetTopChild(P01.Id, "#32770", "印刷");
            }

            Window printButton = printDialog.GetChild("Button", "OK");

            printButton.MouseMove(PointMode.LeftTop, 28, 5, 572);
            printButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 28, 5); Thread.Sleep(141);
        }

        public override void Close()
        {
            Window.BreakKey = KBtn.ESCAPE;

            if (theProcess == null)
                return;

            Process P01 = theProcess;

            Window closeButton = theWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "終了");
            theWindow.SetFocus();
            closeButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 44, 16); Thread.Sleep(148);

            Window confirm = Window.GetTopChild(P01.Id, "#32770", "確認");
            confirm.SetForeground();
            Window yesButton = confirm.GetChild("Button", "はい(&Y)");

            yesButton.WaitForActive(2000);
            yesButton.SetFocus();
            yesButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 27, 20);

        }


        public Action SetSumUnitMidCat
        {
            get
            {
                return () =>
                {
                    Window sumUnitRadio = theWindow.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 7).
                                         GetChild("WindowsForms10.BUTTON.app.0.378734a", "中分類");

                    sumUnitRadio.MouseMove(PointMode.LeftTop, 3, 14, 169);
                    sumUnitRadio.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(141);
                    sumUnitRadio.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(312);
                };
            }
        }


    }
}
