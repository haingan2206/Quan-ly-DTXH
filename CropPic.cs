using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoiTuongXaHoi
{
    public partial class CropPic : Form
    {
        //Khai báo delegate
        public delegate void SendMessage(Image pic);
        public SendMessage Sender; 
        public CropPic()
        {
            InitializeComponent();
            formThemCanBo fTCB = new formThemCanBo();
         
        }

        private void CropPic_Load(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            //Kiểm tra xem người dùng đã chọn file chưa
            if (result == DialogResult.OK)
            {
                // Lấy hình ảnh
                Image img = Image.FromFile(openFileDialog1.FileName);

                // Gán ảnh
          


            }
        }
    }
}
