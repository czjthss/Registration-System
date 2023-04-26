
namespace Registration_System
{
    partial class genggaimima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(genggaimima));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.biaoti = new System.Windows.Forms.Label();
            this.zhanghao_textbox = new System.Windows.Forms.TextBox();
            this.mima_textbox = new System.Windows.Forms.TextBox();
            this.mima_textbox2 = new System.Windows.Forms.TextBox();
            this.quanxian_combobox = new System.Windows.Forms.ComboBox();
            this.zhuce = new System.Windows.Forms.Button();
            this.qingkong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.BackgroundImage")));
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Location = new System.Drawing.Point(51, 33);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(60, 60);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // biaoti
            // 
            this.biaoti.AutoSize = true;
            this.biaoti.BackColor = System.Drawing.Color.Transparent;
            this.biaoti.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.biaoti.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.biaoti.Location = new System.Drawing.Point(135, 51);
            this.biaoti.Name = "biaoti";
            this.biaoti.Size = new System.Drawing.Size(133, 30);
            this.biaoti.TabIndex = 1;
            this.biaoti.Text = "更改密码";
            // 
            // zhanghao_textbox
            // 
            this.zhanghao_textbox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.zhanghao_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zhanghao_textbox.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zhanghao_textbox.Location = new System.Drawing.Point(51, 140);
            this.zhanghao_textbox.Name = "zhanghao_textbox";
            this.zhanghao_textbox.Size = new System.Drawing.Size(277, 27);
            this.zhanghao_textbox.TabIndex = 2;
            this.zhanghao_textbox.MouseEnter += new System.EventHandler(this.zhanghao_textbox_MouseEnter);
            this.zhanghao_textbox.MouseLeave += new System.EventHandler(this.zhanghao_textbox_MouseLeave);
            // 
            // mima_textbox
            // 
            this.mima_textbox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mima_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mima_textbox.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mima_textbox.Location = new System.Drawing.Point(51, 223);
            this.mima_textbox.Name = "mima_textbox";
            this.mima_textbox.Size = new System.Drawing.Size(277, 27);
            this.mima_textbox.TabIndex = 3;
            this.mima_textbox.MouseEnter += new System.EventHandler(this.mima_textbox_MouseEnter);
            this.mima_textbox.MouseLeave += new System.EventHandler(this.mima_textbox_MouseLeave);
            // 
            // mima_textbox2
            // 
            this.mima_textbox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mima_textbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mima_textbox2.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mima_textbox2.Location = new System.Drawing.Point(51, 298);
            this.mima_textbox2.Name = "mima_textbox2";
            this.mima_textbox2.Size = new System.Drawing.Size(277, 27);
            this.mima_textbox2.TabIndex = 4;
            this.mima_textbox2.MouseEnter += new System.EventHandler(this.mima_textbox2_MouseEnter);
            this.mima_textbox2.MouseLeave += new System.EventHandler(this.mima_textbox2_MouseLeave);
            // 
            // quanxian_combobox
            // 
            this.quanxian_combobox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.quanxian_combobox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.quanxian_combobox.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.quanxian_combobox.FormattingEnabled = true;
            this.quanxian_combobox.Items.AddRange(new object[] {
            "——请选择您的身份——",
            "运动员",
            "教练员",
            "参赛队管理员",
            "主办方管理员"});
            this.quanxian_combobox.Location = new System.Drawing.Point(51, 370);
            this.quanxian_combobox.Name = "quanxian_combobox";
            this.quanxian_combobox.Size = new System.Drawing.Size(277, 31);
            this.quanxian_combobox.TabIndex = 7;
            this.quanxian_combobox.MouseEnter += new System.EventHandler(this.quanxian_combobox_MouseEnter);
            this.quanxian_combobox.MouseLeave += new System.EventHandler(this.quanxian_combobox_MouseLeave);
            // 
            // zhuce
            // 
            this.zhuce.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.zhuce.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zhuce.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.zhuce.Location = new System.Drawing.Point(65, 447);
            this.zhuce.Name = "zhuce";
            this.zhuce.Size = new System.Drawing.Size(75, 30);
            this.zhuce.TabIndex = 8;
            this.zhuce.Text = "更改";
            this.zhuce.UseVisualStyleBackColor = false;
            this.zhuce.Click += new System.EventHandler(this.zhuce_Click);
            // 
            // qingkong
            // 
            this.qingkong.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.qingkong.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qingkong.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.qingkong.Location = new System.Drawing.Point(222, 447);
            this.qingkong.Name = "qingkong";
            this.qingkong.Size = new System.Drawing.Size(75, 30);
            this.qingkong.TabIndex = 9;
            this.qingkong.Text = "清空";
            this.qingkong.UseVisualStyleBackColor = false;
            this.qingkong.Click += new System.EventHandler(this.qingkong_Click);
            // 
            // genggaimima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(382, 664);
            this.Controls.Add(this.qingkong);
            this.Controls.Add(this.zhuce);
            this.Controls.Add(this.quanxian_combobox);
            this.Controls.Add(this.mima_textbox2);
            this.Controls.Add(this.mima_textbox);
            this.Controls.Add(this.zhanghao_textbox);
            this.Controls.Add(this.biaoti);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "genggaimima";
            this.Text = "用户注册";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label biaoti;
        private System.Windows.Forms.TextBox zhanghao_textbox;
        private System.Windows.Forms.TextBox mima_textbox;
        private System.Windows.Forms.TextBox mima_textbox2;
        private System.Windows.Forms.ComboBox quanxian_combobox;
        private System.Windows.Forms.Button zhuce;
        private System.Windows.Forms.Button qingkong;
    }
}