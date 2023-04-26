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
    public partial class Sports_Meetings_zhuban : Form
    {
        //是否查询全部运动会
        private bool quanbu = false;
        public Sports_Meetings_zhuban()
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
            String sql;
            //是否显示被删除的运动会
            if (quanbu == false)
            {
                sql = "SELECT 运动会ID, 运动会名称, 主办单位, 承办单位, 地点, 比赛时间, 结束时间 FROM 运动会信息表 WHERE 运动会名称 LIKE '%" + sportsname + "%' AND 生效标记 = 1 ;";
            }
            else
            {
                sql = "SELECT 运动会ID, 运动会名称, 主办单位, 承办单位, 地点, 比赛时间, 结束时间 FROM 运动会信息表 WHERE 运动会名称 LIKE '%" + sportsname + "%' ;";

            }
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

        #region 删除按钮
        private void delete_toolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("\t确定要删除该条记录？\n您可以在'查看往期运动会'按钮中查看已删除的运动会", "提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            //如果确定删除
            if (res == DialogResult.OK)
            {
                //执行删除操作
                String sport_meeting_ID = sports_meetings_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                String sql = "UPDATE 运动会信息表 SET 生效标记 = 0 WHERE 运动会ID = '"+sport_meeting_ID+"'";
                Dao data_delete = new Dao();
                int num = data_delete.Excute(sql);
                if (num > 0)
                {
                    MessageBox.Show("删除成功", "提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

                //显示数据
                sql = "SELECT 运动会ID, 运动会名称, 主办单位, 承办单位, 地点, 比赛时间, 结束时间 FROM 运动会信息表 WHERE 生效标记 = 1 ;";
                Dao data_delete_show = new Dao();
                sports_meetings_dataGridView.DataSource = data_delete_show.SqlDataGridView_Show(sql, "运动会信息表");
            }
        }
        #endregion

        #region 添加按钮
        private void add_toolStripButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sports_Meetings_Add add = new Sports_Meetings_Add();
            add.ShowDialog();
            this.Show();
            //显示添加后的表
            String sportsname = name_input_toolStripTextBox.Text.Trim();
            String sql = "SELECT 运动会ID, 运动会名称, 主办单位, 承办单位, 地点, 比赛时间, 结束时间 FROM 运动会信息表 WHERE 运动会名称 LIKE '%" + sportsname + "%' AND 生效标记 = 1 ;";
            Dao data = new Dao();
            sports_meetings_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动会信息表");
        }
        #endregion

        #region 选中按钮
        private void choose_toolStripButton_Click(object sender, EventArgs e)
        {
            Public_val.set_yundonghui(sports_meetings_dataGridView.SelectedRows[0].Cells[0].Value.ToString());
            MessageBox.Show("您已选择" + sports_meetings_dataGridView.SelectedRows[0].Cells[1].Value.ToString() +
                ",正在进入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            zhubanfang_caozuo zhubanfang = new zhubanfang_caozuo();
            this.Hide();
            zhubanfang.ShowDialog();
            this.Show();

            //主页键
            if (Public_val.home_flag == true)
            {
                Public_val.home_flag = false;
                this.Close();
            }
        }
        #endregion

        #region 查看往期运动会
        private void quanbu_toolStripButton_Click(object sender, EventArgs e)
        {
            //设置全部
            if (quanbu == true)
            {
                quanbu = false;
                quanbu_toolStripButton.Text = "查看往期运动会";
            }
            else
            {
                quanbu = true;
                quanbu_toolStripButton.Text = "查看生效运动会";
            }

            String sportsname = name_input_toolStripTextBox.Text.Trim();
            String sql;

            if (quanbu == true)
            {
                sql = "SELECT 运动会ID, 运动会名称, 主办单位, 承办单位, 地点, 比赛时间, 结束时间 FROM 运动会信息表 WHERE 运动会名称 LIKE '%" + sportsname + "%' ;";
            }
            else
            {
                sql = "SELECT 运动会ID, 运动会名称, 主办单位, 承办单位, 地点, 比赛时间, 结束时间 FROM 运动会信息表 WHERE 运动会名称 LIKE '%" + sportsname + "%' AND 生效标记 = 1;";
            }
            Dao data = new Dao();
            sports_meetings_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动会信息表");

        }
        #endregion
    }
}
