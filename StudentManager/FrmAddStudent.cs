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

        public FrmAddStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            //设置显示属性
            this.cboClassName.DisplayMember = "ClassName";
            //设置对应的班级ID
            this.cboClassName.ValueMember = "ClassId";
        }

        //添加新学员
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //判断用户输入的是否是复合要求的数据
            if (Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证不符合要求!","验证提示");
                //创建焦点
                this.txtStudentIdNo.Focus();
                return;
            }
        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //窗体已经被关闭
        private void FrmAddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.objFrmAddStudent = null;//当窗体关闭时,将窗体对象清理掉
        }

        private void FrmAddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}