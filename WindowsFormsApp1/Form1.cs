using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string playerName1 = textBox1.Text, playerName2 = textBox2.Text;
            if (playerName1 == "" || playerName2 == "")
            {
                MessageBox.Show("Имена не могут быть пустыми");
            }
            else
            {
                var newForm = new Form2();
                newForm.PlayerName1 = playerName1;
                newForm.PlayerName2 = playerName2;
                newForm.Show();
                Program.Context.MainForm = newForm;
                Close();     
            }
        }
    }
}