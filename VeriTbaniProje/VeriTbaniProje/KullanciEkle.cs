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
    public partial class KullanciEkle : Form
    {
        public KullanciEkle()
        {
            InitializeComponent();
        }
        VeriTabaniFasonTakipEntities db = new VeriTabaniFasonTakipEntities();
        private void GridYazdir()
        {
            using (var db = new VeriTabaniFasonTakipEntities())
            {
                if (db.TblKullanici.Any())
                {
                    DgridKullanici.DataSource = db.TblKullanici.Select(x => new { x.Id, x.Adi, x.SoyAdi, x.E_mail, x.KullaniciAdi, x.Sifre, x.Telefon }).ToList();
                }

            }
        }
        private void Temizle()
        {
            TxtAdi.Clear();
            TxtSoyAdi.Clear();
            TxtTel.Clear();
            TxtKullanciAdi.Clear();
            TxtSifre.Clear();
            TxtSifreTekrar.Clear();
            TxtMail.Clear();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (BtnEkle.Text == "Kaydet")
            {
                if (TxtAdi.Text != "" && TxtKullanciAdi.Text != "" && TxtSifre.Text != "" && TxtSifreTekrar.Text != "")
                {
                    if (TxtSifre.Text == TxtSifreTekrar.Text)
                    {
                        try
                        {
                            using (var db = new VeriTabaniFasonTakipEntities())
                            {
                                if (!db.TblKullanici.Any(x => x.KullaniciAdi == TxtKullanciAdi.Text))
                                {
                                    TblKullanici k = new TblKullanici();
                                    k.Adi = TxtAdi.Text;
                                    k.SoyAdi = TxtSoyAdi.Text;
                                    k.Telefon = TxtTel.Text;
                                    k.KullaniciAdi = TxtKullanciAdi.Text.Trim();
                                    k.Sifre = TxtSifre.Text;
                                    k.E_mail = TxtMail.Text;
                                    db.TblKullanici.Add(k);
                                    db.SaveChanges();
                                    GridYazdir();
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Girdiğiniz Kullanıcı Kayıtlı");

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
                        MessageBox.Show("Şifreler Uyuşmuyor.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nKullanıcı Adı \n Şifre \nŞifre tekrar");
                }
            }
            else if (BtnEkle.Text == "Düzenle/Kaydet")
            {
                if (TxtAdi.Text != "" && TxtKullanciAdi.Text != "" && TxtSifre.Text != "" && TxtSifreTekrar.Text != "")
                {
                    if (TxtSifre.Text == TxtSifreTekrar.Text)
                    {
                        int id = Convert.ToInt32(LbId.Text);
                        using (var db = new VeriTabaniFasonTakipEntities())
                        {
                            var guncelle = db.TblKullanici.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.Adi = TxtAdi.Text;
                            guncelle.SoyAdi = TxtSoyAdi.Text;
                            guncelle.Telefon = TxtTel.Text;
                            guncelle.E_mail = TxtMail.Text;
                            guncelle.KullaniciAdi = TxtKullanciAdi.Text.Trim();
                            guncelle.Sifre = TxtSifre.Text;


                            db.SaveChanges();
                            MessageBox.Show("Güncelleme Yapılmıştır");
                            BtnEkle.Text = "Kaydet";
                            Temizle();
                            GridYazdir();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor.");

                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nKullanıcı Adı \n Şifre \nŞifre tekrar");

                }
            }
        }

        private void KullanciEkle_Load(object sender, EventArgs e)
        {
            GridYazdir();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgridKullanici.Rows.Count > 0)
            {
                int id = Convert.ToInt32(DgridKullanici.CurrentRow.Cells["Id"].Value.ToString());
                LbId.Text = id.ToString();
                using (var db = new VeriTabaniFasonTakipEntities())
                {
                    var getir = db.TblKullanici.Where(x => x.Id == id).FirstOrDefault();
                    getir.Adi = TxtAdi.Text;
                    getir.SoyAdi = TxtSoyAdi.Text;
                    getir.Telefon = TxtTel.Text;
                    getir.KullaniciAdi = TxtKullanciAdi.Text.Trim();
                    getir.Sifre = TxtSifre.Text;
                    BtnEkle.Text = "Düzenle/Kaydet";
                    GridYazdir();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz.");
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgridKullanici.Rows.Count > 0)
            {
                int Id = Convert.ToInt32(DgridKullanici.CurrentRow.Cells["Id"].Value.ToString());
                string Kullanciadi = DgridKullanici.CurrentRow.Cells["KullaniciAdi"].Value.ToString();
                DialogResult onay = MessageBox.Show(Kullanciadi + " Kullanıcıyı silmek istiyormusunuz ? ", "Kullanıcı Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var Kullanici = db.TblKullanici.Find(Id);
                    db.TblKullanici.Remove(Kullanici);
                    db.SaveChanges();



                    MessageBox.Show("Seçili Kullanıcı Silindi");
                    GridYazdir();





                }

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
