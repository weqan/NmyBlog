using Dapper;
using NmyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NmyBlog.DAL
{
    public class AdminDAL
    {
        ///// <summary>
        ///// 数据库连接字符串，从web层传入
        ///// </summary>
        //public string ConnStr { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Admin Login(string username, string password)
        {
            string sql = "select * from admin where username=@username and password=@password";
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                Admin m = connection.Query<Admin>(sql, new { username = username, password = password }).FirstOrDefault();
                return m;
            }
        }


        /// <summary>
        /// INSERT
        /// </summary>
        /// <returns></returns>
        public int Insert(Admin ad)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int resid = connection.Query<int>(@"INSERT INTO Admin(username,password,remark) values(@username,@password,@remark);SELECT @@IDENTITY;", ad).FirstOrDefault();
                return resid;
            }
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int res = connection.Execute(@"DELETE FROM Admin WHERE Id=@Id", new { Id = id });
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// GET LIST
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public List<Admin> GetList(string cond)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string sql = "SELECT * FROM Admin";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql += $" WHERE {cond}";
                }

                var list = connection.Query<Admin>(sql).ToList();
                return list;
            }
        }

        /// <summary>
        /// GET TOP LIST
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public List<Admin> GetTopList(int topnum, string cond)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string sql = "SELECT TOP " + topnum + " * FROM Admin";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql += $" WHERE {cond}";
                }

                var list = connection.Query<Admin>(sql).ToList();
                return list;
            }
        }

        /// <summary>
        /// GET RANDOM LIST
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public List<Admin> GetTopRanList(int topnum, string cond)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string sql = "SELECT TOP " + topnum + " *, NewID() AS random FROM Admin ORDER BY random";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql += $" WHERE {cond}";
                }

                var list = connection.Query<Admin>(sql).ToList();
                return list;
            }
        }


        /// <summary>
        /// Get Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin GetModel(int id)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                var m = connection.Query<Admin>(@"SELECT * FROM Admin WHERE Id=@Id", new { Id = id }).FirstOrDefault();

                return m;
            }
        }



        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="ca"></param>
        /// <returns></returns>
        public bool Update(Admin bo)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int res = connection.Execute(@"UPDATE Admin SET username=@username,password=@password,remark=@remark WHERE id=@id", bo);

                if (res > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
