using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VeriTbaniProje
{
    static class islemler
    {
        public static double DoubleYap(string Deger)
        {
            double sonuc;
            double.TryParse(Deger, NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out sonuc);//global para birimi
            return Math.Round(sonuc, 2);

        }

        public static double intYap(string Deger)
        {
            int sonuc;
            int.TryParse(Deger, NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out sonuc);//global para birimi
            return (sonuc);

        }
        public static void StokAzalt(string Code, string miktar)
        {
            if (Code != "1111111111116")
            {
                using (var db = new VeriTabaniFasonTakipEntities())
                {
                    var urunbilgi = db.TblUrun.SingleOrDefault(x => x.CodeNo == Code);
                    urunbilgi.Miktar -= Convert.ToInt32(miktar);
                    db.SaveChanges();
                }
            }


        }
        public static void MagazaStokAzalt(string Code, int miktar)
        {
            if (Code != "1111111111116")
            {
                using (var db = new VeriTabaniFasonTakipEntities())
                {
                    var urunbilgi = db.TblUrun.SingleOrDefault(x => x.CodeNo == Code);
                    urunbilgi.Miktar -= miktar;
                    db.SaveChanges();
                }
            }


        }

        public static void GridDuzenle(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    switch (dgv.Columns[i].HeaderText)
                    {
                        case "UrunId":
                            dgv.Columns[i].HeaderText = "Ürün No"; break;

                        case "CodeNo":
                            dgv.Columns[i].HeaderText = "Kod Numarası"; break;
                        case "UrunAdi":
                            dgv.Columns[i].HeaderText = "Ürün Adı"; break;
                        case "UrunAd":
                            dgv.Columns[i].HeaderText = "Ürün Adı / Code"; break;
                        case "UrunBilgi":
                            dgv.Columns[i].HeaderText = "Ürün Bilgisi / Renk"; break;
                        case "Aciklama":
                            dgv.Columns[i].HeaderText = "Açıklama "; break;
                        case "UrunGrup":
                            dgv.Columns[i].HeaderText = "Ürün Grubu / Model "; break;
                        case "Kullanici":
                            dgv.Columns[i].HeaderText = "Kullanıcı Bilgisi ";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;

                        case "SatisFiyat":
                            dgv.Columns[i].HeaderText = "Satış Fiyatı ";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            //TR para birimi Logosu
                            break;
                        case "AlisFiyatToplam":
                            dgv.Columns[i].HeaderText = "Alış Fiyatı Toplamı ";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            break;

                        case "SeriAdet":
                            dgv.Columns[i].HeaderText = "Seri Adeti ";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;

                        case "Toplam":
                            dgv.Columns[i].HeaderText = "Toplam Tutar";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;



                        case "Miktar":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;

                        case "OdemeSekli":
                            dgv.Columns[i].HeaderText = "Ödeme Şekli";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;

                        case "Kart":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            break;

                        case "Nakit":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            break;



                    }
                }
            }
        }

    }

}
