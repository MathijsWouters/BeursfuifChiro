using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beursfuif
{
    public partial class Beurs : Form
    {
        public Beurs()
        {
            InitializeComponent();
            this.Text = "Secondary Window";
            this.BackColor = Color.Black; 
            this.FormBorderStyle = FormBorderStyle.None; 
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
