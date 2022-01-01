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
    public partial class FasonFirma : Form
    {
        public FasonFirma()
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
                    DgridKesim.DataSource = db.TblKesimhane.Select(x => new { x.Id, x.KhAdi, x.KhSahip, x.KhTel, x.KhAdres, }).ToList();

                }

            }
        }
        private void GridYazdirat()
        {
            using (var db = new VeriTabaniFasonTakipEntities())
            {
                if (db.TblFirma.Any())
                {
                    DgridAt.DataSource = db.TblAtolye.Select(x => new { x.Id, x.AtolyeAdi, x.AtolyeSahip, x.AtolyeTel, x.AtolyeAdres, }).ToList();

                }

            }
        }
        private void GridYazdiryk()
        {
            using (var db = new VeriTabaniFasonTakipEntities())
            {
                if (db.TblFirma.Any())
                {
                    DgridYk.DataSource = db.TblYikama.Select(x => new { x.Id, x.YikamaAdi, x.YikamaSahip, x.YikamaTel, x.YikamaAdres, }).ToList();

                }

            }
        }
        private void Temizle()
        {
            TxtKhAdi.Clear();
            TxtKhAdres.Clear();
            TxtKhSahip.Clear();
            TxtKhTelNo.Clear();


        }

        public void GrupDoldur()
        {
            FasonTakip u = new FasonTakip();

            u.CmbFirmaAdi.DisplayMember = "KhAdi";
            u.CmbFirmaAdi.ValueMember = "KhAdi";
            u.CmbFirmaAdi.DataSource = db.TblKesimhane.ToList();


        }

        private void BtnKhKaydet_Click(object sender, EventArgs e)
        {
            if (BtnKhKaydet.Text == "Kaydet")
            {
                if (TxtKhAdi.Text != "" && TxtKhSahip.Text != "" && TxtKhTelNo.Text != "")
                {
                    try
                    {
                        using (var db = new VeriTabaniFasonTakipEntities())
                        {
                            if (!db.TblKesimhane.Any(x => x.KhAdi == TxtKhAdi.Text))
                            {
                                TblKesimhane KesimH = new TblKesimhane();
                                KesimH.KhAdi = TxtKhAdi.Text;
                                KesimH.KhSahip = TxtKhSahip.Text;
                                KesimH.KhAdres = TxtKhAdres.Text;
                                KesimH.KhTel = TxtKhTelNo.Text;


                                db.TblKesimhane.Add(KesimH);
                                db.SaveChanges();
                                GridYazdir();
                                temizlekh();
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
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nFirma Adı \nTelefon ");
                }
            }
            else if (BtnKhKaydet.Text == "Düzenle/Kaydet")
            {
                if (TxtKhAdi.Text != "" && TxtKhSahip.Text != "" && TxtKhTelNo.Text != "")
                {

                    int id = Convert.ToInt32(LbId.Text);
                    using (var db = new VeriTabaniFasonTakipEntities())
                    {
                        var guncelle = db.TblKesimhane.Where(x => x.Id == id).FirstOrDefault();
                        guncelle.KhAdi = TxtKhAdi.Text;
                        guncelle.KhSahip = TxtKhSahip.Text;
                        guncelle.KhAdres = TxtKhAdres.Text;
                        guncelle.KhTel = TxtKhTelNo.Text;


                        MessageBox.Show("Güncelleme Yapılmıştır");
                        BtnKhKaydet.Text = "Kaydet";
                        db.SaveChanges();
                        GridYazdir();
                        GrupDoldur();
                        temizlekh();




                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nFirma Adı ");

                }
            }
        }

        private void FasonFirma_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GridYazdir();
            GridYazdiryk();
            GridYazdirat();
            Cursor.Current = Cursors.Default;
        }

        private void FasonFirma_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgridKesim.Rows.Count > 0)
            {
                int id = Convert.ToInt32(DgridKesim.CurrentRow.Cells["Id"].Value.ToString());
                LbId.Text = id.ToString();
                using (var db = new VeriTabaniFasonTakipEntities())
                {
                    var getir = db.TblKesimhane.Where(x => x.Id == id).FirstOrDefault();
                    TxtKhSahip.Text = getir.KhSahip;
                    TxtKhTelNo.Text = getir.KhTel;
                    TxtKhAdi.Text = getir.KhAdi;
                    if (TxtKhAdres.Text != "")
                    {
                        TxtKhAdres.Text = "";

                    }
                    else
                    {
                        TxtKhAdres.Text = getir.KhAdres;


                    }
                    BtnKhKaydet.Text = "Düzenle/Kaydet";
                }
            }
            else
            {
                MessageBox.Show("Satır Seçiniz.");
            }
            GridYazdir();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgridKesim.Rows.Count > 0)
            {
                int Id = Convert.ToInt32(DgridKesim.CurrentRow.Cells["Id"].Value.ToString());
                string FirmaAdi = DgridKesim.CurrentRow.Cells["KhAdi"].Value.ToString();
                DialogResult onay = MessageBox.Show(FirmaAdi + " Firmayı silmek istiyormusunuz ? ", "Firma Silme İşlemi", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    var firma = db.TblKesimhane.Find(Id);
                    db.TblKesimhane.Remove(firma);
                    db.SaveChanges();

                    MessageBox.Show("Seçili Firma Silindi");
                    GridYazdir();

                }
            }
        }

        private void BtnAtKaydet_Click(object sender, EventArgs e)
        {
            if (BtnKhKaydet.Text == "Kaydet")
            {
                if (TxtAtAdi.Text != "" && TxtAtFirma.Text != "" && TxtAtTel.Text != "")
                {
                    try
                    {
                        using (var db = new VeriTabaniFasonTakipEntities())
                        {
                            if (!db.TblAtolye.Any(x => x.AtolyeAdi == TxtAtAdi.Text))
                            {
                                TblAtolye atolye = new TblAtolye();
                                atolye.AtolyeAdi = TxtAtAdi.Text;
                                atolye.AtolyeSahip = TxtAtFirma.Text;
                                atolye.AtolyeAdres = TxtAtAdres.Text;
                                atolye.AtolyeTel = TxtAtTel.Text;


                                db.TblAtolye.Add(atolye);
                                db.SaveChanges();
                                GridYazdirat();
                                temizleat();
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
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nFirma Adı \nTelefon ");
                }
            }
            else if (BtnKhKaydet.Text == "Düzenle/Kaydet")
            {
                if (TxtAtAdi.Text != "" && TxtAtFirma.Text != "" && TxtAtTel.Text != "")
                {

                    int id = Convert.ToInt32(LbId.Text);
                    using (var db = new VeriTabaniFasonTakipEntities())
                    {
                        var guncelle = db.TblAtolye.Where(x => x.Id == id).FirstOrDefault();
                        guncelle.AtolyeAdi = TxtAtAdi.Text;
                        guncelle.AtolyeSahip = TxtAtFirma.Text;
                        guncelle.AtolyeAdres = TxtAtAdres.Text;
                        guncelle.AtolyeTel = TxtAtTel.Text;


                        MessageBox.Show("Güncelleme Yapılmıştır");
                        BtnKhKaydet.Text = "Kaydet";
                        db.SaveChanges();
                        GridYazdirat();
                        GrupDoldur();
                        temizleat();




                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nFirma Adı ");

                }
            }
        }
        private void temizleyk()
        {
            TxtYkAdi.Clear();
            TxtYkFirma.Clear();
            TxtYkAdres.Clear();
            TxtYkTel.Clear();
        }

        private void temizleat()
        {
            TxtAtAdi.Clear();
            TxtAtFirma.Clear();
            TxtAtAdres.Clear();
            TxtAtTel.Clear();
        }
        private void BtnAtSil_Click(object sender, EventArgs e)
        {
            temizleat();
        }
        private void temizlekh()
        {
            TxtKhAdi.Clear();
            TxtKhSahip.Clear();
            TxtKhAdres.Clear();
            TxtKhTelNo.Clear();
        }
        private void BtnKhIptal_Click(object sender, EventArgs e)
        {
            temizlekh();
        }

        private void BtnYkKaydet_Click(object sender, EventArgs e)
        {
            if (BtnKhKaydet.Text == "Kaydet")
            {
                if (TxtYkAdi.Text != "" && TxtYkFirma.Text != "" && TxtYkTel.Text != "")
                {
                    try
                    {
                        using (var db = new VeriTabaniFasonTakipEntities())
                        {
                            if (!db.TblYikama.Any(x => x.YikamaAdi == TxtYkAdi.Text))
                            {
                                TblYikama ykm = new TblYikama();
                                ykm.YikamaAdi = TxtYkAdi.Text;
                                ykm.YikamaSahip = TxtYkFirma.Text;
                                ykm.YikamaAdres = TxtYkAdres.Text;
                                ykm.YikamaTel = TxtYkTel.Text;


                                db.TblYikama.Add(ykm);
                                db.SaveChanges();
                                GridYazdiryk();
                                temizleyk();
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
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nFirma Adı \nTelefon ");
                }
            }
            else if (BtnKhKaydet.Text == "Düzenle/Kaydet")
            {
                if (TxtYkAdi.Text != "" && TxtYkFirma.Text != "" && TxtYkTel.Text != "")
                {

                    int id = Convert.ToInt32(LbId.Text);
                    using (var db = new VeriTabaniFasonTakipEntities())
                    {
                        var guncelle = db.TblYikama.Where(x => x.Id == id).FirstOrDefault();
                        guncelle.YikamaAdi = TxtYkAdi.Text;
                        guncelle.YikamaSahip = TxtYkFirma.Text;
                        guncelle.YikamaAdres = TxtYkAdres.Text;
                        guncelle.YikamaTel = TxtYkTel.Text;


                        MessageBox.Show("Güncelleme Yapılmıştır");
                        BtnKhKaydet.Text = "Kaydet";
                        db.SaveChanges();
                        GridYazdiryk();
                        GrupDoldur();
                        temizleyk();




                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nFirma Adı ");

                }
            }
        }
       
        private void BtnYkiptal_Click(object sender, EventArgs e)
        {
            temizleyk();
        }
    }
}
