using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

        }


        ////显示添加学员窗体
        //private void tsmiAddStudent_Click(object sender, EventArgs e)
        //{
        //    FrmAddStudent objAddStudent = new FrmAddStudent();
        //    objAddStudent.ShowDialog();
        //}

        //添加学员
        public static FrmAddStudent objFrmAddStudent = null; //窗体对象
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            if (objFrmAddStudent == null)
            {
                //创建实例化对象
                objFrmAddStudent = new FrmAddStudent();
                //显示对象
                objFrmAddStudent.Show();
            }
            else
            {
                objFrmAddStudent.Activate();//激活窗口
                objFrmAddStudent.WindowState = FormWindowState.Normal;//设置窗口状态
            }

        }
        //学院管理系统
        public static FrmStudentManage objFrmStudentManage = null;
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
            if (objFrmStudentManage == null)
            {
                //创建实例化对象
                objFrmStudentManage = new FrmStudentManage();
                //显示对象
                objFrmStudentManage.Show();
            }
            else
            {
                objFrmStudentManage.Activate();//激活窗口
                objFrmStudentManage.WindowState = FormWindowState.Normal;//设置窗口状态
            }
        }
        //显示成绩查询与分析窗口    
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
        }
        //退出系统
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        //成绩快速查询
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
       
        }
        //密码修改
        private void tmiModifyPwd_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbAddStudent_Click(object sender, EventArgs e)
        {
            tsmiAddStudent_Click(null, null);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsmiManageStudent_Click(null, null);
        }
        private void tsbScoreAnalysis_Click(object sender, EventArgs e)
        {
            tsmiQueryAndAnalysis_Click(null, null);
        }
        private void tsbModifyPwd_Click(object sender, EventArgs e)
        {
            tmiModifyPwd_Click(null, null);
        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }
  
        private void tsmi_Card_Click(object sender, EventArgs e)
        {
          
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗?", "退出询问",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result!=DialogResult.OK)
            {
                //取消当前的关闭操作
                e.Cancel = true;
            }

        }
    }
}