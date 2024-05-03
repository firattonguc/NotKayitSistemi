using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace notkayıt
{
    public partial class frmogretmendetay : Form
    {
        public frmogretmendetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OEOQ425\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True;Encrypt=False");
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmogretmendetay_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbNotKayıtDataSet.TBLDERS' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD)VALUES(@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@p1", msknumara.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ogrenci sisteme eklendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtsınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            msknumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1,s2,s3;
            string durum;
            s1 = Convert.ToDouble(txtsınav1.Text);
            s2 = Convert.ToDouble(txtsınav2.Text);
            s3 = Convert.ToDouble(txtsınav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            lblort.Text=ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "true";
            }
            else
            {
                durum="false";
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@P1,OGRS2=@P2,OGRS3=@P3,ORTALAMA=@P4,DURUM=@P5 WHERE OGRNUMARA=@P6", baglanti);
            komut.Parameters.AddWithValue("@p1", txtsınav1.Text);
            komut.Parameters.AddWithValue("@p2", txtsınav2.Text);
            komut.Parameters.AddWithValue("@p3", txtsınav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblort.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", msknumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("öğrenci notları güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }
    }
}
