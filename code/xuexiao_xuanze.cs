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
    public partial class xuexiao_xuanze : Form
    {
        public xuexiao_xuanze()
        {
            InitializeComponent();
            //启动时即可获得时间
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer.Start();

            //防止图片闪烁
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            //获得窗体数据
            x = this.Width;//获取窗体的宽度
            y = this.Height;//获取窗体的高度
            setTag(this);//调用方法
        }

        /// <summary>
        /// 每1秒计时器跳转一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
        private void xuexiao_xuanze_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
        }

        #endregion

        #region 清空按钮
        private void qingkong_button_Click(object sender, EventArgs e)
        {
            mingcheng_textBox.Text = "";
            yanzhengma_textBox.Text = "";
        }
        #endregion

        #region 确定按钮
        private void queding_button_Click(object sender, EventArgs e)
        {
            if (yanzhengma_textBox.Text == "123456")
            {
                Public_val.set_xuexiao(mingcheng_textBox.Text);
                MessageBox.Show("您已选择" + mingcheng_textBox.Text +
                    ",正在进入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //打开参赛队管理界面
                cansaidui_caozuo cansaidui = new cansaidui_caozuo();
                this.Hide();
                cansaidui.ShowDialog();
                this.Show();
                //主页按钮
                if (Public_val.home_flag == true)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("验证码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
    }
}
