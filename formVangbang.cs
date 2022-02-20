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
    public partial class formVangbang : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");
        private String maDT;
        private String maVB;
        private String menu;
        public formVangbang()
        {
            InitializeComponent();
        }
        public string Message
        {
            get { return maDT; }
            set { maDT = value; }
        }
        private void loadVangbang()
        {
            txtTenVB.Text = "";
            txtTenVB.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select HOTEN,NAMSINH,GIOITINH,ANHTHE from DOI_TUONG where TT = '" + maDT + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtHoten.Text = dr[0].ToString();
                    txtNamsinh.Text = dr[1].ToString();
                    txtGioitinh.Text = dr[2].ToString();
                    String s = dr[3].ToString();
                    if (s != "")
                    {
                        try
                        {
                            String anh = "DTimage\\" + s;
                            Image image = Image.FromFile(anh);
                            pictureBox1.Image = image;
                        }
                        catch
                        {
                            MessageBox.Show("Load ảnh thất bại!", "Lỗi");
                        }

                    }
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi tải dữ liệu");
            }
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select MAVB,TENVANGBANG FROM VANGBANG  where TT = '" + maDT + "'", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt;
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtTenVB.Text = "";
            txtTenVB.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            menu = "them";
        }

        private void formVangbang_Load(object sender, EventArgs e)
        {
            loadVangbang();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loadVangbang();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(menu == "them")
            {
                if (txtTenVB.Text != "")
                {
                    luuVangbang();
                    loadVangbang();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên Văng bằng");
                    txtTenVB.Focus();
                }
            }
            else
            {
                if (txtTenVB.Text != "")
                {
                    suaVangbang();
                    loadVangbang();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên Văng bằng");
                    txtTenVB.Focus();
                }
            }

       
        }
        private void luuVangbang()
        {

                try
                {
                    conn.Open();
                    string sql = "insert into VANGBANG(TT,TENVANGBANG) VALUES('"+maDT+"',N'"+txtTenVB.Text+"')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công! ");
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Lỗi không xác định");
                }            
        }
        private void suaVangbang()
        {
            try
            {
                conn.Open();
                string sql = "update VANGBANG set TENVANGBANG = N'" + txtTenVB.Text + "' WHERE MAVB = '"+maVB+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công! ");
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi không xác định");
            }
        }
        private void xoaVangbang()
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM VANGBANG WHERE MAVB = '" + maVB + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi không xác định");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                maVB = row.Cells[0].Value.ToString();
                txtTenVB.Text = row.Cells[1].Value.ToString();
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            menu = "sua";
            txtTenVB.Enabled = true;
            txtTenVB.Focus();
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult ms = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xóa văng bằng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ms == DialogResult.Yes)
            {
                xoaVangbang();
                loadVangbang();
            }
        }
    }
}
