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
    public partial class FiyatGuncelle : Form
    {
        public FiyatGuncelle()
        {
            InitializeComponent();
        }

        private void TxtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (var db = new VeriTabaniFasonTakipEntities())
                {
                    if (db.TblUrun.Any(x => x.CodeNo == TxtBarkod.Text))
                    {
                        var getir = db.TblUrun.Where(x => x.CodeNo == TxtBarkod.Text).SingleOrDefault();
                        LblBarkod.Text = getir.CodeNo;
                        lblUrunAdi.Text = getir.UrunAdi;
                        double mevcutfiyat = Convert.ToDouble(getir.SatisFiyat);
                        LblFiyat.Text = mevcutfiyat.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Ürün Kayıtlı değil");
                    }
                }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtYeniFiyat.Text != "" && LblBarkod.Text != "")
            {
                using (var db = new VeriTabaniFasonTakipEntities())
                {
                    var guncellenecek = db.TblUrun.Where(x => x.CodeNo == LblBarkod.Text).SingleOrDefault();
                    guncellenecek.SatisFiyat = islemler.DoubleYap(txtYeniFiyat.Text);
                    
                    db.SaveChanges();
                    MessageBox.Show("Fiyat Kaydedildi");
                    LblBarkod.Text = "";
                    lblUrunAdi.Text = "";
                    LblFiyat.Text = "";
                    string barkod = LblBarkod.Text;

                    txtYeniFiyat.Clear();
                    TxtBarkod.Clear();
                    TxtBarkod.Focus();
                }
            }
            else
            {
                MessageBox.Show("Ürün Okutunuz!");
                TxtBarkod.Focus();

            }
        }
    }
}
