﻿using Sistema_de_gestion_de_productos.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_gestion_de_productos.Vista
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            CtlVistaProducto control = new CtlVistaProducto(this);
        }       
    }
}
