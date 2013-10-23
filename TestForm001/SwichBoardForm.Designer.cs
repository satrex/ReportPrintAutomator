namespace ReportPrintAutomator
{
    partial class SwichBoardForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.bwAllButton = new System.Windows.Forms.Button();
            this.sdAllButton = new System.Windows.Forms.Button();
            this.itemMapButton = new System.Windows.Forms.Button();
            this.bestWorstGroup = new System.Windows.Forms.GroupBox();
            this.bwOnePieceButton = new System.Windows.Forms.Button();
            this.bwJacketButton = new System.Windows.Forms.Button();
            this.bwSkirtButton = new System.Windows.Forms.Button();
            this.bwPantsButton = new System.Windows.Forms.Button();
            this.bwClothButton = new System.Windows.Forms.Button();
            this.bwCutButton = new System.Windows.Forms.Button();
            this.bwKnitButton = new System.Windows.Forms.Button();
            this.sdGroup = new System.Windows.Forms.GroupBox();
            this.sdSmallButton = new System.Windows.Forms.Button();
            this.sdMidButton = new System.Windows.Forms.Button();
            this.sdLargeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddAllButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.bestWorstGroup.SuspendLayout();
            this.sdGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwAllButton
            // 
            this.bwAllButton.Location = new System.Drawing.Point(13, 30);
            this.bwAllButton.Name = "bwAllButton";
            this.bwAllButton.Size = new System.Drawing.Size(98, 23);
            this.bwAllButton.TabIndex = 0;
            this.bwAllButton.Text = "ぜんぶ";
            this.bwAllButton.UseVisualStyleBackColor = true;
            this.bwAllButton.Click += new System.EventHandler(this.bwAllButton_Click);
            // 
            // sdAllButton
            // 
            this.sdAllButton.Location = new System.Drawing.Point(12, 30);
            this.sdAllButton.Name = "sdAllButton";
            this.sdAllButton.Size = new System.Drawing.Size(100, 23);
            this.sdAllButton.TabIndex = 0;
            this.sdAllButton.Text = "ぜんぶ";
            this.sdAllButton.UseVisualStyleBackColor = true;
            this.sdAllButton.Click += new System.EventHandler(this.sdAllButton_Click);
            // 
            // itemMapButton
            // 
            this.itemMapButton.Location = new System.Drawing.Point(12, 31);
            this.itemMapButton.Name = "itemMapButton";
            this.itemMapButton.Size = new System.Drawing.Size(100, 23);
            this.itemMapButton.TabIndex = 0;
            this.itemMapButton.Text = "全カテゴリ";
            this.itemMapButton.UseVisualStyleBackColor = true;
            this.itemMapButton.Click += new System.EventHandler(this.itemMapButton_Click);
            // 
            // bestWorstGroup
            // 
            this.bestWorstGroup.Controls.Add(this.bwOnePieceButton);
            this.bestWorstGroup.Controls.Add(this.bwJacketButton);
            this.bestWorstGroup.Controls.Add(this.bwSkirtButton);
            this.bestWorstGroup.Controls.Add(this.bwPantsButton);
            this.bestWorstGroup.Controls.Add(this.bwClothButton);
            this.bestWorstGroup.Controls.Add(this.bwCutButton);
            this.bestWorstGroup.Controls.Add(this.bwKnitButton);
            this.bestWorstGroup.Controls.Add(this.bwAllButton);
            this.bestWorstGroup.Location = new System.Drawing.Point(402, 13);
            this.bestWorstGroup.Name = "bestWorstGroup";
            this.bestWorstGroup.Size = new System.Drawing.Size(117, 311);
            this.bestWorstGroup.TabIndex = 3;
            this.bestWorstGroup.TabStop = false;
            this.bestWorstGroup.Text = "ベスト・ワースト分析";
            // 
            // bwOnePieceButton
            // 
            this.bwOnePieceButton.Location = new System.Drawing.Point(13, 233);
            this.bwOnePieceButton.Name = "bwOnePieceButton";
            this.bwOnePieceButton.Size = new System.Drawing.Size(98, 23);
            this.bwOnePieceButton.TabIndex = 7;
            this.bwOnePieceButton.Text = "ワンピース";
            this.bwOnePieceButton.UseVisualStyleBackColor = true;
            this.bwOnePieceButton.Click += new System.EventHandler(this.bwOnePieceButton_Click);
            // 
            // bwJacketButton
            // 
            this.bwJacketButton.Location = new System.Drawing.Point(13, 204);
            this.bwJacketButton.Name = "bwJacketButton";
            this.bwJacketButton.Size = new System.Drawing.Size(98, 23);
            this.bwJacketButton.TabIndex = 6;
            this.bwJacketButton.Text = "ジャケット";
            this.bwJacketButton.UseVisualStyleBackColor = true;
            this.bwJacketButton.Click += new System.EventHandler(this.bwJacketButton_Click);
            // 
            // bwSkirtButton
            // 
            this.bwSkirtButton.Location = new System.Drawing.Point(13, 175);
            this.bwSkirtButton.Name = "bwSkirtButton";
            this.bwSkirtButton.Size = new System.Drawing.Size(98, 23);
            this.bwSkirtButton.TabIndex = 5;
            this.bwSkirtButton.Text = "スカート";
            this.bwSkirtButton.UseVisualStyleBackColor = true;
            this.bwSkirtButton.Click += new System.EventHandler(this.bwSkirtButton_Click);
            // 
            // bwPantsButton
            // 
            this.bwPantsButton.Location = new System.Drawing.Point(13, 146);
            this.bwPantsButton.Name = "bwPantsButton";
            this.bwPantsButton.Size = new System.Drawing.Size(98, 23);
            this.bwPantsButton.TabIndex = 4;
            this.bwPantsButton.Text = "パンツ";
            this.bwPantsButton.UseVisualStyleBackColor = true;
            this.bwPantsButton.Click += new System.EventHandler(this.bwPantsButton_Click);
            // 
            // bwClothButton
            // 
            this.bwClothButton.Location = new System.Drawing.Point(13, 117);
            this.bwClothButton.Name = "bwClothButton";
            this.bwClothButton.Size = new System.Drawing.Size(98, 23);
            this.bwClothButton.TabIndex = 3;
            this.bwClothButton.Text = "布帛";
            this.bwClothButton.UseVisualStyleBackColor = true;
            this.bwClothButton.Click += new System.EventHandler(this.bwClothButton_Click);
            // 
            // bwCutButton
            // 
            this.bwCutButton.Location = new System.Drawing.Point(13, 88);
            this.bwCutButton.Name = "bwCutButton";
            this.bwCutButton.Size = new System.Drawing.Size(98, 23);
            this.bwCutButton.TabIndex = 2;
            this.bwCutButton.Text = "カット";
            this.bwCutButton.UseVisualStyleBackColor = true;
            this.bwCutButton.Click += new System.EventHandler(this.bwCutButton_Click);
            // 
            // bwKnitButton
            // 
            this.bwKnitButton.Location = new System.Drawing.Point(13, 59);
            this.bwKnitButton.Name = "bwKnitButton";
            this.bwKnitButton.Size = new System.Drawing.Size(98, 23);
            this.bwKnitButton.TabIndex = 1;
            this.bwKnitButton.Text = "ニット";
            this.bwKnitButton.UseVisualStyleBackColor = true;
            this.bwKnitButton.Click += new System.EventHandler(this.bwKnitButton_Click);
            // 
            // sdGroup
            // 
            this.sdGroup.Controls.Add(this.sdSmallButton);
            this.sdGroup.Controls.Add(this.sdAllButton);
            this.sdGroup.Controls.Add(this.sdMidButton);
            this.sdGroup.Controls.Add(this.sdLargeButton);
            this.sdGroup.Location = new System.Drawing.Point(272, 12);
            this.sdGroup.Name = "sdGroup";
            this.sdGroup.Size = new System.Drawing.Size(124, 310);
            this.sdGroup.TabIndex = 2;
            this.sdGroup.TabStop = false;
            this.sdGroup.Text = "詳細在庫";
            // 
            // sdSmallButton
            // 
            this.sdSmallButton.Location = new System.Drawing.Point(12, 117);
            this.sdSmallButton.Name = "sdSmallButton";
            this.sdSmallButton.Size = new System.Drawing.Size(100, 23);
            this.sdSmallButton.TabIndex = 3;
            this.sdSmallButton.Text = "小分類";
            this.sdSmallButton.UseVisualStyleBackColor = true;
            this.sdSmallButton.Click += new System.EventHandler(this.sdSmallButton_Click);
            // 
            // sdMidButton
            // 
            this.sdMidButton.Location = new System.Drawing.Point(12, 88);
            this.sdMidButton.Name = "sdMidButton";
            this.sdMidButton.Size = new System.Drawing.Size(100, 23);
            this.sdMidButton.TabIndex = 2;
            this.sdMidButton.Text = "中分類";
            this.sdMidButton.UseVisualStyleBackColor = true;
            this.sdMidButton.Click += new System.EventHandler(this.sdMidButton_Click);
            // 
            // sdLargeButton
            // 
            this.sdLargeButton.Location = new System.Drawing.Point(12, 60);
            this.sdLargeButton.Name = "sdLargeButton";
            this.sdLargeButton.Size = new System.Drawing.Size(100, 23);
            this.sdLargeButton.TabIndex = 1;
            this.sdLargeButton.Text = "大分類";
            this.sdLargeButton.UseVisualStyleBackColor = true;
            this.sdLargeButton.Click += new System.EventHandler(this.sdLargeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddAllButton);
            this.groupBox1.Location = new System.Drawing.Point(142, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 310);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "詳細データ分析";
            // 
            // ddAllButton
            // 
            this.ddAllButton.Location = new System.Drawing.Point(12, 30);
            this.ddAllButton.Name = "ddAllButton";
            this.ddAllButton.Size = new System.Drawing.Size(100, 23);
            this.ddAllButton.TabIndex = 0;
            this.ddAllButton.Text = "店ごと";
            this.ddAllButton.UseVisualStyleBackColor = true;
            this.ddAllButton.Click += new System.EventHandler(this.detailButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.itemMapButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 310);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "アイテム投入マップ";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(415, 330);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(98, 49);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SwichBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 391);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sdGroup);
            this.Controls.Add(this.bestWorstGroup);
            this.Name = "SwichBoardForm";
            this.Text = "自動レポート印刷";
            this.bestWorstGroup.ResumeLayout(false);
            this.sdGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bwAllButton;
        private System.Windows.Forms.Button sdAllButton;
        private System.Windows.Forms.Button itemMapButton;
        private System.Windows.Forms.GroupBox bestWorstGroup;
        private System.Windows.Forms.Button bwOnePieceButton;
        private System.Windows.Forms.Button bwJacketButton;
        private System.Windows.Forms.Button bwSkirtButton;
        private System.Windows.Forms.Button bwPantsButton;
        private System.Windows.Forms.Button bwClothButton;
        private System.Windows.Forms.Button bwCutButton;
        private System.Windows.Forms.Button bwKnitButton;
        private System.Windows.Forms.GroupBox sdGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button sdSmallButton;
        private System.Windows.Forms.Button sdMidButton;
        private System.Windows.Forms.Button sdLargeButton;
        private System.Windows.Forms.Button ddAllButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button closeButton;
    }
}

