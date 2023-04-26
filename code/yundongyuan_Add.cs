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
    public partial class yundongyuan_Add : Form
    {
        public yundongyuan_Add()
        {
            InitializeComponent();
        }


        #region 清空按钮
        private void qingkong_button_Click(object sender, EventArgs e)
        {
            xuhao_textBox.Text = "";
            xingming_textBox.Text = "";
            xingbie_textBox.Text = "";
            xuexiao_textBox.Text = "";
            ruxue_textBox.Text = "";
            biye_textBox.Text = "";
            jiaolian_textBox.Text = "";
        }
        #endregion

        #region 确定按钮
        private void queding_button_Click(object sender, EventArgs e)
        {
            if (login())
            {
                MessageBox.Show("添加运动员数据成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private bool login()
        {
            //从输入栏取出信息
            String xuhao = xuhao_textBox.Text.Trim();
            String xingming = xingming_textBox.Text.Trim();
            String xingbie = xingbie_textBox.Text.Trim();
            String xuexiao = xuexiao_textBox.Text.Trim();
            String ruxue = ruxue_textBox.Text.Trim();
            String biye = biye_textBox.Text.Trim();
            String jiaolian = jiaolian_textBox.Text.Trim();

            //返回填写不完整提醒
            if (xuhao == "" || xingming == "" || xingbie == "" || xuexiao == "" || ruxue == "" || biye == "" || jiaolian == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            //如果无法转换为日期，用try catch 实现报错
            try
            {
                //如果结束时间早于开始时间
                if (Convert.ToDateTime(ruxue) > Convert.ToDateTime(biye))
                {
                    MessageBox.Show("结束日期早于开始日期，请修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("输入日期格式错误! ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            String sql;
            //检查用户名是否已经被注册
            sql = "SELECT * FROM 运动员注册表 WHERE 运动员ID='" + xuhao + "'";//SQL查询语句

            SqlDataReader information = new Dao().Read(sql); //创建读数据库对象

            if (information.HasRows)
            {
                MessageBox.Show("该账号名已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sql = "INSERT INTO 运动员注册表 VALUES ('" + xuhao + "','" + Public_val.get_zhanghao() + "','" + xingming + "','"
                    + xingbie + "','" + xuexiao + "','" + ruxue + "','" + biye + "','" + jiaolian + "',0);";//SQL插入数据语句

            Dao data_excute = new Dao();

            //插入用户信息

            int num = data_excute.Excute(sql);
            //返回信息值
            if (num == 1)
                return true;
            else
                return false;
        }
        #endregion
    }
}
