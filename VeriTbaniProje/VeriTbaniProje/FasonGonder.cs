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
    public partial class FasonGonder : Form
    {
        public FasonGonder()
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

        public void FirmaGrupDoldur()
        {
            CmbFirmaBilgi.DisplayMember = "FirmaBilgisi";
            CmbFirmaBilgi.ValueMember = "FirmaBilgisi";
            CmbFirmaBilgi.DataSource = db.TblFasonFirmalar.ToList();
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            if (CmbFirmaBilgi.Text == "Atolye")
            {
               

                if (CmbFirmaBilgi.Text != "" && TxtModel.Text != "" && TxtCins.Text != "" && TxtKesimAdet.Text != "" && CmbKumasci.Text != "" && TxtTeslimAlan.Text != "" && CmbFirmaAdi.Text != "" && TxtFisNo.Text != "")
                {

                    if (db.TblAtolyeTakip.Any(a => a.FisNo == TxtFisNo.Text))
                    {

                    }
                    else
                    {
                        TblAtolyeTakip Takip = new TblAtolyeTakip();

                        Takip.FisNo = TxtFisNo.Text;
                        Takip.Model = TxtModel.Text;
                        Takip.Cinsi = TxtCins.Text;
                        Takip.KesimAdet = Convert.ToInt32(TxtKesimAdet.Text);
                        Takip.FirmaBilgisi = CmbFirmaBilgi.Text;
                        Takip.FirmaAdi = CmbFirmaAdi.Text;
                        Takip.Kumasci = CmbKumasci.Text;
                        Takip.TeslimAlanAdi = TxtTeslimAlan.Text;
                        Takip.Tarih = DateTime.Now;

                        db.TblAtolyeTakip.Add(Takip);
                        db.SaveChanges();
                        MessageBox.Show("Adlı Firmaya  " + CmbFirmaBilgi.Text + " gönderildi ");


                    }
                    //Islemler.StokHareket(TxtUrunEkleBarkod.Text, TxtUrunAdi.Text, Convert.ToInt32(TxtSeriAdet.Text), Convert.ToDouble(TxtMiktar.Text), CmbUrunGrup.Text, LblKullanici.Text);
                    Temizle();
                }

            }
            else if (CmbFirmaBilgi.Text == "Yıkama")
            {

                if (CmbFirmaBilgi.Text != "" && TxtModel.Text != "" && TxtCins.Text != "" && TxtKesimAdet.Text != "" && CmbKumasci.Text != "" && TxtTeslimAlan.Text != "" && CmbFirmaAdi.Text != "" && TxtFisNo.Text != "")
                {

                    if (db.TblYikamaTakip.Any(a => a.FisNo == TxtFisNo.Text))
                    {
                    }
                    else
                    {
                        TblYikamaTakip Takip = new TblYikamaTakip();

                        Takip.FisNo = TxtFisNo.Text;
                        Takip.Model = TxtModel.Text;
                        Takip.Cinsi = TxtCins.Text;
                        Takip.KesimAdet = Convert.ToInt32(TxtKesimAdet.Text);
                        Takip.FirmaBilgisi = CmbFirmaBilgi.Text;
                        Takip.FirmaAdi = CmbFirmaAdi.Text;
                        Takip.Kumasci = CmbKumasci.Text;
                        Takip.TeslimAlanAdi = TxtTeslimAlan.Text;
                        Takip.Tarih = DateTime.Now;


                        db.TblYikamaTakip.Add(Takip);
                        db.SaveChanges();


                    }
                    //Islemler.StokHareket(TxtUrunEkleBarkod.Text, TxtUrunAdi.Text, Convert.ToInt32(TxtSeriAdet.Text), Convert.ToDouble(TxtMiktar.Text), CmbUrunGrup.Text, LblKullanici.Text);
                    Temizle();
                }


            }
            else if (true)
            {

            }
        }

        private void FasonGonder_FormClosed(object sender, FormClosedEventArgs e)
        {


            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("gönderim işlemi kapatılsın mı ?", "Gönder", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                FasonTakip f = new FasonTakip();
                this.Hide();
                f.ShowDialog();
                Cursor.Current = Cursors.Default;
                this.Close();
            }
            else
            {
                MessageBox.Show("Temizleme işlemi yapılmadı");
            }

            

        }

        private void FasonGonder_Load(object sender, EventArgs e)
        {
            FirmaGrupDoldur();
        }
    }
}
