﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation;

namespace AutomationClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    OutputBestWorst();
                    OutputStockDetail();
                    OutputDetailData();
                    OutputItemMap();
                }
                else
                {
                    switch (args[0])
                    {
                        case "-bw":
                            OutputBestWorst();
                            break;
                        case "-sd":
                            OutputStockDetail();
                            break;
                        case "-dd":
                            OutputDetailData();
                            break;
                        case "-im":
                            OutputItemMap();
                            break;
                    }
                }
            }
            catch (Exception exp)
            {
                //Oban.Notification.Notificator notificator = new Oban.Notification.Notificator("fukuda-web.jp", "s-suzuki", "Fukuda1129");
                //var mail = new System.Net.Mail.MailMessage("s-suzuki@fukuda-web.jp", "s-suzuki@fukuda-web.jp", "自動実行失敗でやんす", @"失敗したよ\n" + exp.StackTrace + exp.ToString());
                //notificator.Notify(mail);
                Console.WriteLine(exp.ToString());

            }
        }

        private static void OutputBestWorst()
        {
            Automation.BestWorst bw = new Automation.BestWorst();

            DateTime lastMonday = Automation.DateTimeExpander.LastWeekMonday;
            DateTime thisSunday = lastMonday.AddDays(6.0);

            bw.StartDate = lastMonday;
            bw.EndDate = thisSunday;
            // カットソー
            bw.CriteriaSettings = new List<Action>(){bw.SetCutSawn};
            bw.Output("cutsawn", "cut_image");

            // ニット
            bw.CriteriaSettings = new List<Action>(){bw.SetKnit};
            bw.Output("knit", "knit_image");

            // 布帛 
            bw.CriteriaSettings = new List<Action>(){bw.SetCloth};
            bw.Output("cloth", "cloth_image");

            // パンツ 
            bw.CriteriaSettings = new List<Action>(){bw.SetPants};
            bw.Output("pants", "pants_image");

            // ジャケット 
            bw.CriteriaSettings = new List<Action>(){bw.SetJacket};
            bw.Output("jacket", "jacket_image");

            // ワンピース 
            bw.CriteriaSettings = new List<Action>(){bw.SetOnePiece};
            bw.Output("onepiece", "onepiece_image");
        }

        private static void OutputStockDetail()
        {
            Automation.StockDetail sd = new Automation.StockDetail();
            DateTime lastWeekMonday = DateTimeExpander.LastWeekMonday;
            DateTime lastSunday = DateTimeExpander.LastSunday;

            // 大分類別
            sd.StartDate = lastWeekMonday;
            sd.EndDate = lastSunday;
            List<Action> largeActions = new List<Action>()
            {
                sd.SetSumUnitLargeCat,
                sd.SetLargeCatAll
            };
            sd.CriteriaSettings = largeActions;
            sd.Output("large");

            System.Threading.Thread.Sleep(2000);

            // 中分類別
            sd.Open();
            List<Action> midActions = new List<Action>()
            {
                sd.SetSumUnitMidCat,
                sd.SetLargeCatAll
            };
            sd.CriteriaSettings = midActions;
            sd.Output("mid");
            System.Threading.Thread.Sleep(2000);

            // 小分類別
            sd.Open();
            List<Action> smallActions = new List<Action>()
            {
                sd.SetSumUnitSmallCat,
                sd.SetLargeCatAll
            };
            sd.CriteriaSettings = smallActions;
            sd.Output("small");
        }

        private static void OutputDetailData()
        {
            DateTime lastWeekMonday = DateTimeExpander.LastWeekMonday;
            DateTime lastSunday = DateTimeExpander.LastSunday;
            Automation.DetailData dd = new Automation.DetailData();
            List<Action> smallActions = new List<Action>()
            {
                // 店舗別に出力
                dd.selectSumUnitShop
            };
            dd.CriteriaSettings = smallActions;
            dd.Output("detail");
        }

        private static void OutputItemMap()
        {
            DateTime lastMonday = DateTimeExpander.LastWeekMonday.AddDays(7);
            DateTime nextSunday = DateTimeExpander.LastSunday.AddDays(7);
            Automation.ItemMap im = new ItemMap();
            List<Action> smallActions = new List<Action>()
            {
                // 中分類別に出力
                im.SetSumUnitMidCat
            };
            im.CriteriaSettings = smallActions;
            im.Output("mid");
        }

    }
}