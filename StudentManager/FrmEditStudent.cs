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
        private StudentService objStudentService = new StudentService();
        //public StudentExt from_StudentExt;

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

        public FrmEditStudent(StudentExt objStudent):this()
        {
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
            #region 验证消息
            //和添加学员一样
            //判断身份证号是否重复
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim(),this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("身份证不能和现有学员身份证号重复!", "验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
            }



            #endregion

            #region 封装学生对象信息
                Student objStudent = new Student()
                {
                    StudentId = Convert.ToInt32(this.txtStudentId.Text.Trim()),
                    StudentName = this.txtStudentName.Text.Trim(),
                    Gender = this.rdoMale.Checked ? "男" : "女",
                    Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                    StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                    PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                    StudentAddress = this.txtAddress.Text.Trim(),
                    CardNo = this.txtCardNo.Text.Trim(),
                    ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//获取选择班级对应的ClassId
                    Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year
                };
            #endregion

            #region 提交修改
            try
            {
                if (objStudentService.ModifyStudent(objStudent)==1)
                {
                    MessageBox.Show("学员信息修改成功!","提示信息");
                    this.DialogResult = DialogResult.OK;//返回修改成功的提示信息
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //窗体加载事件
        private void FrmEditStudent_Load(object sender, EventArgs e)
        {
        }
    }
}