using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_System
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //string DataSource1 = Interaction.InputBox("请输入电脑型号", "连接数据库", "在这里输入", -1, -1);
            //Public_val.DataSource = DataSource1;
            Application.Run(new Form_first());
            //Application.Run(new cansaidui_caozuo());
        }
    }
}
