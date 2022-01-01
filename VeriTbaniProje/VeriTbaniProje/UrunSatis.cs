using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTbaniProje
{
    public partial class UrunSatis : Form
    {
        public UrunSatis()
        {
            InitializeComponent();
        }
        VeriTabaniFasonTakipEntities db = new VeriTabaniFasonTakipEntities();

        public void FirmaGrupDoldur()
        {

            CmbFirmaSec.DisplayMember = "FirmaAdi";
            CmbFirmaSec.ValueMember = "FirmaAdi";
            CmbFirmaSec.DataSource = db.TblFirma.ToList();
        }
        double toplam = 0;
        private void GenelToplam()
        {

            

            for (int i = 0; i < DgridSecond.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(DgridSecond.Rows[i].Cells["ToplamFiyat"].Value);

            }

            TxtGenelToplam.Text = toplam.ToString();


        }
        private void UrunSatis_Load(object sender, EventArgs e)
        {
            FirmaGrupDoldur();
            GenelToplam();
        }

        private void UrunGetirListe(TblUrun urun, string Code, string miktar)
        {
            int satirsayisi = DgridSecond.Rows.Count;



            bool eklendimi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    if (DgridSecond.Rows[i].Cells["UrunCode"].Value.ToString() == Code)
                    {
                        DgridSecond.Rows[i].Cells["Miktar"].Value = 0 + Convert.ToInt32(DgridSecond.Rows[i].Cells["Miktar"].Value);
                        DgridSecond.Rows[i].Cells["Miktar"].Value = Convert.ToInt32(miktar) + Convert.ToInt32(DgridSecond.Rows[i].Cells["Miktar"].Value);
                        DgridSecond.Rows[i].Cells["ToplamFiyat"].Value = Math.Round(Convert.ToDouble(DgridSecond.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(DgridSecond.Rows[i].Cells["SatisFiyat"].Value), 2);// math round kullanımı virgülden sonra iki basamk yarı için
                        eklendimi = true;
                    }

                }
            }
            if (!eklendimi)
            {
                if (miktar == "0")
                {

                }
                else
                {
                    DgridSecond.Rows.Add();
                    DgridSecond.Rows[satirsayisi].Cells["UrunCode"].Value = Code;
                    DgridSecond.Rows[satirsayisi].Cells["FirmaAd"].Value = urun.FirmaAdi;
                    DgridSecond.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.UrunAdi;
                    DgridSecond.Rows[satirsayisi].Cells["UrunBilgisi"].Value = urun.UrunBilgi;
                    DgridSecond.Rows[satirsayisi].Cells["Miktar"].Value = Convert.ToInt32(miktar);
                    DgridSecond.Rows[satirsayisi].Cells["SatisFiyat"].Value = urun.SatisFiyat;
                    DgridSecond.Rows[satirsayisi].Cells["ToplamFiyat"].Value = Math.Round(Convert.ToInt32(miktar) * (double)urun.SatisFiyat, 2);

                }

            }
            GenelToplam();
        }
        private void Temizle()
        {
            TxtGenelToplam.Clear();
            TxtOdenenTutar.Clear();
            TxtGenelToplam.Text = 0.ToString();
            CheckSatisIade.Checked = false;
            TxtOdenenTutar.Clear();

            TxtUrunAdi.Clear();
            DgridSecond.Rows.Clear();
            //SatisSayfaDgrid.Rows.Clear();
            CmbFirmaSec.Focus();

        }
        private void BtnOdenen_Click(object sender, EventArgs e)
        {
            int x = this.Left + (this.Width / 2) - 200;
            int y = this.Top + (this.Height / 2) - 100;
            string Odenen = Interaction.InputBox("Ödeme Yapma Alanı", "Ödenen Tutarı Giriniz.", "Örn: 50", x, y);
            MessageBox.Show("Ödenen Tutar : " + Odenen);
            TxtOdenenTutar.Text = Odenen;
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Programdan Temizlensin mi?", "Temizle", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {

                TxtGenelToplam.Clear();
                TxtOdenenTutar.Clear();
                TxtGenelToplam.Text = 0.ToString();
                CheckSatisIade.Checked = false;
                TxtOdenenTutar.Clear();
                DgridSecond.Rows.Clear();
                TxtUrunAdi.Clear();
                DgridSecond.Rows.Clear();
                CmbFirmaSec.Focus();
            }
            else
            {
                MessageBox.Show("Temizleme işlemi yapılmadı");
            }
        }



        public void MusteriIslem(string OdemeSekli)
        {
            int satirsayisi = DgridSecond.Rows.Count;

            if (satirsayisi > 0)
            {

                int? islemno = db.TblIslemNo.First().IslemNo;
                string firmaadi = CmbFirmaSec.SelectedValue.ToString();
                TblSatis satis = new TblSatis();
                for (int i = 0; i < satirsayisi; i++)
                {
                    satis.IslemNo = islemno;
                    satis.FirmaAdi = DgridSecond.Rows[i].Cells["FirmaAd"].Value.ToString();
                    satis.UrunAdi = DgridSecond.Rows[i].Cells["UrunAdi"].Value.ToString();
                    satis.CodeNo = DgridSecond.Rows[i].Cells["UrunCode"].Value.ToString();
                    satis.SatisFiyat = islemler.DoubleYap(DgridSecond.Rows[i].Cells["SatisFiyat"].Value.ToString());

                    satis.Miktar = Convert.ToInt32(DgridSecond.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.Toplam = islemler.DoubleYap(DgridSecond.Rows[i].Cells["ToplamFiyat"].Value.ToString());
                    satis.Odenen = islemler.DoubleYap(TxtOdenenTutar.Text);
                    satis.Kalan = islemler.DoubleYap(DgridSecond.Rows[i].Cells["ToplamFiyat"].Value.ToString()) - islemler.DoubleYap(TxtOdenenTutar.Text);

                    satis.OdemeSekli = OdemeSekli;
                    satis.Tarih = DateTime.Now;
                    satis.Kullanici = LblKullaniciSatis.Text;
                    db.TblSatis.Add(satis);
                    db.SaveChanges();

                    islemler.StokAzalt(DgridSecond.Rows[i].Cells["UrunCode"].Value.ToString(), DgridSecond.Rows[i].Cells["Miktar"].Value.ToString());

                }

                var islemnoarttir = db.TblIslemNo.First();
                islemnoarttir.IslemNo += 1;
                db.SaveChanges();
                Temizle();

            }


        }

        private void btnStandart1_Click(object sender, EventArgs e)
        {

            string firma = CmbFirmaSec.SelectedValue.ToString();
            SatisSayfaDgrid.DataSource = db.TblUrun.Where(a => a.FirmaAdi.Contains(firma)).ToList();

        }

        private void TxtAdi_TextChanged(object sender, EventArgs e)
        {
            string firma = CmbFirmaSec.SelectedValue.ToString();
            if (TxtUrunAdi.Text.Length >= 2)
            {
                string urunad = TxtUrunAdi.Text;
                SatisSayfaDgrid.DataSource = db.TblUrun.Where(a => a.UrunAdi.Contains(urunad) && a.FirmaAdi.Contains(firma)).ToList();

            }
            else if (TxtUrunAdi.Text == "")
            {
                SatisSayfaDgrid.DataSource = db.TblUrun.Where(a => a.FirmaAdi.Contains(firma)).ToList();
            }
        }

        private void SatisSayfaDgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = this.Left + (this.Width / 2) - 200;
            int y = this.Top + (this.Height / 2) - 100;
            string miktar = Interaction.InputBox("Miktar Ekranı", "Miktar Giriniz.", "Örnek: 25 ", x, y);
            if (miktar == "")
            {
                miktar = "1";
            }
            string Code = SatisSayfaDgrid.CurrentRow.Cells["CodeNo"].Value.ToString();
            var urun = db.TblUrun.Where(a => a.CodeNo == Code).FirstOrDefault();

            UrunGetirListe(urun, Code, miktar);
        }

        private void BtnNakit_Click(object sender, EventArgs e)
        {
            MusteriIslem("Nakit");
        }
    }
}
