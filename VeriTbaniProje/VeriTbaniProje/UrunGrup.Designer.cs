
namespace VeriTbaniProje
{
    partial class UrunGrup
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
            this.lblstandart1 = new VeriTbaniProje.Lblstandart();
            this.TxtGrupAdiEkle = new VeriTbaniProje.TxtStandart();
            this.LbUrunAdi = new System.Windows.Forms.ListBox();
            this.BtnSil = new VeriTbaniProje.BtnStandart();
            this.BtnEkle = new VeriTbaniProje.BtnStandart();
            this.SuspendLayout();
            // 
            // lblstandart1
            // 
            this.lblstandart1.AutoSize = true;
            this.lblstandart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblstandart1.ForeColor = System.Drawing.Color.Maroon;
            this.lblstandart1.Location = new System.Drawing.Point(68, 22);
            this.lblstandart1.Name = "lblstandart1";
            this.lblstandart1.Size = new System.Drawing.Size(164, 25);
            this.lblstandart1.TabIndex = 0;
            this.lblstandart1.Text = "Grup Kayıt Ekranı";
            // 
            // TxtGrupAdiEkle
            // 
            this.TxtGrupAdiEkle.BackColor = System.Drawing.Color.White;
            this.TxtGrupAdiEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtGrupAdiEkle.ForeColor = System.Drawing.Color.Black;
            this.TxtGrupAdiEkle.Location = new System.Drawing.Point(25, 61);
            this.TxtGrupAdiEkle.Name = "TxtGrupAdiEkle";
            this.TxtGrupAdiEkle.Size = new System.Drawing.Size(250, 26);
            this.TxtGrupAdiEkle.TabIndex = 1;
            // 
            // LbUrunAdi
            // 
            this.LbUrunAdi.FormattingEnabled = true;
            this.LbUrunAdi.Location = new System.Drawing.Point(25, 101);
            this.LbUrunAdi.Name = "LbUrunAdi";
            this.LbUrunAdi.Size = new System.Drawing.Size(250, 303);
            this.LbUrunAdi.TabIndex = 4;
            // 
            // BtnSil
            // 
            this.BtnSil.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSil.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.BtnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Location = new System.Drawing.Point(25, 426);
            this.BtnSil.Margin = new System.Windows.Forms.Padding(1);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(112, 75);
            this.BtnSil.TabIndex = 3;
            this.BtnSil.Text = "Sil";
            this.BtnSil.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnSil.UseVisualStyleBackColor = false;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnEkle
            // 
            this.BtnEkle.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnEkle.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.BtnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEkle.Location = new System.Drawing.Point(163, 426);
            this.BtnEkle.Margin = new System.Windows.Forms.Padding(1);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(112, 75);
            this.BtnEkle.TabIndex = 5;
            this.BtnEkle.Text = "Ekle";
            this.BtnEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnEkle.UseVisualStyleBackColor = false;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // UrunGrup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 537);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.LbUrunAdi);
            this.Controls.Add(this.TxtGrupAdiEkle);
            this.Controls.Add(this.lblstandart1);
            this.Name = "UrunGrup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UrunGrup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UrunGrup_FormClosed);
            this.Load += new System.EventHandler(this.UrunGrup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lblstandart lblstandart1;
        private TxtStandart TxtGrupAdiEkle;
        private System.Windows.Forms.ListBox LbUrunAdi;
        private BtnStandart BtnSil;
        private BtnStandart BtnEkle;
    }
}