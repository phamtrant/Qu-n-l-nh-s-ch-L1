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
using MySql.Data.MySqlClient;


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
            string username = txtTenTaiKhoan.Text;
            string password = txtMatKhau.Text;

            // Debug: Kiểm tra xem thông tin nhập vào có đúng không
            MessageBox.Show("Đang kiểm tra đăng nhập với:\nUsername: " + username + "\nPassword: " + password);

            string query = "SELECT PasswordHash FROM Users WHERE Username = @Username";

            using (MySqlConnection connection = new MySqlConnection("Server=localhost;Database=UserManagement;Uid=root;Pwd=12345;"))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();
                        MessageBox.Show("Kết nối cơ sở dữ liệu thành công!");

                        object result = command.ExecuteScalar();
                        // Debug: Kiểm tra kết quả của truy vấn
                        MessageBox.Show("Kết quả truy vấn: " + (result != null ? result.ToString() : "Không có dữ liệu"));

                        if (result != null)
                        {
                            string storedPasswordHash = result.ToString();

                            // Kiểm tra mật khẩu đã mã hóa
                            if (BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                            {
                                MessageBox.Show("Đăng nhập thành công!");
                                // Chuyển sang form khác
                                Form3 form3 = new Form3();
                                form3.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Mật khẩu không chính xác!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản không tồn tại!");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Debug: In ra thông báo lỗi
                        MessageBox.Show("Lỗi kết nối hoặc truy vấn: " + ex.Message);
                    }
                }
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
