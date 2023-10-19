
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using static beursfuif.AddDrinksForm;
namespace beursfuif
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private FlowLayoutPanel flowLayoutPanel;
        List<Control> associatedControls = new List<Control>();
        private List<Drink> drinks = new List<Drink>();
        public bool DeleteModeEnabled { get; set; } = false;
        public event DrinkAddedEventHandler DrinkAdded;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Beursfuif";
            // Form properties
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            // Set initial position of the addButton
            // Label properties
            // TextBox properties
            // Button properties
            // Example of opening the AddDrinksForm
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("drinksData.json"))
                {
                    string json = File.ReadAllText("drinksData.json");
                    drinks = JsonConvert.DeserializeObject<List<Drink>>(json);
                    for (int i = 0; i < drinks.Count; i++)
                    {
                        Button drinkButton = CreateDrinkButton(drinks[i], i + 1);
                        flowLayoutPanel.Controls.Add(drinkButton);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void titleBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void titleBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void titleBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void OpenBeursButton_Click(object sender, EventArgs e)
        {
            Beurs Beurs = new Beurs();
            Beurs.Show();
        }
        private void AddDrinksButton_Click(object sender, EventArgs e)
        {
            AddDrinksForm addDrinksForm = new AddDrinksForm();
            addDrinksForm.DrinkAdded += OnDrinkAdded;
            addDrinksForm.Show();
        }
        private void OnDrinkAdded(Drink newDrink)
        {
            Button drinkButton = CreateDrinkButton(newDrink, drinks.Count + 1);
            flowLayoutPanel.Controls.Add(drinkButton);
            drinks.Add(newDrink);
            SaveDrinksToFile();
            RefreshDrinkLayout();
        }
        public class CustomButton : Button
        {
            public bool Selected { get; set; } = false;
            public bool DeleteModeEnabled { get; set; } = false;
            public Drink AssociatedDrink { get; set; }


            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                if (DeleteModeEnabled) // global variable to check if delete mode is on
                {
                    Selected = !Selected;
                    this.BackColor = Selected ? Color.Red : Color.FromArgb(45, 45, 48); // change color if selected
                }
            }
            public Color LeftColor { get; set; } = Color.Blue; // Default color
            public Color RightColor { get; set; } = Color.FromArgb(30, 0, 0, 0); // Black tint
            protected override void OnPaint(PaintEventArgs pevent)
            {
                // Clear everything to draw manually
                pevent.Graphics.Clear(this.BackColor);

                // Draw the left color
                using (SolidBrush brush = new SolidBrush(LeftColor))
                {
                    pevent.Graphics.FillRectangle(brush, 0, 0, this.Width / 5, this.Height);
                }

                // Draw the background for the remaining 4/5 of the button
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(30, 0, 0, 0))) // Slightly transparent black
                {
                    pevent.Graphics.FillRectangle(brush, this.Width / 5, 0, 4 * this.Width / 5, this.Height);
                }

                // Split the text to render different parts separately
                string[] textLines = this.Text.Split('\n');
                if (textLines.Length >= 3)
                {
                    Rectangle numberRect = new Rectangle((int)(this.Width * 0.25), (int)(this.Height / 4), (int)(this.Width * 0.25), (int)(this.Height / 2));
                    Rectangle nameRect = new Rectangle((int)(this.Width / 5), (int)(this.Height / 4), (int)(4 * this.Width / 5), (int)(this.Height / 2));
                    Rectangle priceRect = new Rectangle(0, (int)(this.Height - 30), this.Width - 5, 25);

                    // Draw slightly less black rectangle for the number
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0))) // Adjust transparency as needed
                    {
                        pevent.Graphics.FillRectangle(brush, numberRect);
                    }

                    Font biggerFont = new Font(this.Font.FontFamily, (this.Font.Size + 5), FontStyle.Bold);
                    Font nameFont = new Font(this.Font.FontFamily, (this.Font.Size + 1), FontStyle.Bold);
                    TextRenderer.DrawText(pevent.Graphics, textLines[0], biggerFont, numberRect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    TextRenderer.DrawText(pevent.Graphics, textLines[1], nameFont, nameRect, this.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                    TextRenderer.DrawText(pevent.Graphics, textLines[2], this.Font, priceRect, this.ForeColor, TextFormatFlags.Right | TextFormatFlags.Bottom);
                }

                // Draw the border
                using (Pen pen = new Pen(Color.White, 3)) // 3 for thicker border
                {
                    pevent.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            }
        }
        private CustomButton CreateDrinkButton(Drink drink, int drinkNumber)
        {
            CustomButton drinkButton = new CustomButton();
            drinkButton.Width = 250;
            drinkButton.Height = 95;
            drinkButton.LeftColor = drink.Color;  // Assigning the drink's color to LeftColor
            drinkButton.Margin = new Padding(5);
            decimal averagePrice = (drink.MinPrice + drink.MaxPrice) / 2;
            string buttonText = $"{drinkNumber}\n{drink.Name}\n{averagePrice.ToString("F2")} EUR";
            drinkButton.Text = buttonText;
            drinkButton.Font = new Font(drinkButton.Font.FontFamily, drinkButton.Font.Size * 1.5f, FontStyle.Bold);
            drinkButton.AssociatedDrink = drink;
            drinkButton.Click += (s, e) =>
            
            {
                var btn = s as CustomButton;

                if (btn == null) // Just to be safe
                    return;
                if (DeleteModeEnabled)
                {
                    btn.Selected = !btn.Selected;
                    btn.BackColor = btn.Selected ? Color.Red : Color.FromArgb(45, 45, 48);
                }
                else
                {
                    MessageBox.Show($"You clicked on {btn.AssociatedDrink.Name}");
                }
            };
            return drinkButton;
        }
        private void deleteDrinksButton_Click(object sender, EventArgs e)
        {
            if (!flowLayoutPanel.Controls.OfType<CustomButton>().Any())
            {
                MessageBox.Show("No drinks to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DeleteModeEnabled)
            {
                // Handle the deletion
                var drinksToDelete = flowLayoutPanel.Controls.OfType<CustomButton>().Where(b => b.Selected).ToList();
                foreach (var btn in drinksToDelete)
                {
                    if (btn.AssociatedDrink != null)
                    {
                        drinks.Remove(btn.AssociatedDrink);
                    }
                    flowLayoutPanel.Controls.Remove(btn);
                    btn.Dispose();  // Dispose of the button after removing
                }
                RefreshDrinkLayout();
                SaveDrinksToFile();
            }

            // Toggle the delete mode after handling deletions (if applicable)
            DeleteModeEnabled = !DeleteModeEnabled;
            deleteDrinksButton.Text = DeleteModeEnabled ? "Confirm Deletion" : "Delete Drinks";
        }

        private void RefreshDrinkLayout()
        {
            int counter = 1;
            foreach (var control in flowLayoutPanel.Controls.OfType<CustomButton>())
            {
                string[] lines = control.Text.Split('\n');
                control.Text = $"{counter}\n{lines[1]}\n{lines[2]}";
                counter++;
            }
        }
        private void SaveDrinksToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(drinks);
                File.WriteAllText("drinksData.json", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}");
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int numberPressed = -1;
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    numberPressed = 0;
                    break;
                case Keys.NumPad1:
                    numberPressed = 1;
                    break;
                case Keys.NumPad2:
                    numberPressed = 2;
                    break;
                case Keys.NumPad3:
                    numberPressed = 3;
                    break;
                case Keys.NumPad4:
                    numberPressed = 4;
                    break;
                case Keys.NumPad5:
                    numberPressed = 5;
                    break;
                case Keys.NumPad6:
                    numberPressed = 6;
                    break;
                case Keys.NumPad7:
                    numberPressed = 7;
                    break;
                case Keys.NumPad8:
                    numberPressed = 8;
                    break;
                case Keys.NumPad9:
                    numberPressed = 9;
                    break;

                    
            }

            if (numberPressed != -1)
            {
               
                Button correspondingButton = FindButtonWithNumber(numberPressed);
                if (correspondingButton != null)
                {
                    correspondingButton.PerformClick();
                }
            }
        }

        private CustomButton FindButtonWithNumber(int number)
        {
            // Iterate over all CustomButtons in the flowLayoutPanel and find the one with the correct number
            foreach (Control ctrl in flowLayoutPanel.Controls)
            {
                if (ctrl is CustomButton)
                {
                    CustomButton btn = (CustomButton)ctrl;
                    // Get the first line of the button's text, which contains the drinkNumber
                    string firstLine = btn.Text.Split('\n').FirstOrDefault();
                    if (int.TryParse(firstLine, out int parsedNumber) && parsedNumber == number)
                    {
                        return btn;
                    }
                }
            }
            return null;
        }
    }
}
