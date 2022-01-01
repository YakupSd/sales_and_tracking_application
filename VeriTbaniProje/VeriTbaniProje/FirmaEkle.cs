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
    public partial class FirmaEkle : Form
    {
        public FirmaEkle()
        {
            InitializeComponent();
        }
        VeriTabaniFasonTakipEntities db = new VeriTabaniFasonTakipEntities();

        private void GridYazdir()
        {
            using (var db = new VeriTabaniFasonTakipEntities())
            {
                if (db.TblFirma.Any())
                {
                    DgridFirma.DataSource = db.TblFirma.Select(x => new { x.FirmaId, x.FirmaSahip, x.FirmaAdi, x.Telefon, x.Adres, x.E_Mail }).ToList();

                }

            }
        }
        private void Temizle()
        {
            TxtAdiSoyadi.Clear();
            TxtTelNo.Clear();
            TxtFirmaAdi.Clear();
            TxtAdres.Clear();
            TxtEmail.Clear();


        }
        public void GrupDoldur()
        {
            UrunEkle u = new UrunEkle();

            u.CmFirma.DisplayMember = "FirmaAdi";
            u.CmFirma.ValueMember = "FirmaAdi";
            u.CmFirma.DataSource = db.TblFirma.ToList();
        }

        private void FirmaEkle_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GridYazdir();
            Cursor.Current = Cursors.Default;
        }

        private void FirmaEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            UrunEkle f = new UrunEkle();
            f.ShowDialog();

        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunEkle f = new UrunEkle();
            f.ShowDialog();

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgridFirma.Rows.Count > 0)
            {
                int Id = Convert.ToInt32(DgridFirma.CurrentRow.Cells["FirmaId"].Value.ToString());
                string FirmaAdi = DgridFirma.CurrentRow.Cells["FirmaAdi"].Value.ToString();
                DialogResult onay = MessageBox.Show(FirmaAdi + " Firmayı silmek istiyormusunuz ? ", "Firma Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var firma = db.TblFirma.Find(Id);
                    db.TblFirma.Remove(firma);
                    db.SaveChanges();

                    MessageBox.Show("Seçili Firma Silindi");
                    GridYazdir();

                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgridFirma.Rows.Count > 0)
            {
                int id = Convert.ToInt32(DgridFirma.CurrentRow.Cells["FirmaId"].Value.ToString());
                LbId.Text = id.ToString();
                using (var db = new VeriTabaniFasonTakipEntities())
                {
                    var getir = db.TblFirma.Where(x => x.FirmaId == id).FirstOrDefault();
                    TxtAdiSoyadi.Text = getir.FirmaSahip;
                    TxtTelNo.Text = getir.Telefon;
                    TxtFirmaAdi.Text = getir.FirmaAdi;
                    if (TxtEmail.Text != "" && TxtAdres.Text != "")
                    {
                        TxtAdres.Text = "";
                        TxtEmail.Text = "";
                    }
                    else
                    {
                        TxtAdres.Text = getir.Adres;
                        TxtEmail.Text = getir.E_Mail;

                    }
                    BtnFirmaKaydet.Text = "Düzenle/Kaydet";
                    GridYazdir();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz.");
            }
           
        }

        private void BtnFirmaKaydet_Click(object sender, EventArgs e)
        {
            if (BtnFirmaKaydet.Text == "Kaydet")
            {
                if (TxtFirmaAdi.Text != "" && TxtAdiSoyadi.Text != "")
                {
                    try
                    {
                        using (var db = new VeriTabaniFasonTakipEntities())
                        {
                            if (!db.TblFirma.Any(x => x.FirmaAdi == TxtFirmaAdi.Text))
                            {
                                TblFirma FrmBilgi = new TblFirma();
                                FrmBilgi.FirmaAdi = TxtFirmaAdi.Text;
                                FrmBilgi.FirmaSahip = TxtAdiSoyadi.Text;
                                FrmBilgi.Adres = TxtAdres.Text;
                                FrmBilgi.Telefon = TxtTelNo.Text;
                                FrmBilgi.E_Mail = TxtEmail.Text;

                                db.TblFirma.Add(FrmBilgi);
                                db.SaveChanges();
                                GridYazdir();
                                Temizle();
                                GrupDoldur();
                            }
                            else
                            {
                                MessageBox.Show("Girdiğiniz Firma Kayıtlı");

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Hata Oluştu" + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nFirma Adı ");
                }
            }
            else if (BtnFirmaKaydet.Text == "Düzenle/Kaydet")
            {
                if (TxtAdiSoyadi.Text != "" && TxtFirmaAdi.Text != "")
                {

                    int id = Convert.ToInt32(LbId.Text);
                    using (var db = new VeriTabaniFasonTakipEntities())
                    {
                        var guncelle = db.TblFirma.Where(x => x.FirmaId == id).FirstOrDefault();
                        guncelle.FirmaSahip = TxtAdiSoyadi.Text;
                        guncelle.Telefon = TxtTelNo.Text;
                        guncelle.FirmaAdi = TxtFirmaAdi.Text;
                        guncelle.Adres = TxtAdres.Text;
                        guncelle.E_Mail = TxtEmail.Text;


                        MessageBox.Show("Güncelleme Yapılmıştır");
                        BtnFirmaKaydet.Text = "Kaydet";
                        Temizle();
                        GrupDoldur();

                        db.SaveChanges();
                        GridYazdir();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nFirma Adı ");

                }
            }
        }
    }
}
