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
    public partial class Giaodienchinh : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source =LAP01-2K;Database=QLDoiTuongXaHoi;Integrated Security=True;");
        private string _message;
        private string maTinh;
        private Boolean checkDX = false;
        private void ketnoicsdl()
        {
            try
            {
                conn.Open();
                string sql = "SELECT TT, MADT, HOTEN, GIOITINH, GHICHU FROM dbo.DOI_TUONG where stt = '" + _message + "'";
                SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            }
            catch
            {
                MessageBox.Show("Lỗi tải dữ liệu", "Lỗi");
            }
            demDong();

        }
        private void loadTatca()
        {
            try
            {
                conn.Open();
                string sql = "SELECT TT, MADT, HOTEN, GIOITINH, GHICHU FROM dbo.DOI_TUONG";
                SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            }
            catch
            {
                MessageBox.Show("Lỗi tải dữ liệu", "Lỗi");
            }
            demDong();
        }
        private void demDong()
        {
            lbSoDT.Text = "00";
            if (dataGridView1.RowCount > 1)
            {
                    int iCount = dataGridView1.RowCount - 1;
                 
                    lbSoDT.Text = iCount.ToString();
            }
           
        }

        public Giaodienchinh()
        {
            InitializeComponent();
            
        }
        //Hàm lấy thông điệp từ form trước
        private string maDT;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }



        private void MenuInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm quản lý đối tượng xã hội\n-------------\nTrung tâm Công tác xã hội Thanh niên TP.HCM\n-------------\nThiết kế bởi HaiNganScientist", "Thông báo", MessageBoxButtons.OK);
        }
        private void quanLyTK()
        {
            fQuanlyTK QLTK = new fQuanlyTK();
            QLTK.Message = _message;
            QLTK.ShowDialog();
        }
        private void quảnLýTàiKhoảnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            quanLyTK();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lich lich = new Lich();
            lich.Show();
        }

        private void thêmĐốiTượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formThemDTXH fdtxh = new formThemDTXH();
            fdtxh.Message = _message;
            fdtxh.ShowDialog();
        }

        private void thoátChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private Boolean checkQuyen()
        {
            Boolean ck = false;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from TAIKHOAN where STT = " + _message, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lbTenND.Text = dr[1].ToString();
                    String s = dr[9].ToString();
                    conn.Close();
                    if (s == "quantrivien")
                    {
                        ck = true;
                    }

                }

            }
            catch
            {
                MessageBox.Show("Lỗi Không xác định", "Có lỗi");
            }

            return ck;
        }
        private void thêmCánBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    if (checkQuyen() == true)
                    {
                        formThemCanBo themCB = new formThemCanBo();
                        themCB.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bạn không phải là quản trị viên!", "Thông báo");
                    }            
        }
        private void loadThongtin()
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from TAIKHOAN where STT = " + _message, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lbTenND.Text = dr[1].ToString();
                    String s = dr[10].ToString();
                    if (s != "")
                    {
                        try
                        {
                            String anh = "image\\" + s;
                            Image image = Image.FromFile(anh);
                            hinhtron1.Image = image;
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi load avata","Lỗi");
                        }

                    }
                    conn.Close();

                }
            }
            catch
            {
                MessageBox.Show("Lỗi Không xác định", "Có lỗi");
            }

        }
        private void layTinh()
        {
            conn.Open();
            string sql = "select * FROM dbo.TINH";  // lay het du lieu
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }
            catch
            {

            }

            try
            {
                cbTinhthanh.DataSource = dt;
                cbTinhthanh.DisplayMember = "TENTINH";
                cbTinhthanh.ValueMember = "MATINH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }


        private void layHuyen()
        {
            conn.Open();
            string sql = "select * FROM dbo.HUYEN where MATINH ='" + maTinh + "'";  // lay het du lieu
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }
            catch
            {

            }

            try
            {
                cbQuanhuyen.DataSource = dt;
                cbQuanhuyen.DisplayMember = "TENHUYEN";
                cbQuanhuyen.ValueMember = "MAHUYEN";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }
        }
        public void Giaodienchinh_Load(object sender, EventArgs e)
        {
            loadThongtin();
            ketnoicsdl();
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "select TT, MADT, HOTEN, GIOITINH, GHICHU FROM dbo.DOI_TUONG where (HOTEN  LIKE N'%" + txtTimkiem.Text + "%' or MADT  LIKE '%" + txtTimkiem.Text + "%') and (stt = '"+_message+"')";
                SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
                
            }
            catch
            {
                
            }
            demDong();
        }

        private void Giaodienchinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkDX==false)
            {
                DialogResult TL;
                TL = MessageBox.Show("Bạn Có Muốn Thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TL == DialogResult.Yes)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
       
        }

        private void Giaodienchinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(checkDX == false)
            {
                Application.Exit();
            }

        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadThongtin();
            ketnoicsdl();
        }

        private void cbTinhthanh_MouseClick(object sender, MouseEventArgs e)
        {
            layTinh();
        }

        private void cbQuanhuyen_MouseClick(object sender, MouseEventArgs e)
        {
            maTinh = cbTinhthanh.SelectedValue.ToString();
            layHuyen();
        }

        private void cbTinhthanh_SelectedValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                conn.Open();
                string sql = "SELECT TT, MADT, HOTEN, GIOITINH, GHICHU FROM dbo.DOI_TUONG WHERE MATINH = '"+cbTinhthanh.SelectedValue.ToString()+"'";
                SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            }
            catch
            {
                MessageBox.Show("Lỗi tải dữ liệu", "Lỗi");
            }
            demDong();*/
        }

        private void cbQuanhuyen_SelectedValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                conn.Open();
                string sql = "SELECT TT, MADT, HOTEN, GIOITINH, GHICHU FROM dbo.DOI_TUONG WHERE MAHUYEN = '" + cbQuanhuyen.SelectedValue.ToString() + "'";
                SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            }
            catch
            {
                MessageBox.Show("Lỗi tải dữ liệu", "Lỗi");
            }
            demDong();*/
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            quanLyTK();
        }
        private void dangXuat() 
            {
            DialogResult d = MessageBox.Show("Bạn có muốn đăng xuất không? ", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                checkDX = true;
                DangNhap dn = new DangNhap();
                this.Hide();
                dn.Show();
            } 
            } 
        private void menuDangxuat_Click(object sender, EventArgs e)
        {
            dangXuat();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            dangXuat();
        }

        private void btnVanggia_Click(object sender, EventArgs e)
        {
            formVanggia vg = new formVanggia();
            vg.Message = maDT;
            vg.ShowDialog();
        }

        private void btnXemCT_Click(object sender, EventArgs e)
        {
            formXemCTDT xct = new formXemCTDT();
            xct.Message = maDT;
            xct.ShowDialog();
            
        }

        private void menuXemTC_Click(object sender, EventArgs e)
        {
            if (checkQuyen() == true)
            {
                loadTatca();
            }
            else
            {
                MessageBox.Show("Bạn không phải là quản trị viên!", "Thông báo");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formVangbang vb = new formVangbang();
            vb.Message = maDT;
            vb.ShowDialog();
        }
        private void menuXemCT_Click(object sender, EventArgs e)
        {
            formXemCTDT xct = new formXemCTDT();
            xct.Message = maDT;
            xct.ShowDialog();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            formCapnhatDT cn = new formCapnhatDT();
            cn.Message = maDT;
            cn.ShowDialog();
        }

        private void menuCapnhat_Click(object sender, EventArgs e)
        {
            formCapnhatDT cn = new formCapnhatDT();
            cn.Message = maDT;
            cn.ShowDialog();
        }

        private void menuVanggia_Click(object sender, EventArgs e)
        {
            formVanggia vg = new formVanggia();
            vg.Message = maDT;
            vg.ShowDialog();
        }

        private void menuHoigia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang được cập nhật", "Thông báo!");
        }

        private void menuQLVAngbang_Click(object sender, EventArgs e)
        {
            formVangbang vb = new formVangbang();
            vb.Message = maDT;
            vb.ShowDialog();
        }


        private void ctmenuThoatchuongtrinh_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ctmenuXemtatca_Click(object sender, EventArgs e)
        {
            if (checkQuyen() == true)
            {
                loadTatca();
            }
            else
            {
                MessageBox.Show("Bạn không phải là quản trị viên!", "Thông báo");
            }
        }

        private void btnHoigia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang được cập nhật", "Thông báo!");
        }

        private void btnXuatphieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang được cập nhật", "Thông báo!");
        }

        private void menuXuatphieuchuyen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang được cập nhật", "Thông báo!");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "SELECT TT, MADT, HOTEN, GIOITINH, GHICHU FROM dbo.DOI_TUONG WHERE STT = '"+_message+"' and MAHUYEN = '" + cbQuanhuyen.SelectedValue.ToString() + "'";
                SqlCommand com = new SqlCommand(sql, conn); //bat dau truy van
                com.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
                DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
                da.Fill(dt);  // đổ dữ liệu vào kho
                conn.Close();  // đóng kết nối
                dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            }
            catch
            {
                MessageBox.Show("Lỗi tải dữ liệu", "Lỗi");
            }
            demDong();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                maDT = row.Cells[0].Value.ToString();
                txtNguoiduocchon.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
