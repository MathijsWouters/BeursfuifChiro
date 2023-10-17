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
    public partial class AddDrinksForm : Form
    {
        public AddDrinksForm()
        {
            InitializeComponent();
        }

        private void Drink_TextChanged(object sender, EventArgs e)
        {

        }

        private void Min_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Max_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // If you want to use the selected color for something, you can access it using:
                // colorDialog1.Color

                // For example, if you want to set the background color of the button to the selected color:
                ColorPicker.BackColor = colorDialog1.Color;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
