using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//数据库引入库
using System.Data;
using System.Data.SqlClient;

//返回实体类
using Models;
using DAL.Helper;

namespace DAL
{
     public class SysAdminService
    {
        /// <summary>
        /// 根据登录账号和密码进行登录
        /// </summary>
        /// <param name="objAdmin">封装登录账号和密码的管理员对象</param>
        /// <returns>返回包含管理员信息的对象</returns>
        public SysAdmin AdminLogin(SysAdmin objAdmin)
        {
            //构建SQL语句
            string sql = "select AdminName from Admins where LoginId={0} and LoginPwd='{1}'";
            sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);
            //从数据库中查询
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            //判断查询结构
            if (objReader.Read())
            {
                objAdmin.AdminName = objReader["AdminName"].ToString();
            }
            else
            {
                //如果登录不成功，则将当前对象清空
                objAdmin = null;
            }
            //
            objReader.Close();
            //返回结构
            return objAdmin;
        }



    }
}
