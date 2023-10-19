using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonCodeFirstEF
{
    public partial class Form1 : Form
    {
        public delegate void SQLQueryDelegate();
        SQLQueryDelegate[] _query;
        public Form1()
        {
            InitializeComponent();

            //using (PersonContext db = new PersonContext())
            //{
            //    List<Person> person = new List<Person>()
            //    {
            //        new Person(){ Name = "Andrey", Age = 24, City = "Kyiv" },
            //        new Person(){ Name = "Liza", Age = 18, City = "Kryvyi Rih" },
            //        new Person(){ Name = "Oleg", Age = 15, City = "London" },
            //        new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
            //        new Person(){ Name = "Sergey", Age = 32, City = "Kyiv" }
            //    };

            //    db.Persons.AddRange(person);
            //    db.SaveChanges();
            //}

            _query = new SQLQueryDelegate[5];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Выбрать людей, старших 25 лет");
            comboBox1.Items.Add("Выбрать людей, проживающих не в Киеве");
            comboBox1.Items.Add("Выбрать имена людей, проживающих в Киеве");
            comboBox1.Items.Add("Выбрать людей старших 35 лет с именем Sergey");
            comboBox1.Items.Add("Выбрать людей, проживающих в Кривом Роге");

            _query[0] = Over25YearsOld;
            _query[1] = LivingNotInKyiv;
            _query[2] = LivingInKyiv;
            _query[3] = Over35YearsOldNameSergey;
            _query[4] = LivingInKrivoyRog;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _query[comboBox1.SelectedIndex]();
        }
        private void Over25YearsOld()
        {
            using (PersonContext db = new PersonContext())
            {
                var p = db.Persons.Where(o => o.Age >= 25).ToList();

                PrintTable(p);
            }
        }
        private void LivingNotInKyiv()
        {
            using (PersonContext db = new PersonContext())
            {
                var p = db.Persons.Where(o => o.City != "Kyiv").ToList();

                PrintTable(p);
            }
        }
        private void LivingInKyiv()
        {
            using (PersonContext db = new PersonContext())
            {
                var p = db.Persons.Where(o => o.City == "Kyiv").ToList();

                PrintTable(p);
            }
        }
        private void Over35YearsOldNameSergey()
        {
            using (PersonContext db = new PersonContext())
            {
                var p = db.Persons.Where(o => o.Name == "Sergey" && o.Age >= 35).ToList();

                PrintTable(p);
            }
        }
        private void LivingInKrivoyRog()
        {
            using (PersonContext db = new PersonContext())
            {
                var p = db.Persons.Where(o => o.City == "Kryvyi Rih").ToList();

                PrintTable(p);
            }
        }
        private void PrintTable(List<Person> p)
        {
            dataGridView1.DataSource = null;
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("City");

            foreach (var item in p)
            {
                DataRow row = dt.NewRow();
                row[0] = item.Id;
                row[1] = item.Name;
                row[2] = item.Age;
                row[3] = item.City;
                dt.Rows.Add(row);
            }

            dataGridView1.DataSource = dt;
        }
    }
}
