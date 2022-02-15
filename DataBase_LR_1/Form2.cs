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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }
        private static bool getSimvol(string data)
        {
            bool test = true;
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (!(data[i] >= 'a' & data[i] <= 'z'))
                    {
                        test = false;
                    }
                }

            }
            catch (IndexOutOfRangeException)
            {
                test = false;
            }
            return test;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WorkBase.CreateLesson();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Таблица уже создана");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                WorkBase.CreateTable(textBox1.Text);
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Таблица уже создана");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                WorkBase.AddColumn(textBox2.Text, textBox3.Text, comboBox1.Text);
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("В этой таблице уже есть такой столбец");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                WorkBase.DelColumn(textBox4.Text, textBox5.Text);
            }
            catch (MySql.Data.MySqlClient.MySqlException myexp)
            {
                string m = myexp.Message;
                if (m.Contains("Table") & m.Contains("doesn't exist"))
                {
                    MessageBox.Show("Введенной таблицы не существует");
                }
                if (m.Contains("check that column/key exists"))
                {
                    MessageBox.Show("В этой таблицы нет такого солбца");
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                WorkBase.DelTable(textBox6.Text);
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Нельзя удалить таблицу, которой нет");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox1.Text) == true)
            {
                textBox1.ForeColor = Color.Black;
                button2.Enabled = true;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
                button2.Enabled = false;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox2.Text) == true)
            {
                textBox2.ForeColor = Color.Black;
                button3.Enabled = true;

            }
            else
            {
                textBox2.ForeColor = Color.Red;
                button3.Enabled = false;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox3.Text) == true)
            {
                textBox3.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            else
            {
                textBox3.ForeColor = Color.Red;
                button3.Enabled = false;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox4.Text) == true)
            {
                textBox4.ForeColor = Color.Black;
                button5.Enabled = true;
            }
            else
            {
                textBox4.ForeColor = Color.Red;
                button5.Enabled = false;
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox5.Text) == true)
            {
                textBox5.ForeColor = Color.Black;
                button5.Enabled = true;
            }
            else
            {
                textBox5.ForeColor = Color.Red;
                button5.Enabled = false;
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox6.Text) == true)
            {
                textBox6.ForeColor = Color.Black;
                button4.Enabled = true;
            }
            else
            {
                textBox6.ForeColor = Color.Red;
                button4.Enabled = false;
            }
        }
    }
}
