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

namespace QuanLyDoiTuongXaHoi
{
    public partial class DangNhap : Form
    {
        private String ckeckAdmin;
        private String thongdiep;
        private String dataMK;
        private Boolean ckTDN = false;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void TenDN_Click(object sender, EventArgs e)
        {
            txtTenDN.Clear();
        }
        private void MatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.Clear();
        }

        private void MatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
        }
        SqlConnection conn = new SqlConnection(@"Data Source =LAP01-2K;Database=QLDoiTuongXaHoi;Integrated Security=True;");
        
        private Boolean dangNhap()
        {
            Boolean kq = false;
            try
            {
                conn.Open();
                String tk = txtTenDN.Text;
                String mk = txtMatKhau.Text;
                String sql = "select STT,MATKHAU,QUYEN from TAIKHOAN where TENDANGNHAP = '" +tk+ "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dt = cmd.ExecuteReader();
                if (dt.Read() == true)
                {
                    thongdiep = dt[0].ToString();
                    dataMK = dt[1].ToString();
                    ckeckAdmin = dt[2].ToString();
                    kq = true;
                    conn.Close();
                }
                
            }
            catch
            {
                MessageBox.Show("Sai tên đăng nhập!");
            }
            return kq;
        }
        private void DN()
        {
            if (txtTenDN.Text == "" || txtMatKhau.Text == "" || ckTDN == false)
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu", "Thông báo");
            }
            else
            {
                if (dangNhap() == true)
                {
                    if (txtMatKhau.Text == dataMK)
                    {
                        Giaodienchinh gdc = new Giaodienchinh();
                        this.Hide();
                        gdc.Message = thongdiep;
                        gdc.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK);
                        txtTenDN.Focus();
                    }
                }

            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult btn = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (btn == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            
            if (txtTenDN.Text == "" || ckTDN ==false)
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập", "Thông báo");
            }
            else
            {
                dangNhap();
                if (ckeckAdmin == "quantrivien")
                {
                    formQuenMK quenMK = new formQuenMK();
                    this.Hide();
                    quenMK.Message = txtTenDN.Text;
                    quenMK.Show();

                }
                else
                {
                    MessageBox.Show("Chức năng này chỉ dành cho quản trị viên \nBan vui lòng liên hệ Quản trị viên để lấy lại Mật Khẩu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
  
        }

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {
            ckTDN = true;
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
     
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            DN();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DN();
            }
        }
    }
}
