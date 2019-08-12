using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Models;

namespace StudentManager
{
    public partial class FrmStudentInfo : Form
    {
        public FrmStudentInfo()
        {
            InitializeComponent();



        }
        public FrmStudentInfo(StudentExt objStudent)
            : this()
        {
            //��ʾѧԱ��Ϣ
            this.lblStudentName.Text = objStudent.StudentName;
            this.lblStudentIdNo.Text = objStudent.StudentIdNo;
            this.lblPhoneNumber .Text = objStudent.PhoneNumber;
            this.lblBirthday.Text = objStudent.Birthday.ToShortDateString();
            this.lblAddress.Text = objStudent.StudentAddress;
            this.lblGender.Text = objStudent.Gender;
            this.lblClass.Text = objStudent.ClassName;
            this.lblCardNo.Text = objStudent.CardNo;

        }
        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}