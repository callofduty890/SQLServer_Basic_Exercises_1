using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//引入命名空间
using System.Data;
using System.Data.SqlClient;
using Models;
using DAL.Helper;

namespace DAL
{
    /// <summary>
    /// 班级数据访问类
    /// </summary>
    public class StudentClassService
    {
        public List<StudentClass> GetAllClasses()
        {
            string sql = "select * from StudentClass";
            //执行查询语句
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            //构建list类用于接收返回数据
            List<StudentClass> list = new List<StudentClass>();
            //判断读取状态
            while (objReader.Read())
            {
                //通过将StudentClass对象批量添加进入到list类当中
                list.Add(new StudentClass()
                {
                    ClassId = Convert.ToInt32(objReader["ClassId"]),
                    ClassName = objReader["ClassName"].ToString()
                });
            }
            //关闭
            objReader.Close();
            //返回结果
            return list;
        }

    }
}
