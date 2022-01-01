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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        VeriTabaniFasonTakipEntities dbx = new VeriTabaniFasonTakipEntities();
        private void girisyap()
        {
            if (TxtKullanici.Text != "" && TxtSifre.Text != "")
            {
                try
                {
                    using (var db = new VeriTabaniFasonTakipEntities())
                    {
                        if (db.TblKullanici.Any())
                        {
                            var bak = db.TblKullanici.Where(x => x.KullaniciAdi == TxtKullanici.Text && x.Sifre == TxtSifre.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                this.Hide();
                                AnaSayfa asa = new AnaSayfa();
                                asa.LblKullanici.Text = bak.Adi;
                                asa.LblSoyadi.Text = bak.SoyAdi;
                                asa.ShowDialog();
                                this.Close();
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı Giriş");
                            }
                        }
                        else
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            TblKullanici k = new TblKullanici();
                            k.Adi = "admin";
                            k.SoyAdi = "admin";
                            k.Sifre = "admin";
                            k.Telefon = "1111111111";
                            k.KullaniciAdi = "admin";
                            k.E_mail = "admin@gmail.com";
                            db.TblKullanici.Add(k);
                            db.SaveChanges();
                            MessageBox.Show("Yeni Kullanıcı Atandı");
                            TblCodeOlustur bt = new TblCodeOlustur();
                            bt.CodeNo = 1;
                            db.TblCodeOlustur.Add(bt);
                            db.SaveChanges();
                            TblFisNo fs = new TblFisNo();
                            fs.FisNo = 1;
                            db.TblFisNo.Add(fs);
                            db.SaveChanges();
                            this.Hide();
                            AnaSayfa asa = new AnaSayfa();
                            asa.ShowDialog();
                            this.Close();
                            Cursor.Current = Cursors.Default;

                            UrunEkle ur = new UrunEkle();

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }


        private void BtnGiris_Click(object sender, EventArgs e)
        {
            girisyap();
        }

        private void BtnGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                girisyap();
            }
        }
    }
}
