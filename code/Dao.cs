using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Registration_System
{
    class Dao
    {
        SqlConnection con;
        /// <summary>
        /// 构造函数，连接上数据库
        /// </summary>
        public Dao()
        {
            //打开数据库字符串构建
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            //builder.DataSource = Public_val.DataSource;
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "Assignment3_Design_And_Implementation";

            //打开数据库
            SqlConnection sqlConnection = new SqlConnection(builder.ToString());
            con = sqlConnection;
            if(con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        /// <summary>
        /// sql命令构建
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        /// <returns></returns>
        private SqlCommand command(string sql)
        {
            SqlCommand com = new SqlCommand(sql,con);
            return com;
        }

        /// <summary>
        /// 用于UPDATE,DELETE,INSERT INTO等语句,返回受影响的行数
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        /// <returns></returns>
        public int Excute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }

        /// <summary>
        /// 用于SELECT语句,返回SELECT到的数据
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        /// <returns></returns>
        public SqlDataReader Read(string sql)
        {
            return command(sql).ExecuteReader();
        }

        public DataTable SqlDataGridView_Show(string sql,string title)
        {
            //执行查询语句
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset,title);//参数二：表名，自己选择

            //绑定数据到DataGridView
            return dataset.Tables[title];
        }

        public SqlDataAdapter SqlProcedure(String name)
        {
            return new SqlDataAdapter(name, con);
        }
    }
}
