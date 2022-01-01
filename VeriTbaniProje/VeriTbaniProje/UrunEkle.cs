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
    public partial class UrunEkle : Form
    {
        public UrunEkle()
        {
            InitializeComponent();
        }
        VeriTabaniFasonTakipEntities db = new VeriTabaniFasonTakipEntities();

        private bool FBarkodArttir = false;

        private void BtnCodeOlustur_Click(object sender, EventArgs e)
        {
            FBarkodArttir = true;

            var barkodNo = db.TblCodeOlustur.First();
            int Karakter = barkodNo.CodeNo.ToString().Length;
            string Sıfırlar = string.Empty;
            for (int i = 0; i < 6 - Karakter; i++)
            {
                Sıfırlar = Sıfırlar + "0";
            }
            string OlusanBarkodNo = Sıfırlar + barkodNo.CodeNo.ToString();
            TxtUrunCode.Text = OlusanBarkodNo;
            TxtUrunAdi.Focus();
        }
        public void UrunAdiGrupDoldur()
        {
            cmbGrup.DisplayMember = "GrupAdi";
            cmbGrup.ValueMember = "GrupId";
            cmbGrup.DataSource = db.TblGrup.OrderBy(a => a.GrupAdi).ToList();
        }
        private void Temizle()
        {
            TxtUrunCode.Clear();
            TxtUrunAdi.Clear();
            TxtUrunBilgi.Clear();
            TxtSatisFiyat.Text = "";
            cmbGrup.Text = "";
            TxtMiktar.Text = "";
            CmFirma.Text = "";
            TxtUrunCode.Focus();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtUrunCode.Text != "" && TxtUrunAdi.Text != "" && TxtUrunBilgi.Text != "" && cmbGrup.Text != "" && TxtSatisFiyat.Text != "" && TxtMiktar.Text != "" && CmFirma.Text != "")
            {

                if (db.TblUrun.Any(a => a.CodeNo == TxtUrunCode.Text))
                {

                    var guncelle = db.TblUrun.Where(a => a.CodeNo == TxtUrunCode.Text).SingleOrDefault();
                    guncelle.UrunAdi = TxtUrunAdi.Text;
                    guncelle.UrunBilgi = TxtUrunBilgi.Text;
                    guncelle.UrunGrup = cmbGrup.Text;
                    guncelle.FirmaAdi = CmFirma.Text;
                    guncelle.SatisFiyat = Convert.ToDouble(TxtSatisFiyat.Text);
                    guncelle.Miktar += Convert.ToInt32(TxtMiktar.Text);
                    string miktar = DgridUrunEkle.CurrentRow.Cells["Miktar"].Value.ToString();

                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = LblKullaniciUrun.Text;
                    db.SaveChanges();
                    DgridUrunEkle.DataSource = db.TblUrun.OrderByDescending(a => a.UrunId).ToList();
                    MessageBox.Show("Güncelleme İşlemi Başarılı.");

                }
                else
                {
                    TblUrun urun = new TblUrun();

                    urun.CodeNo = TxtUrunCode.Text;
                    urun.UrunAdi = TxtUrunAdi.Text;
                    urun.UrunBilgi = TxtUrunBilgi.Text;
                    urun.UrunGrup = cmbGrup.Text;
                    urun.FirmaAdi = CmFirma.Text;
                    urun.SatisFiyat = Convert.ToDouble(TxtSatisFiyat.Text);
                    urun.Miktar = Convert.ToInt32(TxtMiktar.Text);
                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = LblKullaniciUrun.Text;

                    db.TblUrun.Add(urun);
                    db.SaveChanges();

                    if (FBarkodArttir == true)
                    {
                        var OzelBarkod = db.TblCodeOlustur.First();
                        OzelBarkod.CodeNo += 1;
                        db.SaveChanges();
                    }



                    DgridUrunEkle.DataSource = db.TblUrun.OrderByDescending(a => a.UrunId).ToList();
                    TxtUrunSayisi.Text = db.TblUrun.Count().ToString();

                    islemler.GridDuzenle(DgridUrunEkle);

                }
                //Islemler.StokHareket(TxtUrunEkleBarkod.Text, TxtUrunAdi.Text, Convert.ToInt32(TxtSeriAdet.Text), Convert.ToDouble(TxtMiktar.Text), CmbUrunGrup.Text, LblKullanici.Text);
                Temizle();

                FBarkodArttir = false;


            }
            else
            {
                MessageBox.Show("Hatalı Giriş, Lütfen Kontrol Ediniz..");
                TxtUrunCode.Focus();
            }
        }

        private void Btniptal_Click(object sender, EventArgs e)
        {
            Temizle();
            DgridUrunEkle.DataSource = db.TblUrun.OrderByDescending(a => a.UrunId).ToList();
        }
        private void GrupDoldur()
        {

            cmbGrup.DisplayMember = "GrupAdi";
            cmbGrup.ValueMember = " GrupId";
            cmbGrup.DataSource = db.TblGrup.OrderBy(a => a.GrupAdi).ToList();
        }
        public void FirmaGrupDoldur()
        {

            CmFirma.DisplayMember = "FirmaAdi";
            CmFirma.ValueMember = "FirmaAdi";
            CmFirma.DataSource = db.TblFirma.ToList();
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            TxtUrunSayisi.Text = db.TblUrun.Count().ToString();// Kayıtlı Ürün Sayısı
            DgridUrunEkle.DataSource = db.TblUrun.OrderByDescending(a => a.UrunId).ToList();
            islemler.GridDuzenle(DgridUrunEkle);
            GrupDoldur();
            FirmaGrupDoldur();

        }

        private void txtUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunAra.Text.Length >= 2)
            {
                string urunad = txtUrunAra.Text;
                DgridUrunEkle.DataSource = db.TblUrun.Where(c => c.UrunAdi.Contains(urunad)).ToList();
                islemler.GridDuzenle(DgridUrunEkle);
            }
            else if (txtUrunAra.Text == "")
            {
                DgridUrunEkle.DataSource = db.TblUrun.OrderByDescending(a => a.UrunId).ToList();
            }
        }



        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgridUrunEkle.Rows.Count > 0)
            {
                int urunid = Convert.ToInt32(DgridUrunEkle.CurrentRow.Cells["UrunId"].Value.ToString());
                string urunadi = DgridUrunEkle.CurrentRow.Cells["UrunAdi"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunadi + " Ürünü silmek istiyormusunuz ? ", "Ürün Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.TblUrun.Find(urunid);
                    db.TblUrun.Remove(urun);
                    db.SaveChanges();

                    MessageBox.Show("Seçili Ürün Silindi");
                    DgridUrunEkle.DataSource = db.TblUrun.OrderByDescending(a => a.UrunId).ToList();
                    islemler.GridDuzenle(DgridUrunEkle);
                    TxtUrunCode.Focus();
                    TxtUrunSayisi.Text = db.TblUrun.Count().ToString();// Kayıtlı Ürün Sayısı



                }

            }
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DgridUrunEkle.Rows.Count > 0)
            {

                TxtUrunCode.Text = DgridUrunEkle.CurrentRow.Cells["CodeNo"].Value.ToString();
                TxtUrunAdi.Text = DgridUrunEkle.CurrentRow.Cells["UrunAdi"].Value.ToString();
                TxtUrunBilgi.Text = DgridUrunEkle.CurrentRow.Cells["UrunBilgi"].Value.ToString();
                cmbGrup.Text = DgridUrunEkle.CurrentRow.Cells["UrunGrup"].Value.ToString();
                CmFirma.Text = DgridUrunEkle.CurrentRow.Cells["FirmaAdi"].Value.ToString();

                TxtSatisFiyat.Text = DgridUrunEkle.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                //TxtMiktar.Text = DgridUrunEkle.CurrentRow.Cells["Miktar"].Value.ToString();
                TxtMiktar.Text = "0";



            }



        }

        private void BtnUrunGrup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cursor.Current = Cursors.WaitCursor;
            UrunGrup f = new UrunGrup();
            f.ShowDialog();
            this.Close();
            Cursor.Current = Cursors.Default;
        }

        private void BtnFirma_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cursor.Current = Cursors.WaitCursor;
            FirmaEkle f = new FirmaEkle();
            f.ShowDialog();
            this.Close();

            Cursor.Current = Cursors.Default;
        }

        private void miktarAzaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TxtUrunCode.Text == "")
            {
                MessageBox.Show("Azaltılmak istenen ürünü seçiniz");

            }
            else
            {
                if (DgridUrunEkle.Rows.Count > 0)
                {
                    this.Hide();

                    MiktarDus Mg = new MiktarDus();
                    Mg.TxtMiktarAzalt.Focus();
                    Mg.TxtMiktarCode.Text = TxtUrunCode.Text;
                    Mg.TxtFirmaAzalt.Text = CmFirma.Text;
                    Mg.TxtUrunAdiAzalt.Text = TxtUrunAdi.Text;
                    Mg.TxtEldekiMiktar.Text = DgridUrunEkle.CurrentRow.Cells["Miktar"].Value.ToString();
                    Mg.ShowDialog();
                    this.Close();

                }




            }
        }

        private void DgridUrunEkle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgridUrunEkle.Rows.Count > 0)
            {
                TxtUrunCode.Text = DgridUrunEkle.CurrentRow.Cells["CodeNo"].Value.ToString();
                TxtUrunBilgi.Text = DgridUrunEkle.CurrentRow.Cells["UrunBilgi"].Value.ToString();
                CmFirma.Text = DgridUrunEkle.CurrentRow.Cells["FirmaAdi"].Value.ToString();
                TxtUrunAdi.Text = DgridUrunEkle.CurrentRow.Cells["UrunAdi"].Value.ToString();
                cmbGrup.Text = DgridUrunEkle.CurrentRow.Cells["UrunGrup"].Value.ToString();
                TxtSatisFiyat.Text = DgridUrunEkle.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                TxtMiktar.Text = "0";

            }
        }

        private void UrunEkle_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
