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
    ///学员信息数据访问类
    /// </summary>
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

        #region 查询学员

        /// <summary>
        /// 根据班级名称查询学员信息
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudentByClass(string className)
        {
            string sql = "select StudentName,StudentId,Gender,Birthday,ClassName from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where ClassName='{0}'";
            sql = string.Format(sql, className);
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while (objReader.Read())
            {
                list.Add(new StudentExt()
                    {
                        StudentId = Convert.ToInt32(objReader["StudentId"]),
                        StudentName = objReader["StudentName"].ToString(),
                        Gender = objReader["Gender"].ToString(),
                        Birthday = Convert.ToDateTime(objReader["Birthday"]),
                        ClassName = objReader["ClassName"].ToString()
                    });
            }
            objReader.Close();
            return list;

        }
        /// <summary>
        ///根据学号查询学员对象
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentExt GetStudentById(string studentId)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,StudentIdNo,PhoneNumber,StudentAddress,CardNo from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where StudentId=" + studentId;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            StudentExt objStudent = null;
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
        /// 修改学员时判断身份证号是否和其他学员重复
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo, string studentId)
        {
            string sql = "select count(*) from Students where StudentIdNo={0}  and StudentId<>{1}";
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
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("Update Students set StudentName='{0}',Gender='{1}',Birthday='{2}',");
            sqlBuilder.Append("StudentIdNo={3},Age={4},PhoneNumber='{5}',StudentAddress='{6}',CardNo='{7}',ClassId={8}");
            sqlBuilder.Append(" where StudentId={9}");
            //解析对象
            string sql = string.Format(sqlBuilder.ToString(),
            objStudent.StudentName, objStudent.Gender, objStudent.Birthday,
            objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber,
            objStudent.StudentAddress, objStudent.CardNo, objStudent.ClassId, objStudent.StudentId);
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

        #region 删除学员对象

        public int DeleteStudentById(string studentId)
        {
            string sql = "delete from Students where StudentId=" + studentId;
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该学号被其他数据表引用，不能直接删除该学员对象！");
                else
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
