using OxyPlot;
using OxyPlot.Series;
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
        private PlotModel plotModel;
        public Beurs()
        {
            InitializeComponent();
            this.Text = "Secondary Window";
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            plotModel = new PlotModel { Title = "Beurs Live Chart" };


            Beursgraph.Model = plotModel;
        }

        private void plotView1_Click(object sender, EventArgs e)
        {

        }
    }
}
