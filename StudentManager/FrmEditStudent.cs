using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Models;
using DAL;


namespace StudentManager
{
    public partial class FrmEditStudent : Form
    {
        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStudentService = new StudentService();
        public FrmEditStudent()
        {
            InitializeComponent();
            //��ʼ���༶������
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";
        }
        public FrmEditStudent(StudentExt objStudent)
            : this()
        {

            //��ʾѧԱ��Ϣ
            this.txtStudentId.Text = objStudent.StudentId.ToString();
            this.txtStudentName.Text = objStudent.StudentName;
            this.txtStudentIdNo.Text = objStudent.StudentIdNo;
            this.txtPhoneNumber.Text = objStudent.PhoneNumber;
            this.dtpBirthday.Text = objStudent.Birthday.ToShortDateString();
            this.txtAddress.Text = objStudent.StudentAddress;
            if (objStudent.Gender == "��") this.rdoMale.Checked = true;
            else this.rdoFemale.Checked = true;
            this.cboClassName.Text = objStudent.ClassName;
            this.txtCardNo.Text = objStudent.CardNo;
        }


        //�ύ�޸�
        private void btnModify_Click(object sender, EventArgs e)
        {
            #region ��֤��Ϣ

            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("ѧ����������Ϊ�գ�", "��ʾ��Ϣ");
                this.txtStudentName.Focus();
                return;
            }
            //��֤�Ա�
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("��ѡ��ѧ���Ա�", "��ʾ��Ϣ");
                return;
            }
            //��֤�༶
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶��", "��ʾ��Ϣ");
                return;
            }
            //��֤���֤���Ƿ����Ҫ��
            if (!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤�Ų�����Ҫ��", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                return;
            }
            //��֤���֤���Ƿ��ظ�
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim(), this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("���֤�Ų��ܺ�����ѧԱ���֤���ظ���", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //��֤���֤���Ƿ�ͳ����������Ǻ�
            string month = string.Empty;
            string day = string.Empty;
            if (Convert.ToDateTime(this.dtpBirthday.Text).Month < 10)
                month = "0" + Convert.ToDateTime(this.dtpBirthday.Text).Month;
            if (Convert.ToDateTime(this.dtpBirthday.Text).Day < 10)
                day = "0" + Convert.ToDateTime(this.dtpBirthday.Text).Day;
            string birthday = Convert.ToDateTime(this.dtpBirthday.Text).Year.ToString() + month + day;

            if (!this.txtStudentIdNo.Text.Trim().Contains(birthday))
            {
                MessageBox.Show("���֤�źͳ������ڲ�ƥ�䣡", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //��֤��������
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age < 18)
            {
                MessageBox.Show("ѧ�����䲻��С��18�꣡", "��֤��ʾ");
                return;
            }

            #endregion

            #region ��װѧ������

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
                if (objStudentService.ModifyStudent(objStudent) == 1)
                {
                    MessageBox.Show("ѧԱ��Ϣ�޸ĳɹ���", "��ʾ��Ϣ");           
                    this.DialogResult = DialogResult.OK;//�����޸ĳɹ�����Ϣ
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
    }
}