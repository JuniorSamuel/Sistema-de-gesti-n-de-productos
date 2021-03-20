using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sistema_de_gestion_de_productos.Control;

namespace Sistema_de_gestion_de_productos.Vista
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CtlProducto control = new CtlProducto(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
