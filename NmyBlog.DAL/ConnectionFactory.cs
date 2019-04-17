using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace NmyBlog.DAL
{
    /// <summary>
    /// 数据库连接工厂
    /// </summary>
    public class ConnectionFactory
    {
        public static DbConnection GetOpenConnection(string connStr)
        {
            //"ConnStr": "server=39.108.85.11;user id=root;password=Lsb@1972;database=nmyuan",
            //var connection = new SqlConnection(@"Data Source=39.108.85.11;Initial Catalog=nmyuan;User ID=root;Password=Lsb@1972");

            var connection = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            connection.Open();
            
            return connection;
        }


    }
}
