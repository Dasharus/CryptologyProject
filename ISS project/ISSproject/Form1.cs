using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISSproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            freqRadioBut frm = new freqRadioBut();
            Hide();
            frm.ShowDialog();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            task2 frm = new task2();
            Hide();
            frm.ShowDialog();
        }

        private void GreatJobButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you very much! XOXO");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Close? Are you sure? ",
            "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            task3 frm = new task3();
            Hide();
            frm.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            task4 frm = new task4();
            Hide();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            task5 frm = new task5();
            Hide();
            frm.ShowDialog();
        }

        private void Options_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            task6 frm = new task6();
            Hide();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            taskRSA frm = new taskRSA();
            Hide();
            frm.ShowDialog();
        }
    }
}
