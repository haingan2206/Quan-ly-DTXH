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
    public partial class fQuanlyTK : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");

        private Boolean avata;
        private string thongdiepQLTK;
        private string hinhanh, filename;
          public string Message
        {
            get { return thongdiepQLTK; }
            set { thongdiepQLTK = value; }
        }

        public fQuanlyTK()
        {
            InitializeComponent();
        }

        private void Loadform()
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from TAIKHOAN where STT = " + thongdiepQLTK, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtHoTen.Text = dr[1].ToString();
                    txtChucvu.Text = dr[2].ToString();
                    dateTimePicker1.Text = dr[3].ToString();
                    txtDiaChi.Text = dr[4].ToString();
                    txtEmail.Text = dr[5].ToString();
                    txtSDT.Text = dr[6].ToString();
                    lbName.Text = dr[1].ToString();
                    lbTenDN.Text = dr[7].ToString();
                    String s = dr[10].ToString();
                    if (s != "")
                    {
                        try
                        {
                            String anh = "image\\" + s;
                            Image image = Image.FromFile(anh);
                            picAvata.Image = image;
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

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            formDoiMK dmk = new formDoiMK();
            dmk.Message = thongdiepQLTK;
            dmk.ShowDialog();

        }



        private void lbMatkhau_TextChanged(object sender, EventArgs e)
        {
        
        }
        private Boolean luu = false;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "UPDATE TAIKHOAN SET HOVATEN = N'" + txtHoTen.Text + "',CHUCVU=N'" + txtChucvu.Text + "',NAMSINH = '" + dateTimePicker1.Text + "',DIACHI=N'" + txtDiaChi.Text + "',EMAIL='" + txtEmail.Text + "',SODT='" + txtSDT.Text +"',AVATA = '"+hinhanh+ "' WHERE STT =" + thongdiepQLTK;

                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                luu = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu!", "Error");
            }
            try
            {
                if (avata == true)
                {
                    string newPath = @"image\\";
                    string destFile = Path.Combine(newPath, hinhanh);
                    File.Copy(filename, destFile, true);
                    MessageBox.Show("Lưu thành công");
                }
            }
            catch
            {
                if(luu == true)
                {
                    MessageBox.Show("Lưu thành công");
                }
            }
           
        }

        private void fQuanlyTK_Load(object sender, EventArgs e)
        {
            Loadform();

        }


        private void picAvata_BindingContextChanged(object sender, EventArgs e)
        {
            avata = true;
        }

        private void btnThemAnhCB_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Lấy hình ảnh
                filename = openFileDialog1.FileName;
                hinhanh = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1, openFileDialog1.FileName.Length - openFileDialog1.FileName.LastIndexOf("\\") - 1);
                picAvata.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
    }
}
