
namespace QuanLyDoiTuongXaHoi
{
    partial class formDoiMK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMK_cu = new System.Windows.Forms.TextBox();
            this.tbMK_moi = new System.Windows.Forms.TextBox();
            this.tbXacnhanMK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDMK_Luu = new System.Windows.Forms.Button();
            this.btnDMK_Huy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMK_cu
            // 
            this.tbMK_cu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMK_cu.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbMK_cu.Location = new System.Drawing.Point(25, 55);
            this.tbMK_cu.Name = "tbMK_cu";
            this.tbMK_cu.Size = new System.Drawing.Size(303, 26);
            this.tbMK_cu.TabIndex = 0;
            this.tbMK_cu.Text = "Nhập Mật khẩu cũ";
            this.tbMK_cu.Click += new System.EventHandler(this.tbMK_cu_Click);
            this.tbMK_cu.TextChanged += new System.EventHandler(this.tbMK_cu_TextChanged);
            // 
            // tbMK_moi
            // 
            this.tbMK_moi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMK_moi.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbMK_moi.Location = new System.Drawing.Point(25, 102);
            this.tbMK_moi.Name = "tbMK_moi";
            this.tbMK_moi.Size = new System.Drawing.Size(303, 26);
            this.tbMK_moi.TabIndex = 0;
            this.tbMK_moi.Text = "Nhập Mật khẩu mới";
            this.tbMK_moi.Click += new System.EventHandler(this.tbMK_moi_Click);
            this.tbMK_moi.TextChanged += new System.EventHandler(this.tbMK_moi_TextChanged);
            // 
            // tbXacnhanMK
            // 
            this.tbXacnhanMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbXacnhanMK.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbXacnhanMK.Location = new System.Drawing.Point(25, 146);
            this.tbXacnhanMK.Name = "tbXacnhanMK";
            this.tbXacnhanMK.Size = new System.Drawing.Size(303, 26);
            this.tbXacnhanMK.TabIndex = 0;
            this.tbXacnhanMK.Text = "Nhập lại mật khẩu";
            this.tbXacnhanMK.Click += new System.EventHandler(this.tbXacnhanMK_Click);
            this.tbXacnhanMK.TextChanged += new System.EventHandler(this.tbXacnhanMK_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(115, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đổi mật khẩu";
            // 
            // btnDMK_Luu
            // 
            this.btnDMK_Luu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDMK_Luu.Location = new System.Drawing.Point(67, 192);
            this.btnDMK_Luu.Name = "btnDMK_Luu";
            this.btnDMK_Luu.Size = new System.Drawing.Size(100, 40);
            this.btnDMK_Luu.TabIndex = 2;
            this.btnDMK_Luu.Text = "Lưu";
            this.btnDMK_Luu.UseVisualStyleBackColor = false;
            this.btnDMK_Luu.Click += new System.EventHandler(this.btnDMK_Luu_Click);
            // 
            // btnDMK_Huy
            // 
            this.btnDMK_Huy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDMK_Huy.Location = new System.Drawing.Point(179, 192);
            this.btnDMK_Huy.Name = "btnDMK_Huy";
            this.btnDMK_Huy.Size = new System.Drawing.Size(100, 40);
            this.btnDMK_Huy.TabIndex = 2;
            this.btnDMK_Huy.Text = "Hủy";
            this.btnDMK_Huy.UseVisualStyleBackColor = false;
            this.btnDMK_Huy.Click += new System.EventHandler(this.btnDMK_Huy_Click);
            // 
            // formDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(355, 244);
            this.Controls.Add(this.btnDMK_Huy);
            this.Controls.Add(this.btnDMK_Luu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbXacnhanMK);
            this.Controls.Add(this.tbMK_moi);
            this.Controls.Add(this.tbMK_cu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formDoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DoiMK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMK_cu;
        private System.Windows.Forms.TextBox tbMK_moi;
        private System.Windows.Forms.TextBox tbXacnhanMK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDMK_Luu;
        private System.Windows.Forms.Button btnDMK_Huy;
    }
}