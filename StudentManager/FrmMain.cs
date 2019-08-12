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

            //显示登录用户名
            this.lblCurrentUser.Text = Program.objCurrentAdmin.AdminName + "]";

        }

        public static FrmAddStudent objFrmAddStudent = null;
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            if (objFrmAddStudent == null)
            {
                objFrmAddStudent = new FrmAddStudent();
                objFrmAddStudent.Show();
            }
            else
            {
                objFrmAddStudent.Activate();//激活只能在最小化的时候起作用
                objFrmAddStudent.WindowState = FormWindowState.Normal;
            }
        }
        //学员管理
        public static FrmStudentManage objFrmStuManage = null;
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
            if (objFrmStuManage == null)
            {
                objFrmStuManage = new FrmStudentManage();
                objFrmStuManage.Show();
            }
            else
            {
                objFrmStuManage.Activate();
                objFrmStuManage.WindowState = FormWindowState.Normal;
            }
        }
        //显示成绩查询与分析窗口
        public static FrmScoreManage objFrmScoreManage = null;
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
            if (objFrmScoreManage == null)
            {
                objFrmScoreManage = new FrmScoreManage();
                objFrmScoreManage.Show();
            }
            else
            {
                objFrmScoreManage.Activate();
                objFrmScoreManage.WindowState = FormWindowState.Normal;
            }
        }
        //退出系统
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //成绩快速查询
        public static FrmScoreQuery objFrmScore = null;
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
            if (objFrmScore == null)
            {
                objFrmScore = new FrmScoreQuery();
                objFrmScore.Show();
            }
            else
            {
                objFrmScore.Activate();//激活只能在最小化的时候起作用
                objFrmScore.WindowState = FormWindowState.Normal;
            }
         
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

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }

        private void tsmi_Card_Click(object sender, EventArgs e)
        {

        }
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
            {
                //取消当前的关闭操作
                e.Cancel = true;
            }
        }
    }
}