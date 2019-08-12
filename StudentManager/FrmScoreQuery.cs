using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DAL;


namespace StudentManager
{
    public partial class FrmScoreQuery : Form
    {
        private StudentClassService objClasservice = new StudentClassService();
        private ScoreListService objScoreService = new ScoreListService();

        private DataTable dtScoreList = null;

        public FrmScoreQuery()
        {
            InitializeComponent();

            //显示班级下拉框
            DataTable dt = objClasservice.GetAllClass().Tables[0];
            this.cboClass.DataSource = dt;
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.DisplayMember = "ClassName";

            //显示全部考试成绩
            dtScoreList = objScoreService.GetAllScoreList().Tables[0];
            this.dgvScoreList.DataSource = dtScoreList;//将DataTable作为数据源
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //根据班级名称动态筛选
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            this.dtScoreList.DefaultView.RowFilter = string.Format("ClassName='{0}'", this.cboClass.Text.Trim());
        }
        //显示全部成绩
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            this.dtScoreList.DefaultView.RowFilter = "ClassName like '%%'";
        }
        //根据C#成绩动态筛选
        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            if (this.txtScore.Text.Trim().Length == 0) return;
            if (!Common.DataValidate.IsInteger(this.txtScore.Text.Trim()))
            {
                this.txtScore.Text = "";
                return;
            }
            this.dtScoreList.DefaultView.RowFilter = string.Format("CSharp>{0}", this.txtScore.Text.Trim());
        }
    }
}

//测试选定的班级名称对应的班级编号
//MessageBox.Show(this.cboClass.SelectedValue.ToString(), "班级ID");