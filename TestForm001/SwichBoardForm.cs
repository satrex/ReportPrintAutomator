using Automation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportPrintAutomator
{
    public partial class SwichBoardForm : Form
    {
        public SwichBoardForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Automation.BestWorst bw = new Automation.BestWorst();

            DateTime lastMonday = Automation.DateTimeExpander.LastWeekMonday;
            DateTime thisSunday = lastMonday.AddDays(6.0);

            bw.StartDate = lastMonday;
            bw.EndDate = thisSunday;
            //// カットソー
            //bw.CriteriaSettings = new List<Action>(){bw.SetCutSawn};
            //bw.Output("cutsawn", "cut_image");

            //// ニット
            //bw.CriteriaSettings = new List<Action>(){bw.SetKnit};
            //bw.Output("knit", "knit_image");

            // 布帛 
            bw.CriteriaSettings = new List<Action>(){bw.SetCloth};
            bw.Output("cloth", "cloth_image");

            //// パンツ 
            //bw.CriteriaSettings = new List<Action>(){bw.SetPants};
            //bw.Output("pants", "pants_image");

            //// ジャケット 
            //bw.CriteriaSettings = new List<Action>(){bw.SetJacket};
            //bw.Output("jacket", "jacket_image");

            //// ワンピース 
            //bw.CriteriaSettings = new List<Action>(){bw.SetOnePiece};
            //bw.Output("onepiece", "onepiece_image");
            this.Close();
        }

        private Automation.StockDetail GetStockDetail()
        {
            Automation.StockDetail sd = new Automation.StockDetail();
            DateTime lastWeekMonday = DateTimeExpander.LastWeekMonday;
            DateTime lastSunday = DateTimeExpander.LastSunday;
            sd.StartDate = lastWeekMonday;
            sd.EndDate = lastSunday;
            return sd;
        }

        private void sdAllButton_Click(object sender, EventArgs e)
        {
            Automation.StockDetail sd = this.GetStockDetail();

            // 大分類別
            this.sdLargeButton.PerformClick();
            System.Threading.Thread.Sleep(2000);

            // 中分類別
            this.sdMidButton.PerformClick();
            System.Threading.Thread.Sleep(2000);

            // 小分類別
            this.sdSmallButton.PerformClick();
 
            this.Close();
        }

        private void detailButton_Click(object sender, EventArgs e)
        {
            DateTime lastWeekMonday = DateTimeExpander.LastWeekMonday;
            DateTime lastSunday = DateTimeExpander.LastSunday;
            Automation.DetailData dd = new Automation.DetailData();
            dd.StartDate = lastWeekMonday;
            dd.EndDate = lastSunday;
            List<Action> smallActions = new List<Action>()
            {
                // 店舗別に出力
                dd.selectSumUnitShop
            };
            dd.CriteriaSettings = smallActions;
            dd.Output("detail");
            this.Close();
        }

        private void itemMapButton_Click(object sender, EventArgs e)
        {
            DateTime lastMonday = DateTimeExpander.LastWeekMonday.AddDays(7);
            DateTime nextSunday = DateTimeExpander.LastSunday.AddDays(7);
            Automation.ItemMap im = new ItemMap();
            im.StartDate = lastMonday;
            im.EndDate = nextSunday;
            List<Action> smallActions = new List<Action>()
            {
                // 中分類別に出力
                im.SetSumUnitMidCat
            };
            im.CriteriaSettings = smallActions;
            im.Output("mid");
            this.Close();
        }

        private Automation.BestWorst GetBestWorst(){
            Automation.BestWorst bw = new Automation.BestWorst();

            DateTime lastMonday = Automation.DateTimeExpander.LastWeekMonday;
            DateTime thisSunday = lastMonday.AddDays(6.0);

            bw.StartDate = lastMonday;
            bw.EndDate = thisSunday;
            return bw;
        }

        private void bwAllButton_Click(object sender, EventArgs e)
        {
            Automation.BestWorst bw = this.GetBestWorst();
            // カットソー
            this.bwCutButton.PerformClick();
            System.Threading.Thread.Sleep(2000);

            // ニット
            this.bwKnitButton.PerformClick();
            System.Threading.Thread.Sleep(2000);

            // 布帛 
            this.bwClothButton.PerformClick();
            System.Threading.Thread.Sleep(2000);

            // パンツ 
            this.bwPantsButton.PerformClick();
            System.Threading.Thread.Sleep(2000);

            // ジャケット 
            this.bwJacketButton.PerformClick();
            System.Threading.Thread.Sleep(2000);

            // ワンピース 
            this.bwOnePieceButton.PerformClick();
            System.Threading.Thread.Sleep(2000);
        }

        private void bwKnitButton_Click(object sender, EventArgs e)
        {
            Automation.BestWorst bw = this.GetBestWorst();
            // ニット
            bw.CriteriaSettings = new List<Action>() { bw.SetKnit };
            bw.Output("knit", "knit_image");
        }

        private void bwCutButton_Click(object sender, EventArgs e)
        {
            Automation.BestWorst bw = this.GetBestWorst();
            // カットソー
            bw.CriteriaSettings = new List<Action>() { bw.SetCutSawn };
            bw.Output("cutsawn", "cut_image");
        }

        private void bwClothButton_Click(object sender, EventArgs e)
        {
            Automation.BestWorst bw = this.GetBestWorst();
            // 布帛 
            bw.CriteriaSettings = new List<Action>() { bw.SetCloth };
            bw.Output("cloth", "cloth_image");
        }

        private void bwPantsButton_Click(object sender, EventArgs e)
        {
            Automation.BestWorst bw = this.GetBestWorst();

            // パンツ 
            bw.CriteriaSettings = new List<Action>() { bw.SetPants };
            bw.Output("pants", "pants_image");
        }

        private void bwSkirtButton_Click(object sender, EventArgs e)
        {
            Automation.BestWorst bw = this.GetBestWorst();

            // スカート 
            bw.CriteriaSettings = new List<Action>() { bw.SetSkirt};
            bw.Output("skirt", "skirt_image");
        }

        private void bwJacketButton_Click(object sender, EventArgs e)
        {
            Automation.BestWorst bw = this.GetBestWorst();

            // ワンピース 
            bw.CriteriaSettings = new List<Action>() { bw.SetOnePiece };
            bw.Output("onepiece", "onepiece_image");
        }

        private void sdLargeButton_Click(object sender, EventArgs e)
        {
            Automation.StockDetail sd = this.GetStockDetail();

            // 大分類別
            List<Action> largeActions = new List<Action>()
            {
                sd.SetSumUnitLargeCat,
                sd.SetLargeCatAll
            };
            sd.CriteriaSettings = largeActions;
            sd.Output("large");
        }

        private void sdMidButton_Click(object sender, EventArgs e)
        {
            Automation.StockDetail sd = this.GetStockDetail();

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

        }

        private void sdSmallButton_Click(object sender, EventArgs e)
        {
            Automation.StockDetail sd = this.GetStockDetail();
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
