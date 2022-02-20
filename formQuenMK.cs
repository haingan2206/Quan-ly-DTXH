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
    public partial class formQuenMK : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");
        private string stt;
        private String MaBV = "admin12345";
        private String Hoten;
        private Boolean ckeckTK = false;
        public string Message
        {
            get { return stt; }
            set { stt = value; }
        }
        public formQuenMK()
        {
            InitializeComponent();
            
        }
       
        private void layTenTK()
        {
            ckeckTK = false;
            txtTenTK.Text = "";
            try
            {
                conn.Open();
                String sql = "select HOVATEN FROM TAIKHOAN where TENDANGNHAP  = '" + tbTDN.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtTenTK.Text = dr[0].ToString();
                    Hoten = dr[0].ToString();
                    ckeckTK = true;
                }
                conn.Close();
            }
            catch
            {
            }
        }
        private void doiMK()
        {
            
            try
            {
                String query = "UPDATE TAIKHOAN SET MATKHAU = '" + tbMK_moi.Text + "' WHERE TENDANGNHAP = '" + tbTDN.Text + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công");
                conn.Close();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Error");
            }
        }
        private void btnDMK_Luu_Click(object sender, EventArgs e)
        {
            if(ckeckTK == true)
            {
                if(txtMaBV.Text == MaBV)
                {
                    if(tbMK_moi.Text == tbXacnhanMK.Text & tbMK_moi.Text!="")
                    {
                        DialogResult d = MessageBox.Show("Bạn có chắc muốn đổi mật khẩu của tài khoản "+Hoten+" không?", "Hủy lưu", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if (d == DialogResult.Yes)
                        {
                            doiMK();
                            DangNhap dn = new DangNhap();
                            this.Hide();
                            dn.Show();                           
                        }
                        
                    }
                    else
                    {
                        txtThongbao.Text = "Mật khẩu không đúng";
                    }
                }
                else
                {
                    MessageBox.Show("Mã bảo vệ không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Tên đăng nhập không đúng!");
                tbTDN.Focus();
            }
            
        }

        private void btnDMK_Huy_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            this.Hide();
            dn.Show();

        }

        private void formQuenMK_FormClosed(object sender, FormClosedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void tbTDN_TextChanged(object sender, EventArgs e)
        {
            layTenTK();
        }

        private void formQuenMK_Load(object sender, EventArgs e)
        {
            txtThongbao.Text = "";
            tbTDN.Text = stt;
        }

        private void tbMK_moi_TextChanged(object sender, EventArgs e)
        { 
                tbMK_moi.PasswordChar = '*';                    
        }

        private void tbXacnhanMK_TextChanged(object sender, EventArgs e)
        {
                tbXacnhanMK.PasswordChar = '*';        
        }
    }
}
