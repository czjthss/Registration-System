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
    public partial class Sports_Meetings_Add : Form
    {
        public Sports_Meetings_Add()
        {
            InitializeComponent();

            //防止图片闪烁
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        #region 确定按钮
        private void queding_button_Click(object sender, EventArgs e)
        {
            if (login())
            {
                MessageBox.Show("添加运动会数据成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool login()
        {
            //从输入栏取出信息
            String xuhao = xuhao_textBox.Text.Trim(); 
            String mingcheng = mingchen_textBox.Text.Trim();
            String zhuban = zhuban_textBox.Text.Trim();
            String chengban = chengban_textBox.Text.Trim();
            String didian = didian_textBox.Text.Trim();
            String start = start_shijian_textBox.Text.Trim();
            String end = end_shijian_textBox.Text.Trim();

            //返回填写不完整提醒
            if (xuhao == ""||mingcheng==""||zhuban==""||chengban==""||didian==""||start==""||end=="")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            //如果无法转换为日期，用try catch 实现报错
            try
            {
                //如果结束时间早于开始时间
                if (Convert.ToDateTime(start) > Convert.ToDateTime(end))
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
            sql = "SELECT * FROM 运动会信息表 WHERE 运动会ID='" + xuhao + "'";//SQL查询语句
                                                                    
            SqlDataReader information = new Dao().Read(sql); //创建读数据库对象

            if (information.HasRows)
            {
                MessageBox.Show("该账号名已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sql = "INSERT INTO 运动会信息表 VALUES ('" + xuhao + "','" + mingcheng + "','"
                    + zhuban + "','" + chengban + "','" + didian + "','" + start + "','" + end + "', 1 );";//SQL插入数据语句

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

        #region 清空按钮

        #endregion

        private void qingkong_button_Click(object sender, EventArgs e)
        {
            xuhao_textBox.Text = "";
            mingchen_textBox.Text = "";
            zhuban_textBox.Text = "";
            chengban_textBox.Text = "";
            didian_textBox.Text = "";
            start_shijian_textBox.Text = "";
            end_shijian_textBox.Text = "";
        }
    }
}
