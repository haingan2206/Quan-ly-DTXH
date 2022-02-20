
namespace QuanLyDoiTuongXaHoi
{
    partial class picCrop
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureCrop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCrop)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCrop
            // 
            this.pictureCrop.Location = new System.Drawing.Point(33, 36);
            this.pictureCrop.Name = "pictureCrop";
            this.pictureCrop.Size = new System.Drawing.Size(300, 300);
            this.pictureCrop.TabIndex = 0;
            this.pictureCrop.TabStop = false;
            // 
            // picCrop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureCrop);
            this.Name = "picCrop";
            this.Size = new System.Drawing.Size(364, 366);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCrop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCrop;
    }
}
