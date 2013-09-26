using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using FNF.WindowController;
using Oban.Notification;
using NLog;

namespace Automation
{
    /// <summary>
    /// ベストワースト分析の帳票印刷を自動化するクラスです。
    /// </summary>
    public class BestWorst : HonbuAutomation
    {
        public Window galleryWindow = null;

        public void Output(string reportSuffix, string pictureSuffix)
        {
            try
            {
                this.Open();
                this.Query();
                this.PrintPreview(this.theWindow, reportSuffix);

                this.PrintImageGallery();
                this.PrintPreview(this.galleryWindow, pictureSuffix);

                this.CloseImageGallery();
                this.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace + ex.TargetSite);
                if (this.theWindow != null && this.theWindow.IsExists())
                {
                    theWindow.SendMessage(FNF.WindowController.API.P_WM.WM_DESTROY, IntPtr.Zero, IntPtr.Zero);
                }
                throw ex;
            }
        }
        /// <summary>
        /// 画面を開きます。
        /// </summary>
        public override void Open()
        {
            Window.BreakKey = KBtn.ESCAPE;
            DisplayMenuWindow();
            Process menuProcess = Process.GetProcessesByName("MNU0003S")[0];
            Console.WriteLine("プロセス取得完了");

            Window menuWindow = Window.GetTopChild(menuProcess.Id, "WindowsForms10.Window.8.app4", "服飾販売管理 本部システム");
            if (menuWindow != null)
            {
                Console.WriteLine("ウィンドウ取得完了");
            }
            else
            {
                Console.WriteLine("ウィンドウがnull");
                menuWindow = Window.GetTopChild(menuProcess.Id, "WindowsForms10.Window.8.app3", "服飾販売管理 本部システム");
            }
            menuWindow.MouseMove(PointMode.LeftTop, 89, -13, 29);
            menuWindow.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 89, -13); Thread.Sleep(156);
            menuWindow.MouseMove(PointMode.LeftTop, 89, -13);
            menuWindow.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 89, -13); Thread.Sleep(281);

            Window menu = Window.GetTopChild(menuProcess.Id, "#32768", "");
            Console.WriteLine("メニュー取得完了");

            menu.MouseMove(PointMode.LeftTop, 29, 8, 65); Thread.Sleep(32);
            menu.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 29, 8);
            menu.MouseMove(PointMode.LeftTop, 29, 8, 171);
            menu.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 29, 8); Thread.Sleep(1404);

            theProcess = Process.GetProcessesByName("HBA0001V")[0];
            theWindow = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app.0.378734a", "売上ベストワースト分析");

        }

        /// <summary>
        /// お待ちください画面が消えるのを待ちます。
        /// </summary>
        internal void WaitForActive()
        {
            Window waitForm = Window.GetTopChild(theProcess.Id, "WindowsForms10.Window.8.app.0.378734a", "");
            while (waitForm != null && waitForm.IsExists())
            {
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 大分類：トップス、中分類：カットソーを選択します。
        /// </summary>
        public Action SetCutSawn
        {
            get
            {
                return () =>
                {
                    Window.BreakKey = KBtn.ESCAPE;

                    Console.WriteLine("カットソー選択開始");
                    Process P01 = theProcess;
                    Window P01_001 = theWindow;
                    Window largeCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 4);

                    largeCategory.MouseMove(PointMode.LeftTop, 14, 9, 99);
                    largeCategory.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 14, 9); Thread.Sleep(41);

                    Window topsItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);
                    for (int i = 0; topsItem == null && i < 3; i++ ) Thread.Sleep(2000);

                    topsItem.MouseMove(PointMode.LeftTop, 29, 34, 76);
                    topsItem.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 29, 34); Thread.Sleep(16);

                    Window midCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 3);

                    midCategory.MouseMove(PointMode.LeftTop, 41, 6, 385);
                    midCategory.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 41, 6);

                    Window cutItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    cutItem.MouseMove(PointMode.LeftTop, 68, 42, 301);
                    cutItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 68, 42); Thread.Sleep(15);
                    cutItem.MouseMove(PointMode.LeftTop, 68, 42, 50);
                    cutItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 68, 42);
                    Console.WriteLine("カットソー選択完了");
                };
            }
        }

        /// <summary>
        /// 大分類：トップス、中分類：布帛を選択します。
        /// </summary>
        public Action SetCloth
        {
            get
            {
                return () =>
                {
                    Window.BreakKey = KBtn.ESCAPE;
                    Console.WriteLine("布帛選択開始");

                    Process P01 = theProcess;

                    Window P01_001 = theWindow;
                    Window largeCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 4);

                    largeCategory.MouseMove(PointMode.LeftTop, 56, 11, 1981);
                    largeCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 56, 11); Thread.Sleep(16);
                    largeCategory.MouseMove(PointMode.LeftTop, 56, 11);
                    largeCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 56, 11); Thread.Sleep(733);

                    Window topsItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    topsItem.MouseMove(PointMode.LeftTop, 67, 34, 1248);
                    topsItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 67, 34); Thread.Sleep(686);
                    topsItem.MouseMove(PointMode.LeftTop, 67, 34);
                    topsItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 67, 34); Thread.Sleep(562);

                    Window midCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 3);

                    midCategory.MouseMove(PointMode.LeftTop, 68, 10, 671);
                    midCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 68, 10); Thread.Sleep(125);
                    midCategory.MouseMove(PointMode.LeftTop, 68, 10);
                    midCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 68, 10); Thread.Sleep(374);

                    Window clothItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    clothItem.MouseMove(PointMode.LeftTop, 76, 51, 640); Thread.Sleep(62);
                    clothItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 76, 51);
                    clothItem.MouseMove(PointMode.LeftTop, 76, 51, 125);
                    clothItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 76, 51);
                };
            }
        }

        /// <summary>
        /// 大分類：トップス、中分類：ニットを選択します。
        /// </summary>
        public Action SetKnit
        {
            get
            {
                return () =>
                {
                    Window.BreakKey = KBtn.ESCAPE;

                    Console.WriteLine("ニット選択開始");
                    Process P01 = theProcess;

                    Window P01_001 = theWindow;
                    Window largeCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 4);

                    largeCategory.MouseMove(PointMode.LeftTop, 40, 2, 90);
                    largeCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 40, 2); Thread.Sleep(125);
                    largeCategory.MouseMove(PointMode.LeftTop, 40, 2);
                    largeCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 40, 2); Thread.Sleep(421);

                    Window topsItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    topsItem.MouseMove(PointMode.LeftTop, 41, 32, 734);
                    topsItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 41, 32); Thread.Sleep(156);
                    topsItem.MouseMove(PointMode.LeftTop, 41, 32);
                    topsItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 41, 32); Thread.Sleep(296);

                    Window midCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 3);

                    midCategory.MouseMove(PointMode.LeftTop, 58, 5, 265);
                    midCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 58, 5); Thread.Sleep(94);
                    midCategory.MouseMove(PointMode.LeftTop, 58, 5);
                    midCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 58, 5); Thread.Sleep(390);

                    Window knitItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    knitItem.MouseMove(PointMode.LeftTop, 56, 19, 499);
                    knitItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 56, 19); Thread.Sleep(109);
                    knitItem.MouseMove(PointMode.LeftTop, 56, 19);
                    knitItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 56, 19);
                    Console.WriteLine("ニット選択完了");
                };
            }
        }
        
        /// <summary>
        /// 大分類：ボトムス、中分類：スカートを選択します。
        /// </summary>
        public Action SetSkirt
        {
            get
            {
                return () =>
                {
                    Window.BreakKey = KBtn.ESCAPE;
                    Console.WriteLine("スカート選択開始");

                    Process P01 = theProcess;

                    Window largeCategory = this.theWindow.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 4);

                    largeCategory.MouseMove(PointMode.LeftTop, 34, 9, 1092);
                    largeCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 34, 9); Thread.Sleep(141);
                    largeCategory.MouseMove(PointMode.LeftTop, 34, 9);
                    largeCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 34, 9); Thread.Sleep(483);

                    Window bottomsItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    bottomsItem.MouseMove(PointMode.LeftTop, 51, 50, 1061);
                    bottomsItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 51, 50); Thread.Sleep(140);
                    bottomsItem.MouseMove(PointMode.LeftTop, 51, 50);
                    bottomsItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 51, 50); Thread.Sleep(344);

                    Window midCategory = this.theWindow.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 3);

                    midCategory.MouseMove(PointMode.LeftTop, 52, 12, 826);
                    midCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 52, 12); Thread.Sleep(156);
                    midCategory.MouseMove(PointMode.LeftTop, 52, 12);
                    midCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 52, 12); Thread.Sleep(687);

                    Window skirtItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    skirtItem.MouseMove(PointMode.LeftTop, 31, 20, 686);
                    skirtItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 31, 20); Thread.Sleep(125);
                    skirtItem.MouseMove(PointMode.LeftTop, 31, 20);
                    skirtItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 31, 20);
                    Console.WriteLine("スカート選択完了");
                };
            }
        }


        /// <summary>
        /// 大分類：ボトムス、中分類：パンツを選択します。
        /// </summary>
        public Action SetPants
        {
            get
            {
                return () =>
                {
                    Window.BreakKey = KBtn.ESCAPE;
                    Console.WriteLine("パンツ選択開始");

                    Process P01 = theProcess;

                    Window largeCategory = this.theWindow.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 4);

                    largeCategory.MouseMove(PointMode.LeftTop, 34, 9, 1092);
                    largeCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 34, 9); Thread.Sleep(141);
                    largeCategory.MouseMove(PointMode.LeftTop, 34, 9);
                    largeCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 34, 9); Thread.Sleep(483);

                    Window bottomsItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    bottomsItem.MouseMove(PointMode.LeftTop, 51, 50, 1061);
                    bottomsItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 51, 50); Thread.Sleep(140);
                    bottomsItem.MouseMove(PointMode.LeftTop, 51, 50);
                    bottomsItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 51, 50); Thread.Sleep(344);

                    Window midCategory = this.theWindow.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 3);

                    midCategory.MouseMove(PointMode.LeftTop, 52, 12, 826);
                    midCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 52, 12); Thread.Sleep(156);
                    midCategory.MouseMove(PointMode.LeftTop, 52, 12);
                    midCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 52, 12); Thread.Sleep(687);

                    Window pantsItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    pantsItem.MouseMove(PointMode.LeftTop, 51, 35, 686);
                    pantsItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 51, 35); Thread.Sleep(125);
                    pantsItem.MouseMove(PointMode.LeftTop, 51, 35);
                    pantsItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 51, 35);
                    Console.WriteLine("パンツ選択完了");
                };
            }
        }

        /// <summary>
        /// 大分類：外装、中分類：ジャケットを選択します。
        /// </summary>
        public Action SetJacket
        {
            get
            {
                return () =>
                {
                    Window.BreakKey = KBtn.ESCAPE;
                    Console.WriteLine("ジャケット選択開始");

                    Process P01 = theProcess;

                    Window P01_001 = theWindow;
                    Window largeCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 4);

                    largeCategory.MouseMove(PointMode.LeftTop, 53, 7, 858);
                    largeCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 53, 7); Thread.Sleep(140);
                    largeCategory.MouseMove(PointMode.LeftTop, 53, 7);
                    largeCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 53, 7); Thread.Sleep(390);

                    Window outerItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    outerItem.MouseMove(PointMode.LeftTop, 65, 67, 1810);
                    outerItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 65, 67); Thread.Sleep(172);
                    outerItem.MouseMove(PointMode.LeftTop, 65, 67);
                    outerItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 65, 67); Thread.Sleep(327);

                    Window midCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 3);

                    midCategory.MouseMove(PointMode.LeftTop, 74, 7, 406);
                    midCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 74, 7); Thread.Sleep(125);
                    midCategory.MouseMove(PointMode.LeftTop, 74, 7);
                    midCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 74, 7); Thread.Sleep(359);

                    Window jacketItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    jacketItem.MouseMove(PointMode.LeftTop, 73, 20, 967);
                    jacketItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 73, 20); Thread.Sleep(125);
                    jacketItem.MouseMove(PointMode.LeftTop, 73, 20);
                    jacketItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 73, 20);

                    Console.WriteLine("ジャケット選択完了");
                };
            }
        }

        /// <summary>
        /// 大分類：外装、中分類：ワンピースを選択します。
        /// </summary>
        public Action SetOnePiece
        {
            get
            {
                return () =>
                {
                    Window.BreakKey = KBtn.ESCAPE;
                    Console.WriteLine("ワンピース選択開始");
                    Process P01 = theProcess;
                    Window P01_001 = theWindow;

                    Window largeCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 4);

                    largeCategory.MouseMove(PointMode.LeftTop, 93, 11, 1435);
                    largeCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 93, 11); Thread.Sleep(109);
                    largeCategory.MouseMove(PointMode.LeftTop, 93, 11);
                    largeCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 93, 11); Thread.Sleep(546);

                    Window outerItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    outerItem.MouseMove(PointMode.LeftTop, 112, 66, 1623);
                    outerItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 112, 66); Thread.Sleep(124);
                    outerItem.MouseMove(PointMode.LeftTop, 112, 66);
                    outerItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 112, 66); Thread.Sleep(531);

                    Window midCategory = P01_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 3);

                    midCategory.MouseMove(PointMode.LeftTop, 78, 12, 608);
                    midCategory.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 78, 12); Thread.Sleep(16);
                    midCategory.MouseMove(PointMode.LeftTop, 78, 11, 109);
                    midCategory.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 78, 11); Thread.Sleep(312);

                    Window onePieceItem = Window.GetTopChild(P01.Id, "ComboLBox", "", 0);

                    onePieceItem.MouseMove(PointMode.LeftTop, 88, 69, 546);
                    onePieceItem.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 88, 69); Thread.Sleep(172);
                    onePieceItem.MouseMove(PointMode.LeftTop, 88, 69);
                    onePieceItem.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 88, 69);

                    Console.WriteLine("ワンピース選択完了");
                };
            }
        }

        /// <summary>
        /// 画面に、抽出結果を表示させます。
        /// </summary>
        /// <param name="startDate">出力開始日を指定します。</param>
        /// <param name="endDate">出力終了日を指定します。</param>
        /// <param name="criteriaSetting">その他の条件を選択するアクションを指定します。</param>
        protected override void Query()
        {
            Console.WriteLine("問い合わせ処理開始");
            this.theWindow.WaitForActive(10000);
            this.theWindow.SetForeground();
            Window startDatePicker = theWindow.GetChild("WindowsForms10.SysDateTimePick32.app.0.378734a", "", 1);
            if (startDatePicker == null) Console.WriteLine("startDateコントロールが取れない");

            startDatePicker.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 20, 13);
            Trace.WriteLine(string.Format("start date:{0}", this.StartDate.ToString("yyyy/MM/dd")));
            startDatePicker.InputText(this.StartDate.Year.ToString("0000"));
            startDatePicker.PushKey(KBtn.RIGHT);
            startDatePicker.InputText(this.StartDate.Month.ToString("00"));
            startDatePicker.PushKey(KBtn.RIGHT);
            startDatePicker.InputText(this.StartDate.Day.ToString("00"));
            startDatePicker.PushKey(KBtn.TAB);

            Window endDatePicker = theWindow.GetChild("WindowsForms10.SysDateTimePick32.app.0.378734a", "", 0);
            if (endDatePicker == null) Console.WriteLine("endDateコントロールが取れない");

            endDatePicker.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 20, 13);
            endDatePicker.InputText(this.EndDate.Year.ToString("0000"));
            endDatePicker.PushKey(KBtn.RIGHT);
            endDatePicker.InputText(this.EndDate.Month.ToString("00"));
            endDatePicker.PushKey(KBtn.RIGHT);
            endDatePicker.InputText(this.EndDate.Day.ToString("00"));
            endDatePicker.PushKey(KBtn.TAB);

            foreach (var criteria in this.CriteriaSettings)
            {
                criteria.Invoke();
            }

            this.SetSearch50Hits();

            Window searchButton = this.theWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "検索");
            searchButton.PushKey(KBtn.RETURN);
            Console.WriteLine("問い合わせ処理完了");
        }

        /// <summary>
        /// 印刷プレビューを表示させます。
        /// </summary>
        /// <param name="saveFileName">保存するファイルの末尾につけるサフィックスを指定します。</param>
        public void PrintPreview(Window window, string saveFileName)
        {
            Console.WriteLine("印刷プレビュー呼び出し開始");
            Process P01 = theProcess;

            this.WaitForActive();
            //Window printPreviewButton = Window.GetTopChild(P01.Id, "WindowsForms10.Window.8.app.0.378734a", "売上ベストワースト分析").GetChild("WindowsForms10.BUTTON.app.0.378734a", "印刷");
            Window printPreviewButton = window.GetChild("WindowsForms10.BUTTON.app.0.378734a", "印刷");

            printPreviewButton.MouseMove(PointMode.LeftTop, 55, 18, 340);
            printPreviewButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 55, 18);                       Thread.Sleep(4774);

            this.SaveFile(saveFileName);
            this.PrintOut();
            this.ClosePrintPreview();

            Console.WriteLine("印刷プレビュー呼び出し完了");
        }

        /// <summary>
        /// 印刷プレビュー画面から印刷ボタンをクリックします。
        /// </summary>
        private void PrintOut()
        {
            Console.WriteLine("印刷ボタン押下開始");
            Process P01 = theProcess;

            this.WaitForActive();
            Window previewWindow = Window.GetTopChild(P01.Id, new Regex(@"WindowsForms10\.Window\.8\.app\.0\.378734a"), new Regex("売上ベスト・ワースト分析.*印刷プレビュー画面"));
            for (int i = 0; previewWindow == null && i < 5; i++)
            {
                Thread.Sleep(2000);
                previewWindow = Window.GetTopChild(P01.Id, new Regex(@"WindowsForms10\.Window\.8\.app\.0\.378734a"), new Regex("売上ベスト・ワースト分析.*印刷プレビュー画面"));
            }

            Window menu = previewWindow.GetChild("WindowsForms10.Window.8.app.0.378734a", "");
            for (int i = 0; menu == null && i < 5; i++)
            {
                Thread.Sleep(2000);
                menu = previewWindow.GetChild("WindowsForms10.Window.8.app.0.378734a", "");
            }

            Window printButton = menu.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 2);
            for (int i = 0; printButton == null && i < 5; i++)
            {
                Thread.Sleep(1000);
                printButton = menu.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 2);
            }
            printButton.WaitForActive(5000);
            printButton.MouseMove(PointMode.LeftTop, 60, 18, 104);
            printButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 60, 18);

            this.StartPrint();

            Console.WriteLine("印刷ボタン押下完了");
        }

        private void SaveFile(string fileName)
        {
            Console.WriteLine("保存ボタン押下開始");
            Process P01 = theProcess;

            this.WaitForActive();
            Window previewWindow = Window.GetTopChild(P01.Id, new Regex(@"WindowsForms10\.Window\.8\.app\.0\.378734a"), new Regex("売上ベスト・ワースト分析.*印刷プレビュー画面"));
            if (previewWindow == null)
                return;
            else
                Console.WriteLine("プレビュー画面が取れたよ");

            Window pdfButton = previewWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "PDF出力");
            pdfButton.WaitForActive(5000);
            pdfButton.PushKey(KBtn.RETURN);
            //pdfButton.MouseMove(PointMode.LeftTop, 40, 31, 407);
            //pdfButton.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 40, 31);
            //pdfButton.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 40, 31);
            Console.WriteLine("PDF出力ボタンを押したよ");
            Thread.Sleep(1560);

            Window saveDialog = Window.GetTopChild(P01.Id, "#32770", "保存先を指定してください");
            Console.Write("saveDialogが");
            for (int i = 0; saveDialog == null && i < 30; i++)
            {
                Console.WriteLine("取れてないよ" ) ;
                saveDialog = Window.GetTopChild(P01.Id, "#32770", "保存先を指定してください");
            }
            Console.WriteLine("取れたよ") ;

            Window fileNameText = null;
            try
            {
                for (int i = 0; fileNameText == null && i < 5; i++)
                {
                    fileNameText = saveDialog.GetChild("DUIViewWndClassName", "").GetChild("DirectUIHWND", "").GetChild("FloatNotifySink", "", 0).GetChild("ComboBox", "").GetChild("Edit", "");
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                for (int j = 0; fileNameText == null && j < 5; j++)
                {
                    fileNameText = saveDialog.GetChild("ComboBoxEx32", "").GetChild("ComboBox", "")
                        .GetChild("Edit", "");
                    Thread.Sleep(1000);
                }
            }
            Console.Write("fileNameTextが");
            Console.WriteLine(fileNameText == null? "取れてないよ" : "取れたよ") ;

            fileNameText.MouseMove(PointMode.LeftTop, 510, 9, 188);
            fileNameText.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 510, 9); Thread.Sleep(125);
            fileNameText.KeyE(KType.Click, KBtn.LEFT, KBtn.LEFT, KBtn.LEFT, KBtn.LEFT); Thread.Sleep(338);
            fileNameText.KeyE(KType.Click, KBtn.BACK, KBtn.BACK, KBtn.BACK, KBtn.BACK); Thread.Sleep(87);
            fileNameText.KeyE(KType.Click, KBtn.BACK, KBtn.BACK); Thread.Sleep(197);
            fileNameText.InputText(fileName);
            fileNameText.PushKey(KBtn.RETURN);

            //Window saveButton = saveDialog.GetChild("Button", "保存(&S)");
            //Console.Write("saveButtonが");
            //for (int i = 0; saveButton == null && i < 3; i++)
            //{
            //    Console.WriteLine("取れてないよ" ) ;
            //    saveButton = saveDialog.GetChild("Button", "保存(&S)");
            //}
            //Console.WriteLine("取れたよ") ;

            //saveButton.MouseMove(PointMode.LeftTop, 31, 11, 546);
            //saveButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 31, 11);
            AnswerDialogOK();
            Console.WriteLine("保存ボタン押下完了");
        }

       public void StartPrint()
        {
                Window.BreakKey = KBtn.ESCAPE;
                Console.WriteLine("印刷ダイアログの印刷ボタン押下開始");

                WaitForActive();

                Process P01 = theProcess;

                Window printDialog = Window.GetTopChild(P01.Id, "#32770", "印刷");
                for (int i = 0; printDialog == null && i < 5; i++ )
                {
                    Thread.Sleep(1000);
                    printDialog = Window.GetTopChild(P01.Id, "#32770", "印刷");
                }

                Window printButton = printDialog.GetChild("Button", "OK");

                printButton.MouseMove(PointMode.LeftTop, 28, 5, 3572);
                printButton.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 28, 5); Thread.Sleep(141);
                printButton.MouseMove(PointMode.LeftTop, 28, 5);
                printButton.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 28, 5);
                Console.WriteLine("印刷ダイアログの印刷ボタン押下完了");
        }

       internal new void AnswerDialogOK()
       {
           Window.BreakKey = KBtn.ESCAPE;

           WaitForActive();
           Thread.Sleep(2000);
           Process P01 = theProcess;

           Window dialog = Window.GetTopChild(P01.Id, "#32770", "PDF出力");
           for (int i = 0; dialog == null && i < 5; i++)
           {
               Thread.Sleep(1000);
               dialog = Window.GetTopChild(P01.Id, "#32770", "PDF出力");
           }
           dialog.PushKey(KBtn.RETURN);
           return;

           Window okButton = dialog.GetChild("Button", "OK");
           for (int i = 0; okButton == null && i < 5; i++)
           {
               Thread.Sleep(1000);
               okButton = dialog.GetChild("Button", "OK");
           }
           //int i = 0;
           //while (i < 5)
           //{
           //    if (okButton == null)
           //        Thread.Sleep(1000);
           //    i++;
           //}

           okButton.MouseMove(PointMode.LeftTop, 39, 7, 216);
           okButton.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 39, 6);
           okButton.MouseMove(PointMode.LeftTop, 39, 7, 187);
           okButton.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 39, 7);


       }

        /// <summary>
        /// 印刷プレビュー画面を閉じます。
        /// </summary>
       private void ClosePrintPreview()
       {
           Process P01 = theProcess;

           Window previewWindow = Window.GetTopChild(P01.Id, new Regex(@"WindowsForms10\.Window\.8\.app\.0\.378734a"), new Regex("売上ベスト・ワースト分析.*印刷プレビュー画面"));
           if (previewWindow == null) return;

           Window closeButton = previewWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "閉じる");

           closeButton.MouseMove(PointMode.LeftTop, 32, 18, 307);
           closeButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 32, 18);
       }

       public void PrintImageGallery()
       {
           Window.BreakKey = KBtn.ESCAPE;
           Process P01 = theProcess;

           Window imageButton = this.theWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "画像一覧");

           imageButton.MouseMove(PointMode.LeftTop, 57, 21, 591);
           imageButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 57, 21); Thread.Sleep(6691);

           this.galleryWindow = Window.GetTopChild(P01.Id, "WindowsForms10.Window.8.app.0.378734a", "売上ベスト・ワースト分析  画像一覧");
           Window printButton = this.galleryWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "印刷");

           printButton.MouseMove(PointMode.LeftTop, 59, 18, 700);
           printButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 59, 18); Thread.Sleep(219);
       }

       public void CloseImageGallery()
       {
           Window.BreakKey = KBtn.ESCAPE;
           Process P01 = theProcess;

           Window closeButton = this.galleryWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "閉じる");
           closeButton.MouseMove(PointMode.LeftTop, 57, 13, 952);
           closeButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 57, 13);
       }

        /// <summary>
        /// 検索件数を５０件に設定します。
        /// </summary>
        private void SetSearch50Hits()
        {
            Window.BreakKey = KBtn.ESCAPE;

            Window hitsCombo = this.theWindow.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 0);

            // コンボボックスをいったん最上段へ
            for (int i = 0; i < 5; i++)
            {
                hitsCombo.PushKey(KBtn.UP);
            }

            // 下キーを２回入力
            hitsCombo.PushKey(KBtn.DOWN); Thread.Sleep(50);
            hitsCombo.PushKey(KBtn.DOWN); Thread.Sleep(50);
            hitsCombo.PushKey(KBtn.RETURN); Thread.Sleep(78);

        }

        /// <summary>
        /// フォームを閉じます。
        /// </summary>
        public override void Close()
        {
            if (theProcess == null)
                return;

            Process P01 = theProcess;

            Window closeButton = this.theWindow.GetChild("WindowsForms10.BUTTON.app.0.378734a", "終了");
            this.WaitForActive();
            this.theWindow.SetFocus();
            closeButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 27, 20);
            Thread.Sleep(1500);

            Window confirm = Window.GetTopChild(P01.Id, "#32770", "確認");
            for (int i = 0; confirm == null && i < 5; i++ )
            {
                Thread.Sleep(2000);
                confirm = Window.GetTopChild(P01.Id, "#32770", "確認");
            }
            confirm.SetForeground();
            Window yesButton = confirm.GetChild("Button", "はい(&Y)");

            yesButton.SetFocus();
            yesButton.MouseE(MType.Click, MBtn.L, PointMode.LeftTop, 27, 20);
        }
    }
}