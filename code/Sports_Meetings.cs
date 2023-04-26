using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_System
{
    public partial class Sports_Meetings : Form
    {
        public Sports_Meetings()
        {
            InitializeComponent();
            //启动时即可获得时间
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer.Start();

            #region 绑定数据库
            String sql = "SELECT 运动会ID, 运动会名称, 主办单位, 承办单位, 地点, 比赛时间, 结束时间 FROM 运动会信息表 WHERE 生效标记 = 1 ;";
            Dao data = new Dao();
            sports_meetings_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动会信息表");
            #endregion
        }

        /// <summary>
        /// 每1秒计时器跳转一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #region 查询按钮
        private void search_toolStripButton_Click(object sender, EventArgs e)
        {
            String sportsname = name_input_toolStripTextBox.Text.Trim();
            String sql = "SELECT 运动会ID, 运动会名称, 主办单位, 承办单位, 地点, 比赛时间, 结束时间 FROM 运动会信息表 WHERE 运动会名称 LIKE '%" + sportsname +"%' AND 生效标记 = 1 ;";
            Dao data = new Dao();
            sports_meetings_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动会信息表");
        }
        #endregion

        #region 主页按钮
        /// <summary>
        /// 返回主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void home_toolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 选中按钮
        private void choose_toolStripButton_Click(object sender, EventArgs e)
        {
            Public_val.set_yundonghui(sports_meetings_dataGridView.SelectedRows[0].Cells[0].Value.ToString());
            MessageBox.Show("您已选择"+sports_meetings_dataGridView.SelectedRows[0].Cells[1].Value.ToString()+
                ",正在进入","提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            xuexiao_xuanze xuexiao = new xuexiao_xuanze();
            this.Hide();
            xuexiao.ShowDialog();
            this.Show();
            if (Public_val.home_flag == true)
            {
                Public_val.home_flag = false;
                this.Close();
            }
        }
        #endregion
    }
}
