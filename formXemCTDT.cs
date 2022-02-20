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
    public partial class formXemCTDT : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");

        public formXemCTDT()
        {
            InitializeComponent();
        }
        private string maDT;
        public string Message
        {
            get { return maDT; }
            set { maDT = value; }
        }

        private string hinhanh;
        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadThongtin()
        {

        }
        private void formXemCTDT_Load(object sender, EventArgs e)
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
                    txtThongqua.Text = dr[7].ToString();
                    txtDiadiemTN.Text = dr[27].ToString();
                    txtThoigian.Text = dr[8].ToString();
                    txtHoten.Text = dr[9].ToString();
                    txtNamsinh.Text = dr[25].ToString();
                    txtGioitinh.Text = dr[10].ToString();
                    txtXaphuong.Text = dr[26].ToString();
                    txtTinhthanh.Text = dr[5].ToString();
                    txtQuanhuyen.Text = dr[4].ToString();


                    if (dr[12].ToString() == "Khong")
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
