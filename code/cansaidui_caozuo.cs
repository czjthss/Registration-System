using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Registration_System
{
    public partial class cansaidui_caozuo : Form
    {
        private String identity = "";

        //datatable全局
        DataTable dt1;
        DataTable dt2;
        public cansaidui_caozuo()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer.Start();

            //隐藏
            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;

            add_toolStripButton.Visible = false;
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;
            baocun_toolStripButton.Visible = false;
        }
        #region 计时
        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region Menustrip跳转
        private void 运动员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //改标题
            name_toolStripLabel.Text = "查看运动员数据";
            identity = "运动员";

            //隐藏与显示
            yundongyuan_dataGridView.Visible = true;
            cansaidui_splitContainer.Visible = false;
            jiaolianyuan_dataGridView.Visible = false;
            xiangmu_dataGridView.Visible = false;
            kongbai_dataGridView.Visible = false;

            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;

            add_toolStripButton.Visible = false;
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;
            baocun_toolStripButton.Visible = false;

            //显示初始化
            String sql = "SELECT 运动员ID, 姓名 , 性别, 入学时间, 毕业时间, 教练员ID" +
            " FROM 运动员注册表 WHERE 学校 = '"+Public_val.get_xuexiao()+"' AND 生效标记 = 1";
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
            cansaidui_splitContainer.Visible = false;
            jiaolianyuan_dataGridView.Visible = true;
            xiangmu_dataGridView.Visible = false;
            kongbai_dataGridView.Visible = false;

            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;

            add_toolStripButton.Visible = false;
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;
            baocun_toolStripButton.Visible = false;

            //显示初始化
            String sql = "SELECT 教练员ID, 姓名, 职称" +
            " FROM 教练员注册表 WHERE 学校 = '" + Public_val.get_xuexiao() + "' AND 生效标记 = 1";
            Dao data = new Dao();
            jiaolianyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
        }

        private void 参赛队ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //改标题
            name_toolStripLabel.Text = "查看项目数据";
            identity = "项目";

            //隐藏与显示
            yundongyuan_dataGridView.Visible = false;
            cansaidui_splitContainer.Visible = false;
            jiaolianyuan_dataGridView.Visible = false;
            xiangmu_dataGridView.Visible = true;
            kongbai_dataGridView.Visible = false;

            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;

            add_toolStripButton.Visible = false;
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;
            baocun_toolStripButton.Visible = false;

            //显示初始化
            String sql = "SELECT 项目ID, 项目名称, 项目类型, 团体项目标记" +
            " FROM 项目信息表 WHERE 运动会ID = '" + Public_val.get_yundonghui() + "';";
            Dao data = new Dao();
            xiangmu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "项目信息表");
        }

        private void cansaidui_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            //改标题
            name_toolStripLabel.Text = "参赛队组建";
            identity = "参赛队";

            //隐藏与显示
            yundongyuan_dataGridView.Visible = false;
            cansaidui_splitContainer.Visible = true;
            jiaolianyuan_dataGridView.Visible = false;
            xiangmu_dataGridView.Visible = false;
            kongbai_dataGridView.Visible = false;

            toolStripSeparator1.Visible = true;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;

            add_toolStripButton.Visible = true;
            delete_toolStripButton.Visible = false;
            change_toolStripButton.Visible = false;
            baocun_toolStripButton.Visible = false;

            //显示初始化
            String sql = "SELECT 参赛队ID, 参赛队全称, 最小号码, 最大号码, 生效标记" +
            " FROM 参赛队信息表 WHERE 运动会ID = '" + Public_val.get_yundonghui() + "' AND 学校 = '"+Public_val.get_xuexiao()+"';";
            Dao data_1 = new Dao();
            cansaidui_dataGridView.DataSource = data_1.SqlDataGridView_Show(sql, "参赛队信息表");
        }
        #endregion

        #region 界面级联
        private void cansaidui_dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String team="";
            //当前选中队伍

            team = cansaidui_dataGridView.SelectedRows[0].Cells[0].Value.ToString();

            if (team == "") team = "1";

            //加载并连接数据表
            String sql = "SELECT 运动员ID, 号码, 报名项目一, 报名项目二" +
            " FROM 运动员信息表 WHERE 参赛队ID = '" + team + "';";
            Dao data_2 = new Dao();
            dt1 = data_2.SqlDataGridView_Show(sql, "报名运动员信息表");
            yundongyuan_cansai_dataGridView.DataSource = dt1;

            sql = "SELECT 教练员ID" +
            " FROM 教练员信息表 WHERE 参赛队ID = '" + team + "';";
            Dao data_3 = new Dao();
            dt2 = data_3.SqlDataGridView_Show(sql, "报名教练员信息表");
            jiaolianyuan_cansai_dataGridView.DataSource = dt2;

            toolStripSeparator2.Visible = true;
            delete_toolStripButton.Visible = true;
            toolStripSeparator3.Visible = true;
            change_toolStripButton.Visible = true;
            toolStripSeparator4.Visible = true;
            baocun_toolStripButton.Visible = true;
        }
        #endregion

        #region 查询按钮
        private void search_toolStripButton_Click(object sender, EventArgs e)
        {
            if (identity == "运动员")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 运动员ID, 姓名, 性别, 入学时间, 毕业时间, 教练员ID " +
                    " FROM 运动员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%' AND 学校 = '" + Public_val.get_xuexiao() + "';";
                Dao data = new Dao();
                yundongyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "运动员注册表");
            }
            else if (identity == "教练员")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 教练员ID, 姓名, 职称 " +
                    " FROM 教练员注册表 WHERE 姓名 LIKE '%" + yundongyuanname + "%' AND 学校 = '"+Public_val.get_xuexiao()+"';";
                Dao data = new Dao();
                jiaolianyuan_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "教练员注册表");
            }
            else if (identity == "项目")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 项目ID , 项目名称, 项目类型, 团体项目标记" +
                    " FROM 项目信息表 WHERE 项目名称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "' ;";
                Dao data = new Dao();
                xiangmu_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "项目信息表");
            }
            else if (identity == "参赛队")
            {
                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                String sql = "SELECT 参赛队ID, 参赛队全称, 最小号码, 最大号码, 生效标记" +
                    " FROM 参赛队信息表 WHERE 参赛队全称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "' AND 学校 = '" + Public_val.get_xuexiao() + "' ;";
                Dao data = new Dao();
                cansaidui_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "参赛队信息表");
            }
        }

        #endregion

        #region 添加按钮(仅对参赛队)
        private void add_toolStripButton_Click(object sender, EventArgs e)
        {
            cansaidui_Add add = new cansaidui_Add();
            this.Hide();
            add.ShowDialog();
            this.Show();

            String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
            //显示加入的数据
            String sql = "SELECT 参赛队ID, 参赛队全称, 最小号码, 最大号码, 生效标记" +
                    " FROM 参赛队信息表 WHERE 参赛队全称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "' AND 学校 = '" + Public_val.get_xuexiao() + "' ;";
            Dao data = new Dao();
            cansaidui_dataGridView.DataSource = data.SqlDataGridView_Show(sql, "参赛队信息表");
        }

        #endregion

        #region 删除按钮(仅对参赛队)
        private void delete_toolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("确定要删除该条记录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //如果确定删除
            if (res == DialogResult.OK)
            {
                //执行删除操作
                String cansaidui_ID = cansaidui_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                String sql = "DELETE FROM 参赛队信息表 WHERE 参赛队ID = '" + cansaidui_ID + "'";
                Dao data_delete = new Dao();
                int num = data_delete.Excute(sql);
                if (num > 0)
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
                //查看删除后的表
                sql = "SELECT 参赛队ID, 参赛队全称, 最小号码, 最大号码, 生效标记" +
                    " FROM 参赛队信息表 WHERE 参赛队全称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "' AND 学校 = '" + Public_val.get_xuexiao() + "' ;"; 
                //sql = "SELECT * FROM 运动员注册表;";
                Dao data_delete_show = new Dao();
                cansaidui_dataGridView.DataSource = data_delete_show.SqlDataGridView_Show(sql, "参赛队信息表");
            }
        }
        #endregion

        #region 更改按钮(仅对参赛队)
        private void change_toolStripButton_Click(object sender, EventArgs e)
        {
            //更改使能
            Public_val.change_flag = true;
            Public_val.change_xuhao = cansaidui_dataGridView.SelectedRows[0].Cells[0].Value.ToString();

            //调用
            cansaidui_Add add = new cansaidui_Add();
            this.Hide();
            add.ShowDialog();
            this.Show();

            Public_val.change_flag = false;

            String yundongyuanname = name_input_toolStripTextBox.Text.Trim();
            //查看删除后的表
            String sql = "SELECT 参赛队ID, 参赛队全称, 最小号码, 最大号码, 生效标记" +
                " FROM 参赛队信息表 WHERE 参赛队全称 LIKE '%" + yundongyuanname + "%' AND 运动会ID = '" + Public_val.get_yundonghui() + "' AND 学校 = '" + Public_val.get_xuexiao() + "' ;";
            Dao data_delete_show = new Dao();
            cansaidui_dataGridView.DataSource = data_delete_show.SqlDataGridView_Show(sql, "参赛队信息表");
        }
        #endregion

        #region 保存操作(直接在表上改运动员和教练员[重难点])
        private void baocun_toolStripButton_Click(object sender, EventArgs e)
        {
            String sql="";
            //当前选中队伍
            String team = cansaidui_dataGridView.SelectedRows[0].Cells[0].Value.ToString();
            if (team == "") team = "1";

            //判断增删改,先运动员表

            //加载更改
            DataTable yundongyuan_change = dt1.GetChanges();
            //利用循环读取行

            //如果有更改
            if (yundongyuan_change != null)
            {
                //计数
                int add = 0, delete = 0, modify = 0;
                //循环判断
                foreach (DataRow dr in yundongyuan_change.Rows)
                {
                    //判断每一行是什么操作
                    if (dr.RowState == System.Data.DataRowState.Added)
                    {
                        //填写不完整错误

                        if(dr["运动员ID"].ToString()==""|| dr["号码"].ToString()==""|| dr["报名项目一"].ToString()==""|| dr["报名项目二"].ToString() == "")
                        {
                            MessageBox.Show("填写不完整", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        //主键错误（不在学校或者重复）

                        #region 编号检查存储过程
                        SqlDataAdapter da = new Dao().SqlProcedure("check_ID_yundongyuan");
                        //1.如果传入了存储过程，必须告诉服务器按存储过程进行处理，否则就会按sql语句进行处理
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //2.创建存储过程中所需要的参数，注意：名称必须与存储过程的参数名称对应
                        SqlParameter[] ps_xuhao = {
                                 new SqlParameter("@运动员ID",dr["运动员ID"].ToString()),
                                 new SqlParameter("@参赛队ID",team),
                                 new SqlParameter("@学校",Public_val.get_xuexiao()),
                                 new SqlParameter("@result",SqlDbType.Int)
                        };
                        ps_xuhao[3].Direction = ParameterDirection.ReturnValue;
                        //3.将参数传递给服务器使用
                        da.SelectCommand.Parameters.AddRange(ps_xuhao);
                        DataTable dt_xuhao = new DataTable();
                        da.Fill(dt_xuhao);
                        if (ps_xuhao[3].Value.ToString() == "0")
                        {
                            MessageBox.Show("运动员重复报名或没有此注册运动员信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        #endregion


                        //号码不在范围错误，重复错误

                        #region 查号码存储过程
                        da = new Dao().SqlProcedure("check_haoma");
                        //1.如果传入了存储过程，必须告诉服务器按存储过程进行处理，否则就会按sql语句进行处理
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //2.创建存储过程中所需要的参数，注意：名称必须与存储过程的参数名称对应
                        SqlParameter[] ps = {
                                 new SqlParameter("@号码",dr["号码"].ToString()),//Text获取显示在下拉列表控件中的文本值
                                 new SqlParameter("@参赛队ID",team),
                                 new SqlParameter("@result",SqlDbType.Int)
                        };
                        ps[2].Direction = ParameterDirection.ReturnValue;
                        //3.将参数传递给服务器使用
                        da.SelectCommand.Parameters.AddRange(ps);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (ps[2].Value.ToString() == "0")
                        {
                            MessageBox.Show("同参赛队号码存在重复", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        #endregion

                        //报名项目:在项目表中

                        #region 查项目存储过程
                        da = new Dao().SqlProcedure("check_xiangmu");
                        //1.如果传入了存储过程，必须告诉服务器按存储过程进行处理，否则就会按sql语句进行处理
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //2.创建存储过程中所需要的参数，注意：名称必须与存储过程的参数名称对应
                        SqlParameter[] ps_xiangmu = {
                                 new SqlParameter("@项目ID1",dr["报名项目一"].ToString()),
                                 new SqlParameter("@项目ID2",dr["报名项目二"].ToString()),
                                 new SqlParameter("@运动会ID",Public_val.get_yundonghui()),
                                 new SqlParameter("@result",SqlDbType.Int)
                        };
                        ps_xiangmu[3].Direction = ParameterDirection.ReturnValue;
                        //3.将参数传递给服务器使用
                        da.SelectCommand.Parameters.AddRange(ps_xiangmu);
                        DataTable dt_xiangmu = new DataTable();
                        da.Fill(dt_xiangmu);
                        if (ps_xiangmu[3].Value.ToString() == "0")
                        {
                            MessageBox.Show("项目不在项目表中，请检查！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        #endregion

                        //sql语句
                        sql = "INSERT INTO 运动员信息表 VALUES ('" + dr["运动员ID"].ToString() + "' , '" + team + "' , '" + dr["号码"].ToString() + "' , '" + dr["报名项目一"].ToString() + "' , '" + dr["报名项目二"].ToString() + "' );";
                        //计数
                        add++;
                    }
                    else if (dr.RowState == System.Data.DataRowState.Deleted)
                    {
                        //sql语句
                        sql = "DELETE 运动员信息表 WHERE 运动员ID = '" + dr["运动员ID",DataRowVersion.Original].ToString() + "' ; ";
                        //计数
                        delete++;
                    }
                    else if (dr.RowState == System.Data.DataRowState.Modified)
                    {
                        //填写不完整错误

                        if (dr["运动员ID"].ToString() == "" || dr["号码"].ToString() == "" || dr["报名项目一"].ToString() == "" || dr["报名项目二"].ToString() == "")
                        {
                            MessageBox.Show("填写不完整", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        //禁止修改主键
                        if (dr["运动员ID"].ToString() != dr["运动员ID", DataRowVersion.Original].ToString())
                        {
                            MessageBox.Show("禁止修改运动员编号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        //号码不在范围错误+重复错误

                        #region 查号码存储过程
                        SqlDataAdapter da = new Dao().SqlProcedure("check_haoma");
                        //1.如果传入了存储过程，必须告诉服务器按存储过程进行处理，否则就会按sql语句进行处理
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //2.创建存储过程中所需要的参数，注意：名称必须与存储过程的参数名称对应
                        SqlParameter[] ps = {
                                 new SqlParameter("@号码",dr["号码"].ToString()),//Text获取显示在下拉列表控件中的文本值
                                 new SqlParameter("@参赛队ID",team),
                                 new SqlParameter("@result",SqlDbType.Int)
                        };
                        ps[2].Direction = ParameterDirection.ReturnValue;
                        //3.将参数传递给服务器使用
                        da.SelectCommand.Parameters.AddRange(ps);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (ps[2].Value.ToString() == "0")
                        {
                            MessageBox.Show("同参赛队号码存在重复", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        #endregion

                        //报名项目重复问题当作我自己写了
                        //报名项目：必须在项目表内

                        #region 查项目存储过程
                        da = new Dao().SqlProcedure("check_xiangmu");
                        //1.如果传入了存储过程，必须告诉服务器按存储过程进行处理，否则就会按sql语句进行处理
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //2.创建存储过程中所需要的参数，注意：名称必须与存储过程的参数名称对应
                        SqlParameter[] ps_xiangmu = {
                                 new SqlParameter("@项目ID1",dr["报名项目一"].ToString()),
                                 new SqlParameter("@项目ID2",dr["报名项目二"].ToString()),
                                 new SqlParameter("@运动会ID",Public_val.get_yundonghui()),
                                 new SqlParameter("@result",SqlDbType.Int)
                        };
                        ps_xiangmu[3].Direction = ParameterDirection.ReturnValue;
                        //3.将参数传递给服务器使用
                        da.SelectCommand.Parameters.AddRange(ps_xiangmu);
                        DataTable dt_xiangmu = new DataTable();
                        da.Fill(dt_xiangmu);
                        if (ps_xiangmu[3].Value.ToString() == "0")
                        {
                            MessageBox.Show("项目不在项目表中，请检查！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        #endregion

                        sql = "UPDATE 运动员信息表 SET 号码 = '"+ dr["号码"].ToString() + "', 报名项目一 = '"+ dr["报名项目一"].ToString() + "',报名项目二 = '"+ dr["报名项目二"].ToString() + "' WHERE 运动员ID = '" + dr["运动员ID"].ToString() + "' ; ";
                        //计数
                        modify++;
                    }

                    //开始操作
                    Dao data_caozuo = new Dao();
                    data_caozuo.Excute(sql);
                }
                //操作

                //查看操作后的表,并重新连接
                //如果没改，不用更新
                if(add==0&&delete==0&&modify==0) MessageBox.Show("运动员表未进行更改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("运动员表更改成功\n共增加" + add + "条记录\n共删除" + delete + "条记录\n共修改" + modify + "条记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "SELECT 运动员ID, 号码, 报名项目一, 报名项目二" +
                        " FROM 运动员信息表 WHERE 参赛队ID = '" + team + "' ;";
                    Dao data_show = new Dao();
                    dt1 = data_show.SqlDataGridView_Show(sql, "运动员信息表");
                    yundongyuan_cansai_dataGridView.DataSource = dt1;
                }
            }
            else
            {
                MessageBox.Show("运动员表未进行更改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

            //后教练员表

            //加载更改
            DataTable jiaolianyuan_change = dt2.GetChanges();

            if (jiaolianyuan_change != null)
            {
                //计数
                int add = 0, delete = 0;
                //利用循环读取行
                foreach (DataRow dr in jiaolianyuan_change.Rows)
                {
                    //判断每一行是什么操作
                    if (dr.RowState == System.Data.DataRowState.Added)
                    {
                        //主键错误（不在学校或者重复）

                        #region 编号检查存储过程
                        SqlDataAdapter da = new Dao().SqlProcedure("check_ID_jiaolianyuan");
                        //1.如果传入了存储过程，必须告诉服务器按存储过程进行处理，否则就会按sql语句进行处理
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //2.创建存储过程中所需要的参数，注意：名称必须与存储过程的参数名称对应
                        SqlParameter[] ps_xuhao = {
                                 new SqlParameter("@教练员ID",dr["教练员ID"].ToString()),
                                 new SqlParameter("@参赛队ID",team),
                                 new SqlParameter("@学校",Public_val.get_xuexiao()),
                                 new SqlParameter("@result",SqlDbType.Int)
                        };
                        ps_xuhao[3].Direction = ParameterDirection.ReturnValue;
                        //3.将参数传递给服务器使用
                        da.SelectCommand.Parameters.AddRange(ps_xuhao);
                        DataTable dt_xuhao = new DataTable();
                        da.Fill(dt_xuhao);
                        if (ps_xuhao[3].Value.ToString() == "0")
                        {
                            MessageBox.Show("教练员重复报名或没有此注册教练员信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                        #endregion

                        //sql语句
                        sql = "INSERT INTO 教练员信息表 VALUES ('" + dr["教练员ID"].ToString() + "' , '" + team + "' );";
                        //计数
                        add++;
                    }
                    else if (dr.RowState == System.Data.DataRowState.Deleted)
                    {
                        //sql语句
                        sql = "DELETE 教练员信息表 WHERE 教练员ID = '" + dr["教练员ID", DataRowVersion.Original].ToString() + "' ; ";
                        //计数
                        delete++;
                    }
                    else if (dr.RowState == System.Data.DataRowState.Modified)
                    {
                        //不允许更改
                        MessageBox.Show("禁止修改教练员编号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    //开始操作
                    Dao data_caozuo = new Dao();
                    data_caozuo.Excute(sql);
                }

                //查看操作后的表,并重新连接
                //如果没改，不用更新
                if (add == 0 && delete == 0) MessageBox.Show("教练员表未进行更改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    //查看操作后的表,并重新连接
                    MessageBox.Show("教练员表更改成功\n共增加" + add + "条记录\n共删除" + delete + "条记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sql = "SELECT 教练员ID" +
                        " FROM 教练员信息表 WHERE 参赛队ID = '" + team + "' ;";
                    Dao data_show = new Dao();
                    dt2 = data_show.SqlDataGridView_Show(sql, "教练员信息表");
                    jiaolianyuan_cansai_dataGridView.DataSource = dt2;
                }
            }
            else
            {
                MessageBox.Show("教练员表未进行更改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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