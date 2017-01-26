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
            this.Font = new Font(Font.Name, 15);
            ClearStock();
        }

        private void ClearStock()
        {
            lv_Result.Clear();
            lv_Result.Columns.Add("代码", 80, HorizontalAlignment.Left);
            lv_Result.Columns.Add("名称", 100, HorizontalAlignment.Left);
            lv_Result.Columns.Add("最后更新日期", 200, HorizontalAlignment.Left);
            lv_Result.Columns.Add("总减少比例%", 200, HorizontalAlignment.Left);
            lv_Result.Columns.Add("总股本", 150, HorizontalAlignment.Left);
            lv_Result.Columns.Add("流通股", 150, HorizontalAlignment.Left);
            lv_Result.Columns.Add("公积金", 150, HorizontalAlignment.Left);
            lv_Result.Columns.Add("未分配", 150, HorizontalAlignment.Left);
            lv_Result.Columns.Add("每股收益", 150, HorizontalAlignment.Left);
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
                    float per;
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
                        sql = sql + string.Format("order by (SNumber1-SNumber{0:d})/SNumber{0:d} DESC", period);
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
                                float n1 = float.Parse(dt.Rows[i][8].ToString());
                                float nn = float.Parse(dt.Rows[i][11 + (period - 2) * 3].ToString());
                                per = (n1 - nn) * 100 / nn;
                            }
                            float zgb = float.Parse(dt.Rows[i][2].ToString());
                            float ltg = float.Parse(dt.Rows[i][3].ToString());
                            string string_zgb, string_ltg;
                            if(zgb<10000)
                            {
                                string_zgb = (zgb ).ToString() + "千万";
                            }
                            else
                            {
                                string_zgb = (zgb/10000).ToString() + "亿";
                            }
                            if (ltg < 10000)
                            {
                                string_ltg = (ltg ).ToString() + "千万";
                            }
                            else
                            {
                                string_ltg = (ltg/10000).ToString() + "亿";
                            }
                            lv_Result.Items.Insert(0, new ListViewItem(new string[] { dt.Rows[i][0].ToString().PadLeft(6, '0'), dt.Rows[i][1].ToString(), dt.Rows[i][7].ToString(), per.ToString() + "%", string_zgb, string_ltg }));
                            lv_Result.EnsureVisible(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void nud_Period_ValueChanged(object sender, EventArgs e)
        {
            UpdateStockTable();
        }
    }
}
