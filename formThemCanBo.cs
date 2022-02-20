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
    public partial class formThemCanBo : Form
    {
 
        public formThemCanBo()
        {
            InitializeComponent();
            
        }
        private String hinhanh,filename;
        private void btnThemanh_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog();
            if (result== DialogResult.OK)
            {
                // Lấy hình ảnh
                filename = openFileDialog1.FileName;
                hinhanh = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1, openFileDialog1.FileName.Length - openFileDialog1.FileName.LastIndexOf("\\") - 1);
                picAvata.Image = new Bitmap(openFileDialog1.FileName);

            }       
        }

        private void tbMK_moi_TextChanged(object sender, EventArgs e)
        {
            tbMK_moi.PasswordChar = '*';
        }

        private void tbXacnhanMK_TextChanged(object sender, EventArgs e)
        {
            tbXacnhanMK.PasswordChar = '*';
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            txtTDN.Clear();
        }

        private void tbMK_moi_Click(object sender, EventArgs e)
        {
            tbMK_moi.Clear();
        }

        private void tbXacnhanMK_Click(object sender, EventArgs e)
        {
            tbXacnhanMK.Clear();
        }
   
        private void formThemCanBo_Load(object sender, EventArgs e)
        {
            loadCombobox();
            sao1.Text = "";
            sao2.Text = "";
            sao3.Text = "";
            sao4.Text = "";
        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        List<ComboboxItem> phanquyen;
        private void loadCombobox()
        {
            
            phanquyen = new List<ComboboxItem>()
            {
                new ComboboxItem { Text = "Người dùng", Value = "nguoidung" },
                new ComboboxItem { Text = "Quản trị viên", Value = "quantrivien" }

};
            comboBox1.DataSource = phanquyen;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
        }
        private void luucanbo()
        {
            SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");
            try
            {

                String s1 = txtHoten.Text;
                String s2 = txtChucvu.Text;
                String s3 = dateNamSinh.Text;
                String s4 = txtDiachi.Text;
                String s5 = txtEmail.Text;
                String s6 = txtSDT.Text;
                String s7 = txtTDN.Text;
                String s8 = tbMK_moi.Text;
                String s9 = comboBox1.SelectedValue.ToString();
                

                string newPath = @"image\\";
                string destFile = Path.Combine(newPath, hinhanh);
                File.Copy(filename, destFile, true);


                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO TAIKHOAN (HOVATEN,CHUCVU,NAMSINH,DIACHI,EMAIL,SODT,TENDANGNHAP,MATKHAU,QUYEN,AVATA) VALUES (N'" + s1 + "',N'" + s2 + "','" + s3 + "',N'" + s4 + "',N'" + s5 + "','" + s6 + "','" + s7 + "','" + s8 + "','" + s9 + "','" + hinhanh + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công! ");
                conn.Close();


            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }
        private Boolean ckeckCanbo()
        {
            Boolean a = false;
            String t1, t2, t3, t4;
            t1 = txtHoten.Text;
            t2 = txtTDN.Text;
            t3 = tbMK_moi.Text;
            t4 = tbXacnhanMK.Text;

            if (t1 == "" || t2 == "" || t3 == "" || t4 == "")
            {
                a = false;
            }
            else
            {
                a = true;
            }
            return a;
        }
        private void btnDMK_Luu_Click(object sender, EventArgs e)
        {
            Boolean check = ckeckCanbo();
            if (check == true)
            {
                DialogResult d = MessageBox.Show("Bạn có chắc muốn lưu không", "Lưu lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    luucanbo();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng không được bỏ trống các ô có dấu (*)");
                sao1.Text = "(*)";
                sao2.Text = "(*)";
                sao3.Text = "(*)";
                sao4.Text = "(*)";
            }
        }

        private void btnDMK_Huy_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc muốn hủy không", "Hủy lưu", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }


    }
}