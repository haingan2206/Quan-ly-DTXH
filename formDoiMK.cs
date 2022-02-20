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
    public partial class formDoiMK : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");
        private string check;
        private string maDMK;
        public formDoiMK()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return maDMK; }
            set { maDMK = value; }
        }
        private void btnDMK_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDMK_Luu_Click(object sender, EventArgs e)
        {
            
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from TAIKHOAN where STT = '" + maDMK+ "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    check = dr[8].ToString();
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Error");
            }
            if (check == tbMK_cu.Text)
            {
                if (tbMK_moi.Text == tbXacnhanMK.Text)
                {
                    try
                    {
                        String query = "UPDATE TAIKHOAN SET MATKHAU =" + tbMK_moi.Text + " where STT = " + maDMK;

                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đổi thành công!");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi nhập dữ liệu!", "Error");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mật khẩu cũ!","Thông báo");
            }
            
        }

        private void tbMK_cu_TextChanged(object sender, EventArgs e)
        {
            // The password character is an asterisk.
            tbMK_cu.PasswordChar = '*';
        }

        private void tbMK_cu_Click(object sender, EventArgs e)
        {
            tbMK_cu.Clear();
        }

        private void tbMK_moi_TextChanged(object sender, EventArgs e)
        {
            // The password character is an asterisk.
            tbMK_moi.PasswordChar = '*';
        }

        private void tbXacnhanMK_TextChanged(object sender, EventArgs e)
        {
            // The password character is an asterisk.
            tbXacnhanMK.PasswordChar = '*';
        }

        private void tbMK_moi_Click(object sender, EventArgs e)
        {
            tbMK_moi.Clear();
        }

        private void tbXacnhanMK_Click(object sender, EventArgs e)
        {
            tbXacnhanMK.Clear();
        }
    }
}
