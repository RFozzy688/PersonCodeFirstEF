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
        public Form1()
        {
            InitializeComponent();

            using (PersonContext db = new PersonContext())
            {
                List<Person> person = new List<Person>()
                {
                    new Person(){ Name = "Andrey", Age = 24, City = "Kyiv" },
                    new Person(){ Name = "Liza", Age = 18, City = "Kryvyi Rih" },
                    new Person(){ Name = "Oleg", Age = 15, City = "London" },
                    new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
                    new Person(){ Name = "Sergey", Age = 32, City = "Kyiv" }
                };

                db.Persons.AddRange(person);
                db.SaveChanges();
            }

            comboBox1.Items.Add("Выбрать людей, старших 25 лет");
            comboBox1.Items.Add("Выбрать людей, проживающих не в Киеве");
            comboBox1.Items.Add("Выбрать имена людей, проживающих в Киеве");
            comboBox1.Items.Add("Выбрать людей старших 35 лет с именем Sergey");
            comboBox1.Items.Add("Выбрать людей, проживающих в Кривом Роге");
        }
    }
}
