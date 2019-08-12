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
    public partial class FrmStudentManage : Form
    {
        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStudentService = new StudentService();

        public FrmStudentManage()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClass.DataSource = objClassService.GetAllClasses();
            //设置显示属性
            this.cboClass.DisplayMember = "ClassName";
            //设置对应的班级ID
            this.cboClass.ValueMember = "ClassId";
            //默认不选中
            this.cboClass.SelectedIndex = -1;
        }
        //按照班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cboClass.SelectionLength==-1)
            {
                MessageBox.Show("请选择班级!", "提示信息");
                return;
            }
            //禁止生成其他列
            this.dgvStudentList.AutoGenerateColumns = false;//不显示未封装的类

            //执行查询
            this.dgvStudentList.DataSource = objStudentService.GetStudentByClass(this.cboClass.Text);
        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入学号");
                this.txtStudentId.Focus();
                return;
            }
            //验证是否是数字

            StudentExt objStudent = objStudentService.GetStudentById(this.txtStudentId.Text.Trim());
            if (objStudent==null)
            {
                MessageBox.Show("学员学习不存在!", "提示信息");
                this.txtStudentId.Focus();
            }
            else
            {
                //在学员详细信息窗体显示
                FrmStudentInfo objFrmStuInfor = new FrmStudentInfo(objStudent);
                objFrmStuInfor.Show();
            }

        }
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
        //双击选中的学员对象并显示详细信息
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        //修改学员对象
        private void btnEidt_Click(object sender, EventArgs e)
        {
            //判断是否要修改
            if (this.dgvStudentList.RowCount==0)
            {
                MessageBox.Show("没有选中要修改的信息!", "提示信息");
                return;
            }
            //判断是否当前被选中的状态
            if (this.dgvStudentList.CurrentRow==null)
            {
                MessageBox.Show("请选中要修改的学员信息!", "提示信息");
                return;
            }
            //获取学号
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //获取要修改的学员详细信息
            StudentExt objStudent = objStudentService.GetStudentById(studentId);
            //显示要修改的学员信息窗口
            FrmEditStudent objEditStudent = new FrmEditStudent(objStudent);
            //获取窗口执行的结果
            DialogResult result = objEditStudent.ShowDialog();
            //判断修改是否成功
            if (result==DialogResult.OK)
            {
                btnQuery_Click(null, null);//同步显示刷新修改的信息
            }
            
        }       
        //删除学员对象
        private void btnDel_Click(object sender, EventArgs e)
        {
          
        }
        //窗体关闭相应事件
        private void FrmSearchStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.objFrmStudentManage = null;//当窗体关闭时,将窗体对象清理掉
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}