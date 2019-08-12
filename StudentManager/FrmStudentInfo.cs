using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Models;
using DAL;

namespace StudentManager
{
    public partial class FrmStudentInfo : Form
    {
        public FrmStudentInfo()
        {
            InitializeComponent();
        }


        //注意this()会使用FrmStudentIfo()这个构造函数
        public FrmStudentInfo(StudentExt objStudent):this()
        {
            //显示学员信息
            this.lblStudentName.Text = objStudent.StudentName;
            this.lblStudentIdNo.Text = objStudent.StudentIdNo;
            this.lblAddress.Text = objStudent.StudentAddress;
            this.lblBirthday.Text = objStudent.Birthday.ToShortDateString();
            this.lblCardNo.Text = objStudent.CardNo;
            this.lblClass.Text = objStudent.ClassName;
            this.lblGender.Text = objStudent.Gender;
            this.lblPhoneNumber.Text = objStudent.PhoneNumber;

        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}