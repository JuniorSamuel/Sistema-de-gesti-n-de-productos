using Sistema_de_gestion_de_productos.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_gestion_de_productos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void AbrirForm(Form f)
        {
            if (this.panel3.Controls.Count > 0)
            {
                this.panel3.Controls.RemoveAt(0);
            }
            f.TopLevel = false;
            this.panel3.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.Show();
            
        }        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            AbrirForm(Form2);
            this.button1.BackColor = Color.FromArgb(9, 56, 104);
            this.button2.BackColor = Color.FromArgb(6, 37, 69);
            this.button3.BackColor = Color.FromArgb(6, 37, 69);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            AbrirForm(Form3);
            this.button2.BackColor = Color.FromArgb(9, 56, 104);
            this.button1.BackColor = Color.FromArgb(6, 37, 69);
            this.button3.BackColor = Color.FromArgb(6, 37, 69);
        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.panel3.Controls.Count > 0)
            {
                this.panel3.Controls.RemoveAt(0);
                Form5 Form5 = new Form5();
                AbrirForm(Form5);
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            AbrirForm(Form3);
            this.button2.BackColor = Color.FromArgb(9, 56, 104);
            this.button1.BackColor = Color.FromArgb(6, 37, 69);
            this.button3.BackColor = Color.FromArgb(6, 37, 69);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Participantes: \nJunior Samuel De los Santos 2019-8756 \nJose Miguel Upia 2019-8757 \nKlevin Hernadez 2019-8680\nKerlin Smerlyn Liberato 2019-8910 \n Eddy Manuel Peña 2019-8868 ");
        }
    }

}
