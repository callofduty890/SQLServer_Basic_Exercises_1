using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using DAL.Helper;
using Models;

namespace DAL
{
    public class StudentService
    {
        #region 添加学员对象

        /// <summary>
        /// 判断当前身份证号是否已经存在
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo)
        {
            string sql = "select count(*) from Students where StudentIdNo={0}";
            sql = string.Format(sql, studentIdNo);
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 添加学员
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int AddStudent(Student objStudent)
        {
            //【1】编写SQL语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(StudentName,Gender,Birthday,StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId)");
            sqlBuilder.Append("  values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8})");
            //【2】解析对象
            string sql = string.Format(sqlBuilder.ToString(),
               objStudent.StudentName, objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
               objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber,
               objStudent.StudentAddress, objStudent.CardNo, objStudent.ClassId);
            //【3】提交到数据库
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
