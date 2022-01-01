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
    public partial class FasonTakip : Form
    {
        public FasonTakip()
        {
            InitializeComponent();
        }
        VeriTabaniFasonTakipEntities db = new VeriTabaniFasonTakipEntities();

        private void Temizle()
        {
            TxtCins.Clear();
            TxtKesimAdet.Clear();
            TxtKumasMetre.Clear();
            TxtMetraj.Clear();
            TxtModel.Clear();
            TxtTeslimAlan.Clear();
            TxtFisNo.Clear();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            if (CmbFirmaBilgi.Text != "" && TxtModel.Text != "" && TxtMetraj.Text != "" && TxtCins.Text != "" && TxtKesimAdet.Text != "" && CmbKumasci.Text != "" && TxtKumasMetre.Text != "" && TxtTeslimAlan.Text != "")
            {

                if (db.TblUrunTakip.Any(a => a.FisNo == TxtFisNo.Text))
                {

                    var guncelle = db.TblUrunTakip.Where(a => a.FisNo == TxtFisNo.Text).SingleOrDefault();
                    guncelle.FisNo = TxtFisNo.Text;
                    guncelle.Model = TxtModel.Text;
                    guncelle.Cinsi = TxtCins.Text;
                    guncelle.KesimAdet = Convert.ToInt32(TxtKesimAdet.Text);
                    guncelle.FirmaBilgisi = CmbFirmaBilgi.Text;
                    guncelle.FirmaAdi = CmbFirmaAdi.Text;
                    guncelle.Metraj = Convert.ToInt32(TxtMetraj.Text);
                    guncelle.Kumasci = CmbKumasci.Text;
                    guncelle.KumasMetre = Convert.ToInt32(TxtKumasMetre.Text);
                    guncelle.TeslimAlanAdi = TxtTeslimAlan.Text;
                    guncelle.Tarih = DateTime.Now;
                    db.SaveChanges();
                    DgridKesimHane.DataSource = db.TblUrunTakip.OrderByDescending(a => a.FisNo).ToList();
                    MessageBox.Show("Güncelleme İşlemi Başarılı.");

                }
                else
                {
                    TblUrunTakip Takip = new TblUrunTakip();

                    Takip.FisNo = TxtFisNo.Text;
                    Takip.Model = TxtModel.Text;
                    Takip.Cinsi = TxtCins.Text;
                    Takip.KesimAdet = Convert.ToInt32(TxtKesimAdet.Text);
                    Takip.FirmaBilgisi = CmbFirmaBilgi.Text;
                    Takip.FirmaAdi = CmbFirmaAdi.Text;
                    Takip.Metraj = Convert.ToInt32(TxtMetraj.Text);
                    Takip.Kumasci = CmbKumasci.Text;
                    Takip.KumasMetre = Convert.ToInt32(TxtKumasMetre.Text);
                    Takip.TeslimAlanAdi = TxtTeslimAlan.Text;
                    Takip.Tarih = DateTime.Now;

                    db.TblUrunTakip.Add(Takip);
                    db.SaveChanges();

                    if (FfisOlustur == true)
                    {
                        var OzelBarkod = db.TblFisNo.First();
                        OzelBarkod.FisNo += 1;
                        db.SaveChanges();
                    }

                    DgridKesimHane.DataSource = db.TblUrunTakip.OrderByDescending(a => a.FisNo).ToList();


                    islemler.GridDuzenle(DgridKesimHane);

                }
                //Islemler.StokHareket(TxtUrunEkleBarkod.Text, TxtUrunAdi.Text, Convert.ToInt32(TxtSeriAdet.Text), Convert.ToDouble(TxtMiktar.Text), CmbUrunGrup.Text, LblKullanici.Text);
                Temizle();
            }
        }
        private void FasonTakip_Load(object sender, EventArgs e)
        {
            DgridKesimHane.DataSource = db.TblUrunTakip.OrderByDescending(a => a.FisNo).ToList();
            DgridAtalyo.DataSource = db.TblAtolyeTakip.OrderByDescending(a => a.FisNo).ToList();
            DgridYikama.DataSource = db.TblYikamaTakip.OrderByDescending(a => a.FisNo).ToList();
            FirmaGrupDoldur();
            FirmaAdiDoldur();
            KumasciDoldur();
            atFirmaGrupDoldur();
            atFirmaAdiDoldur();
            atKumasciDoldur();
        }

        public void FirmaGrupDoldur()
        {
            CmbFirmaBilgi.DisplayMember = "FirmaBilgisi";
            CmbFirmaBilgi.ValueMember = "FirmaBilgisi";
            CmbFirmaBilgi.DataSource = db.TblFasonFirmalar.ToList();
        }
        public void KumasciDoldur()
        {
            CmbKumasci.DisplayMember = "Kumasci";
            CmbKumasci.ValueMember = "Kumasci";
            CmbKumasci.DataSource = db.TblKumasci.ToList();
        }
        public void FirmaAdiDoldur()
        {
            CmbFirmaAdi.DisplayMember = "KhAdi";
            CmbFirmaAdi.ValueMember = "KhAdi";
            CmbFirmaAdi.DataSource = db.TblKesimhane.ToList();
        }
        public void atFirmaGrupDoldur()
        {
            cmbAtBilgi.DisplayMember = "FirmaBilgisi";
            cmbAtBilgi.ValueMember = "FirmaBilgisi";
            cmbAtBilgi.DataSource = db.TblAtolyeTakip.ToList();
        }
        public void atKumasciDoldur()
        {
            CmbAtKumas.DisplayMember = "Kumasci";
            CmbAtKumas.ValueMember = "Kumasci";
            CmbAtKumas.DataSource = db.TblKumasci.ToList();
        }
        public void atFirmaAdiDoldur()
        {
            CmbAtAdi.DisplayMember = "AtolyeAdi";
            CmbAtAdi.ValueMember = "AtolyeAdi";
            CmbAtAdi.DataSource = db.TblAtolye.ToList();
        }




        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgridKesimHane.Rows.Count > 0)
            {
                int urunid = Convert.ToInt32(DgridKesimHane.CurrentRow.Cells["id"].Value.ToString());
                string fisno = DgridKesimHane.CurrentRow.Cells["FisNo"].Value.ToString();
                DialogResult onay = MessageBox.Show(fisno + " Ürünü silmek istiyormusunuz ? ", "Ürün Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.TblUrunTakip.Find(urunid);
                    db.TblUrunTakip.Remove(urun);
                    db.SaveChanges();

                    MessageBox.Show("Seçili Ürün Silindi");
                    DgridKesimHane.DataSource = db.TblUrunTakip.OrderByDescending(a => a.id).ToList();
                    islemler.GridDuzenle(DgridKesimHane);
                    CmbFirmaAdi.Focus();




                }

            }
        }
        private bool FfisOlustur = false;
        private void BtnFisOlustur_Click(object sender, EventArgs e)
        {
            FfisOlustur = true;

            var fisNo = db.TblFisNo.First();
            int Karakter = fisNo.FisNo.ToString().Length;
            string Sıfırlar = string.Empty;
            for (int i = 0; i < 5 - Karakter; i++)
            {
                Sıfırlar = Sıfırlar + "0";
            }
            string OlusanBarkodNo = Sıfırlar + fisNo.FisNo.ToString();
            TxtFisNo.Text = OlusanBarkodNo;
            CmbFirmaAdi.Focus();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DgridKesimHane.Rows.Count > 0)
            {

                TxtFisNo.Text = DgridKesimHane.CurrentRow.Cells["FisNo"].Value.ToString();
                CmbFirmaAdi.Text = DgridKesimHane.CurrentRow.Cells["FirmaAdi"].Value.ToString();
                CmbFirmaBilgi.Text = DgridKesimHane.CurrentRow.Cells["FirmaBilgisi"].Value.ToString();
                TxtModel.Text = DgridKesimHane.CurrentRow.Cells["Model"].Value.ToString();
                TxtCins.Text = DgridKesimHane.CurrentRow.Cells["Cinsi"].Value.ToString();
                TxtKesimAdet.Text = DgridKesimHane.CurrentRow.Cells["KesimAdet"].Value.ToString();
                TxtMetraj.Text = DgridKesimHane.CurrentRow.Cells["Metraj"].Value.ToString();
                CmbKumasci.Text = DgridKesimHane.CurrentRow.Cells["Kumasci"].Value.ToString();
                TxtKumasMetre.Text = DgridKesimHane.CurrentRow.Cells["KumasMetre"].Value.ToString();
                TxtTeslimAlan.Text = DgridKesimHane.CurrentRow.Cells["TeslimAlanAdi"].Value.ToString();
                //TxtMiktar.Text = DgridUrunEkle.CurrentRow.Cells["Miktar"].Value.ToString();




            }
        }

        private void gönderToolStripMenuItem_Click(object sender, EventArgs e)
        {



            if (TxtFisNo.Text == "")
            {
                MessageBox.Show("Göndermek istenen ürünü seçiniz");

            }
            else
            {
                if (DgridKesimHane.Rows.Count > 0)
                {
                    int urunid = Convert.ToInt32(DgridKesimHane.CurrentRow.Cells["id"].Value.ToString());
                    string fisno = DgridKesimHane.CurrentRow.Cells["FisNo"].Value.ToString();
                    DialogResult onay = MessageBox.Show(fisno + " Ürünü Göndermek istiyormusunuz ? ", "Ürün gönderme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (onay == DialogResult.Yes)
                    {
                        var urun = db.TblUrunTakip.Find(urunid);
                        db.TblUrunTakip.Remove(urun);
                        db.SaveChanges();

                        this.Hide();

                        FasonGonder Mg = new FasonGonder();
                        Mg.TxtFisNo.Focus();
                        Mg.TxtFisNo.Text = TxtFisNo.Text;

                        Mg.TxtCins.Text = TxtCins.Text;
                        Mg.TxtTeslimAlan.Text = TxtTeslimAlan.Text;
                        Mg.TxtKesimAdet.Text = TxtKesimAdet.Text;
                        Mg.TxtKumasMetre.Text = TxtKumasMetre.Text;
                        Mg.TxtModel.Text = TxtModel.Text;
                        Mg.CmbFirmaBilgi.Text = CmbFirmaBilgi.Text;
                        Mg.CmbFirmaAdi.Text = CmbFirmaAdi.Text;
                        Mg.CmbKumasci.Text = CmbKumasci.Text;
                        Mg.ShowDialog();
                        this.Close();
                    }



                }




            }
        }

        private void DgridKesimHane_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgridKesimHane.Rows.Count > 0)
            {
                TxtFisNo.Text = DgridKesimHane.CurrentRow.Cells["FisNo"].Value.ToString();
                CmbFirmaAdi.Text = DgridKesimHane.CurrentRow.Cells["FirmaAdi"].Value.ToString();
                CmbFirmaBilgi.Text = DgridKesimHane.CurrentRow.Cells["FirmaBilgisi"].Value.ToString();
                TxtModel.Text = DgridKesimHane.CurrentRow.Cells["Model"].Value.ToString();
                TxtCins.Text = DgridKesimHane.CurrentRow.Cells["Cinsi"].Value.ToString();
                TxtKesimAdet.Text = DgridKesimHane.CurrentRow.Cells["KesimAdet"].Value.ToString();
                TxtMetraj.Text = DgridKesimHane.CurrentRow.Cells["Metraj"].Value.ToString();
                CmbKumasci.Text = DgridKesimHane.CurrentRow.Cells["Kumasci"].Value.ToString();
                TxtKumasMetre.Text = DgridKesimHane.CurrentRow.Cells["KumasMetre"].Value.ToString();
                TxtTeslimAlan.Text = DgridKesimHane.CurrentRow.Cells["TeslimAlanAdi"].Value.ToString();

            }
        }


    }
}