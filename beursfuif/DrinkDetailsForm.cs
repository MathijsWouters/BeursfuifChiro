using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static beursfuif.AddDrinksForm;

namespace beursfuif
{
    public partial class DrinkDetailsForm : Form
    {
        private Drink currentDrink;

        public bool DrinkDeleted { get; private set; } = false;

        public DrinkDetailsForm(Drink drink)
        {
            InitializeComponent();
            currentDrink = drink;
            LoadDrinkDetails();
        }

        private void LoadDrinkDetails()
        {
            drinkNameTextBox.Text = currentDrink.Name;
            drinkColorDisplay.BackColor = currentDrink.Color;
            minPriceNumericUpDown.Value = currentDrink.MinPrice;
            maxPriceNumericUpDown.Value = currentDrink.MaxPrice;
            intervalNumericUpDown.Value = currentDrink.PriceInterval;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            currentDrink.Name = drinkNameTextBox.Text;
            currentDrink.Color = drinkColorDisplay.BackColor;
            currentDrink.MinPrice = minPriceNumericUpDown.Value;
            currentDrink.MaxPrice = maxPriceNumericUpDown.Value;
            currentDrink.PriceInterval = intervalNumericUpDown.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DrinkDeleted = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
