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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng bấm vào cột nút bấm "Chi tiết"
            if (dgvSanPham.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Lấy dữ liệu sản phẩm từ dòng được nhấn
                string maSanPham = dgvSanPham.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();
                string tenSanPham = dgvSanPham.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
                int gia = Convert.ToInt32(dgvSanPham.Rows[e.RowIndex].Cells["Gia"].Value);

                // Hiển thị chi tiết sản phẩm (có thể thay bằng một form mới hoặc message box)
                MessageBox.Show($"Chi tiết sản phẩm:\nMã: {maSanPham}\nTên: {tenSanPham}\nGiá: {gia} VND",
                                "Thông tin sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo một instance của Form4
            Form4 form4 = new Form4();

            // Hiển thị Form4
            form4.Show();

            // Ẩn Form3 nếu cần
            this.Hide();
        }
    }
}
