﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoverControl
{
    public partial class DialogCustom : Form
    {
        public DialogCustom()
        {
            InitializeComponent();
        }

        public void ShowDiag(string Text)
        {
            label1.Text = Text;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
