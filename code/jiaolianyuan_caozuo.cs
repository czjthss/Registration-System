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
    public partial class jiaolianyuan_caozuo : Form
    {
        private String caozuo = "注册";

        public jiaolianyuan_caozuo()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();

            #region 绑定数据库
            //显示设置
            toolStripSeparator2.Visible = true;
            toolStripSeparator3.Visible = true;
            add_toolStripButton.Visible = true;
            delete_toolStripButton.Visible = true;
            kongbai_dataGridView.Visible = true;
            jiaolianyuanzhuce_dataGridView.Visible = false;
            duiwu_dataGridView.Visible = false;

            //String sql = "SELECT * FROM 运动员注册表;";
            String sql = "SELECT 教练员ID, 姓名, 学校, 职称, 生效标记" +
                " FROM 教练员注册表 WHERE 教练员账号= '" + Public_val.get_zhanghao() + "';";

            Dao data = new Dao();
            jiaolianyuanzhuce_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
            #endregion
        }

        #region 计时
        /// <summary>
        /// 每1秒计时器跳转一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region MenuStrip跳转
        private void 已注册信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caozuo = "注册";
            name_toolStripLabel.Text = "教练员注册界面";

            //构建界面 
            toolStripSeparator2.Visible = true;
            toolStripSeparator3.Visible = true;
            add_toolStripButton.Visible = true;
            delete_toolStripButton.Visible = true;
            kongbai_dataGridView.Visible = false;
            jiaolianyuanzhuce_dataGridView.Visible = true;
            duiwu_dataGridView.Visible = false;
        }
        private void 已加入队伍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caozuo = "队伍";
            name_toolStripLabel.Text = "教练员队伍查看";

            //构建界面 
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            add_toolStripButton.Visible = false;
            delete_toolStripButton.Visible = false;
            kongbai_dataGridView.Visible = false;
            jiaolianyuanzhuce_dataGridView.Visible = false;
            duiwu_dataGridView.Visible = true;

            //初始显示
            String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
            String sql = "SELECT * FROM 教练员信息表 WHERE 教练员ID IN " +
                "(SELECT 教练员ID FROM 教练员注册表 WHERE 教练员账号 = '" + Public_val.get_zhanghao() + "' );";

            Dao data = new Dao();
            duiwu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员信息表");
        }

        #endregion

        #region 添加教练员按钮(注册)
        private void add_toolStripButton_Click(object sender, EventArgs e)
        {
            jiaolianyuan_Add add = new jiaolianyuan_Add();
            this.Hide();
            add.ShowDialog();
            this.Show();

            //显示加入的数据
            //String sql = "SELECT * FROM 运动员注册表;";
            String sql = "SELECT 教练员ID, 姓名, 学校, 职称, 生效标记" +
                " FROM 教练员注册表 WHERE 教练员账号= '" + Public_val.get_zhanghao() + "';";
            Dao data = new Dao();
            jiaolianyuanzhuce_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
        }
        #endregion

        #region 删除运动员按钮(注册)
        private void delete_toolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确定要删除该条记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //如果确定删除
            if (res == DialogResult.OK)
            {
                //执行删除操作
                String yundongyuan_ID = jiaolianyuanzhuce_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                String sql = "DELETE FROM 教练员注册表 WHERE 教练员ID = '" + yundongyuan_ID + "'";
                Dao data_delete = new Dao();
                int num = data_delete.Excute(sql);
                if (num > 0)
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //显示数据
                sql = "SELECT 教练员ID, 姓名, 学校, 职称, 生效标记" +
                    " FROM 教练员注册表 WHERE 教练员账号= '" + Public_val.get_zhanghao()+"' ;";
                //sql = "SELECT * FROM 运动员注册表;";
                Dao data_delete_show = new Dao();
                jiaolianyuanzhuce_dataGridView.DataSource = data_delete_show.SqlDataGridView_Show(sql, "教练员注册表");
            }
        }
        #endregion

        #region 查询按钮
        private void search_toolStripButton_Click(object sender, EventArgs e)
        {
            if (caozuo == "注册")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 教练员ID, 姓名, 学校, 职称, 生效标记" +
                    " FROM 教练员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%' " +
                    "AND 教练员账号 = "+Public_val.get_zhanghao()+";";
                Dao data = new Dao();
                jiaolianyuanzhuce_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
            }
            else if (caozuo == "队伍")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "";

                if (yundongyuanname == "")
                {
                    sql = "SELECT * FROM 教练员信息表 WHERE 教练员ID IN " +
                        "(SELECT 教练员ID FROM 教练员注册表 WHERE 教练员账号 = '" + Public_val.get_zhanghao() + "' );";
                }
                else
                {
                    sql = "SELECT *" +
                    " FROM 教练员信息表 WHERE 教练员ID LIKE '%" + yundongyuanname + "%' ";
                }

                Dao data = new Dao();
                duiwu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员信息表");
            }
        }
        #endregion

        #region 主页按钮
        private void home_toolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}