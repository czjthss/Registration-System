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
    public partial class cansaidui_Add : Form
    {
        public cansaidui_Add()
        {
            InitializeComponent();

            //如果是更改
            if (Public_val.change_flag == true)
            {
                biaoti.Text = " 更改参赛队";
                xuhao_textBox.Text = Public_val.change_xuhao;
            }
        }

        #region 清空按钮
        private void qingkong_button_Click(object sender, EventArgs e)
        {
            xuhao_textBox.Text = "";
            mingcheng_textBox.Text = "";
            min_textBox.Text = "";
            max_textBox.Text = "";
        }

        #endregion

        #region 确定按钮
        private void queding_button_Click(object sender, EventArgs e)
        {
            if (login())
            {
                if(Public_val.change_flag == false)
                {
                    MessageBox.Show("添加参赛队数据成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            String max = max_textBox.Text.Trim();
            String min = min_textBox.Text.Trim();

            //返回填写不完整提醒
            if (xuhao == "" || mingcheng == "" || max == "" || min == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            //如果无法转换为数字，用try catch 实现报错
            try
            {
                int max_num = Convert.ToInt32(max);
                int min_num = Convert.ToInt32(min);
                //如果结束时间早于开始时间
                if ( min_num > max_num )
                {
                    MessageBox.Show("最小号码大于最大号码，请修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //如果数字号码簿范围不是四位
                if (min_num < 0 || min_num > 9999 || max_num < 0 || max_num > 9999)
                {
                    MessageBox.Show("输入号码格式错误! ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("输入号码格式错误! ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                sql = "UPDATE 参赛队信息表 SET 参赛队全称 = '" + mingcheng + "' ,最小号码 = '" + min + "',最大号码 = '" + max +
                    "' WHERE 参赛队ID = '" + xuhao + "'";
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
            sql = "SELECT * FROM 参赛队信息表 WHERE 参赛队ID='" + xuhao + "'";//SQL查询语句

            SqlDataReader information = new Dao().Read(sql); //创建读数据库对象

            if (information.HasRows)
            {
                MessageBox.Show("该账号名已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sql = "INSERT INTO 参赛队信息表 VALUES ('" + xuhao + "','" + Public_val.get_yundonghui() + "','"+Public_val.get_xuexiao() + "','" + mingcheng + "','"
                    + min + "','" + max + "',0);";//SQL插入数据语句

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
