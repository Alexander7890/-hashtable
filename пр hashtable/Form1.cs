using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace пр_hashtable
{
    public partial class Form1 : Form
    {
        Hashtable students = new Hashtable();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            int grade = int.Parse(textBox2.Text);
            string roomNumber = textBox3.Text;

            students.Add(roomNumber, new Student { Surname = surname, Grade = grade });

            listBox1.Items.Clear();
            foreach (DictionaryEntry entry in students)
            {
                listBox1.Items.Add($"{entry.Key}: {((Student)entry.Value).Surname}, {((Student)entry.Value).Grade}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string roomNumber = textBox3.Text;
            if (students.ContainsKey(roomNumber))
            {
                students.Remove(roomNumber);
            }

            listBox1.Items.Clear();
            foreach (DictionaryEntry entry in students)
            {
                listBox1.Items.Add($"{entry.Key}: {((Student)entry.Value).Surname}, {((Student)entry.Value).Grade}");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            string message = "";
            foreach (DictionaryEntry entry in students)
            {
                if (((Student)entry.Value).Surname == surname)
                {
                    message += $"{entry.Key}: {((Student)entry.Value).Surname}, {((Student)entry.Value).Grade}\n";
                }
            }
            MessageBox.Show(message);
        }
    }
}

