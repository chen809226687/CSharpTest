using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }





        #region 特性
        private void button1_Click(object sender, EventArgs e)
        {
            OldMethod();
        }


        [Obsolete("OldMethod 已弃用，请改用 NewMethod", false)]
        void OldMethod()
        {
            Console.WriteLine("已弃用的函数");
        }
        void NewMethod()
        {
            Console.WriteLine("新定义的函数");
        }
        #endregion
    }
}
