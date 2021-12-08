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

namespace P6_1_1204045
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Method update dengan parameter cmd
        private void UpdateDB(string cmd)
        {
            try
            {
                //koneksi ke database
                //string connectionString = "Data Source=LAPTOP-2TQJ2POM\P6_1204045;Initial Catalog=P6_1204045;Integrated Security=True";

                //objek baru connectionString
                SqlConnection myConnection = new SqlConnection(@"Data Source=LAPTOP-2TQJ2POM\P6_1204045;Initial Catalog=P6_1204045;Integrated Security=True");

                //membuka koneksi dengan objek connectionString
                myConnection.Open();

                //objek baru myCommand, inisialisasi dari class SqlCommand
                SqlCommand myCommand = new SqlCommand();

                //menetapkan koneksi basisdata, yaitu myConnection
                myCommand.Connection = myConnection;

                //mengatur query yang digunakan, diambil dari parameter cmd
                myCommand.CommandText = cmd;

                //eksekusi
                myCommand.ExecuteNonQuery();

                //Alert jika eksekusi berhasil
                MessageBox.Show("Basisdata berhasil diperbarui", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //Alert jika eksekusi gagal
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string myCmd = "INSERT INTO msprodi VALUES('"
                 + txtIdProdi.Text + "','"
                 + txtNamaProdi.Text + "','"
                 + txtSingkatan.Text + "','"
                 + txtKaProdi.Text + "','"
                 + txtSekProdi.Text + "')";

            UpdateDB(myCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIdProdi.Text = "";
            txtNamaProdi.Text = "";
            txtSingkatan.Text = "";
            txtKaProdi.Text = "";
            txtSekProdi.Text = "";
        }
    }
}
