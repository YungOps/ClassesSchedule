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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox5.Text = WorkBase.SumString();
            zapolnenietabl();
        }

        private void button1_Click(object sender, EventArgs e)  //добавить
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "")
            {
                if (getSimvol(textBox1.Text) & getChislo(textBox2.Text) & getChislo(textBox3.Text) & getSimvol(textBox4.Text))
                {
                    WorkLesson temp = new WorkLesson();
                    temp = WorkLesson.zap(WorkLesson.newid(), textBox1.Text, dateTimePicker1.Value, Convert.ToInt32(textBox2.Text), float.Parse(textBox3.Text), textBox4.Text);

                    WorkBase.insertTable(temp);
                    textBox5.Text = WorkBase.SumString();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    zapolnenietabl();
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены коректно");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        private void button2_Click(object sender, EventArgs e)  //удалить
        {
            if(comboBox1.SelectedIndex != -1)
            {
                string idF = comboBox1.Text;
                WorkBase.delFromTable(idF);
                comboBox1.SelectedIndex = -1;
                textBox5.Text = WorkBase.SumString();
                zapolnenietabl();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        private void button3_Click(object sender, EventArgs e)  //обновить данные
        {

            if (comboBox2.Text != "" & textBox8.Text != "" & textBox9.Text != "" & textBox10.Text != "" & textBox11.Text != "")
            {
                if (getSimvol(textBox8.Text) & getChislo(textBox9.Text) & getChislo(textBox10.Text) & getSimvol(textBox11.Text))
                {
                    WorkLesson temp = new WorkLesson();  
                    temp = WorkLesson.zap(comboBox2.Text, textBox8.Text, dateTimePicker2.Value, Convert.ToInt32(textBox9.Text), float.Parse(textBox10.Text), textBox11.Text);
                    WorkBase.updateTable(temp);
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    comboBox2.SelectedIndex = -1;
                    zapolnenietabl();
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены коректно");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }
        private void button4_Click(object sender, EventArgs e)  //найти min
        {
            if (textBox12.Text != "")
            {
                string temp = string.Empty;
                temp = WorkBase.MinWorth(textBox12.Text);
                if (temp != "")
                {
                    textBox13.Text = temp;
                    textBox14.Text = WorkBase.MinName(textBox12.Text, temp);
                }
                else
                {
                    MessageBox.Show("Такого преподавателя нет");
                }
            }
            else
            {
                MessageBox.Show("Введите фамилию преподавателя");
            }
        }
        private void button5_Click(object sender, EventArgs e)  //сведения о N занятиях преподавателя Х с самой низкой стоимостью
        {
            if (textBox16.Text != "" & textBox15.Text != "")
            {
                if (getSimvol(textBox16.Text) & getChislo(textBox15.Text))
                {
                    textBox6.Text = WorkBase.poick(Convert.ToInt32(textBox15.Text), textBox16.Text);
                    if (textBox6.Text == "")
                    {
                        textBox6.Text = "Нет данных";
                    }
                }
                else
                {
                    textBox6.Text = "Не верно введены данные";
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        private static bool getSimvol(string data)
        {
            bool test = true;
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (!((data[i] >= 'А' & data[i] <= 'я') || (data[i] == ' ')))
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
        private static bool getChislo(string data)
        {
            bool test = true;
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (!(data[i] >= '0' & data[i] <= '9'))
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
        private static bool getidf(string data)
        {
        bool test = true;
            try
            {
                for (int i = 0; i<data.Length; i++)
                {
                    if (!((data[i] >= 'a' & data[i] <= 'z') || (data[i] >= '0' & data[i] <= '9') || (data[i] == '-')))
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox1.Text) == true)
            {
                textBox1.ForeColor = Color.Black;
                button1.Enabled = true;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
                button1.Enabled = false;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (getChislo(textBox2.Text) == true)
            {
                textBox2.ForeColor = Color.Black;
                button1.Enabled = true;
            }
            else
            {
                textBox2.ForeColor = Color.Red;
                button1.Enabled = false;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (getChislo(textBox3.Text) == true)
            {
                textBox3.ForeColor = Color.Black;
                button1.Enabled = true;
            }
            else
            {
                textBox3.ForeColor = Color.Red;
                button1.Enabled = false;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox4.Text) == true)
            {
                textBox4.ForeColor = Color.Black;
                button1.Enabled = true;
            }
            else
            {
                textBox4.ForeColor = Color.Red;
                button1.Enabled = false;
            }
        }      
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox8.Text) == true)
            {
                textBox8.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            else
            {
                textBox8.ForeColor = Color.Red;
                button3.Enabled = false;
            }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (getChislo(textBox9.Text) == true)
            {
                textBox9.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            else
            {
                textBox9.ForeColor = Color.Red;
                button3.Enabled = false;
            }
        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (getChislo(textBox10.Text) == true)
            {
                textBox10.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            else
            {
                textBox10.ForeColor = Color.Red;
                button3.Enabled = false;
            }
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox11.Text) == true)
            {
                textBox11.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            else
            {
                textBox11.ForeColor = Color.Red;
                button3.Enabled = false;
            }
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox12.Text) == true)
            {
                textBox12.ForeColor = Color.Black;
                button4.Enabled = true;
            }
            else
            {
                textBox12.ForeColor = Color.Red;
                button4.Enabled = false;
            }
        }
        private void textBox15_TextChanged(object sender, EventArgs e)
        {

            if (getChislo(textBox15.Text) == true)
            {
                textBox15.ForeColor = Color.Black;
                button5.Enabled = true;
            }
            else
            {
                textBox15.ForeColor = Color.Red;
                button5.Enabled = false;
            }
        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (getSimvol(textBox16.Text) == true)
            {
                textBox16.ForeColor = Color.Black;
                button5.Enabled = true;
            }
            else
            {
                textBox16.ForeColor = Color.Red;
                button5.Enabled = false;
            }
        }
        private void comboBox1_Click(object sender, EventArgs e)
        {
            zapcombo();
        }
        private void comboBox2_Click(object sender, EventArgs e)
        {
            zapcombo();
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text != "")
            { 
                textBox8.Text = WorkBase.openUpdateTable(comboBox2.Text, "name");
                dateTimePicker2.Value = Convert.ToDateTime(WorkBase.openUpdateTable(comboBox2.Text, "data"));
                textBox9.Text = WorkBase.openUpdateTable(comboBox2.Text, "time");
                textBox10.Text = WorkBase.openUpdateTable(comboBox2.Text, "worth");
                textBox11.Text = WorkBase.openUpdateTable(comboBox2.Text, "teacher");
            }
            
        }
        private void zapcombo()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            List<string> IDList = new List<string>();
            IDList = WorkBase.CollId();
            for (int i = 0; i < IDList.Count; i++)
            {
                comboBox1.Items.Add(IDList[i]);
                comboBox2.Items.Add(IDList[i]);
            }
        }
        private void zapolnenietabl()
        {
            List<WorkLesson> lessons = new List<WorkLesson>();
            lessons = WorkBase.sumlesson();
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < lessons.Count; i++)
            {
                dataGridView1.Rows.Insert(i);
                dataGridView1.Rows[i].Cells["ID_D"].Value = lessons[i].id;
                dataGridView1.Rows[i].Cells["NAME_D"].Value = lessons[i].name;
                dataGridView1.Rows[i].Cells["DATA_D"].Value = Convert.ToString(lessons[i].data.ToShortDateString());
                dataGridView1.Rows[i].Cells["TIME_D"].Value =   lessons[i].time;
                dataGridView1.Rows[i].Cells["WORTH_D"].Value = lessons[i].worth;
                dataGridView1.Rows[i].Cells["TEACHER_D"].Value = lessons[i].teacher;
            }
        }
    }
}
