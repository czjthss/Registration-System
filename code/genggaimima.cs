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
    public partial class genggaimima : Form
    {
        public genggaimima()
        {
            InitializeComponent();

            //防止图片闪烁
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            //将图片转换为圆形
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);

            //默认显示
            zhanghao_textbox.Text = " 请输入您所要创建的账号";
            zhanghao_textbox.ForeColor = Color.Gray;
            mima_textbox.Text = " 请输入原先登录密码";
            mima_textbox.ForeColor = Color.Gray;
            mima_textbox2.Text = " 请输入新的登录密码";
            mima_textbox2.ForeColor = Color.Gray;
            quanxian_combobox.SelectedIndex = 0;
            quanxian_combobox.ForeColor = Color.Gray;
        }

        #region TextBox默认显示文字，点击后消失

        //创建账号显示文字
        Boolean textboxHasText_zhanghao = false;//判断输入框是否有文本
        private void zhanghao_textbox_MouseEnter(object sender, EventArgs e)
        {
            if (textboxHasText_zhanghao == false)
                zhanghao_textbox.Text = "";

            zhanghao_textbox.ForeColor = Color.Black;
        }

        private void zhanghao_textbox_MouseLeave(object sender, EventArgs e)
        {
            if (zhanghao_textbox.Text == "")
            {
                zhanghao_textbox.Text = " 请输入您所要创建的账号";
                zhanghao_textbox.ForeColor = Color.Gray;
                textboxHasText_zhanghao = false;
            }
            else
                textboxHasText_zhanghao = true;
        }

        //密码显示文字

        Boolean textboxHasText_mima = false;//判断输入框是否有文本

        private void mima_textbox_MouseEnter(object sender, EventArgs e)
        {
            if (textboxHasText_mima == false)
                mima_textbox.Text = "";

            mima_textbox.ForeColor = Color.Black;
            mima_textbox.PasswordChar = '*';
        }

        private void mima_textbox_MouseLeave(object sender, EventArgs e)
        {
            if (mima_textbox.Text == "")
            {
                mima_textbox.PasswordChar = '\0';
                mima_textbox.Text = " 请输入原先登录密码";
                mima_textbox.ForeColor = Color.Gray;
                textboxHasText_mima = false;
            }
            else
                textboxHasText_mima = true;
        }

        //再次密码显示文字
        Boolean textboxHasText_mima2 = false;//判断输入框是否有文本
        private void mima_textbox2_MouseEnter(object sender, EventArgs e)
        {
            if (textboxHasText_mima2 == false)
                mima_textbox2.Text = "";

            mima_textbox2.ForeColor = Color.Black;
            mima_textbox2.PasswordChar = '*';
        }

        private void mima_textbox2_MouseLeave(object sender, EventArgs e)
        {
            if (mima_textbox2.Text == "")
            {
                mima_textbox2.PasswordChar = '\0';
                mima_textbox2.Text = " 请输入新的登录密码";
                mima_textbox2.ForeColor = Color.Gray;
                textboxHasText_mima2 = false;
            }
            else
                textboxHasText_mima2 = true;
        }
        //权限选择
        private void quanxian_combobox_MouseEnter(object sender, EventArgs e)
        {
            if(quanxian_combobox.Text== "——请选择您的身份——")
            {
                quanxian_combobox.ForeColor = Color.Black;
            }
        }
        private void quanxian_combobox_MouseLeave(object sender, EventArgs e)
        {
            if (quanxian_combobox.Text == "——请选择您的身份——")
            {
                quanxian_combobox.ForeColor = Color.Gray;
            }
            else
            {
                quanxian_combobox.ForeColor = Color.Black;
            }
        }
        #endregion

        #region 清空按钮
        private void qingkong_Click(object sender, EventArgs e)
        {
            zhanghao_textbox.Text = "";
            zhanghao_textbox.ForeColor = Color.Gray;
            mima_textbox.Text = "";
            mima_textbox.ForeColor = Color.Gray;
            mima_textbox2.Text = "";
            mima_textbox2.ForeColor = Color.Gray;
            quanxian_combobox.SelectedIndex = 0;
            quanxian_combobox.ForeColor = Color.Gray;
        }
        #endregion

        #region 更改按钮，调用数据库
        private void zhuce_Click(object sender, EventArgs e)
        {
            if (login())
            {
                MessageBox.Show("更改密码成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private  bool login()
        {
            //从输入栏取出信息
            String username = zhanghao_textbox.Text.Trim(); //取出用户名
            String password = mima_textbox.Text.Trim(); //取出密码
            String password_2 = mima_textbox2.Text.Trim(); //取出重复密码
            String identity = quanxian_combobox.Text.Trim();//取出用户身份

            //返回填写不完整提醒
            if (identity == "——请选择您的身份——")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Dao data_read = new Dao();
            //检查用户名是否已经被注册
            String sql = "SELECT * FROM " + identity + "登录表 WHERE " + identity + "账号='" + username + "';";//SQL查询语句
                                                                                                         //创建读数据库对象
            SqlDataReader information = data_read.Read(sql);

            if (information.HasRows == false)
            {
                MessageBox.Show("该账号名不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //检查输入是否完整
            if (username == "" || password == "" || password_2 == "" ||
                username == "请输入您所要创建的账号" || password == "请输入登录密码" || password_2 == "请再次输入登录密码")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //第一次密码必须和之前对应

            Dao data_mima = new Dao();

            sql = "SELECT * FROM " + identity + "登录表 WHERE " + identity + "账号='" + username + "' AND 密码 = '"+ password +"';";//SQL查询语句
                                                                                                         //创建读数据库对象
            SqlDataReader mima = data_mima.Read(sql);

            if (mima.HasRows == false)
            {
                MessageBox.Show("原密码输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //更改用户密码

            Dao data_excute = new Dao();

            sql = "UPDATE " + identity + "登录表 SET 密码 = '"+password_2+"' WHERE " + identity + "账号 = '" + username + "';";//SQL插入数据语句
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
