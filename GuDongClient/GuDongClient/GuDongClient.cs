using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GuDongClient
{
    public partial class GuDongClient : Form
    {
        private string DB_File_Name = "";
        SQLiteConnection conn = null;

        public GuDongClient()
        {
            InitializeComponent();
            this.Font = new Font(Font.Name, 12);
            ClearStock();
        }

        private void ClearStock()
        {
            lv_Result.Clear();
            lv_Result.Columns.Add("代码", 60, HorizontalAlignment.Left);
            lv_Result.Columns.Add("名称", 80, HorizontalAlignment.Left);
            lv_Result.Columns.Add("最后更新日期", 140, HorizontalAlignment.Left);
            lv_Result.Columns.Add("总减少比例%", 120, HorizontalAlignment.Left);
            lv_Result.Columns.Add("总股本", 90, HorizontalAlignment.Left);
            lv_Result.Columns.Add("流通股", 70, HorizontalAlignment.Left);
            lv_Result.Columns.Add("公积金", 70, HorizontalAlignment.Left);
            lv_Result.Columns.Add("未分配", 70, HorizontalAlignment.Left);
            lv_Result.Columns.Add("每股收益", 90, HorizontalAlignment.Left);
        }

        private void ClearStockInfo()
        {
            lv_StockInfo.Clear();
            lv_StockInfo.Columns.Add("日期", 150, HorizontalAlignment.Center);
            lv_StockInfo.Columns.Add("股东人数", 150, HorizontalAlignment.Center);
            lv_StockInfo.Columns.Add("减少比例%", 150, HorizontalAlignment.Center);
        }

        private void Bttn_ChooseDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Sqlite文件|*.sqlite";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if(conn != null)
                {
                    conn.Dispose();
                }
                DB_File_Name = ofd.FileName;
                tb_SelectedDB.Text = ofd.FileName;
                try
                {
                    conn = new SQLiteConnection("Data Source=" + ofd.FileName);
                    conn.Open();
                    UpdateStockTable();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void UpdateStockTable()
        {
            if(conn != null)
            {
                //SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
                //cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  

                //SQLiteCommand cmdInsert = new SQLiteCommand(conn);
                //cmdInsert.CommandText = "INSERT INTO student VALUES(1, '小红', '男')";//插入几条数据  
                //cmdInsert.ExecuteNonQuery();
                //cmdInsert.CommandText = "INSERT INTO student VALUES(2, '小李', '女')";
                //cmdInsert.ExecuteNonQuery();
                //cmdInsert.CommandText = "INSERT INTO student VALUES(3, '小明', '男')";
                //cmdInsert.ExecuteNonQuery();

                //conn.Close();

                try
                {
                    DataTable dt = new DataTable();
                    int period = (int)nud_Period.Value;
                    float per = 1.0f;
                    string sql = "select * from Gudong where SPercent1<0 ";

                    if (period == 1)
                    {
                        sql = "select * from Gudong where SPercent1<0 order by SPercent1 DESC";
                    }
                    else
                    {
                        for (int i = 2; i <= period; i++)
                        {
                            sql = sql + string.Format("and SPercent{0:d}<0 ", i);
                        }
                        sql = sql + string.Format("order by 1 - ((1+SPercent1/100)");
                        for (int i = 2; i <= period; i++)
                        {
                            sql = sql + string.Format("*(1+SPercent{0:d}/100)", i);
                        }
                        sql = sql + ")";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(conn))
                    {
                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                        command.CommandText = sql;
                        command.ExecuteNonQuery();

                        adapter.Fill(dt);
                        ClearStock();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DateTime datet;
                            DateTime.TryParse(dt.Rows[i][7].ToString(), out datet);
                            if (period == 1)
                            {
                                per = float.Parse(dt.Rows[i][9].ToString());
                            }
                            else
                            {
                                //per = (float.Parse(dt.Rows[i][12 + (period - 2) * 3].ToString()) - float.Parse(dt.Rows[i][9].ToString()))/float.Parse(dt.Rows[i][9].ToString();
                                //per = (float.Parse(dt.Rows[i][8].ToString()) - float.Parse(dt.Rows[i][11 + (period - 2) * 3].ToString()))/float.Parse(dt.Rows[i][11 + (period - 2) * 3].ToString());
                                //float n1 = float.Parse(dt.Rows[i][9].ToString());
                                //float nn = float.Parse(dt.Rows[i][12 + (period - 2) * 3].ToString());

                                //per = (100 + n1) * (100 + nn);
                                per = 1.0f + float.Parse(dt.Rows[i][9].ToString())/100;
                                for (int j=2; j<=period;j++)
                                {
                                    per *= (1.0f + float.Parse(dt.Rows[i][12 + (j - 2) * 3].ToString()) / 100);
                                }
                                per = (1.0f - per)*100;
                            }
                            float zgb = float.Parse(dt.Rows[i][2].ToString());
                            float ltg = float.Parse(dt.Rows[i][3].ToString());
                            string string_zgb, string_ltg;
                            if((zgb<1.0f) && (zgb>0))
                            {
                                string_zgb = (zgb*10000 ).ToString() + "万";
                            }
                            else
                            {
                                string_zgb = (zgb).ToString() + "亿";
                            }
                            if ((ltg < 1.0f) && (zgb > 0))
                            {
                                string_ltg = (ltg*10000 ).ToString() + "万";
                            }
                            else
                            {
                                string_ltg = (ltg).ToString() + "亿";
                            }
                            lv_Result.Items.Insert(0, new ListViewItem(new string[] { dt.Rows[i][0].ToString().PadLeft(6, '0'), dt.Rows[i][1].ToString(),DateTime.Parse(dt.Rows[i][7].ToString()).ToString("yyyy年MM月dd日"), per.ToString() + "%", string_zgb, string_ltg, dt.Rows[i][4].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][5].ToString() }));
                            lv_Result.EnsureVisible(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                ClearStockInfo();
            }
        }

        private void nud_Period_ValueChanged(object sender, EventArgs e)
        {
            UpdateStockTable();
        }

        private void lv_Result_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(lv_Result.SelectedItems[0] != null)
            if (lv_Result.SelectedIndices == null || lv_Result.SelectedIndices.Count == 0)
            {
                ClearStockInfo();
            }
            else
            {
                try
                {
                    if(conn != null)
                    {
                        DataTable dt = new DataTable();

                        lb_StockName.Text =  lv_Result.SelectedItems[0].SubItems[1].Text + "(" + lv_Result.SelectedItems[0].SubItems[0].Text + ") 股东信息";
                        string sql = "select * from Gudong where StockNumber = " + lv_Result.SelectedItems[0].SubItems[0].Text;
                        using (SQLiteCommand command = new SQLiteCommand(conn))
                        {
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                            command.CommandText = sql;
                            command.ExecuteNonQuery();

                            adapter.Fill(dt);
                            ClearStockInfo();

                            for(int i=1;i<=20; i++)
                            {
                                string DateX = "SDate" + string.Format("{0:d}",i);
                                string NumX = "SNumber" + string.Format("{0:d}", i);
                                string PerX = "SPercent" + string.Format("{0:d}", i);
                                if (dt.Rows[0][NumX].ToString() == null || dt.Rows[0][NumX].ToString() == "")
                                {
                                    break;
                                }
                                else
                                {
                                    //MessageBox.Show(DateTime.Parse(dt.Rows[0][DateX].ToString()).ToString("yyyy年MM月dd日") + "\n" + dt.Rows[0][NumX].ToString() + "\n"+ dt.Rows[0][PerX].ToString());
                                    ListViewItem item = new ListViewItem(new string[] { DateTime.Parse(dt.Rows[0][DateX].ToString()).ToString("yyyy年MM月dd日"), dt.Rows[0][NumX].ToString(), dt.Rows[0][PerX].ToString() + "%" });
                                    if(float.Parse(dt.Rows[0][PerX].ToString()) >= 0)
                                    {
                                        item.ForeColor = Color.Red;
                                    }
                                    else
                                    {
                                        item.ForeColor = Color.Green;
                                    }
                                    lv_StockInfo.Items.Insert(lv_StockInfo.Items.Count, item);
                                }
                            }
                            lv_StockInfo.EnsureVisible(0);
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
