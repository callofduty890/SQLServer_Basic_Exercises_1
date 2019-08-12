using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 学员信息扩展实体
    /// </summary>
    public class StudentExt : Student
    {
        public string ClassName { get; set; }

        public int CSharp { get; set; }
        public int SQLServerDB { get; set; }


    }
}
