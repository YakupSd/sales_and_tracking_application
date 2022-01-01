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
    public partial class MiktarDus : Form
    {
        public MiktarDus()
        {
            InitializeComponent();
        }

        private void BtnAzalt_Click(object sender, EventArgs e)
        {
            if (TxtMiktarAzalt.Text == "")
            {
                MessageBox.Show("lütfen adet giriniz.");
            }
            else
            {
                islemler.MagazaStokAzalt(TxtMiktarCode.Text, Convert.ToInt32(TxtMiktarAzalt.Text));
                MessageBox.Show("Azaldı");
                this.Close();


            }
        }



        private void MiktarDus_Load(object sender, EventArgs e)
        {
            TxtMiktarAzalt.Focus();
        }

        private void MiktarDus_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            UrunEkle dp = new UrunEkle();
            dp.ShowDialog();
        }
    }
}
