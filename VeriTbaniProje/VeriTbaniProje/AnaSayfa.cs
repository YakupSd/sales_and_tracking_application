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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void BtnSatis_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UrunSatis us = new UrunSatis();
            us.LblKullaniciSatis.Text = LblKullanici.Text;
            us.ShowDialog();

            Cursor.Current = Cursors.Default;
        }
        private void BtnUrunEkle_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UrunEkle f = new UrunEkle();
            f.LblKullaniciUrun.Text = LblKullanici.Text;
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void AnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnFiyatDegis_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FiyatGuncelle f = new FiyatGuncelle();
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void BtnFirmalar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FasonFirma f = new FasonFirma();
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void BtnFason_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FasonTakip f = new FasonTakip();
            f.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnKullaniciDegis_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Login l = new Login();
            this.Hide();
            l.ShowDialog();
            Cursor.Current = Cursors.Default;
            this.Close();
        }

        private void BtnAyar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            KullanciEkle f = new KullanciEkle();
            f.ShowDialog();
            Cursor.Current =Cursors.Default;


        }
    }
}
