
namespace Registration_System
{
    partial class Sports_Meetings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sports_Meetings));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.name_input_toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.search_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.choose_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.home_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.name_toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.sports_meetings_dataGridView = new System.Windows.Forms.DataGridView();
            this.运动会ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.运动会名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.主办单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.承办单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.地点 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.比赛时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.结束时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sports_meetings_dataGridView)).BeginInit();
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
            this.toolStripStatusLabel3});
            this.statusStrip.Location = new System.Drawing.Point(0, 527);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(822, 26);
            this.statusStrip.TabIndex = 0;
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
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(469, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(104, 20);
            this.toolStripStatusLabel3.Text = "当前时间：";
            // 
            // toolStrip
            // 
            this.toolStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip.BackgroundImage")));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.name_input_toolStripTextBox,
            this.search_toolStripButton,
            this.toolStripSeparator1,
            this.choose_toolStripButton,
            this.home_toolStripButton,
            this.name_toolStripLabel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(822, 31);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // name_input_toolStripTextBox
            // 
            this.name_input_toolStripTextBox.BackColor = System.Drawing.Color.LightCyan;
            this.name_input_toolStripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.name_input_toolStripTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.name_input_toolStripTextBox.Name = "name_input_toolStripTextBox";
            this.name_input_toolStripTextBox.Size = new System.Drawing.Size(150, 31);
            // 
            // search_toolStripButton
            // 
            this.search_toolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.search_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.search_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("search_toolStripButton.Image")));
            this.search_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.search_toolStripButton.Name = "search_toolStripButton";
            this.search_toolStripButton.Size = new System.Drawing.Size(29, 28);
            this.search_toolStripButton.Text = "查找";
            this.search_toolStripButton.Click += new System.EventHandler(this.search_toolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // choose_toolStripButton
            // 
            this.choose_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.choose_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("choose_toolStripButton.Image")));
            this.choose_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.choose_toolStripButton.Name = "choose_toolStripButton";
            this.choose_toolStripButton.Size = new System.Drawing.Size(29, 28);
            this.choose_toolStripButton.Text = "进入";
            this.choose_toolStripButton.Click += new System.EventHandler(this.choose_toolStripButton_Click);
            // 
            // home_toolStripButton
            // 
            this.home_toolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.home_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.home_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("home_toolStripButton.Image")));
            this.home_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.home_toolStripButton.Name = "home_toolStripButton";
            this.home_toolStripButton.Size = new System.Drawing.Size(29, 28);
            this.home_toolStripButton.Text = "toolStripButton3";
            this.home_toolStripButton.Click += new System.EventHandler(this.home_toolStripButton_Click);
            // 
            // name_toolStripLabel
            // 
            this.name_toolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.name_toolStripLabel.BackColor = System.Drawing.Color.Transparent;
            this.name_toolStripLabel.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.name_toolStripLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.name_toolStripLabel.Name = "name_toolStripLabel";
            this.name_toolStripLabel.Size = new System.Drawing.Size(229, 28);
            this.name_toolStripLabel.Text = "请选择需要操作的数据库";
            // 
            // sports_meetings_dataGridView
            // 
            this.sports_meetings_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sports_meetings_dataGridView.BackgroundColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sports_meetings_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sports_meetings_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sports_meetings_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.运动会ID,
            this.运动会名称,
            this.主办单位,
            this.承办单位,
            this.地点,
            this.比赛时间,
            this.结束时间});
            this.sports_meetings_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sports_meetings_dataGridView.EnableHeadersVisualStyles = false;
            this.sports_meetings_dataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.sports_meetings_dataGridView.Location = new System.Drawing.Point(0, 31);
            this.sports_meetings_dataGridView.MultiSelect = false;
            this.sports_meetings_dataGridView.Name = "sports_meetings_dataGridView";
            this.sports_meetings_dataGridView.ReadOnly = true;
            this.sports_meetings_dataGridView.RowHeadersWidth = 51;
            this.sports_meetings_dataGridView.RowTemplate.Height = 27;
            this.sports_meetings_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sports_meetings_dataGridView.Size = new System.Drawing.Size(822, 496);
            this.sports_meetings_dataGridView.TabIndex = 3;
            // 
            // 运动会ID
            // 
            this.运动会ID.DataPropertyName = "运动会ID";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.运动会ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.运动会ID.HeaderText = "运动会编号";
            this.运动会ID.MinimumWidth = 6;
            this.运动会ID.Name = "运动会ID";
            this.运动会ID.ReadOnly = true;
            // 
            // 运动会名称
            // 
            this.运动会名称.DataPropertyName = "运动会名称";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.运动会名称.DefaultCellStyle = dataGridViewCellStyle3;
            this.运动会名称.HeaderText = "运动会名称";
            this.运动会名称.MinimumWidth = 6;
            this.运动会名称.Name = "运动会名称";
            this.运动会名称.ReadOnly = true;
            // 
            // 主办单位
            // 
            this.主办单位.DataPropertyName = "主办单位";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.主办单位.DefaultCellStyle = dataGridViewCellStyle4;
            this.主办单位.HeaderText = "主办单位";
            this.主办单位.MinimumWidth = 6;
            this.主办单位.Name = "主办单位";
            this.主办单位.ReadOnly = true;
            // 
            // 承办单位
            // 
            this.承办单位.DataPropertyName = "承办单位";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.承办单位.DefaultCellStyle = dataGridViewCellStyle5;
            this.承办单位.HeaderText = "承办单位";
            this.承办单位.MinimumWidth = 6;
            this.承办单位.Name = "承办单位";
            this.承办单位.ReadOnly = true;
            // 
            // 地点
            // 
            this.地点.DataPropertyName = "地点";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.地点.DefaultCellStyle = dataGridViewCellStyle6;
            this.地点.HeaderText = "比赛地点";
            this.地点.MinimumWidth = 6;
            this.地点.Name = "地点";
            this.地点.ReadOnly = true;
            // 
            // 比赛时间
            // 
            this.比赛时间.DataPropertyName = "比赛时间";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.比赛时间.DefaultCellStyle = dataGridViewCellStyle7;
            this.比赛时间.HeaderText = "比赛时间";
            this.比赛时间.MinimumWidth = 6;
            this.比赛时间.Name = "比赛时间";
            this.比赛时间.ReadOnly = true;
            // 
            // 结束时间
            // 
            this.结束时间.DataPropertyName = "结束时间";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkRed;
            this.结束时间.DefaultCellStyle = dataGridViewCellStyle8;
            this.结束时间.HeaderText = "结束时间";
            this.结束时间.MinimumWidth = 6;
            this.结束时间.Name = "结束时间";
            this.结束时间.ReadOnly = true;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Sports_Meetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(822, 553);
            this.Controls.Add(this.sports_meetings_dataGridView);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Sports_Meetings";
            this.Text = "运动会选择";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sports_meetings_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton search_toolStripButton;
        private System.Windows.Forms.DataGridView sports_meetings_dataGridView;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripTextBox name_input_toolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton choose_toolStripButton;
        private System.Windows.Forms.ToolStripButton home_toolStripButton;
        private System.Windows.Forms.ToolStripLabel name_toolStripLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn 运动会ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 运动会名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 主办单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 承办单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 地点;
        private System.Windows.Forms.DataGridViewTextBoxColumn 比赛时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 结束时间;
    }
}