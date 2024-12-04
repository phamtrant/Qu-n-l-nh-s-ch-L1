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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form4 (nếu cần)
            Form4 form4 = new Form4();

            // Hiển thị Form4
            form4.Show();

            // Ẩn Form hiện tại (Form4 hoặc form gọi sự kiện này)
            this.Hide();
        }
    }
}
