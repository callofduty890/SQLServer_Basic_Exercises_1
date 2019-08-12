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
            if (this.cboClass.SelectionLength==-1)
            {
                MessageBox.Show("��ѡ��༶!", "��ʾ��Ϣ");
                return;
            }
            //��ֹ����������
            this.dgvStudentList.AutoGenerateColumns = false;//����ʾδ��װ����

            //ִ�в�ѯ
            this.dgvStudentList.DataSource = objStudentService.GetStudentByClass(this.cboClass.Text);
        }
        //����ѧ�Ų�ѯ
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length==0)
            {
                MessageBox.Show("������ѧ��");
                this.txtStudentId.Focus();
                return;
            }
            //��֤�Ƿ�������

            StudentExt objStudent = objStudentService.GetStudentById(this.txtStudentId.Text.Trim());
            if (objStudent==null)
            {
                MessageBox.Show("ѧԱѧϰ������!", "��ʾ��Ϣ");
                this.txtStudentId.Focus();
            }
            else
            {
                //��ѧԱ��ϸ��Ϣ������ʾ
                FrmStudentInfo objFrmStuInfor = new FrmStudentInfo(objStudent);
                objFrmStuInfor.Show();
            }

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
            //�ж��Ƿ�Ҫ�޸�
            if (this.dgvStudentList.RowCount==0)
            {
                MessageBox.Show("û��ѡ��Ҫ�޸ĵ���Ϣ!", "��ʾ��Ϣ");
                return;
            }
            //�ж��Ƿ�ǰ��ѡ�е�״̬
            if (this.dgvStudentList.CurrentRow==null)
            {
                MessageBox.Show("��ѡ��Ҫ�޸ĵ�ѧԱ��Ϣ!", "��ʾ��Ϣ");
                return;
            }
            //��ȡѧ��
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //��ȡҪ�޸ĵ�ѧԱ��ϸ��Ϣ
            StudentExt objStudent = objStudentService.GetStudentById(studentId);
            //��ʾҪ�޸ĵ�ѧԱ��Ϣ����
            FrmEditStudent objEditStudent = new FrmEditStudent(objStudent);
            //��ȡ����ִ�еĽ��
            DialogResult result = objEditStudent.ShowDialog();
            //�ж��޸��Ƿ�ɹ�
            if (result==DialogResult.OK)
            {
                btnQuery_Click(null, null);//ͬ����ʾˢ���޸ĵ���Ϣ
            }
            
        }       
        //ɾ��ѧԱ����
        private void btnDel_Click(object sender, EventArgs e)
        {
          
        }
        //����ر���Ӧ�¼�
        private void FrmSearchStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.objFrmStudentManage = null;//������ر�ʱ,��������������
        }
        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}