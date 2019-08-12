using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DAL;
using Models;


namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStudentService = new StudentService();

        public FrmAddStudent()
        {
            InitializeComponent();

            //初始化班级下拉框
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";
            this.cboClassName.SelectedIndex = -1;//默认不选中
        }

        //添加新学员
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region  验证数据

            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("学生姓名不能为空！", "提示信息");
                this.txtStudentName.Focus();
                return;
            }
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("考勤卡号不能为空！", "提示信息");
                this.txtCardNo.Focus();
                return;
            }
            //验证性别
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("请选择学生性别！", "提示信息");
                return;
            }
            //验证班级
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级！", "提示信息");
                return;
            }
            //验证身份证号是否符合要求
            if (!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号不符合要求！", "验证提示");
                this.txtStudentIdNo.Focus();
                return;
            }
            //验证身份证号是否重复
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号不能和现有学员身份证号重复！", "验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //验证身份证号是否和出生日期相吻合
            string month = string.Empty;
            string day = string.Empty;
            if (Convert.ToDateTime(this.dtpBirthday.Text).Month < 10)
                month = "0" + Convert.ToDateTime(this.dtpBirthday.Text).Month;
            else
                month = Convert.ToDateTime(this.dtpBirthday.Text).Month.ToString();
            if (Convert.ToDateTime(this.dtpBirthday.Text).Day < 10)
                day = "0" + Convert.ToDateTime(this.dtpBirthday.Text).Day;
            else
                day = Convert.ToDateTime(this.dtpBirthday.Text).Day.ToString();
            string birthday = Convert.ToDateTime(this.dtpBirthday.Text).Year.ToString() + month + day;

            if (!this.txtStudentIdNo.Text.Trim().Contains(birthday))
            {
                MessageBox.Show("身份证号和出生日期不匹配！", "验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //验证出生日期
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age < 18)
            {
                MessageBox.Show("学生年龄不能小于18岁！", "验证提示");
                return;
            }
            #endregion

            #region 封装学生对象

            Student objStudent = new Student()
            {
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

            //Student objStudent = new Student()
            //{
            //    StudentName = this.txtStudentName.Text.Trim(),
            //    Gender = this.rdoMale.Checked ? "男" : "女",
            //    Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
            //    StudentIdNo = this.txtStudentIdNo.Text.Trim(),
            //    PhoneNumber = this.txtPhoneNumber.Text.Trim(),
            //    StudentAddress = this.txtAddress.Text.Trim(),
            //    CardNo = this.txtCardNo.Text.Trim(),
            //    ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//获取选择班级对应的ClassId
            //    Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year
            //};

            #endregion

            #region 调用后台数据访问方法添加对象

            try
            {
                if (objStudentService.AddStudent(objStudent) == 1)
                {
                    //返回SQL查询结果
                    DialogResult result = MessageBox.Show("新学员添加成功！是否继续添加？", "提示信息", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)//清空用户的输入
                    {
                        //下拉框设置
                        this.cboClassName.SelectedIndex = -1;
                        //设置
                        this.rdoFemale.Checked = false;
                        this.rdoMale.Checked = false;
                        //清除文本框
                        foreach (Control item in this.Controls)
                        {
                            if (item is TextBox)
                                item.Text = "";
                        }
                        this.txtStudentName.Focus();
                    }
                }
                else
                {
                    this.Close();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion

        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //窗体已经被关闭
        private void FrmAddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.objFrmAddStudent = null;//当窗体关闭时，将窗体对象清理掉
        }
    }
}