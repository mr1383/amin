using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace ProejectGamenet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                label3.Text = "نام کاربری را وارد کنید";
                textBox1.Focus();
            }
            else if (textBox2.Text.Trim().Length == 0)
            {
                label3.Text = "کلمه عبور را وارد کنید";
                textBox2.Focus();
            }
            else
            {
                blhuman o = new blhuman();
                if (o.login(textBox2.Text, textBox1.Text) == true)
                {

                    Form2 frm2 = new Form2();
                    frm2.Show();
                    this.Hide();

                }
                else
                {
                    label3.Text = "نام کاربری یا پسوورد اشتباه است";
                }
            }
        }
    }
}
