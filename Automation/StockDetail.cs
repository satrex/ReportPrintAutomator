using System;
using FNF.WindowController;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Automation
{
    public class StockDetail: HonbuAutomation
    {
        /// <summary>
        /// 帳票の作成、ファイルの保存、印刷を行います。
        /// </summary>
        /// <param name="fileSuffix">保存するファイル名の末尾を指定します。</param>
        public void Output(string fileSuffix)
        {
            // 大分類別
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
                    if(menuWindow == null)  
                    menuWindow = Window.GetTopChild(P01.Id, "WindowsForms10.Window.8.app3", "服飾販売管理 本部システム");

                    menuWindow.MouseMove(PointMode.LeftTop, 275, -6, 305);
                    menuWindow.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 275, -6); Thread.Sleep(140);
                    menuWindow.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 275, -6); Thread.Sleep(312);

                    Window menu = Window.GetTopChild(P01.Id, "#32768", "");

                    menu.MouseMove(PointMode.LeftTop, 44, 59, 370); Thread.Sleep(441);
                    menu.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 44, 59);
                    menu.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 44, 59); Thread.Sleep(5179);
                }

                theProcess = Process.GetProcessesByName("HBZ0002LNEW")[0];

                theWindow = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app4", "詳細在庫明細表");
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

        public Action SetSumUnitLargeCat
        {
            get
            {
                return () =>
                {
                    Window sumUnitRadio = theWindow.GetChild("WindowsForms10.Window.8.app4", "", 5).GetChild("WindowsForms10.BUTTON.app4", "大分類");

                    sumUnitRadio.MouseMove(PointMode.LeftTop, 3, 14, 169);
                    sumUnitRadio.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(141);
                    sumUnitRadio.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(312);
                };
            }
        }
        
        private void SetCriteriaDate(DateTime startDate, DateTime endDate)
        {
                Window startDatePicker = theWindow.GetChild("WindowsForms10.SysDateTimePick32.app4", "", 2);

                startDatePicker.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 20, 13);
                Trace.WriteLine(string.Format("start date:{0}", startDate.ToString("yyyy/MM/dd")));
                startDatePicker.InputText(startDate.Year.ToString("0000"));
                startDatePicker.PushKey(KBtn.RIGHT);
                startDatePicker.InputText(startDate.Month.ToString("00"));
                startDatePicker.PushKey(KBtn.RIGHT);
                startDatePicker.InputText(startDate.Day.ToString("00"));
                startDatePicker.PushKey(KBtn.TAB);

                Window endDatePicker = theWindow.GetChild("WindowsForms10.SysDateTimePick32.app4", "", 3);

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

                theProcess = Process.GetProcessesByName("HBZ0002LNEW")[0];
                theWindow = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app4", "詳細在庫明細表");

                this.SetCriteriaDate(this.StartDate, this.EndDate);
                foreach (Action setting in this.CriteriaSettings)
                {
                    setting.Invoke();
                }
                Window okButton = theWindow.GetChild("WindowsForms10.BUTTON.app4", "ＯＫ");

                okButton.MouseMove(PointMode.LeftTop, 44, 15, 250); Thread.Sleep(151);
                okButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 44, 15);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }

        private void SaveFile(string fileName)
        {
            try
            {
                Window.BreakKey = KBtn.ESCAPE;
                Window previewWindow = null;
                while (previewWindow == null)
                {
                    previewWindow = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app4", "詳細在庫明細表 印刷プレビュー");
                    Thread.Sleep(500);
                }
                Window pdfButton =  previewWindow.GetChild("WindowsForms10.Window.8.app4", "", 1).
                                     GetChild("WindowsForms10.BUTTON.app4", "PDFに出力");
                pdfButton.WaitForActive(5000);
                pdfButton.MouseMove(PointMode.LeftTop, 41, 16, 51);
                pdfButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 41, 16); Thread.Sleep(347);

                Window saveDialog = Window.GetTopChild(theProcess.Id, "#32770", "保存先を指定してください");
                Window saveButton = saveDialog.GetChild("Button", "保存(&S)");

                Window fileNameText = saveDialog.GetChild("ComboBoxEx32", "").GetChild("ComboBox", "").GetChild("Edit", "");

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
        private void PrintOut()
        {
            try
            {
                Window previewWindow =Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app4", "詳細在庫明細表 印刷プレビュー"); 
                Window printButton = previewWindow.GetChild("WindowsForms10.Window.8.app4", "", 0).GetChild("WindowsForms10.Window.8.app4", "", 2);

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
        private void ClosePrintPreview()
        {
            try
            {

                theProcess = Process.GetProcessesByName("HBZ0002LNEW")[0];
                Process P01 = theProcess;
                Window previewWindow =Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app4", "詳細在庫明細表 印刷プレビュー"); 
                if (previewWindow == null) return;

                Window closeButton = previewWindow.GetChild("WindowsForms10.Window.8.app4", "", 1).GetChild("WindowsForms10.BUTTON.app4", "閉じる");

                closeButton.MouseMove(PointMode.LeftTop, 32, 18, 307);
                closeButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 32, 18);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }


       private void StartPrint()
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
 
        /// <summary>
        /// フォームを閉じます。
        /// </summary>
        public override void Close()
        {
            try
            {
                if (theProcess == null) 
                    return;

                Process P01 = theProcess;
                
                Window closeButton = theWindow.GetChild("WindowsForms10.BUTTON.app4", "終了");
                theWindow.SetFocus();
                closeButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 27, 20);

                Window confirm = Window.GetTopChild(P01.Id, "#32770", "");
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

        public Action SetLargeCatAll
        {
            get
            {
                return () =>
                {
                    Window largeCategory = theWindow.GetChild("WindowsForms10.COMBOBOX.app4", "", 3);

                    largeCategory.MouseMove(PointMode.LeftTop, 203, 15, 350);
                    largeCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 203, 15); Thread.Sleep(141);
                    largeCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 203, 15); Thread.Sleep(277);

                    Window largeCatAll = Window.GetTopChild(theProcess.Id, "ComboLBox", "", 0);

                    largeCatAll.MouseMove(PointMode.LeftTop, 194, 11, 577);
                    largeCatAll.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 194, 11); Thread.Sleep(172);
                    largeCatAll.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 194, 11); Thread.Sleep(951);
                };
            }
        }


        public Action SetSumUnitMidCat
        {
            get
            {
                return () =>
                {
                    Window sumUnitRadio = theWindow.GetChild("WindowsForms10.Window.8.app4", "", 5).GetChild("WindowsForms10.BUTTON.app4", "中分類");

                    sumUnitRadio.MouseMove(PointMode.LeftTop, 3, 14, 169);
                    sumUnitRadio.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(141);
                    sumUnitRadio.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(312);
                };
            }
        }

        public Action SetSumUnitSmallCat
        {
            get
            {
                return () =>
                {
                    Window sumUnitRadio = theWindow.GetChild("WindowsForms10.Window.8.app4", "", 5).GetChild("WindowsForms10.BUTTON.app4", "小分類");
                    sumUnitRadio.MouseMove(PointMode.LeftTop, 3, 14, 169);
                    sumUnitRadio.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(141);
                    sumUnitRadio.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 3, 14); Thread.Sleep(312);
                };
            }
        }
    }
}
