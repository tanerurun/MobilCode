using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobilCode
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con = new SqlConnection("data source=.;initial catalog=DbisTakip;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        SqlDataAdapter adtr;
        SqlCommand cmd;
        DataTable tablo = new DataTable();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ListelePersonel();

            int x = 0;
            x = dataGridView1.Rows.Count;

            txtToplamPersonel.Text = x.ToString();

        }

        public void EklePersonel()
        {
            con.Open();
            cmd = new SqlCommand("EklePersonel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID",txtId);
            cmd.Parameters.AddWithValue("@Adi", txtAdi);
            cmd.Parameters.AddWithValue("@Soyadi", txtSoyadi);
            cmd.Parameters.AddWithValue("@Meil", txtMeil);
            cmd.Parameters.AddWithValue("@Telefon", txtTelefon);
            cmd.Parameters.AddWithValue("@Gorsel", txtGorsel); 
            cmd.Parameters.AddWithValue("@Departman", txtDepartman);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarı ile eklendi");
            ListelePersonel();

        }
        public void Guncelle()
        {

        }
        public void SilPersonel()
        {
            con.Open();
            cmd = new SqlCommand("SilPersonel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID",dataGridView1.CurrentRow.Cells[0].Value);
          
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarı ile silindi.");
            ListelePersonel();

        }
        public void ListelePersonel()
        {
            tablo.Clear();
            adtr = new SqlDataAdapter("GosterPersonel", con);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("EklePersonel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ID", txtId.Text);
            cmd.Parameters.AddWithValue("@Adi", txtAdi.Text);
            cmd.Parameters.AddWithValue("@Soyadi", txtSoyadi.Text);
            cmd.Parameters.AddWithValue("@Meil", txtMeil.Text);
            cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            cmd.Parameters.AddWithValue("@Gorsel", txtGorsel.Text);
            cmd.Parameters.AddWithValue("@Departman", txtDepartman.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarı ile eklendi");
            ListelePersonel();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SilPersonel();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("GuncellePersonel", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", txtId.Text);
            cmd.Parameters.AddWithValue("@Adi", txtAdi.Text);
            cmd.Parameters.AddWithValue("@Soyadi", txtSoyadi.Text);
            cmd.Parameters.AddWithValue("@Meil", txtMeil.Text);
            cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            cmd.Parameters.AddWithValue("@Gorsel", txtGorsel.Text);
            cmd.Parameters.AddWithValue("@Departman", txtDepartman.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Başarı ile GUncellendi");
            ListelePersonel();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("Select count(*) from TblPersonel", con);
            Int32 count = (Int32)cmd.ExecuteScalar();
            txtToplamPersonel.Text = Convert.ToString(count );
            con.Close();
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}