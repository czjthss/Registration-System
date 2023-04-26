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
    public partial class Register : Form
    {
        public Register()
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
            mima_textbox.Text = " 请输入登录密码";
            mima_textbox.ForeColor = Color.Gray;
            mima_textbox2.Text = " 请再次输入登录密码";
            mima_textbox2.ForeColor = Color.Gray;
            quanxian_combobox.SelectedIndex = 0;
            quanxian_combobox.ForeColor = Color.Gray;

            //权限管理不显示
            guanliyuan_textbox.Visible=false;
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
                mima_textbox.Text = " 请输入登录密码";
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
                mima_textbox2.Text = " 请再次输入登录密码";
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
                if (quanxian_combobox.Text == "参赛队管理员" ||
                    quanxian_combobox.Text == "主办方管理员") 
                {
                    guanliyuan_textbox.Visible = true;
                    if (quanxian_combobox.Text == "参赛队管理员")
                    {
                        guanliyuan_textbox.Text = " 请输入参赛队管理员验证码";
                    }
                    else if (quanxian_combobox.Text == "主办方管理员")
                    {
                        guanliyuan_textbox.Text = " 请输入主办方管理员验证码";
                    }
                    guanliyuan_textbox.ForeColor = Color.Gray;
                }
                else
                {
                    guanliyuan_textbox.Visible = false;
                }
            }
        }

        //管理员验证码输入
        Boolean textboxHasText_guanliyuan = false;//判断输入框是否有文本
        private void guanliyuan_textbox_MouseEnter(object sender, EventArgs e)
        {
            if (textboxHasText_guanliyuan == false)
                guanliyuan_textbox.Text = "";

            guanliyuan_textbox.ForeColor = Color.Black;
        }

        private void guanliyuan_textbox_MouseLeave(object sender, EventArgs e)
        {
            if (guanliyuan_textbox.Text == "")
            {
                if (quanxian_combobox.Text == "参赛队管理员")
                {
                    guanliyuan_textbox.Text = " 请输入参赛队管理员验证码";
                }
                else if(quanxian_combobox.Text == "主办方管理员")
                {
                    guanliyuan_textbox.Text = " 请输入主办方管理员验证码";
                }
                guanliyuan_textbox.ForeColor = Color.Gray;
                textboxHasText_guanliyuan = false;
            }
            else
                textboxHasText_guanliyuan = true;
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
            guanliyuan_textbox.Text = "";
            guanliyuan_textbox.ForeColor = Color.Gray;
        }
        #endregion

        #region 注册按钮，调用数据库
        private void zhuce_Click(object sender, EventArgs e)
        {
            if (login())
            {
                MessageBox.Show("注册成功", "欢迎您，新用户！", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            String guanliyuan = guanliyuan_textbox.Text.Trim();//取出管理员验证码

            //返回填写不完整提醒
            if (identity == "——请选择您的身份——")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //若为运动员或教练员
            else if (identity == "运动员" || identity == "教练员")
            {
                if (username == "" || password == "" || password_2 == ""||
                    username == "请输入您所要创建的账号" || password == "请输入登录密码" || password_2 == "请再次输入登录密码")
                {
                    MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //两次密码必须相同
                if (password != password_2)
                {
                    MessageBox.Show("两次输入的密码必须相同！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                Dao data_read = new Dao();
                //检查用户名是否已经被注册
                String sql = "SELECT * FROM " + identity + "登录表 WHERE " + identity + "账号='" + username + "'";//SQL查询语句
                //创建读数据库对象
                SqlDataReader information = data_read.Read(sql);

                if (information.HasRows)
                {
                    MessageBox.Show("该账号名已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Dao data_excute = new Dao();

                //插入用户信息

                sql = "INSERT INTO "+identity+"登录表 VALUES ('"+username+"','"+password+"');";//SQL插入数据语句
                int num = data_excute.Excute(sql);

                //返回信息值
                if (num == 1)
                    return true;
                else
                    return false;
            }
            //若为管理员
            else
            {
                if (username == "" || password == "" || password_2 == "" || guanliyuan == "" ||
                    username == "请输入您所要创建的账号" || password == "请输入登录密码" || password_2 == "请再次输入登录密码"||
                    guanliyuan== "请输入参赛队管理员验证码" ||guanliyuan== "请输入主办方管理员验证码")
                {
                    MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //两次密码必须相同
                if (password != password_2)
                {
                    MessageBox.Show("两次输入的密码必须相同！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (identity == "参赛队管理员")
                {
                    if (guanliyuan != "123")
                    {
                        MessageBox.Show("参赛队管理员验证码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else if (identity == "主办方管理员")
                {
                    if (guanliyuan != "abc")
                    {
                        MessageBox.Show("主办方管理员验证码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                Dao data_read = new Dao();
                //检查用户名是否已经被注册
                String sql = "SELECT * FROM " + identity + "登录表 WHERE " + identity + "账号='" + username + "'";//SQL查询语句
                //创建读数据库对象
                SqlDataReader information = data_read.Read(sql);

                if (information.HasRows)
                {
                    MessageBox.Show("该账号名已经存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Dao data_excute = new Dao();

                //插入用户信息

                sql = "INSERT INTO " + identity + "登录表 VALUES ('" + username + "','" + password + "');";//SQL插入数据语句
                int num = data_excute.Excute(sql);

                //返回信息值
                if (num == 1)
                    return true;
                else
                    return false;
            }
        }

        #endregion

    }
}
