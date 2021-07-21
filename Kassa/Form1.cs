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
        public Form1()
        {
            InitializeComponent();
            // за допомогою нашої функції змінюємо колір заголовку groupBox
            GetColorTextGroupBox(groupBox1);
            GetColorTextGroupBox(groupBox2);
            GetColorTextGroupBox(groupBox3);
            var naftoProduct = new[] {"Дизпаливо", "A-95", "A-92", "A-80" };
            comboBox1.Items.AddRange(naftoProduct);
            comboBox1.SelectedIndex = 0; //вибір елемента по замовчуванню

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
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = priceA95.ToString();
            }

        }
    }
}
