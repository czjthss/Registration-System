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
    public partial class Form_first : Form
    {
        private String identity = "";
        private String username = "";
        public Form_first()
        {
            InitializeComponent();

            //防止图片闪烁
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲


            //默认显示
            zhanghao_textbox.Text = " 请输入账号";
            zhanghao_textbox.ForeColor = Color.LightGray;
            mima_textbox.Text = " 请输入密码";
            mima_textbox.ForeColor = Color.LightGray;
            quanxian_combobox.SelectedIndex = 0;
            quanxian_combobox.ForeColor = Color.LightGray;

            //获得窗体数据
            x = this.Width;//获取窗体的宽度
            y = this.Height;//获取窗体的高度
            setTag(this);//调用方法
        }

        #region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }
        private void Form_first_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
            //选中后位置不改变的bug
            if (quanxian_combobox.SelectedItem != null)
            {
                string people = quanxian_combobox.SelectedItem.ToString() + "登录";
                biaoti_label.Location = new Point(Convert.ToInt32(this.Width - people.Length * 10 * newx) / 2, Convert.ToInt32(newy * 30));
            }
        }

        #endregion

        #region Label显示Combobox中的内容

        private void quanxian_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (quanxian_combobox.Text != "——请选择身份——")
            {
            string people = quanxian_combobox.SelectedItem.ToString()+"登录";
            biaoti_label.Text = people;
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
            biaoti_label.Location = new Point(Convert.ToInt32(this.Width - people.Length * 10 * newx) / 2, Convert.ToInt32(newy * 30));
            }
        }

        #endregion

        #region 用户登录,调用数据库
        /// <summary>
        /// 登录按钮点击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void denglu_button_Click(object sender, EventArgs e)
        {
            if (login()) //查询结果存在
            {
                //为之后的窗口传值
                Public_val.set_zhanghao(username);

                //打开不同的窗口
                if(identity == "参赛队管理员")
                {
                    Sports_Meetings sports = new Sports_Meetings();
                    this.Hide();//隐藏登录的界面
                    sports.ShowDialog();
                    this.Show();
                }
                else if(identity == "主办方管理员")
                {
                    Sports_Meetings_zhuban sports = new Sports_Meetings_zhuban();
                    this.Hide();//隐藏登录的界面
                    sports.ShowDialog();
                    this.Show();
                }
                else if(identity == "运动员")
                {
                    yundongyuan_caozuo sports = new yundongyuan_caozuo();
                    this.Hide();//隐藏登录的界面
                    sports.ShowDialog();
                    this.Show();
                }
                else if(identity == "教练员")
                {
                    jiaolianyuan_caozuo sports = new jiaolianyuan_caozuo();
                    this.Hide();//隐藏登录的界面
                    sports.ShowDialog();
                    this.Show();
                }
            }
        }

        /// <summary>
        /// 查询函数
        /// </summary>
        /// <returns>返回查询是否成功</returns>
        private bool login()
        {
            //从输入栏取出信息
            username = zhanghao_textbox.Text.Trim(); //取出用户名
            String password = mima_textbox.Text.Trim(); //取出密码
            identity = quanxian_combobox.Text.Trim();//取出用户身份

            //返回填写不完整提醒
            if (username == "请输入账号" || password == "请输入密码" || identity == "——请选择身份——")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                return false;
            }

            String sql = "SELECT * FROM " + identity + "登录表 WHERE "+identity+"账号='" + username + "'AND 密码='" + password +  "'";//SQL查询语句
            //创建读数据库对象
            Dao data = new Dao();
            //读取数据
            SqlDataReader information = data.Read(sql);

            //若登陆成功
            if (information.HasRows)
            {
                MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//设置弹出对话窗
                return true;
            }
            //若登陆失败
            else
            {
                MessageBox.Show("用户名或密码错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        #region TextBox默认显示文字，点击后消失

        Boolean textboxHasText_zhanghao = false;//判断输入框是否有文本

        //账号显示文字
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
                zhanghao_textbox.Text = " 请输入账号";
                zhanghao_textbox.ForeColor = Color.LightGray;
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
                mima_textbox.Text = " 请输入密码";
                mima_textbox.ForeColor = Color.LightGray;
                textboxHasText_mima = false;
            }
            else
                textboxHasText_mima = true;
        }

        private void quanxian_combobox_MouseLeave(object sender, EventArgs e)
        {
            if (quanxian_combobox.Text == "——请选择身份——")
            {
                quanxian_combobox.ForeColor = Color.LightGray;
            }
            else
            {
                quanxian_combobox.ForeColor = Color.Black;
            }
        }

        private void quanxian_combobox_MouseEnter(object sender, EventArgs e)
        {
            if (quanxian_combobox.Text == "——请选择身份——")
            {
                quanxian_combobox.ForeColor = Color.Black;
            }
        }

        #endregion

        #region 注册按钮
        private void zhuce_button_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.ShowDialog();
            this.Show();
        }
        #endregion

        #region 更改密码
        private void genggaimima_Click(object sender, EventArgs e)
        {
            genggaimima g = new genggaimima();
            this.Hide();
            g.ShowDialog();
            this.Show();
        }
        #endregion
    }
}
