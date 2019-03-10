namespace GuDongClient
{
    partial class GuDongClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lv_Result = new System.Windows.Forms.ListView();
            this.nud_Period = new System.Windows.Forms.NumericUpDown();
            this.Bttn_ChooseDB = new System.Windows.Forms.Button();
            this.tb_SelectedDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_StockName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lv_StockInfo = new System.Windows.Forms.ListView();
            this.Pic_Stock_Day = new System.Windows.Forms.PictureBox();
            this.dtp_StockDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_LocateStock = new System.Windows.Forms.TextBox();
            this.Bttn_LocateStock = new System.Windows.Forms.Button();
            this.Pic_Stock_Week = new System.Windows.Forms.PictureBox();
            this.Pic_Stock_Month = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Period)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Stock_Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Stock_Week)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Stock_Month)).BeginInit();
            this.SuspendLayout();
            // 
            // lv_Result
            // 
            this.lv_Result.FullRowSelect = true;
            this.lv_Result.Location = new System.Drawing.Point(14, 63);
            this.lv_Result.Name = "lv_Result";
            this.lv_Result.Size = new System.Drawing.Size(624, 678);
            this.lv_Result.TabIndex = 4;
            this.lv_Result.UseCompatibleStateImageBehavior = false;
            this.lv_Result.View = System.Windows.Forms.View.Details;
            this.lv_Result.SelectedIndexChanged += new System.EventHandler(this.lv_Result_SelectedIndexChanged);
            // 
            // nud_Period
            // 
            this.nud_Period.Location = new System.Drawing.Point(86, 36);
            this.nud_Period.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_Period.Name = "nud_Period";
            this.nud_Period.Size = new System.Drawing.Size(46, 21);
            this.nud_Period.TabIndex = 3;
            this.nud_Period.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Period.ValueChanged += new System.EventHandler(this.nud_Period_ValueChanged);
            // 
            // Bttn_ChooseDB
            // 
            this.Bttn_ChooseDB.Location = new System.Drawing.Point(558, 8);
            this.Bttn_ChooseDB.Name = "Bttn_ChooseDB";
            this.Bttn_ChooseDB.Size = new System.Drawing.Size(80, 21);
            this.Bttn_ChooseDB.TabIndex = 2;
            this.Bttn_ChooseDB.Text = "选择文件";
            this.Bttn_ChooseDB.UseVisualStyleBackColor = true;
            this.Bttn_ChooseDB.Click += new System.EventHandler(this.Bttn_ChooseDB_Click);
            // 
            // tb_SelectedDB
            // 
            this.tb_SelectedDB.Location = new System.Drawing.Point(86, 9);
            this.tb_SelectedDB.Name = "tb_SelectedDB";
            this.tb_SelectedDB.ReadOnly = true;
            this.tb_SelectedDB.Size = new System.Drawing.Size(466, 21);
            this.tb_SelectedDB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "1. 选择文件";
            // 
            // lb_StockName
            // 
            this.lb_StockName.AutoSize = true;
            this.lb_StockName.Location = new System.Drawing.Point(645, 45);
            this.lb_StockName.Name = "lb_StockName";
            this.lb_StockName.Size = new System.Drawing.Size(0, 12);
            this.lb_StockName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "2. 连续减少";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "期";
            // 
            // lv_StockInfo
            // 
            this.lv_StockInfo.Location = new System.Drawing.Point(644, 9);
            this.lv_StockInfo.Name = "lv_StockInfo";
            this.lv_StockInfo.Size = new System.Drawing.Size(351, 732);
            this.lv_StockInfo.TabIndex = 9;
            this.lv_StockInfo.UseCompatibleStateImageBehavior = false;
            this.lv_StockInfo.View = System.Windows.Forms.View.Details;
            // 
            // Pic_Stock_Day
            // 
            this.Pic_Stock_Day.Location = new System.Drawing.Point(1001, 8);
            this.Pic_Stock_Day.Name = "Pic_Stock_Day";
            this.Pic_Stock_Day.Size = new System.Drawing.Size(400, 240);
            this.Pic_Stock_Day.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Pic_Stock_Day.TabIndex = 10;
            this.Pic_Stock_Day.TabStop = false;
            // 
            // dtp_StockDate
            // 
            this.dtp_StockDate.Location = new System.Drawing.Point(292, 36);
            this.dtp_StockDate.Name = "dtp_StockDate";
            this.dtp_StockDate.Size = new System.Drawing.Size(121, 21);
            this.dtp_StockDate.TabIndex = 11;
            this.dtp_StockDate.ValueChanged += new System.EventHandler(this.dtp_StockDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "最后一期更新日期在";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(419, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "之后";
            // 
            // tb_LocateStock
            // 
            this.tb_LocateStock.Location = new System.Drawing.Point(455, 36);
            this.tb_LocateStock.Name = "tb_LocateStock";
            this.tb_LocateStock.Size = new System.Drawing.Size(97, 21);
            this.tb_LocateStock.TabIndex = 14;
            this.tb_LocateStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_LocateStock_KeyDown);
            // 
            // Bttn_LocateStock
            // 
            this.Bttn_LocateStock.Location = new System.Drawing.Point(558, 36);
            this.Bttn_LocateStock.Name = "Bttn_LocateStock";
            this.Bttn_LocateStock.Size = new System.Drawing.Size(80, 21);
            this.Bttn_LocateStock.TabIndex = 15;
            this.Bttn_LocateStock.Text = "定位股票";
            this.Bttn_LocateStock.UseVisualStyleBackColor = true;
            this.Bttn_LocateStock.Click += new System.EventHandler(this.Bttn_LocateStock_Click);
            // 
            // Pic_Stock_Week
            // 
            this.Pic_Stock_Week.Location = new System.Drawing.Point(1001, 254);
            this.Pic_Stock_Week.Name = "Pic_Stock_Week";
            this.Pic_Stock_Week.Size = new System.Drawing.Size(400, 240);
            this.Pic_Stock_Week.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Pic_Stock_Week.TabIndex = 16;
            this.Pic_Stock_Week.TabStop = false;
            // 
            // Pic_Stock_Month
            // 
            this.Pic_Stock_Month.Location = new System.Drawing.Point(1001, 497);
            this.Pic_Stock_Month.Name = "Pic_Stock_Month";
            this.Pic_Stock_Month.Size = new System.Drawing.Size(400, 240);
            this.Pic_Stock_Month.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Pic_Stock_Month.TabIndex = 17;
            this.Pic_Stock_Month.TabStop = false;
            // 
            // GuDongClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 749);
            this.Controls.Add(this.Pic_Stock_Month);
            this.Controls.Add(this.Pic_Stock_Week);
            this.Controls.Add(this.Bttn_LocateStock);
            this.Controls.Add(this.tb_LocateStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_StockDate);
            this.Controls.Add(this.Pic_Stock_Day);
            this.Controls.Add(this.lv_StockInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_StockName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_Result);
            this.Controls.Add(this.nud_Period);
            this.Controls.Add(this.Bttn_ChooseDB);
            this.Controls.Add(this.tb_SelectedDB);
            this.Name = "GuDongClient";
            this.Text = "股东人数";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Period)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Stock_Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Stock_Week)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Stock_Month)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Bttn_ChooseDB;
        private System.Windows.Forms.TextBox tb_SelectedDB;
        private System.Windows.Forms.NumericUpDown nud_Period;
        private System.Windows.Forms.ListView lv_Result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_StockName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lv_StockInfo;
        private System.Windows.Forms.PictureBox Pic_Stock_Day;
        private System.Windows.Forms.DateTimePicker dtp_StockDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_LocateStock;
        private System.Windows.Forms.Button Bttn_LocateStock;
        private System.Windows.Forms.PictureBox Pic_Stock_Week;
        private System.Windows.Forms.PictureBox Pic_Stock_Month;
    }
}

