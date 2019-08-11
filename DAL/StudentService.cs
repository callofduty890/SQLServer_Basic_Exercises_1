using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Models;
using DAL.Helper;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 学生信息访问类
    /// </summary>
    public class StudentService
    {
        #region  添加学员对象
        /// <summary>
        /// 判断当前身份证号是否已经存在
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo)
        {
            //构建SQL查询语句
            string sql = "select count(*) from Students where StudentIdNo={0}";
            sql = string.Format(sql, studentIdNo);
            //判断数量是否等于1，如果相等返回真
            return (1 == Convert.ToInt32(SQLHelper.GetSingleResult(sql)));
        }
        /// <summary>
        /// 添加学员信息
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int AddStudent(Student objStudent)
        {
            //【1】构建SQL查询语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(StudentName,Gender,Birthday,StudentldNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId)");
            sqlBuilder.Append(" values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}')");
            //【2】解析对象
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName, objStudent.Gender, objStudent.Birthday, objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.CardNo, objStudent.ClassId);
            //【3】提交到数据库 -返回受影响的行数
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                throw new Exception("数控操作异常!,具体信息："+ex.Message) ;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
