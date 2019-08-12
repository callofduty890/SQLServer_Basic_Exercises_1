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
    public partial class FrmEditStudent : Form
    {
        public StudentClassService objClassService = new StudentClassService();
        private StudentService objStudentService = new StudentService();
        //public StudentExt from_StudentExt;

        public FrmEditStudent()
        {
            InitializeComponent();
            //��ʼ��������
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            //������ʾ����
            this.cboClassName.DisplayMember = "ClassName";
            //���ö�Ӧ�İ༶ID
            this.cboClassName.ValueMember = "ClassId";
        }

        public FrmEditStudent(StudentExt objStudent):this()
        {
            //��ʾѧԱ��Ϣ
            this.txtStudentName.Text = objStudent.StudentName;
            this.txtStudentIdNo.Text = objStudent.StudentIdNo;
            this.txtAddress.Text = objStudent.StudentAddress;
            this.dtpBirthday.Text = objStudent.Birthday.ToShortDateString();
            this.txtCardNo.Text = objStudent.CardNo;
            this.cboClassName.Text = objStudent.ClassName;
            if (objStudent.Gender == "��")
            {
                this.rdoMale.Checked = true;
            }
            else
            {
                this.rdoFemale.Checked = true;
            }
            this.txtPhoneNumber.Text = objStudent.PhoneNumber;

        }

        //�ύ�޸�
        private void btnModify_Click(object sender, EventArgs e)
        {
            #region ��֤��Ϣ
            //�����ѧԱһ��
            //�ж����֤���Ƿ��ظ�
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim(),this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("���֤���ܺ�����ѧԱ���֤���ظ�!", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
            }



            #endregion

            #region ��װѧ��������Ϣ
                Student objStudent = new Student()
                {
                    StudentId = Convert.ToInt32(this.txtStudentId.Text.Trim()),
                    StudentName = this.txtStudentName.Text.Trim(),
                    Gender = this.rdoMale.Checked ? "��" : "Ů",
                    Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                    StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                    PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                    StudentAddress = this.txtAddress.Text.Trim(),
                    CardNo = this.txtCardNo.Text.Trim(),
                    ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//��ȡѡ��༶��Ӧ��ClassId
                    Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year
                };
            #endregion

            #region �ύ�޸�
            try
            {
                if (objStudentService.ModifyStudent(objStudent)==1)
                {
                    MessageBox.Show("ѧԱ��Ϣ�޸ĳɹ�!","��ʾ��Ϣ");
                    this.DialogResult = DialogResult.OK;//�����޸ĳɹ�����ʾ��Ϣ
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //��������¼�
        private void FrmEditStudent_Load(object sender, EventArgs e)
        {
        }
    }
}