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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }

        private Form5 form5; // Tham chiếu đến Form3

        public Form4(Form5 form)
        {
            InitializeComponent();
            form5 = form; // Lưu tham chiếu của Form3
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa từ TextBox
            string keyword = txtSearch.Text.Trim().ToLower();

            // Lấy danh sách sản phẩm từ Form5
            var danhSachSanPham = form5.DanhSachSanPham;

            // Tìm kiếm các sản phẩm chứa từ khóa
            var ketQuaTimKiem = danhSachSanPham
                .Where(sp => sp.TenSanPham.ToLower().Contains(keyword))
                .ToList();

            // Cập nhật lại DataGridView của Form5
            form5.CapNhatDataGridView(ketQuaTimKiem);

            // Hiển thị thông báo nếu không tìm thấy sản phẩm nào
            if (ketQuaTimKiem.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public class Sach
        {
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public decimal Gia { get; set; }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form4 (nếu cần)
            Form3 form3 = new Form3();

            // Hiển thị Form4
            form3.Show();

            // Ẩn Form hiện tại (Form3 hoặc form gọi sự kiện này)
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();

            // Hiển thị Form4
            form6.Show();

            // Ẩn Form hiện tại (Form3 hoặc form gọi sự kiện này)
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Tạo instance của Form5
            Form5 form5 = new Form5();

            // Truyền thông tin sản phẩm nếu cần
            form5.ProductID = "SP01"; // Truyền mã sản phẩm (nếu bạn có thuộc tính này trong Form5)

            // Hiển thị Form5
            form5.Show();

            // Ẩn form hiện tại (Form4)
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form4 (nếu cần)
            Form7 form7 = new Form7();

            // Hiển thị Form4
            form7.Show();

            // Ẩn Form hiện tại (Form4 hoặc form gọi sự kiện này)
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form4 (nếu cần)
            Form8 form8 = new Form8();

            // Hiển thị Form4
            form8.Show();

            // Ẩn Form hiện tại (Form4 hoặc form gọi sự kiện này)
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form4 (nếu cần)
            Form9 form9 = new Form9();

            // Hiển thị Form4
            form9.Show();

            // Ẩn Form hiện tại (Form4 hoặc form gọi sự kiện này)
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra tham chiếu đến Form5 (đảm bảo form5 được truyền vào và có dữ liệu)
            if (form5 == null || form5.DanhSachSanPham == null)
            {
                MessageBox.Show("Form sản phẩm chưa được mở hoặc dữ liệu chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy từ khóa tìm kiếm
            string keyword = txtSearch.Text.Trim().ToLower();

            // Lọc danh sách sản phẩm theo từ khóa
            var ketQuaTimKiem = form5.DanhSachSanPham
                .Where(sp => sp.TenSanPham.ToLower().Contains(keyword))
                .ToList();

            // Gọi phương thức cập nhật DataGridView trong Form5
            form5.CapNhatDataGridView(ketQuaTimKiem);

            // Kiểm tra nếu không tìm thấy sản phẩm
            if (ketQuaTimKiem.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Đảm bảo không mở lại form đã mở sẵn
            if (!form5.Visible)
            {
                form5.Show(); // Chỉ hiển thị lại nếu form đang bị ẩn
            }

            // Ẩn Form4 (nếu cần thiết)
            this.Hide();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
