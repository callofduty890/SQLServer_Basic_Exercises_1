using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace StudentManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //创建登录窗口
            FrmUserLogin objFrmLogin = new FrmUserLogin();
            //设定为当前窗口所有者控制-也就是这个窗体结束后才能接着下面运行
            DialogResult result = objFrmLogin.ShowDialog();

            //判断登录是否成功
            if (result == DialogResult.OK)
            {
                //运行主窗体
                Application.Run(new FrmMain());
            }
            else
            {
                //退出整个应用程序
                Application.Exit();
            }
            
        }

    }
}
