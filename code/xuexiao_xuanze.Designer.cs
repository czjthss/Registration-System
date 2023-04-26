
namespace Registration_System
{
    partial class xuexiao_xuanze
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xuexiao_xuanze));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.biaoti = new System.Windows.Forms.Label();
            this.mingchen_label = new System.Windows.Forms.Label();
            this.yanzhengma_textBox = new System.Windows.Forms.TextBox();
            this.xuhao_Label = new System.Windows.Forms.Label();
            this.mingcheng_textBox = new System.Windows.Forms.TextBox();
            this.qingkong_button = new System.Windows.Forms.Button();
            this.queding_button = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip.BackgroundImage")));
            this.statusStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip.Location = new System.Drawing.Point(0, 527);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(822, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(234, 20);
            this.toolStripStatusLabel1.Text = "欢迎来到首都高校运动会报名系统";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(454, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(104, 20);
            this.toolStripStatusLabel3.Text = "当前时间：";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(15, 20);
            this.toolStripStatusLabel4.Text = "t";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // biaoti
            // 
            this.biaoti.AutoSize = true;
            this.biaoti.BackColor = System.Drawing.Color.Transparent;
            this.biaoti.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.biaoti.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.biaoti.Location = new System.Drawing.Point(245, 78);
            this.biaoti.Name = "biaoti";
            this.biaoti.Size = new System.Drawing.Size(297, 40);
            this.biaoti.TabIndex = 2;
            this.biaoti.Text = "输入操作的学校";
            // 
            // mingchen_label
            // 
            this.mingchen_label.AutoSize = true;
            this.mingchen_label.BackColor = System.Drawing.Color.Transparent;
            this.mingchen_label.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mingchen_label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.mingchen_label.Location = new System.Drawing.Point(186, 301);
            this.mingchen_label.Name = "mingchen_label";
            this.mingchen_label.Size = new System.Drawing.Size(180, 28);
            this.mingchen_label.TabIndex = 8;
            this.mingchen_label.Text = "学校验证码：";
            // 
            // yanzhengma_textBox
            // 
            this.yanzhengma_textBox.BackColor = System.Drawing.Color.SeaShell;
            this.yanzhengma_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yanzhengma_textBox.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.yanzhengma_textBox.ForeColor = System.Drawing.Color.SeaGreen;
            this.yanzhengma_textBox.Location = new System.Drawing.Point(372, 302);
            this.yanzhengma_textBox.Name = "yanzhengma_textBox";
            this.yanzhengma_textBox.PasswordChar = '*';
            this.yanzhengma_textBox.Size = new System.Drawing.Size(227, 27);
            this.yanzhengma_textBox.TabIndex = 7;
            // 
            // xuhao_Label
            // 
            this.xuhao_Label.AutoSize = true;
            this.xuhao_Label.BackColor = System.Drawing.Color.Transparent;
            this.xuhao_Label.Font = new System.Drawing.Font("楷体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xuhao_Label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.xuhao_Label.Location = new System.Drawing.Point(186, 199);
            this.xuhao_Label.Name = "xuhao_Label";
            this.xuhao_Label.Size = new System.Drawing.Size(180, 28);
            this.xuhao_Label.TabIndex = 6;
            this.xuhao_Label.Text = " 学校全称 ：";
            // 
            // mingcheng_textBox
            // 
            this.mingcheng_textBox.BackColor = System.Drawing.Color.SeaShell;
            this.mingcheng_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mingcheng_textBox.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mingcheng_textBox.ForeColor = System.Drawing.Color.SeaGreen;
            this.mingcheng_textBox.Location = new System.Drawing.Point(372, 200);
            this.mingcheng_textBox.Name = "mingcheng_textBox";
            this.mingcheng_textBox.Size = new System.Drawing.Size(227, 27);
            this.mingcheng_textBox.TabIndex = 5;
            // 
            // qingkong_button
            // 
            this.qingkong_button.BackColor = System.Drawing.Color.SeaShell;
            this.qingkong_button.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qingkong_button.ForeColor = System.Drawing.Color.MidnightBlue;
            this.qingkong_button.Location = new System.Drawing.Point(466, 421);
            this.qingkong_button.Name = "qingkong_button";
            this.qingkong_button.Size = new System.Drawing.Size(95, 34);
            this.qingkong_button.TabIndex = 18;
            this.qingkong_button.Text = "清空";
            this.qingkong_button.UseVisualStyleBackColor = false;
            this.qingkong_button.Click += new System.EventHandler(this.qingkong_button_Click);
            // 
            // queding_button
            // 
            this.queding_button.BackColor = System.Drawing.Color.SeaShell;
            this.queding_button.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.queding_button.ForeColor = System.Drawing.Color.MidnightBlue;
            this.queding_button.Location = new System.Drawing.Point(223, 421);
            this.queding_button.Name = "queding_button";
            this.queding_button.Size = new System.Drawing.Size(95, 34);
            this.queding_button.TabIndex = 17;
            this.queding_button.Text = "确定";
            this.queding_button.UseVisualStyleBackColor = false;
            this.queding_button.Click += new System.EventHandler(this.queding_button_Click);
            // 
            // xuexiao_xuanze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(822, 553);
            this.Controls.Add(this.qingkong_button);
            this.Controls.Add(this.queding_button);
            this.Controls.Add(this.mingchen_label);
            this.Controls.Add(this.yanzhengma_textBox);
            this.Controls.Add(this.xuhao_Label);
            this.Controls.Add(this.mingcheng_textBox);
            this.Controls.Add(this.biaoti);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "xuexiao_xuanze";
            this.Text = "xuexiao_xuanze";
            this.Resize += new System.EventHandler(this.xuexiao_xuanze_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label biaoti;
        private System.Windows.Forms.Label mingchen_label;
        private System.Windows.Forms.TextBox yanzhengma_textBox;
        private System.Windows.Forms.Label xuhao_Label;
        private System.Windows.Forms.TextBox mingcheng_textBox;
        private System.Windows.Forms.Button qingkong_button;
        private System.Windows.Forms.Button queding_button;
    }
}