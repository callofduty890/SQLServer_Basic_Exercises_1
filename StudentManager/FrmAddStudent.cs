using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
     
        public FrmAddStudent()
        {
            InitializeComponent();
         
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
    }
}