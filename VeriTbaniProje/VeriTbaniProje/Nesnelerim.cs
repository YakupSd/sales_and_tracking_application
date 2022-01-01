using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTbaniProje
{
    class Nesnelerim
    {
    }
    class Lblstandart : Label
    {
        public Lblstandart()
        {
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Text = "LblStandart";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "LblStandart";
        }
    }
    class BtnStandart : Button
    {
        public BtnStandart()
        {
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Location = new System.Drawing.Point(229, 1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "BtnStandart";
            this.Size = new System.Drawing.Size(112, 113);
            this.TabIndex = 3;
            this.Text = "BtnStandart";
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.UseVisualStyleBackColor = false;

        }
    }

    class TxtStandart : TextBox
    {
        public TxtStandart()
        {
            this.Size = new System.Drawing.Size(250, 26);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "TxtStandart";

        }
    }
    class TxtNumeric : TextBox
    {
        public TxtNumeric()
        {
            this.Size = new System.Drawing.Size(115, 26);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "TxtNumeric";
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Click += TxtNumeric_Click;
            this.KeyPress += TxtNumeric_KeyPress;
        }

        private void TxtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void TxtNumeric_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }
    }
    class DgridStandart : DataGridView
    {
        public DgridStandart()
        {
            this.AllowUserToAddRows = false;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            this.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkCyan;
            this.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = this.DefaultCellStyle;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableHeadersVisualStyles = false;
            this.Location = new System.Drawing.Point(3, 122);
            this.Name = "DgridSatisListesi";
            this.RowHeadersVisible = false;
            this.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2);
            this.RowsDefaultCellStyle = this.DefaultCellStyle;

            this.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.RowTemplate.Height = 32;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Size = new System.Drawing.Size(567, 452);
        }
    }
}
