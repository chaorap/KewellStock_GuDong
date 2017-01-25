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
            lv_Result.Columns.Add("代码", 60, HorizontalAlignment.Left);
            lv_Result.Columns.Add("最后更新日期", 140, HorizontalAlignment.Left);
            lv_Result.Columns.Add("减少比例%", 650, HorizontalAlignment.Left);
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
                    string sql = "";
                    switch(period)
                    {
                        case 1: sql = "select * from Gudong where SPercent1<0 order by SPercent1 DESC"; break;
                        case 2: sql = "select * from Gudong where SPercent1<0 and SPercent2<0 order by SPercent1+SPercent2 DESC"; break;
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
                            //dt.Rows[0][Column]
                            int lineNo = lv_Result.Items.Count;
                            lv_Result.Items.Insert(0, new ListViewItem(new string[] { dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][3].ToString() + "%" }));
                            lv_Result.EnsureVisible(0);
                        }
                    }
                }
                catch(Exception ex)
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
