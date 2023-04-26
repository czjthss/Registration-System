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
    public partial class jiaolianyuan_Add : Form
    {
        public jiaolianyuan_Add()
        {
            InitializeComponent();
        }

        #region 清空按钮
        private void qingkong_button_Click(object sender, EventArgs e)
        {
            xuhao_textBox.Text = "";
            xingming_textBox.Text = "";
            zhicheng_textBox.Text = "";
            xuexiao_textBox.Text = "";
        }
        #endregion

        #region 确定按钮
        private void queding_button_Click(object sender, EventArgs e)
        {
            if (login())
            {
                MessageBox.Show("添加教练员数据成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private bool login()
        {
            //从输入栏取出信息
            String xuhao = xuhao_textBox.Text.Trim();
            String xingming = xingming_textBox.Text.Trim();
            String zhicheng = zhicheng_textBox.Text.Trim();
            String xuexiao = xuexiao_textBox.Text.Trim();

            //返回填写不完整提醒
            if (xuhao == "" || xingming == "" || zhicheng == "" || xuexiao == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            String sql;
            //检查用户名是否已经被注册
            sql = "SELECT * FROM 教练员注册表 WHERE 教练员ID='" + xuhao + "'";//SQL查询语句

            SqlDataReader information = new Dao().Read(sql); //创建读数据库对象

            if (information.HasRows)
            {
                MessageBox.Show("该账号名已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sql = "INSERT INTO 教练员注册表 VALUES ('" + xuhao + "','" + Public_val.get_zhanghao() + "','" + xingming + "','"
                     + xuexiao + "','"  +  zhicheng + "',0);";//SQL插入数据语句

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
