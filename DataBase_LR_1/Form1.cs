using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_LR_1
{
    public partial class Form1 : Form
    {
        private Form2 form2 = new Form2();
        private Form3 form3 = new Form3();
        public Form1()
        {
            InitializeComponent();
            AddOwnedForm(form2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            form3.ShowDialog();
        }
    }
}
