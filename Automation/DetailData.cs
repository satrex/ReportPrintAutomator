using FNF.WindowController;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Automation
{
    public class DetailData: HonbuAutomation
    {
        public void Output(string fileSuffix)
        {
            this.Open();
            this.Query();
            this.SaveFile(fileSuffix);
            this.PrintOut();
            this.ClosePrintPreview();
            this.Close();

        }

        public override void Open()
        {
            try
            {
                Window.BreakKey = KBtn.ESCAPE;
                DisplayMenuWindow();

                var processes = Process.GetProcessesByName("HBZ0002LNEW");
                if (processes.Count() == 0)
                {
                    Process P01 = Process.GetProcessesByName("MNU0003S")[0];
                    Window menuWindow = Window.GetTopChild(P01.Id, "WindowsForms10.Window.8.app4", "服飾販売管理 本部システム");

                    menuWindow.MouseMove(PointMode.LeftTop, 27, -10, 827);
                    menuWindow.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 27, -10); Thread.Sleep(265);
                    menuWindow.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 27, -10); Thread.Sleep(405);

                    Window menu = Window.GetTopChild(P01.Id, "#32768", "");

                    menu.MouseMove(PointMode.LeftTop, 57, 74, 1092);
                    menu.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 57, 74); Thread.Sleep(173);
                    menu.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 57, 75); Thread.Sleep(173);
                }


                theProcess = Process.GetProcessesByName("HBA0005L")[0];

                theWindow = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app.0.378734a", "詳細データ一覧表");
                while (theWindow == null)
                {
                    Thread.Sleep(1000);
                    theWindow = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app4", "詳細在庫明細表");
                }


            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }

        public void SetCriteriaDate(DateTime startDate, DateTime endDate)
        {
            Window startDatePicker =theWindow.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 1).
                GetChild("WindowsForms10.SysDateTimePick32.app.0.378734a", "", 1); 

            startDatePicker.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 7, 8);
            Trace.WriteLine(string.Format("start date:{0}", startDate.ToString("yyyy/MM/dd")));
            startDatePicker.InputText(startDate.Year.ToString("0000"));
            startDatePicker.PushKey(KBtn.RIGHT);
            startDatePicker.InputText(startDate.Month.ToString("00"));
            startDatePicker.PushKey(KBtn.RIGHT);
            startDatePicker.InputText(startDate.Day.ToString("00"));
            startDatePicker.PushKey(KBtn.TAB);

            Thread.Sleep(400);
            Window endDatePicker = theWindow.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 1).
                GetChild("WindowsForms10.SysDateTimePick32.app.0.378734a", "", 0);

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
             try
            {
                Window.BreakKey = KBtn.ESCAPE;

                this.SetCriteriaDate(this.StartDate, this.EndDate);
                foreach (Action setting in this.CriteriaSettings)
                {
                    setting.Invoke();
                }
                Window okButton = theWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "OK");

                okButton.MouseMove(PointMode.LeftTop, 44, 15, 250); Thread.Sleep(151);
                okButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 44, 15);
                WaitForActive();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// お待ちください画面が消えるのを待ちます。
        /// </summary>
        internal void WaitForActive()
        {
            Window waitForm = Window.GetTopChild("HBA0005L", "WindowsForms10.Window.8.app.0.378734a", "");
            while (waitForm != null && waitForm.IsExists())
            {
                Thread.Sleep(1000);
            }
        }


        public void SaveFile(string fileName)
        {
            try
            {
                this.WaitForActive();
                Window.BreakKey = KBtn.ESCAPE;
                Window previewWindow = null;
                while (previewWindow == null)
                {
                    previewWindow =Window.GetTopChild("HBA0005L", "WindowsForms10.Window.8.app.0.378734a", "詳細データ一覧表 印刷プレビュー画面");
                    Thread.Sleep(500);
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

                Window saveDialog = Window.GetTopChild(theProcess.Id, "#32770", "保存先を指定してください");
                Window saveButton = saveDialog.GetChild("Button", "保存(&S)");


                Window fileNameText = saveDialog. GetChild("DUIViewWndClassName", "").GetChild("DirectUIHWND", "").
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
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 印刷プレビュー画面から印刷ボタンをクリックします。
        /// </summary>
        public void PrintOut()
        {
            try
            {
                Window previewWindow =Window.GetTopChild("HBA0005L", "WindowsForms10.Window.8.app.0.378734a", "詳細データ一覧表 印刷プレビュー画面");
                Window printButton = previewWindow.GetChild("WindowsForms10.Window.8.app.0.378734a", "").GetChild("WindowsForms10.Window.8.app.0.378734a", "", 2);

                printButton.WaitForActive(5000);
                printButton.MouseMove(PointMode.LeftTop, 60, 18, 104);
                printButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 60, 18);

                this.StartPrint();
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 印刷プレビュー画面を閉じます。
        /// </summary>
        public void ClosePrintPreview()
        {
            try
            {
                Process P01 = theProcess;
                Window previewWindow =Window.GetTopChild("HBA0005L", "WindowsForms10.Window.8.app.0.378734a", "詳細データ一覧表 印刷プレビュー画面");
                if (previewWindow == null) return;

                Window closeButton = previewWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "閉じる");

                closeButton.MouseMove(PointMode.LeftTop, 32, 18, 307);
                closeButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 32, 18);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }


       public void StartPrint()
        {
            try
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
                printButton.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 28, 5); Thread.Sleep(141);
                printButton.MouseMove(PointMode.LeftTop, 28, 5);
                printButton.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 28, 5);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }
 
        public override void Close()
        {
            try
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
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("{0}\n{1}", ex.GetType().Name, ex.Message));
            }

        }

        public Action selectSumUnitShop
        {
            get
            {
                return () =>
                {

                    Window sumUnitRadio = theWindow.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 3).
                                     GetChild("WindowsForms10.BUTTON.app.0.378734a", "店舗別で出力する");
                    sumUnitRadio.MouseMove(PointMode.LeftTop, 3, 14, 169);
                    sumUnitRadio.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(141);
                    sumUnitRadio.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(312);
                    
                };
            }
        }
    }
}
