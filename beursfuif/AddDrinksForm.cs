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
        public delegate void DrinkAddedEventHandler(string drinkName);
        public class Drink
        {
            public string Name { get; set; }
            public Color Color { get; set; }  // If you're using System.Drawing.Color
            public decimal MinPrice { get; set; }
            public decimal MaxPrice { get; set; }
            public decimal PriceInterval { get; set; }
            // Add other properties as needed
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
            Drink newDrink = new Drink
            {
                Name = Drinkname.Text,
                // Assuming you have properties like Color, MinPrice, MaxPrice, and PriceInterval in the Drink class:
                Color = colorDialog1.Color,
                MinPrice = (decimal)Min.Value,
                MaxPrice = (decimal)Max.Value,
                PriceInterval = (decimal)Interval.Value
            };

            DrinkAdded?.Invoke(newDrink);

            this.Close();
        }

    }
}
