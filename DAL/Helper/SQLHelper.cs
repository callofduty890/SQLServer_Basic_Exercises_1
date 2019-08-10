using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Helper
{
    public class SQLHelper
    {
        //链接语句
        public static string connstring= "Server=.;DataBase=StudentManageDB;Uid=sa;Pwd=123456";

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //将错误写入日志
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行获取单一结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将错误写入日志
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 执行结果集查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(String sql)
        {
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                //CommandBehavior.CloseConnection 枚举自动关闭
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                //关闭链接
                conn.Close();
                //将错误写入日志

                throw;
            }
        }
    }
}
