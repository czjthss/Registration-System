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
    public partial class xiangmu_Add : Form
    {
        public xiangmu_Add()
        {
            InitializeComponent();

            //如果是更改
            if (Public_val.change_flag == true)
            {
                biaoti.Text = "  更改项目";
                xuhao_textBox.Text = Public_val.change_xuhao;
            }

        }

        #region 清空按钮
        private void qingkong_button_Click(object sender, EventArgs e)
        {
            xuhao_textBox.Text = "";
            mingcheng_textBox.Text = "";
            xiangmu_comboBox.Text = "";
            tuanti_comboBox.Text = "";
        }

        #endregion

        #region 确定按钮
        private void queding_button_Click(object sender, EventArgs e)
        {
            if (login())
            {
                if (Public_val.change_flag == false)
                {
                    MessageBox.Show("添加项目数据成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private bool login()
        {
            //从输入栏取出信息
            String xuhao = xuhao_textBox.Text.Trim();
            String mingcheng = mingcheng_textBox.Text.Trim();
            String xiangmu = xiangmu_comboBox.Text.Trim();
            String tuanti = tuanti_comboBox.Text.Trim();

            //将团体类型转化为1与0 
            if (tuanti == "是") tuanti = "1";
            else if (tuanti == "否") tuanti = "0";

            //返回填写不完整提醒
            if (xuhao == "" || mingcheng == "" || xiangmu == "" || tuanti == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            String sql;
            int num;

            #region 更改操作
            if (Public_val.change_flag == true)
            {
                //序号不可以更改
                if (xuhao != Public_val.change_xuhao)
                {
                    MessageBox.Show("序号不可以更改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //更改操作
                sql = "UPDATE 项目信息表 SET 项目名称 = '" + mingcheng + "' ,项目类型 = '"+xiangmu+"',团体项目标记 = '" + tuanti+
                    "' WHERE 项目ID = '" + xuhao + "'";
                Dao data_update = new Dao();
                num = data_update.Excute(sql);
                if (num > 0)
                {
                    MessageBox.Show("更改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            #endregion

            //检查用户名是否已经被注册
            sql = "SELECT * FROM 项目信息表 WHERE 项目ID='" + xuhao + "'";//SQL查询语句

            SqlDataReader information = new Dao().Read(sql); //创建读数据库对象

            if (information.HasRows)
            {
                MessageBox.Show("该项目序号已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sql = "INSERT INTO 项目信息表 VALUES ('" + xuhao + "','" + Public_val.get_yundonghui() + "','" + mingcheng + "','"
                    + xiangmu + "','" + tuanti + "');";//SQL插入数据语句

            Dao data_excute = new Dao();

            //插入用户信息

            num = data_excute.Excute(sql);
            //返回信息值
            if (num == 1)
                return true;
            else
                return false;
        }
        #endregion
    }
}
