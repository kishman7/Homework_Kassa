using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kassa
{
    public partial class Form1 : Form
    {
        void GetForm() // функція для виводу форми
        {
            InitializeComponent();
            // за допомогою нашої функції змінюємо колір заголовку groupBox
            GetColorTextGroupBox(groupBox1);
            GetColorTextGroupBox(groupBox2);
            GetColorTextGroupBox(groupBox3);
            var naftoProduct = new[] { "Дизпаливо", "A-95", "A-92", "A-80" };
            comboBox1.Items.AddRange(naftoProduct);
            comboBox1.SelectedIndex = 0; //вибір елемента по замовчуванню
        }
        public Form1()
        {
            GetForm();
        }

        //Функція для зміни заголовка коліру groupBox, без зміни коліру тексту всіх Control, які є в groupBox
        void GetColorTextGroupBox(GroupBox groupBox)
        {
            groupBox.ForeColor = Color.Blue;
            foreach (Control item in groupBox.Controls)
            {
                item.ForeColor = SystemColors.ControlText;
            }
        }
        double priceDT = 29.90; //ціна на ДТ
        double priceA95 = 33.50; //ціна на A95
        double priceA92 = 31.25; //ціна на A92
        double priceA80 = 28.30; //ціна на A80

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = priceDT.ToString();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = priceA95.ToString();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Text = priceA92.ToString();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Text = priceA80.ToString();
            }
            else
            {
                textBox1.Text = string.Empty;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = true;
        }

        double symaNaftoProduct = 0.00; // загальна сума чеку по Автозаправці
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (!string.IsNullOrEmpty(textBox2.Text)) // якщо поле не пусте
                {
                    symaNaftoProduct = Math.Round(double.Parse(textBox1.Text) * double.Parse(textBox2.Text), 2);
                    label9.Text = symaNaftoProduct.ToString();
                }
            }

            //label9.Text = (double.Parse(textBox3.Text) * double.Parse(textBox2.Text)).ToString();
            //label9.Leave =
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false;
            textBox2.ReadOnly = true;
            groupBox5.Text = "До видачі";
            label8.Text = "л.";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {

                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    label9.Text = Math.Round((double.Parse(textBox3.Text) / double.Parse(textBox1.Text)), 2).ToString();
                }
            }
        }
        double symaTotal = 0.0; // загальна сума по чеку

        private void timer1_Tick(object sender, EventArgs e) // обробка таймера
        {
            timer1.Stop(); // зупинка таймера
            var result = MessageBox.Show("Ви бажаєте завершити цей чек?", "Оберіть дію!", MessageBoxButtons.YesNo); // присвоюємо обєкт класу MessageBox в змінну result. MessageBoxButtons.YesNo встановлює кнопки "так" та "ні"
            if (result == DialogResult.Yes) // якщо натиснута кнопка "так" в MessageBox
            {
                symaTotal = symaNaftoProduct + symaKafe;
                label12.Text = symaTotal.ToString();
                //double.Parse(label12.Text); //додаємо в змінну кінцеве значення з label12
                symaTotal += symaTotal;
                this.Controls.Clear(); // то очищаємо всі Controls нашої форми
                GetForm(); // знову визиваємо форму
               

            }
            else
            {
                timer1.Start(); // інакше (тобто, коли натиснута клавіша "ні" в MessageBox), то знову запускаємо таймер
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            symaTotal = symaNaftoProduct + symaKafe;
            label12.Text = symaTotal.ToString();
            timer1.Start(); // запуск таймера
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // подія, яка показує, що буде після закриття форми
        {
            MessageBox.Show(symaTotal.ToString() + " грн.", "Ваш дохід за сьогоднішній день!");
        }

        //ціни на потрібні нам товари
        double priceHotDog = 44.50;
        double priceGamburger = 38.00;
        double pricePoteteusFri = 42.50;
        double priceCocaCola = 18.00;
        double symaKafe = 0.00; // загальна сума чеку по кафе

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox4.Text = priceHotDog.ToString();
            }
            else
            {
                textBox4.Text = string.Empty;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox6.Text = priceGamburger.ToString();
            }
            else
            {
                textBox6.Text = string.Empty;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox8.Text = pricePoteteusFri.ToString();
            }
            else
            {
                textBox8.Text = string.Empty;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox10.Text = priceCocaCola.ToString();
            }
            else
            {
                textBox10.Text = string.Empty;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //double symaTemp = 0.00;
                if (!string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    symaKafe += Math.Round(double.Parse(textBox4.Text) * double.Parse(textBox5.Text), 2);
                    label10.Text = symaKafe.ToString();
                }
                else
                {
                    //symaKafe -= symaTemp;
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (!string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    symaKafe += Math.Round(double.Parse(textBox6.Text) * double.Parse(textBox7.Text), 2);
                    label10.Text = symaKafe.ToString();
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                if (!string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    symaKafe += Math.Round(double.Parse(textBox8.Text) * double.Parse(textBox9.Text), 2);
                    label10.Text = symaKafe.ToString();
                }
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                if (!string.IsNullOrWhiteSpace(textBox11.Text))
                {
                    symaKafe += Math.Round(double.Parse(textBox10.Text) * double.Parse(textBox11.Text), 2);
                    label10.Text = symaKafe.ToString();
                }
            }
        }

       
    }
}
