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

        #region 查询学员信息
            /// <summary>
            /// 根据班级名称查询学员信息
            /// </summary>
            /// <param name="className"></param>
            /// <returns></returns>
            public List<StudentExt> GetStudentByClass(string className)
            {
                //构建SQL语句
                string sql = "select StudentName,StudentId,Gender,Birthday,ClassName from Students";
                sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
                sql += " where ClassName='{0}'";
                sql = string.Format(sql, className);
                //执行SQL语句
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                //构建储存列表
                List<StudentExt> list = new List<StudentExt>();
                //循环
                while (objReader.Read())
                {
                    list.Add(new StudentExt()
                    {
                        StudentId = Convert.ToInt32(objReader["studentId"]),
                        StudentName = objReader["StudentName"].ToString(),
                        Gender = objReader["Gender"].ToString(),
                        Birthday = Convert.ToDateTime(objReader["Birthday"]),
                        ClassName = objReader["ClassName"].ToString()

                    });
                }
                //关闭连接
                objReader.Close();
                //返回结构
                return list;
            }

        /// <summary>
        /// 更加学员学号查询信息
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentExt GetStudentById(string studentId)
        {
            //构建SQL语句
            string sql = "select StudentId,StudentName,Gender,Birthday,StudentIdNo,CardNo,Age,PhoneNumber,StudentAddress,ClassName from Students inner join StudentClass on Students.ClassId=StudentClass.ClassId where StudentId=" + studentId;
            //执行查询
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            //设置对象
            StudentExt objStudent = null;
            //判断读取是否成功
            if (objReader.Read())
            {
                objStudent = new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    CardNo = objReader["CardNo"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString()
                };
            }
            objReader.Close();
            return objStudent;
        }
        #endregion

        #region 修改学员对象
        /// <summary>
        /// 判断身份证号是否和其他学员重复
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo,string studentId)
        {
            string sql = "select count(*) from Students where StudentIdNo={0} and StudentId<>{0}";
            sql = string.Format(sql, studentIdNo, studentId);
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }

        /// <summary>
        /// 修改学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int ModifyStudent(Student objStudent)
        {
            //搭建SQL语句框架
            StringBuilder sqlBuilder=new StringBuilder();
            sqlBuilder.Append("Update Students set " +
                "StudentName='{0}'," +
                "Gender='{1}'," +
                "Birthday='{2}'," +
                "StudentIdNo={3}," +
                "CardNo={4}," +
                "Age={5}," +
                "PhoneNumber='{6}'," +
                "StudentAddress='{7}'," +
                "ClassId={8}");
            sqlBuilder.Append(" where StudentId={9}");
            //构建SQL语句
            string sql = string.Format(sqlBuilder.ToString(),
                objStudent.StudentName,
                objStudent.Gender,
                objStudent.Birthday,
                objStudent.StudentIdNo,
                objStudent.CardNo,
                objStudent.Age,
                objStudent.PhoneNumber,
                objStudent.StudentAddress,
                objStudent.ClassId,
                objStudent.StudentId);
            //进行访问
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常!具体信息" + ex.Message);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
