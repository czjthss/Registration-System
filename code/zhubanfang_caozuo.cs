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
    public partial class zhubanfang_caozuo : Form
    {
        private String identity = "";
        public zhubanfang_caozuo()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer.Start();

            kongbai_dataGridView.Visible = true;


            //先隐藏按钮
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;

            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;
        }

        #region 计时
        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region MenuStrip跳转
        private void 运动员ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //改标题
            name_toolStripLabel.Text = "查看运动员数据";
            identity = "运动员";

            //隐藏与显示
            yundongyuan_dataGridView.Visible = true;
            cansaidui_dataGridView.Visible = false;
            jiaolianyuan_dataGridView.Visible = false;
            xiangmu_dataGridView.Visible = false;
            kongbai_dataGridView.Visible = false;

            toolStripSeparator1.Visible = true;
            toolStripSeparator2.Visible = true;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;

            shaixuan_toolStripButton.Visible = true;
            shezhi_toolStripButton.Visible = true;
            add_toolStripButton.Visible = false;
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;

            //显示初始化
            String sql = "SELECT 运动员ID, 姓名, 性别, 学校, 入学时间, 毕业时间, 教练员ID, 生效标记" +
            " FROM 运动员注册表 ";
            Dao data = new Dao();
            yundongyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动员注册表");
        }

        private void 教练员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //改标题
            name_toolStripLabel.Text = "查看教练员数据";
            identity = "教练员";

            //隐藏与显示
            yundongyuan_dataGridView.Visible = false;
            cansaidui_dataGridView.Visible = false;
            jiaolianyuan_dataGridView.Visible = true;
            xiangmu_dataGridView.Visible = false;
            kongbai_dataGridView.Visible = false;

            toolStripSeparator1.Visible = true;
            toolStripSeparator2.Visible = true;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;

            shaixuan_toolStripButton.Visible = true;
            shezhi_toolStripButton.Visible = true;
            add_toolStripButton.Visible = false;
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;

            //显示初始化
            String sql = "SELECT 教练员ID, 姓名, 学校, 职称, 生效标记" +
            " FROM 教练员注册表 ";
            Dao data = new Dao();
            jiaolianyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
        }

        private void 参赛队ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //改标题
            name_toolStripLabel.Text = "查看参赛队数据";
            identity = "参赛队";

            //隐藏与显示
            yundongyuan_dataGridView.Visible = false;
            cansaidui_dataGridView.Visible = true;
            jiaolianyuan_dataGridView.Visible = false;
            xiangmu_dataGridView.Visible = false;
            kongbai_dataGridView.Visible = false;

            toolStripSeparator1.Visible = true;
            toolStripSeparator2.Visible = true;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;

            shaixuan_toolStripButton.Visible = true;
            shezhi_toolStripButton.Visible = true;
            add_toolStripButton.Visible = false;
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;

            //显示初始化
            String sql = "SELECT 参赛队ID, 参赛队全称,学校, 最小号码, 最大号码, 生效标记" +
            " FROM 参赛队信息表 WHERE 运动会ID = "+ Public_val.get_yundonghui() + ";";
            Dao data = new Dao();
            cansaidui_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "参赛队信息表");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //改标题
            name_toolStripLabel.Text = "修改运动会项目";
            identity = "项目";

            //隐藏与显示
            yundongyuan_dataGridView.Visible = false;
            cansaidui_dataGridView.Visible = false;
            jiaolianyuan_dataGridView.Visible = false;
            xiangmu_dataGridView.Visible = true;
            kongbai_dataGridView.Visible = false;

            toolStripSeparator1.Visible = true;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = true;
            toolStripSeparator5.Visible = true;

            shaixuan_toolStripButton.Visible = false;
            shezhi_toolStripButton.Visible = false;
            add_toolStripButton.Visible = true;
            delete_toolStripButton.Visible = true;
            change_toolStripButton.Visible = true;

            //显示初始化
            String sql = "SELECT 项目ID, 项目名称, 项目类型, 团体项目标记" +
            " FROM 项目信息表 WHERE 运动会ID = "+Public_val.get_yundonghui()+";";
            Dao data = new Dao();
            xiangmu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "项目信息表");
        }

        #endregion

        #region 查找按钮
        private void search_toolStripButton_Click(object sender, EventArgs e)
        {
            if (identity == "运动员")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 运动员ID, 姓名, 性别, 学校, 入学时间, 毕业时间, 教练员ID, 生效标记" +
                    " FROM 运动员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%' ;";
                Dao data = new Dao();
                yundongyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动员注册表");
            }
            else if (identity == "教练员")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 教练员ID, 姓名, 学校, 职称, 生效标记" +
                    " FROM 教练员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%' ;";
                Dao data = new Dao();
                jiaolianyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
            }
            else if (identity == "参赛队")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 参赛队ID, 参赛队全称,学校, 最小号码, 最大号码, 生效标记" +
                    " FROM 参赛队信息表 WHERE 参赛队全称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '"+Public_val.get_yundonghui()+"';";
                Dao data = new Dao();
                cansaidui_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "参赛队信息表");
            }
            else if (identity == "项目")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 项目ID , 项目名称, 项目类型, 团体项目标记" +
                    " FROM 项目信息表 WHERE 项目名称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "';";
                Dao data = new Dao();
                xiangmu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "项目信息表");
            }
        }

        #endregion

        #region 筛选按钮
        private void shaixuan_toolStripButton_Click(object sender, EventArgs e)
        {
            if (identity == "运动员")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 运动员ID, 姓名, 性别, 学校, 入学时间, 毕业时间, 教练员ID, 生效标记" +
                    " FROM 运动员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%' AND 生效标记 = 0;";
                Dao data = new Dao();
                yundongyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动员注册表");
            }
            else if (identity == "教练员")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 教练员ID, 姓名, 学校, 职称, 生效标记" +
                    " FROM 教练员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%' AND 生效标记 = 0;";
                Dao data = new Dao();
                jiaolianyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
            }
            else if (identity == "参赛队")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 参赛队ID, 参赛队全称, 学校 , 最小号码, 最大号码, 生效标记" +
                    " FROM 参赛队信息表 WHERE 参赛队全称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "'" +
                    "AND 生效标记 = 0 ;";
                Dao data = new Dao();
                cansaidui_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "参赛队信息表");
            }
        }

        #endregion

        #region 设置生效按钮
        private void shezhi_toolStripButton_Click(object sender, EventArgs e)
        {
            if (identity == "运动员")
            {
                DialogResult res = MessageBox.Show("确定使该条记录生效？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //如果确定更改
                if (res == DialogResult.OK)
                {
                    //执行删除操作
                    String yundongyuan_ID = yundongyuan_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                    String sql = "UPDATE 运动员注册表 SET 生效标记 =1 WHERE 运动员ID = '" + yundongyuan_ID + "'";
                    Dao data_update = new Dao();
                    int num = data_update.Excute(sql);
                    if (num > 0)
                    {
                        MessageBox.Show("激活成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //显示更改后表
                    String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                    sql = "SELECT 运动员ID, 姓名, 性别, 学校, 入学时间, 毕业时间, 教练员ID, 生效标记" +
                        " FROM 运动员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%';";
                    Dao data = new Dao();
                    yundongyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动员注册表");
                }
            }
            else if (identity == "教练员")
            {
                DialogResult res = MessageBox.Show("确定使该条记录生效？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //如果确定更改
                if (res == DialogResult.OK)
                {
                    //执行删除操作
                    String jiaolianyuan_ID = jiaolianyuan_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                    String sql = "UPDATE 教练员注册表 SET 生效标记 =1 WHERE 教练员ID = '" + jiaolianyuan_ID + "'";
                    Dao data_update = new Dao();
                    int num = data_update.Excute(sql);
                    if (num > 0)
                    {
                        MessageBox.Show("激活成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //显示更改后表
                    String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                    sql = "SELECT 教练员ID, 姓名, 学校, 职称, 生效标记" +
                        " FROM 教练员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%';";
                    Dao data = new Dao();
                    jiaolianyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
                }
            }
            else if (identity == "参赛队")
            {
                DialogResult res = MessageBox.Show("确定使该条记录生效？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //如果确定更改
                if (res == DialogResult.OK)
                {
                    //执行删除操作
                    String cansaidui_ID = cansaidui_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                    String sql = "UPDATE 参赛队信息表 SET 生效标记 =1 WHERE 参赛队ID = '" + cansaidui_ID + "'";
                    Dao data_update = new Dao();
                    int num = data_update.Excute(sql);
                    if (num > 0)
                    {
                        MessageBox.Show("激活成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //显示更改后表
                    String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                    sql = "SELECT 参赛队ID, 参赛队全称, 学校,最小号码, 最大号码, 生效标记" +
                        " FROM 参赛队信息表 WHERE 参赛队全称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "';";
                    Dao data = new Dao();
                    cansaidui_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "参赛队信息表");
                }
            }
        }
        #endregion

        #region 添加按钮
        private void add_toolStripButton_Click(object sender, EventArgs e)
        {
            xiangmu_Add add = new xiangmu_Add();
            this.Hide();
            add.ShowDialog();
            this.Show();

            //显示加入的数据
            String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
            String sql = "SELECT 项目ID , 项目名称, 项目类型, 团体项目标记" +
                " FROM 项目信息表 WHERE 项目名称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "';";
            Dao data = new Dao();
            xiangmu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "项目信息表");
        }
        #endregion

        #region 删除按钮
        private void delete_toolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确定要删除该条记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //如果确定删除
            if (res == DialogResult.OK)
            {
                //执行删除操作
                String xiangmu_ID = xiangmu_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                String sql = "DELETE FROM 项目信息表 WHERE 项目ID = '" + xiangmu_ID + "'";
                Dao data_delete = new Dao();
                int num = data_delete.Excute(sql);
                if (num > 0)
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //显示数据
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                sql = "SELECT 项目ID , 项目名称, 项目类型, 团体项目标记" +
                    " FROM 项目信息表 WHERE 项目名称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "';";
                Dao data = new Dao();
                xiangmu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "项目信息表");
            }
        }

        #endregion

        #region 更改按钮
        private void change_toolStripButton_Click(object sender, EventArgs e)
        {
            //更改使能
            Public_val.change_flag = true;
            Public_val.change_xuhao = xiangmu_dataGridView.SelectedRows[0].Cells[0].Value.ToString();

            //调用
            xiangmu_Add add = new xiangmu_Add();
            this.Hide();
            add.ShowDialog();
            this.Show();

            Public_val.change_flag = false;

            //显示加入的数据
            String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
            String sql = "SELECT 项目ID , 项目名称, 项目类型, 团体项目标记" +
                " FROM 项目信息表 WHERE 项目名称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "';";
            Dao data = new Dao();
            xiangmu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "项目信息表");

        }
        #endregion

        #region 主页按钮
        private void home_toolStripButton_Click(object sender, EventArgs e)
        {
            Public_val.home_flag = true;
            this.Close();
        }
        #endregion
    }
}
