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
    public partial class formVanggia : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");

        private string vanggia;
        private string maCB;

        public string Message
        {
            get { return vanggia; }
            set { vanggia = value; }
        }

        public formVanggia()
        {
            InitializeComponent();
        }

        private void formVanggia_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select HOTEN,NAMSINH,STT from DOI_TUONG where TT = '" + vanggia + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtHoten.Text = dr[0].ToString();
                    txtNamsinh.Text = dr[1].ToString();
                    maCB = dr[2].ToString();
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi không xác định!", "Lỗi");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc muốn hủy không", "Hủy lưu", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc muốn lưu không", "Lưu lại", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                luuVanggia();
            }
            
        }

        private void luuVanggia()
        {
            string sDiaDiem, sSuckhoe, sNguoiCS, sHoancanh, sNhanxet, sHuongGQ, sNgayVG, sMaHS;
            sDiaDiem = txtDiadiem.Text;
            sSuckhoe = txtSuckhoe.Text;
            sNguoiCS = txtNguoiCS.Text;
            sHoancanh = txtHoancanh.Text;
            sNhanxet = txtNhanxet.Text;
            sHuongGQ = txtHuongGQ.Text;
            sNgayVG = dateTimePicker1.Text;
            sMaHS = txtMahoso.Text;
            try
            {
                conn.Open();
                String sql = "insert into VANG_GIA(STT,TT,DIAIEM,SUCKHOE,NGUOICS,HOANCANH,NHANXET,HUONGGQ,NGAYVG,MAHOSO) values ('" +
                "'" + maCB + "'," +
                "'" + vanggia + "'," +
                "N'" + sDiaDiem + "'," +
                "N'" + sSuckhoe + "'," +
                "N'" + sNguoiCS + "'," +
                "N'" + sHoancanh + "'," +
                "N'" + sNhanxet + "'," +
                "N'" + sHuongGQ + "'," +
                "'" + sNgayVG + "'," +
                "'" + sMaHS + "')"; 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công! ");
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }


        }
    }
}

