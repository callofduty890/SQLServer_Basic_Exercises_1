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

            //��ʾ��¼�û���
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
                objFrmAddStudent.Activate();//����ֻ������С����ʱ��������
                objFrmAddStudent.WindowState = FormWindowState.Normal;
            }
        }
        //ѧԱ����
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
        //��ʾ�ɼ���ѯ���������
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
        //�˳�ϵͳ
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //�ɼ����ٲ�ѯ
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
                objFrmScore.Activate();//����ֻ������С����ʱ��������
                objFrmScore.WindowState = FormWindowState.Normal;
            }
         
        }
        //�����޸�
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
            DialogResult result = MessageBox.Show("ȷ���˳���", "�˳�ѯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result != DialogResult.OK)
            {
                //ȡ����ǰ�Ĺرղ���
                e.Cancel = true;
            }
        }
    }
}