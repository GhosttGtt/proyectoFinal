using System;
using System.Windows.Forms;

namespace POS
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            pictureBox1.Click += pictureBox1_Click;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox3.Click += pictureBox3_Click;
            pictureBox4.Click += pictureBox4_Click;
            pictureBox5.Click += pictureBox5_Click;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //FormProducts formProducts = new FormProducts();
            //formProducts.Show();
            this.Hide();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //FormClients formClients = new FormClients();
            //formClients.Show();
            this.Hide();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //FormEmployees formEmployees = new FormEmployees();
            //formEmployees.Show();
            this.Hide();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //FormBills formBills = new Formbills();
            //formBills.Show();
            this.Hide();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //FormRecord formRecord = new FormRecord();
            //formRecord.Show();
            this.Hide();
        }

    }
}
