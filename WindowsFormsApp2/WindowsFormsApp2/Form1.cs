using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.str.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            try
            {
                str = this.textBox1.Text;
                Properties.Settings.Default.str = str;
                Properties.Settings.Default.Save();
                MessageBox.Show(Logic.Orderliness(str), "Ответ");
            }
            catch(FormatException)
            {
                return;
            }

            
        }
    }

    public class Logic
    {
        public static string Orderliness(string str)
        {
            {
                string outMessage = "";
                string[] strSplit = str.Split(' ');
                int[] num = Array.ConvertAll(strSplit, int.Parse);

                int num1 = 0;
                bool f = true;
                for (int i = 0; i < num.Length; i++)
                {
                    if (num[i] > num1)
                    {
                        num1 = num[i];
                    }
                    else
                    {
                        outMessage = "Не упорядочена";
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    outMessage = "Упорядочена по возрастанию";
                }
                return outMessage;
            }
        }
    }
}
