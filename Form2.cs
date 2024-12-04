using MySql.Data.MySqlClient;
using BCrypt.Net;  // Thêm thư viện BCrypt.Net
using System;
using System.Windows.Forms;

namespace ProjectCuoiKyNET
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.label1.Click += new System.EventHandler(this.label1_Click);

        }
        private void label1_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi label1 được nhấn
            MessageBox.Show("Label1 clicked!");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = txtTenTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string email = txtEmail.Text;

            // Kiểm tra kết nối và lưu thông tin vào cơ sở dữ liệu
            try
            {
                // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(matKhau);

                // Câu lệnh SQL để thêm dữ liệu
                string query = "INSERT INTO Users (Username, PasswordHash, Email) VALUES (@Username, @PasswordHash, @Email)";

                // Chuỗi kết nối đến MySQL
                string connectionString = "Server=localhost;Database=UserManagement;Uid=root;Pwd=12345;";

                // Kết nối đến cơ sở dữ liệu MySQL
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Khởi tạo MySqlCommand
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@Username", tenTaiKhoan);
                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);  // Sử dụng mật khẩu đã mã hóa
                        command.Parameters.AddWithValue("@Email", email);

                        // Mở kết nối và thực thi câu lệnh
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký thành công!");

                        // Chuyển sang form khác
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

