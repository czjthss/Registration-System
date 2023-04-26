using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_System
{
    /// <summary>
    /// 全部窗体共有数据
    /// </summary>
    public static class Public_val
    {
        private static String zhanghao="1";
        private static String yundonghui = "1";
        private static String xuexiao = "1";

        //更改
        public static bool change_flag = false;
        public static String change_xuhao = "";
        //主页键
        public static bool home_flag = false;

        //public static String DataSource = "";

        public static String get_zhanghao() { return zhanghao; }
        public static void set_zhanghao(String s) { zhanghao=s; }

        public static String get_yundonghui() { return yundonghui; }
        public static void set_yundonghui(String s) { yundonghui = s; }

        public static String get_xuexiao() { return xuexiao; }
        public static void set_xuexiao(String s) {xuexiao = s; }
    }
}
