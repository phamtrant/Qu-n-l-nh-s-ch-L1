using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCuoiKyNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo một instance của Form4
            Form3 form3 = new Form3();

            // Hiển thị Form4
            form3.Show();

            // Ẩn Form3 nếu cần
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo một instance của Form4
            Form2 form2 = new Form2();

            // Hiển thị Form4
            form2.Show();

            // Ẩn Form3 nếu cần
            this.Hide();
        }
    }
}
