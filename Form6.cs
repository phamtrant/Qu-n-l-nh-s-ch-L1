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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
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
