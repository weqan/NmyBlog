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
        public static DbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(@"Data Source=.;Initial Catalog=NMY_DB;User ID=sa;Password=sa");

            connection.Open();

            return connection;
        }


    }
}
