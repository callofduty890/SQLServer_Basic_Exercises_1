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
        //ע��this()��ʹ��FrmStudentIfo()������캯��
        public FrmStudentInfo(StudentExt objStudent):this()
        {

            //��ʾѧԱ��Ϣ
            this.lblStudentName.Text = objStudent.StudentName;
            this.lblStudentIdNo.Text = objStudent.StudentIdNo;
        }

        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}