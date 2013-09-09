using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using FNF.WindowController;

namespace Automation
{
    public class BestWorst
    {
        public static void Main()
        {
            try
            {
                Window.BreakKey = KBtn.ESCAPE;

                Process P01 = Process.GetProcessesByName("MNU0003S")[0];

                Window P01_001 = Window.GetTopChild(P01.Id, "WindowsForms10.Window.8.app.0.378734a", "服飾販売管理 本部システム");

                P01_001.MouseMove(PointMode.LeftTop, 89, -13, 2979);
                P01_001.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 89, -13); Thread.Sleep(156);
                P01_001.MouseMove(PointMode.LeftTop, 89, -13);
                P01_001.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 89, -13); Thread.Sleep(281);

                Window P01_002 = Window.GetTopChild(P01.Id, "#32768", "");

                P01_002.MouseMove(PointMode.LeftTop, 29, 8, 655); Thread.Sleep(32);
                P01_002.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 29, 8);
                P01_002.MouseMove(PointMode.LeftTop, 29, 8, 171);
                P01_002.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 29, 8); Thread.Sleep(1404);

                Process P02 = Process.GetProcessesByName("HBA0001V")[0];

                Window P02_001 = Window.GetTopChild(P02.Id, "WindowsForms10.Window.8.app.0.378734a", "売上ベストワースト分析");
                Window P02_002 = P02_001.GetChild("WindowsForms10.SysDateTimePick32.app.0.378734a", "", 1);

                P02_002.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(141);

                Window P02_003 = P02_001.GetChild("WindowsForms10.SysDateTimePick32.app.0.378734a", "", 0);

                P02_003.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(2340);
                P02_003.KeyE(KType.Down, KBtn.No2); Thread.Sleep(187);
                P02_003.KeyE(KType.Up, KBtn.No2); Thread.Sleep(16);
                P02_003.KeyE(KType.Down, KBtn.No0); Thread.Sleep(140);
                P02_003.KeyE(KType.Up, KBtn.No0); Thread.Sleep(608);
                P02_003.KeyE(KType.Down, KBtn.No1); Thread.Sleep(234);
                P02_003.KeyE(KType.Up, KBtn.No1); Thread.Sleep(125);
                P02_003.KeyE(KType.Down, KBtn.No3); Thread.Sleep(172);
                P02_003.KeyE(KType.Up, KBtn.No3); Thread.Sleep(4742);
                P02_003.KeyE(KType.Down, KBtn.RIGHT); Thread.Sleep(141);
                P02_003.KeyE(KType.Up, KBtn.RIGHT); Thread.Sleep(2308);
                P02_003.KeyE(KType.Down, KBtn.No0); Thread.Sleep(203);
                P02_003.KeyE(KType.Down, KBtn.No8); Thread.Sleep(31);
                P02_003.KeyE(KType.Up, KBtn.No0); Thread.Sleep(110);
                P02_003.KeyE(KType.Up, KBtn.No8); Thread.Sleep(780);
                P02_003.KeyE(KType.Down, KBtn.RIGHT); Thread.Sleep(124);
                P02_003.KeyE(KType.Up, KBtn.RIGHT); Thread.Sleep(3791);
                P02_003.KeyE(KType.Down, KBtn.No2); Thread.Sleep(94);
                P02_003.KeyE(KType.Up, KBtn.No2); Thread.Sleep(47);
                P02_003.KeyE(KType.Down, KBtn.No2); Thread.Sleep(140);
                P02_003.KeyE(KType.Up, KBtn.No2); Thread.Sleep(2278);

                Window P02_004 = P02_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 6);

                P02_004.MouseMove(PointMode.LeftTop, 91, 8, 78); Thread.Sleep(795);
                P02_003.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(172);

                Window P02_005 = P02_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 7);

                P02_005.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(140);
                P02_005.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(125);
                P02_004.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(187);
                P02_004.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(125);

                Window P02_006 = P02_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 5);

                P02_006.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(281);
                P02_006.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(140);

                Window P02_007 = P02_001.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 3).GetChild("WindowsForms10.EDIT.app.0.378734a", "0000");

                P02_007.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(172);
                P02_007.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(140);

                Window P02_008 = P02_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 4);

                P02_008.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(125);
                P02_008.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(141);

                Window P02_009 = P02_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 3);

                P02_009.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(140);
                P02_009.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(140);

                Window P02_010 = P02_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 2);

                P02_010.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(141);
                P02_010.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(156);

                Window P02_011 = P02_001.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 2).GetChild("WindowsForms10.EDIT.app.0.378734a", "0000");

                P02_011.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(140);
                P02_011.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(187);

                Window P02_012 = P02_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 1);

                P02_012.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(110);
                P02_012.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(171);

                Window P02_013 = P02_001.GetChild("WindowsForms10.EDIT.app.0.378734a", "", 2);

                P02_013.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(141);
                P02_013.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(156);

                Window P02_014 = P02_001.GetChild("WindowsForms10.EDIT.app.0.378734a", "", 1);

                P02_014.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(140);
                P02_014.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(156);

                Window P02_015 = P02_001.GetChild("WindowsForms10.EDIT.app.0.378734a", "", 0);

                P02_015.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(374);
                P02_015.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(141);

                Window P02_016 = P02_001.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 1).GetChild("WindowsForms10.BUTTON.app.0.378734a", "売上数");

                P02_016.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(249);
                P02_016.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(156);

                Window P02_017 = P02_001.GetChild("WindowsForms10.Window.8.app.0.378734a", "", 0).GetChild("WindowsForms10.BUTTON.app.0.378734a", "ベスト");

                P02_017.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(203);
                P02_017.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(156);

                Window P02_018 = P02_001.GetChild("WindowsForms10.COMBOBOX.app.0.378734a", "", 0);

                P02_018.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(1108);
                P02_018.KeyE(KType.Down, KBtn.DOWN); Thread.Sleep(187);
                P02_018.KeyE(KType.Up, KBtn.DOWN); Thread.Sleep(1170);
                P02_018.KeyE(KType.Down, KBtn.TAB); Thread.Sleep(156);

                Window P02_019 = P02_001.GetChild("WindowsForms10.BUTTON.app.0.378734a", "検索");

                P02_019.KeyE(KType.Up, KBtn.TAB); Thread.Sleep(515);
                P02_019.MouseMove(PointMode.LeftTop, 16, 23, 3837);
                P02_019.MouseE(MType.Down, MBtn.L, PointMode.LeftTop, 16, 23); Thread.Sleep(141);
                P02_019.MouseMove(PointMode.LeftTop, 16, 23);
                P02_019.MouseE(MType.Up, MBtn.L, PointMode.LeftTop, 16, 23);
            }
            catch (Exception ex)
            {
                MessageBox.Show("[Source]\n" + ex.Source + "\n\n[Message]\n" + ex.Message + "\n\n[StackTrace]\n" + ex.StackTrace);
            }
        }
    }
}