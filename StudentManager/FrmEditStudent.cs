using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmEditStudent : Form
    {
        public StudentClassService objClassService = new StudentClassService();

        public FrmEditStudent()
        {
            InitializeComponent();
            //初始化下拉框
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            //设置显示属性
            this.cboClassName.DisplayMember = "ClassName";
            //设置对应的班级ID
            this.cboClassName.ValueMember = "ClassId";
        }

        public FrmEditStudent(StudentExt objStudent) : this()
        {
            InitializeComponent();
            //显示学员信息
            this.txtStudentName.Text = objStudent.StudentName;
            this.txtStudentIdNo.Text = objStudent.StudentIdNo;
            this.txtAddress.Text = objStudent.StudentAddress;
            this.dtpBirthday.Text = objStudent.Birthday.ToShortDateString();
            this.txtCardNo.Text = objStudent.CardNo;
            this.cboClassName.Text = objStudent.ClassName;
            if (objStudent.Gender == "男")
            {
                this.rdoMale.Checked = true;
            }
            else
            {
                this.rdoFemale.Checked = true;
            }
            this.txtPhoneNumber.Text = objStudent.PhoneNumber;
        }

        //提交修改
        private void btnModify_Click(object sender, EventArgs e)
        {
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}