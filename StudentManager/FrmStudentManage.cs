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
        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
           
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
          
        }       
        //删除学员对象
        private void btnDel_Click(object sender, EventArgs e)
        {
          
        }
        private void FrmSearchStudent_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}