using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//引入中间件
using DAL;
using Models;


namespace StudentManager
{
    public partial class FrmUserLogin : Form
    {
        //创建数据访问类对象
        private SysAdminService sysAdminService = new SysAdminService();

        public FrmUserLogin()
        {
            InitializeComponent();
        }


        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //【1】用户数据验证
            //账号
           if (this.txtLoginId.Text.Trim().Length==0)
           {
                MessageBox.Show("请输入登录账号!","登录提示");
                this.txtLoginId.Focus();
                return;
           }
            //密码
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录密码!", "登录提示");
                this.txtLoginPwd.Focus();
                return;
            }

            //【2】封装对象
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text.Trim()
            };

            //【3】后台交互判断登录信息是否正确
            try
            {
                objAdmin = sysAdminService.AdminLogin(objAdmin);
                //如果登录成功
                if (objAdmin != null)
                {
                    //保存登录信息
                    Program.objCurrentAdmin = objAdmin;
                    //设置登录窗体的返回值
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("登录账号密码有误", "登录提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据访问出现异常,登录失败!原因:" + ex.Message);
            }
            


                
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 改善用户体验 --回车光标跳转
        //账号输入框
        private void txtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            //判断是否按下回车键
            if (e.KeyValue==13)
            {
                //登录账号框是否输入内容
                if (this.txtLoginId.Text.Trim().Length != 0)
                {
                    //将当前焦点跳转到密码框
                    this.txtLoginPwd.Focus();
                }
            }
        }
        //密码输入框
        private void txtLoginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            //判断是否按下回车键
            if (e.KeyValue == 13)
            {
                //调用登录按钮的事件
                btnLogin_Click(null, null);
            }
        }
        #endregion

    }
}
