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
    public partial class frmogrencidetay : Form
    {
        public frmogrencidetay()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OEOQ425\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True;Encrypt=False");
        private void frmogrencidetay_Load(object sender, EventArgs e)
        {
            lblnumara.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDERS where OGRNUMARA=@P1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[2].ToString()+""+dr[3].ToString();
                lblsınav1.Text = dr[4].ToString();
                lblsınav2.Text = dr[5].ToString();
                lblsınav3.Text = dr[6].ToString();
                lblort.Text = dr[7].ToString();
                lbldurum.Text = dr[8].ToString();
            }
            baglanti.Close();
        }
    }
}
