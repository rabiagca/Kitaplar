using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitaplar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        kitapEntities baglan=new kitapEntities();
       
        private void button1_Click(object sender, EventArgs e)
        {
            string deger = Convert.ToString(textBox1.Text);
            var sorgu= baglan.kitabım.Where(a=>a.kit_adi==deger).ToList();
            var sorgu1 = baglan.kitabım.Where(b => b.kit_yazar == deger).ToList();
            var saorgu2= baglan.kitabım.Where(c => c.okundu_bilgisi == deger).ToList();
            dataGridView1.DataSource = sorgu;
            temizle();
        }

      
        void doldur()
        {
            dataGridView1.DataSource = baglan.kitabım.ToList();
        }
        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kitabım tablo = new kitabım();
            tablo.kit_adi = textBox1.Text;
            tablo.kit_yazar = textBox2.Text;
            tablo.okundu_bilgisi= textBox3.Text;
            baglan.kitabım.Add(tablo);
            baglan.SaveChanges();
            MessageBox.Show("Yeni Kayıt Eklendi");
            doldur();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deger = textBox1.Text;
            kitabım bos = new kitabım();
            bos = baglan.kitabım.Where(z => z.kit_adi == deger).FirstOrDefault();
            bos.kit_adi = textBox1.Text;
            bos.kit_yazar = textBox2.Text;
            bos.okundu_bilgisi = textBox3.Text;
            baglan.SaveChanges();
            MessageBox.Show("Düzenleme Yapıldı");
            doldur();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string deger=textBox1.Text;
            kitabım sorgu = new kitabım();
            sorgu = baglan.kitabım.Where(x => x.kit_adi == deger).FirstOrDefault();
            baglan.kitabım.Remove(sorgu);
            MessageBox.Show("Kaydınız Silindi");
            doldur();
        }
    }
}
