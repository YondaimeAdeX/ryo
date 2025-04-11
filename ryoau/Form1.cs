using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ryoau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void Doldur() 
        {
            var ogrenciliste = db.tblOgrenciler.ToList();
            dataGridView1.DataSource = ogrenciliste;

            var sinifliste = db.tblSiniflar.Select(x => new
            {
                x.id,
                sinif = x.sinifAdi



            }).ToList();
            cmbSinif.DataSource = sinifliste;
            cmbSinif.DisplayMember = "sinif";
            dataGridView2.DataSource = sinifliste;

            var alanliste = db.tblAlanlar.Select(x => new
            {
                x.id,
                alan = x.alanAdi



            }).ToList();
            cmbAlan.DataSource = alanliste;
            cmbAlan.DisplayMember = "alan";
            dataGridView3.DataSource = alanliste;

            var kulupliste = db.tblKulupler.Select(x => new
            {
                x.id,
                kulup = x.kulupAdi



            }).ToList();
            cmbKulup.DataSource = kulupliste;
            cmbKulup.DisplayMember = "kulup";
            dataGridView4.DataSource = kulupliste;

        }
        dbOkulEntities db = new dbOkulEntities();
        private void Kaydet_Click(object sender, EventArgs e)
        {
            tblOgrenciler og = new tblOgrenciler();
            og.adi = txtAdi.Text;
            og.no = txtNo.Text;
            og.sinifi = cmbSinif.Text;
            og.kulubu = cmbKulup.Text;
            og.alani = cmbAlan.Text;
            og.durumu = chkdurum.Checked;
            db.tblOgrenciler.Add(og);
            db.SaveChanges();
            Doldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tblSiniflar sinif = new tblSiniflar();
            sinif.sinifAdi = txtsinifad.Text;
            db.tblSiniflar.Add(sinif);
            db.SaveChanges();
            Doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tblAlanlar alan = new tblAlanlar();
            alan.alanAdi = txtalanad.Text;
            db.tblAlanlar.Add(alan);
            db.SaveChanges();
            Doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tblKulupler kulup = new tblKulupler();
            kulup.kulupAdi = txtkulupad.Text;
            db.tblKulupler.Add(kulup);
            db.SaveChanges();
            Doldur();
        }
    }
}
