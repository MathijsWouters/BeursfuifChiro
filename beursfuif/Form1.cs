
using System.Windows.Forms;
using static beursfuif.AddDrinksForm;

namespace beursfuif
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private int textBoxLocationX = 0;
        private int drinkCount = 0;
        private FlowLayoutPanel flowLayoutPanel;
        List<Control> associatedControls = new List<Control>();
        private List<Drink> drinks = new List<Drink>();

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
            AddDrinksForm addDrinksForm = new AddDrinksForm();
            addDrinksForm.DrinkAdded += OnDrinkAdded;
            addDrinksForm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
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
        private void OpenForm2Button_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
        private void AddDrinksButton_Click(object sender, EventArgs e)
        {
            AddDrinksForm addDrinksForm = new AddDrinksForm();
            addDrinksForm.DrinkAdded += OnDrinkAdded;
            addDrinksForm.Show();
        }
        private void OnDrinkAdded(Drink newDrink)
        {
            drinkCount++;
            Button drinkButton = CreateDrinkButton(newDrink, drinkCount);
            // Set the location for your button, e.g., use the drinkCount to position it in a grid layout
            // For now, just setting a sample location:
            flowLayoutPanel.Controls.Add(drinkButton); // Add the button to Form1


        }
        private Button CreateDrinkButton(Drink drink, int drinkNumber)
        {
            Button drinkButton = new Button();
            drinkButton.Width = 150;
            drinkButton.Height = 80; 
            drinkButton.BackColor = drink.Color;
            drinkButton.Margin = new Padding(5);

            decimal averagePrice = (drink.MinPrice + drink.MaxPrice) / 2;
            string buttonText = $"{drinkNumber}\n{drink.Name}\n{averagePrice.ToString("F2")} EUR";

            drinkButton.Text = buttonText;
            drinkButton.Font = new Font(drinkButton.Font.FontFamily, drinkButton.Font.Size, FontStyle.Bold);

            return drinkButton;
        }
    }
}
