using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        // Метод для додавання або редагування студента
        private void AddOrUpdateStudent(string roomNumber, string surname, int grade)
        {
            if (students.ContainsKey(roomNumber))
            {
                students[roomNumber] = new Student { Surname = surname, Grade = grade };
            }
            else
            {
                students.Add(roomNumber, new Student { Surname = surname, Grade = grade });
            }
            UpdateListBox();
        }

        // Метод для видалення студента
        private void RemoveStudent(string roomNumber)
        {
            if (students.ContainsKey(roomNumber))
            {
                students.Remove(roomNumber);
                UpdateListBox();
            }
        }

        // Метод для оновлення списку у ListBox
        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (DictionaryEntry entry in students)
            {
                listBox1.Items.Add($"{entry.Key}: {((Student)entry.Value).Surname}, {((Student)entry.Value).Grade}");
            }
        }
        // Додавання студента
        private void button1_Click_1(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            int grade = int.Parse(textBox2.Text);
            string roomNumber = textBox3.Text;

            AddOrUpdateStudent(roomNumber, surname, grade);
        }

        // Видалення студента
        private void button2_Click(object sender, EventArgs e)
        {
            string roomNumber = textBox3.Text;
            RemoveStudent(roomNumber);
        }

        // Пошук студента
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

        // Редагування студента
        private void button4_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text;
            int grade = int.Parse(textBox2.Text);
            string roomNumber = textBox3.Text;

            AddOrUpdateStudent(roomNumber, surname, grade);
        }
    }
}
