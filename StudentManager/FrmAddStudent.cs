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
            //��ʼ���༶������
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            //������ʾ����
            this.cboClassName.DisplayMember = "ClassName";
            //���ö�Ӧ�İ༶ID
            this.cboClassName.ValueMember = "ClassId";
        }

        //�����ѧԱ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //�ж��û�������Ƿ��Ǹ���Ҫ�������
            if (Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤������Ҫ��!","��֤��ʾ");
                //��������
                this.txtStudentIdNo.Focus();
                return;
            }
        }
        //�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //�����Ѿ����ر�
        private void FrmAddStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.objFrmAddStudent = null;//������ر�ʱ,��������������
        }

        private void FrmAddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}