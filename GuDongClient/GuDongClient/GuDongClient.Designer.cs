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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lv_Result = new System.Windows.Forms.ListView();
            this.nud_Period = new System.Windows.Forms.NumericUpDown();
            this.Bttn_ChooseDB = new System.Windows.Forms.Button();
            this.tb_SelectedDB = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Period)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(870, 489);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lv_Result);
            this.tabPage2.Controls.Add(this.nud_Period);
            this.tabPage2.Controls.Add(this.Bttn_ChooseDB);
            this.tabPage2.Controls.Add(this.tb_SelectedDB);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(862, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lv_Result
            // 
            this.lv_Result.Location = new System.Drawing.Point(10, 72);
            this.lv_Result.Name = "lv_Result";
            this.lv_Result.Size = new System.Drawing.Size(304, 385);
            this.lv_Result.TabIndex = 4;
            this.lv_Result.UseCompatibleStateImageBehavior = false;
            this.lv_Result.View = System.Windows.Forms.View.Details;
            // 
            // nud_Period
            // 
            this.nud_Period.Location = new System.Drawing.Point(10, 45);
            this.nud_Period.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Period.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Period.Name = "nud_Period";
            this.nud_Period.Size = new System.Drawing.Size(80, 20);
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
            this.Bttn_ChooseDB.Location = new System.Drawing.Point(758, 15);
            this.Bttn_ChooseDB.Name = "Bttn_ChooseDB";
            this.Bttn_ChooseDB.Size = new System.Drawing.Size(98, 23);
            this.Bttn_ChooseDB.TabIndex = 2;
            this.Bttn_ChooseDB.Text = "Choose File";
            this.Bttn_ChooseDB.UseVisualStyleBackColor = true;
            this.Bttn_ChooseDB.Click += new System.EventHandler(this.Bttn_ChooseDB_Click);
            // 
            // tb_SelectedDB
            // 
            this.tb_SelectedDB.Location = new System.Drawing.Point(10, 19);
            this.tb_SelectedDB.Name = "tb_SelectedDB";
            this.tb_SelectedDB.Size = new System.Drawing.Size(741, 20);
            this.tb_SelectedDB.TabIndex = 1;
            // 
            // GuDongClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 513);
            this.Controls.Add(this.tabControl1);
            this.Name = "GuDongClient";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Period)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button Bttn_ChooseDB;
        private System.Windows.Forms.TextBox tb_SelectedDB;
        private System.Windows.Forms.NumericUpDown nud_Period;
        private System.Windows.Forms.ListView lv_Result;
    }
}

