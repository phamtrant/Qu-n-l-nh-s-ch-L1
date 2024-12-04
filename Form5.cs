using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCuoiKyNET
{
    public partial class Form5 : Form
    {
        // Thêm thuộc tính ProductID
        public string ProductID { get; set; }

        private string connectionString = @"Data Source=.;Initial Catalog=LibraryDB;Integrated Security=True";

        public List<Sach> DanhSachSanPham = new List<Sach>(); // Danh sách sản phẩm

        public Form5()
        {
            InitializeComponent();

            // Dữ liệu mẫu
            DanhSachSanPham.Add(new Sach { MaSanPham = "SP01", TenSanPham = "Sách A", Gia = 50000 });
            DanhSachSanPham.Add(new Sach { MaSanPham = "SP02", TenSanPham = "Sách B", Gia = 70000 });
            DanhSachSanPham.Add(new Sach { MaSanPham = "SP03", TenSanPham = "Sách C", Gia = 90000 });

            // Gán dữ liệu vào DataGridView
            dataGridView1.DataSource = DanhSachSanPham;
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            // Hiển thị dữ liệu từ cơ sở dữ liệu khi form load
            LoadData();
        }


        // Phương thức này có thể được gọi khi cần
        private void DisplayProductDetails()
        {
            // Bạn có thể sử dụng ProductID ở đây
            MessageBox.Show("Product ID is: " + ProductID);
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM BorrowedBooks"; // Thay bằng tên bảng của bạn
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable; // Gắn dữ liệu vào DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void CapNhatDataGridView(List<Sach> danhSachMoi)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = danhSachMoi;
        }

        public class Sach
        {
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public decimal Gia { get; set; }
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true; // DataGridView sẽ tự tạo cột dựa trên nguồn dữ liệu

            try
            {
                if (e.RowIndex >= 0)
                {
                    // Lấy dòng được chọn
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    // Lấy thông tin sách
                    string maSach = row.Cells["MaSanPham"].Value?.ToString() ?? "Không rõ";
                    string tenSach = row.Cells["TenSanPham"].Value?.ToString() ?? "Không rõ";
                    int gia = row.Cells["Gia"].Value != null ? Convert.ToInt32(row.Cells["Gia"].Value) : 0;
                    int soLuong = row.Cells["SoLuong"].Value != null ? Convert.ToInt32(row.Cells["SoLuong"].Value) : 0;

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form4 (nếu cần)
            Form3 form3 = new Form3();

            // Hiển thị Form4
            form3.Show();

            // Ẩn Form hiện tại (Form3 hoặc form gọi sự kiện này)
            this.Hide();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string maSanPham = txtMaSach.Text.Trim();
            string tenSanPham = txtTenSach.Text.Trim();
            int gia = int.TryParse(txtGia.Text.Trim(), out int giaValue) ? giaValue : 0;
            int soLuong = int.TryParse(txtSoLuong.Text.Trim(), out int soLuongValue) ? soLuongValue : 0;

            if (string.IsNullOrEmpty(maSanPham) || string.IsNullOrEmpty(tenSanPham))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO BorrowedBooks (MaSanPham, TenSanPham, Gia, SoLuong) VALUES (@MaSanPham, @TenSanPham, @Gia, @SoLuong)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    command.Parameters.AddWithValue("@TenSanPham", tenSanPham);
                    command.Parameters.AddWithValue("@Gia", gia);
                    command.Parameters.AddWithValue("@SoLuong", soLuong);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại DataGridView
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
