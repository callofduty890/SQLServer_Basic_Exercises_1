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
            //��ʼ���༶������
            this.cboClass.DataSource = objClassService.GetAllClasses();
            //������ʾ����
            this.cboClass.DisplayMember = "ClassName";
            //���ö�Ӧ�İ༶ID
            this.cboClass.ValueMember = "ClassId";
            //Ĭ�ϲ�ѡ��
            this.cboClass.SelectedIndex = -1;
        }
        //���հ༶��ѯ
        private void btnQuery_Click(object sender, EventArgs e)
        {
        }
        //����ѧ�Ų�ѯ
        private void btnQueryById_Click(object sender, EventArgs e)
        {
           
        }
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
          
        }
        //˫��ѡ�е�ѧԱ������ʾ��ϸ��Ϣ
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        //�޸�ѧԱ����
        private void btnEidt_Click(object sender, EventArgs e)
        {
          
        }       
        //ɾ��ѧԱ����
        private void btnDel_Click(object sender, EventArgs e)
        {
          
        }
        private void FrmSearchStudent_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}