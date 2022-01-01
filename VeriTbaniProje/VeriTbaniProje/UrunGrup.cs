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
    public partial class UrunGrup : Form
    {
        public UrunGrup()
        {
            InitializeComponent();
        }
        VeriTabaniFasonTakipEntities db = new VeriTabaniFasonTakipEntities();

        private void GrupDoldur()
        {
            LbUrunAdi.DisplayMember = "GrupAdi";
            LbUrunAdi.ValueMember = "GrupId";
            LbUrunAdi.DataSource = db.TblGrup.OrderBy(a => a.GrupAdi).ToList();
        }
            
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int urunid = Convert.ToInt32(LbUrunAdi.SelectedValue.ToString());
            string urunadi = LbUrunAdi.Text;
            DialogResult onay = MessageBox.Show(urunadi + " Kayıtlı Ürünü silmek istiyormusunuz ?", "Silme işlemi ", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                var urun = db.TblGrup.FirstOrDefault(x => x.GrupId == urunid);
                db.TblGrup.Remove(urun);
                db.SaveChanges();
                GrupDoldur();
                TxtGrupAdiEkle.Focus();
                MessageBox.Show(urunadi + "Adlı Ürün Silindi");
                UrunEkle f = (UrunEkle)Application.OpenForms["Sayfalar.FrmUrunGiris"];
                if (f != null)
                {
                    f.UrunAdiGrupDoldur();
                }
            }
        }

        private void UrunGrup_Load(object sender, EventArgs e)
        {
            GrupDoldur();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (TxtGrupAdiEkle.Text != "")
            {
                TblGrup urunekle = new TblGrup();
                urunekle.GrupAdi = TxtGrupAdiEkle.Text;
                db.TblGrup.Add(urunekle);
                db.SaveChanges();
                GrupDoldur();
                TxtGrupAdiEkle.Clear();
                MessageBox.Show("Ürün Grubu Eklenmiştir..");
                UrunEkle f = (UrunEkle)Application.OpenForms["UrunEkle"];
                if (f != null)
                {
                    f.UrunAdiGrupDoldur();
                }



            }
            else
            {
                MessageBox.Show("Grup Bilgisi Ekleyiniz.");
            }
        }

        private void UrunGrup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            UrunEkle f = new UrunEkle();
            f.ShowDialog();
            this.Close();
        }
    }
}
