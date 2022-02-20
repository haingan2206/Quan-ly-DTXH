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
    public partial class formThemDTXH : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-3J14JA1;Database=QLDoiTuongXaHoi;Integrated Security=True;");
        private string themDTXH;
        public static String maTinh, maHuyen;
        Boolean c1 = false, c2 = false, c3 = false;
        private string layMaTT;
        public string Message
        {
            get { return themDTXH; }
            set { themDTXH = value; }
        }
        public formThemDTXH()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private Boolean checkNhaplieu()
        {
            Boolean a =false;
            String t1, t2;
            t1 = txtMaso.Text;
            t2 = txtHoten.Text;


            if(t1==""||t2 == "" || c1 == false || c2 == false || c3 == false)
            {
                a = false;
            }
            else
            {
                a = true;
            }

            return a;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Boolean a = checkNhaplieu();
            if (a == true)
            {
                DialogResult d = MessageBox.Show("Bạn có chắc muốn lưu không", "Lưu lại", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    LuuDoiTuong();
                    addThanNhan();
/*                    Giaodienchinh gdc = new Giaodienchinh();
                    gdc.Show();*/
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
                sao5.Text = "(*)";
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

        private void formThemDTXH_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select HOVATEN from TAIKHOAN where STT = " + themDTXH, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtCanbo.Text = dr[0].ToString();
                conn.Close();
            }
            
              txtThechat.ReadOnly =true;
              txtTinhthan.ReadOnly=true;
              txtTinhcam.ReadOnly =true;

            sao1.Text = "";
            sao2.Text = "";
            sao3.Text = "";
            sao4.Text = "";
            sao5.Text = "";

            fillData();


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
            string sql = "select * FROM dbo.HUYEN where MATINH ='"+maTinh+"'";  // lay het du lieu
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

        private void LuuDoiTuong()
        {

            String sMaDT, sThongqua, sCB, sDdTN, sHoten, sTuoi, sGioitinh, sBoicanh, sXa;
            String sTC, sTT, sTLTC, sTTKhac, sCanT, sHauQ, sGiacanh;
            String[,] thanNhan = new String[4,5];
            String[] nhomDT = new String[14];
            String hoTenNbt, SDTNbt, diachiNbt, ghichuNbt, Ghichu, thoiGian, giayTokemTheo;

            giayTokemTheo = txtGiaytokemtheo.Text;
            sMaDT = txtMaso.Text;
            sThongqua = cbThongqua.Text;
            sCB = themDTXH;
            sDdTN = txtDiadiemTN.Text;
            thoiGian = dateThoigian.Text;
            sHoten = txtHoten.Text;
            sTuoi = numTuoi.Text;
            sGioitinh = cbGioitinh.SelectedItem.ToString();
            sBoicanh = txtBoicanh.Text;



            sXa = txtXaphuong.Text;
            if(ckCo_thechat.Checked==true)
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
            hoTenNbt = txtHotenNBT.Text;
            SDTNbt = txtSDTNBT.Text;
            diachiNbt = txtDiachiNBT.Text;
            ghichuNbt = txtGhichuNBT.Text;
            Ghichu = txtGhichu.Text;



            try
            {
                maHuyen = cbQuanhuyen.SelectedValue.ToString();
                conn.Open();
                String sql = "INSERT INTO DOI_TUONG(STT,MADT,MAXA,MAHUYEN,MATINH,HOTEN,GIOITINH,THONGQUA,BOICANH,THOIGIAN,THECHAT,TINHTHAN,TAMLY,KHAC,DACANTHIEP,DUDOAN,HOANCANHGD,NGUOIBAOTIN,SDTNGUOIBAOTIN,DIACHINBT,GHICHUNBT,GHICHU,GIAYTOKEMTHEO,NAMSINH,DIADIEMTN,XA) values " +
                    "('" + sCB + "','" + sMaDT + "','1','" + maHuyen + "','" + maTinh + "',N'" + sHoten + "',N'" + sGioitinh + 
                   "',N'" + sThongqua + "'," +
                   "N'" + sBoicanh + "'," +
                   "" + thoiGian + "," +
                   "N'" + sTC + "'," +
                   "N'" + sTT + "'," +
                   "N'" + sTLTC + "'," +
                   "N'" + sTTKhac + "'," +
                   "N'" + sCanT + "'," +
                   "N'" + sHauQ + "'," +
                   "N'" + sGiacanh + "'," +
                   "N'" + hoTenNbt + "'," +
                   "'" + SDTNbt + "'," +
                   "N'" + diachiNbt + "'," +
                   "N'" + ghichuNbt + "'," +
                   "N'" + Ghichu + "'," +
                   "N'" + giayTokemTheo + "'," +
                   "'" + sTuoi + "'," +
                   "N'" + sDdTN + "'," +
                   "N'" + sXa + "')";
                   
                    
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
                
                conn.Close();


            }
            catch
            {
                MessageBox.Show("Lỗi lưu đối tượng");
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
            if (ckKhongo_tihthan.Checked==true)
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

        private void txtXaphuong_Click(object sender, EventArgs e)
        {

        }

        private void formThemDTXH_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void cbGioitinh_MouseClick(object sender, MouseEventArgs e)
        {
            c3 = true;
        }

        private void txtMaso_Validated(object sender, EventArgs e)
        {

        }

        private void addThanNhan()
        {
            try
            {
                conn.Open();
                string sql = "select TT from DOI_TUONG WHERE MADT = 'Tn123'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    layMaTT = dr[0].ToString();
                    conn.Close();
                }

            }
            catch
            {
                MessageBox.Show("Lỗi lấy mã đối tượng");
            }

            for (int i=0;i<dataThannhan.Rows.Count - 1; i++)
            {
                try
                {
                    conn.Open();
                    String sql = "insert into THAN_NHAN(TT,TENTN,QUANHE,HOANCANH,GHICHU,XDTN) VALUES ('" +
                        layMaTT + "',N'" +
                        dataThannhan.Rows[i].Cells["TENTN"].Value.ToString() + "',N'" +
                        dataThannhan.Rows[i].Cells["QUANHE"].Value.ToString() + "',N'" +
                        dataThannhan.Rows[i].Cells["HOANCANH"].Value.ToString() + "',N'" +
                        dataThannhan.Rows[i].Cells["GHICHU"].Value.ToString() + "','" +
                        txtMaso.Text + "')";
                    
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Lưu thành công! ");
                }
                catch
                {
                    MessageBox.Show("Lỗi lưu thân nhân!");
                }

            }
            
           
        }

        private void btnThemTN_Click(object sender, EventArgs e)
        {
            if (txtHT_Thannhan.Text!=""& txtQuanheTN.Text!="")
            {
                dt.Rows.Add(txtHT_Thannhan.Text, txtQuanheTN.Text, txtHoancanhTN.Text, txtGCTN.Text);

            }
            
        }

        private void txtSDTNBT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addThanNhan();
            
        }

        private DataTable dt = new DataTable();
        public void fillData()
        {           
            //Add columns  
            dt.Columns.Add(new DataColumn("TENTN", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANHE", typeof(string)));
            dt.Columns.Add(new DataColumn("HOANCANH", typeof(string)));
            dt.Columns.Add(new DataColumn("GHICHU", typeof(string)));
            dataThannhan.DataSource = dt;
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
    }
}
