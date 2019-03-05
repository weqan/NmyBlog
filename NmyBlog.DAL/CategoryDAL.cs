using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NmyBlog.Model;

namespace NmyBlog.DAL
{
    /// <summary>
    /// 分类表的数据操作类
    /// </summary>
    public class CategoryDAL
    {
        /// <summary>
        /// INSEERT
        /// </summary>
        /// <returns></returns>
        public int Insert(Category ca)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int resid = connection.Query<int>(@"INSERT INTO Category(CaName,Bh,Pbh,Remark) values(@CaName,@Bh,@Pbh,@Remark);SELECT @@IDENTITY;", ca).FirstOrDefault();
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
               int res=  connection.Execute(@"DELETE FROM Category WHERE Id=@Id", new {Id = id});
               if (res>0)
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
        public List<Category> GetList(string cond)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string sql = "SELECT * FROM Category";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql += $" WHERE {cond}";
                }

                var list = connection.Query<Category>(sql).ToList();
                return list;
            }
        }

        /// <summary>
        /// GET TOP LIST
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public List<Category> GetTopList(int topnum, string cond)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string sql = "SELECT TOP " + topnum + " * FROM Category";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql += $" WHERE {cond}";
                }

                var list = connection.Query<Category>(sql).ToList();
                return list;
            }
        }


        /// <summary>
        /// Get Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetModel(int id)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
              var m =  connection.Query<Category>(@"SELECT * FROM Category WHERE Id=@Id",new {Id=id}).FirstOrDefault();

              return m;
            }
        }

        /// <summary>
        /// Get Model By CaBh
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public Category GetModelByBh(string cabh)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                var m = connection.Query<Category>(@"SELECT * FROM Category WHERE bh=@bh", new { bh = cabh }).FirstOrDefault();

                return m;
            }
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="ca"></param>
        /// <returns></returns>
        public bool Update(Category ca)
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int res = connection.Execute(@"UPDATE Category SET CaName=@CaName,Bh=@Bh,Pbh=@Pbh,Remark=@Remark WHERE Id=@Id",ca);

                if (res>0)
                {
                    return true;
                }

                return false;
            }
        }



    }
}
