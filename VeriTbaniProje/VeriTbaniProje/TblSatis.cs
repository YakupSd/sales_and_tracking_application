//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VeriTbaniProje
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblSatis
    {
        public int SatisId { get; set; }
        public Nullable<int> IslemNo { get; set; }
        public string FirmaAdi { get; set; }
        public string UrunAdi { get; set; }
        public string CodeNo { get; set; }
        public string UrunBilgi { get; set; }
        public Nullable<int> Miktar { get; set; }
        public Nullable<double> SatisFiyat { get; set; }
        public Nullable<double> Toplam { get; set; }
        public Nullable<double> Odenen { get; set; }
        public Nullable<double> Kalan { get; set; }
        public string OdemeSekli { get; set; }
        public Nullable<bool> Iade { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Kullanici { get; set; }
    }
}
