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

        }


        ////显示添加学员窗体
        //private void tsmiAddStudent_Click(object sender, EventArgs e)
        //{
        //    FrmAddStudent objAddStudent = new FrmAddStudent();
        //    objAddStudent.ShowDialog();
        //}

        //添加学员
        public static FrmAddStudent objFrmAddStudent = null; //窗体对象
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            if (objFrmAddStudent == null)
            {
                //创建实例化对象
                objFrmAddStudent = new FrmAddStudent();
                //显示对象
                objFrmAddStudent.Show();
            }
            else
            {
                objFrmAddStudent.Activate();//激活窗口
                objFrmAddStudent.WindowState = FormWindowState.Normal;//设置窗口状态
            }

        }
   
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
          
        }
        //显示成绩查询与分析窗口    
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
        }
        //退出系统
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        //成绩快速查询
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
       
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
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }
  
        private void tsmi_Card_Click(object sender, EventArgs e)
        {
          
        }


    }
}