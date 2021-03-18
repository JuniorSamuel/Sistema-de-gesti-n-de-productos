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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            CtlCategoria control = new CtlCategoria(this);
        }
        
    }
}
