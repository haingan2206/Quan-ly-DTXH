using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoiTuongXaHoi
{
    public partial class formCapnhatDT : Form
    {
        public formCapnhatDT()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");
        private string maDT;
        private string hinhanh;
        public static String maTinh, maHuyen;
        Boolean c1 = false, c2 = false, c3 = false;
        public string Message
        {
            get { return maDT; }
            set { maDT = value; }
        }



        

        private void button1_Click(object sender, EventArgs e)
        {
            




        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc muốn hủy không", "Hủy lưu", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                this.Close();
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
                cbTinhThanh.DataSource = dt;
                cbTinhThanh.DisplayMember = "TENTINH";
                cbTinhThanh.ValueMember = "MATINH";
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


        private void cbTinhThanh_MouseClick(object sender, MouseEventArgs e)
        {
            c1 = true;
            layTinh();

        }

        private void cbQuanhuyen_MouseClick(object sender, MouseEventArgs e)
        {
            c2 = true;
            maTinh = cbTinhThanh.SelectedValue.ToString();
            layHuyen();
        }
        private Boolean avata = false;
        private void capnhatDoiTuong()
        {

            String  sHoten, sTuoi, sGioitinh, sXa;
            String sTC, sTT, sTLTC, sTTKhac, sCanT, sHauQ, sGiacanh;


            sHoten = txtHoten.Text;
            sTuoi = numTuoi.Text;
            sGioitinh = cbGioitinh.SelectedItem.ToString();




            sXa = txtXaphuong.Text;
            if (ckCo_thechat.Checked == true)
            {
                sTC = txtThechat.Text;
            }
            else
            {
                sTC = "Khong";
            }
            if (ckCo_tinhthan.Checked == true)
            {
                sTT = txtTinhthan.Text;
            }
            else
            {
                sTT = "Khong";
            }
            if (ckCo_tinhcam.Checked == true)
            {
                sTLTC = txtTinhcam.Text;
            }
            else
            {
                sTLTC = "Khong";
            }
            sTTKhac = txtTinhrangkhac.Text;
            sCanT = txtDacanthiep.Text;
            sHauQ = txtDudoanHQ.Text;
            sGiacanh = txtHoancanh.Text;


            Boolean luu =false;

            try
            {            
                conn.Open();
                String sql = "update DOI_TUONG SET " +
                   "HOTEN = N'" + sHoten + "'," +
                   "GIOITINH = N'" + sGioitinh + "',"+
                   "THECHAT = N'" + sTC + "'," +
                   "TINHTHAN = N'" + sTT + "'," +
                   "TAMLY = N'" + sTLTC + "'," +
                   "KHAC = N'" + sTTKhac + "'," +
                   "DACANTHIEP = N'" + sCanT + "'," +
                   "ANHTHE = N'" + hinhanh + "'," +
                   "DUDOAN = N'" + sHauQ + "'," +
                   "HOANCANHGD = N'" + sGiacanh + "'," +
                   "NAMSINH = '" + sTuoi + "' where TT = '"+maDT+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                luu = true;
                conn.Close();


            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
            try
            {
                if (avata == true)
                {
                    string newPath = @"DTimage\\";
                    string destFile = Path.Combine(newPath, hinhanh);
                    File.Copy(filename, destFile, true);
                    MessageBox.Show("Lưu thành công");
                }
            }
            catch
            {
                if (luu == true)
                {
                    MessageBox.Show("Lưu thành công");
                }
            }

        }

        private void ckCo_thechat_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCo_thechat.Checked == true)
            {
                txtThechat.ReadOnly = false;
                ckKhong_thechat.Checked = false;
            }
            else
            {
                txtThechat.ReadOnly = true;
                ckKhong_thechat.Checked = true;
            }
        }

        private void ckCo_tinhthan_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCo_tinhthan.Checked == true)
            {
                txtTinhthan.ReadOnly = false;
                ckKhongo_tihthan.Checked = false;
            }
            else
            {
                txtTinhthan.ReadOnly = true;
                ckKhongo_tihthan.Checked = true;
            }
        }

        private void ckCo_tinhcam_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCo_tinhcam.Checked == true)
            {
                txtTinhcam.ReadOnly = false;
                ckKhong_tinhcam.Checked = false;
            }
            else
            {
                txtTinhcam.ReadOnly = true;
                ckKhong_tinhcam.Checked = true;
            }
        }

        private void ckKhong_thechat_CheckedChanged(object sender, EventArgs e)
        {
            if (ckKhong_thechat.Checked == true)
            {
                txtThechat.ReadOnly = true;
                ckCo_thechat.Checked = false;
            }
            else
            {
                txtThechat.ReadOnly = false;
                ckCo_thechat.Checked = true;
            }
        }

        private void ckKhongo_tihthan_CheckedChanged(object sender, EventArgs e)
        {
            if (ckKhongo_tihthan.Checked == true)
            {
                txtTinhthan.ReadOnly = true;
                ckCo_tinhthan.Checked = false;
            }
            else
            {
                txtTinhthan.ReadOnly = false;
                ckCo_tinhthan.Checked = true;
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            
            if(txtHoten.Text!="")
            {
                DialogResult d = MessageBox.Show("Bạn có chắc muốn lưu không", "Lưu lại", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    capnhatDoiTuong();
                    this.Close();
                }
            }
        }

        private void formCapnhatDT_Load(object sender, EventArgs e)
        {
            Loadform();
        }
        private string filename;
        private void btnAvata_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Lấy hình ảnh
                filename = openFileDialog1.FileName;
                hinhanh = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1, openFileDialog1.FileName.Length - openFileDialog1.FileName.LastIndexOf("\\") - 1);
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                avata = true;
            }
        }

        private void ckKhong_tinhcam_CheckedChanged(object sender, EventArgs e)
        {
            if (ckKhong_tinhcam.Checked == true)
            {
                txtTinhcam.ReadOnly = true;
                ckCo_tinhcam.Checked = false;
            }
            else
            {
                txtTinhcam.ReadOnly = false;
                ckCo_tinhcam.Checked = true;
            }
        }
        private void txtSDTNBT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        
        private void Loadform()
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from DOI_TUONG where TT = " + maDT, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    String s = dr[28].ToString();
                    txtTinhrangkhac.Text = dr[15].ToString();
                    txtDacanthiep.Text = dr[16].ToString();
                    txtDudoanHQ.Text = dr[17].ToString();
                    txtHoancanh.Text = dr[18].ToString();
                    txtMaso.Text = dr[2].ToString();
                    cbThongqua.Text = dr[7].ToString();
                    txtDiadiemTN.Text = dr[27].ToString();
                    dateThoigian.Text = dr[8].ToString();
                    txtHoten.Text = dr[9].ToString();
                    numTuoi.Text = dr[25].ToString();
                    cbGioitinh.Text = dr[10].ToString();
                    txtXaphuong.Text = dr[26].ToString();
                    maTinh = dr[5].ToString();
                    maHuyen = dr[4].ToString();


                    if(dr[12].ToString()== "Khong")
                    {
                        ckKhong_thechat.Checked = true;
                    }
                    else
                    {
                        ckCo_thechat.Checked = true;
                        txtThechat.Text = dr[12].ToString();
                    }
                    if (dr[13].ToString() == "Khong")
                    {
                        ckKhongo_tihthan.Checked = true;
                    }
                    else
                    {
                        ckCo_tinhthan.Checked = true;
                        txtTinhthan.Text = dr[13].ToString();
                    }
                    if (dr[14].ToString() == "Khong")
                    {
                        ckKhong_tinhcam.Checked = true;
                    }
                    else
                    {
                        ckCo_tinhcam.Checked = true;
                        txtTinhcam.Text = dr[14].ToString();
                    }

                    if (s != "")
                    {
                        try
                        {
                            String anh = "DTimage\\" + s;
                            Image image = Image.FromFile(anh);
                            pictureBox1.Image = image;
                            hinhanh = s;
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
                MessageBox.Show("Lỗi không xác định!", "Lỗi");
                this.Close();
            }
        }
    }
}
