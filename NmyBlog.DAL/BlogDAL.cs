﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using NmyBlog.Model;

namespace NmyBlog.DAL
{
    public class BlogDAL
    {
        /// <summary>
        /// 数据库连接字符串，从web层传入
        /// </summary>
        public string ConnStr { get; set; }



        /// <summary>
        /// INSERT
        /// </summary>
        /// <returns></returns>
        public int Insert(Blog bo)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int resid = connection.Query<int>(@"INSERT INTO Blog(Title,Body,Body_md,VisitNum,CaBh,CaName,Remark,Sort) values(@Title,@Body,@Body_md,@VisitNum,@CaBh,@CaName,@Remark,@Sort);SELECT @@IDENTITY;", bo).FirstOrDefault();
                return resid;
            }
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int res = connection.Execute(@"DELETE FROM Blog WHERE Id=@Id", new { Id = id });
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
        public List<Blog> GetList(string cond)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string sql = "SELECT * FROM Blog";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql += $" WHERE {cond}";
                }

                var list = connection.Query<Blog>(sql).ToList();
                return list;
            }
        }

        /// <summary>
        /// GET TOP LIST
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public List<Blog> GetTopList(int topnum, string cond)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string sql = "SELECT TOP " + topnum + " * FROM Blog";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql += $" WHERE {cond}";
                }

                var list = connection.Query<Blog>(sql).ToList();
                return list;
            }
        }

        /// <summary>
        /// GET RANDOM LIST
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public List<Blog> GetTopRanList(int topnum, string cond)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                string sql = "SELECT TOP " + topnum + " *, NewID() AS random FROM Blog ORDER BY random";
                if (!string.IsNullOrEmpty(cond))
                {
                    sql += $" WHERE {cond}";
                }

                var list = connection.Query<Blog>(sql).ToList();
                return list;
            }
        }


        /// <summary>
        /// Get Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Blog GetModel(int id)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                var m = connection.Query<Blog>(@"SELECT * FROM Blog WHERE Id=@Id", new { Id = id }).FirstOrDefault();

                return m;
            }
        }



        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="ca"></param>
        /// <returns></returns>
        public bool Update(Blog bo)
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int res = connection.Execute(@"UPDATE Blog SET Title=@Title,Body=@Body,Body_md=@Body_md,VisitNum=@VisitNum,CaBh=@CaBh,CaName=@CaName,Remark=@Remark,Sort=@Sort WHERE Id=@Id", bo);

                if (res > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public int BlogCounts()
        {
            using (var connection = ConnectionFactory.GetOpenConnection(ConnStr))
            {
                int res = connection.ExecuteScalar<int>(@"select COUNT(*) from blog");

                return res;
            }
        }
    }
}
