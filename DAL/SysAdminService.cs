using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    /// <summary>
    /// 管理员数据访问类
    /// </summary>
    public class SysAdminService
    {
        /// <summary>
        /// 根据登录账号和密码登录
        /// </summary>
        /// <param name="objAdmin">封装了登录账号和密码的管理员对象</param>
        /// <returns>返回包含管理员信息的对象</returns>
        public SysAdmin AdminLogin(SysAdmin objAdmin)
        {
            //组合SQL语句
            string sql = "select AdminName from Admins where LoginId={0}  and LoginPwd='{1}'";
            sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);
            //从数据库中查询
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            if (objReader.Read())
            {
                objAdmin.AdminName = objReader["AdminName"].ToString();
            }
            else
            {
                objAdmin = null;//如果登录不成功，则将当前对象清空
            }
            objReader.Close();
            //返回结果
            return objAdmin;
        }
    }
}
