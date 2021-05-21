using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ThucTap2
{
    public partial class frmDangNhap : Form
    {
        
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private string getId(string user, string pass)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-NALUFR0D\MSSQLSERVER01;Initial Catalog=Mixue;Integrated Security=True");
            string id = "";
            SqlCommand cmd = new SqlCommand("Select * from tblTaiKhoan where TenDangNhap = N'" + txtTenDangNhap.Text + "'" +
                "and MatKhau=N'" + txtMatKhau.Text + "'", conn);
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["Id"].ToString();
                }
            }
            return id;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string sql="Select * from tblTaiKhoan where TenDangNhap=N'" + txtTenDangNhap.Text + "'" +
                "and MatKhau=N'" + txtMatKhau.Text + "'";
            string id_user;
            id_user = getId(txtTenDangNhap.Text, txtMatKhau.Text);
            if (id_user != "")
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                Form main = new frmPhieuNhapKho(); //sửa frmPhieuNhapKho thành form chính nhá
                main.Show();
            }
            else 
            {
                MessageBox.Show("Đăng nhập không thành công!");
                txtTenDangNhap.Text = "";
                txtMatKhau.Text = "";
                txtTenDangNhap.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
