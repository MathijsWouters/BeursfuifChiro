
using System.Windows.Forms;
using static beursfuif.AddDrinksForm;

namespace beursfuif
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private int textBoxLocationX = 0;
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
        private void OnDrinkAdded(Drink drink)
        {
            drinks.Add(drink);
            comboBox1.Items.Add(drink.Name);
            comboBox1.DisplayMember = "Name";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDrink = comboBox1.SelectedItem as Drink;
            if (selectedDrink != null)
            {
                using (var detailsForm = new DrinkDetailsForm(selectedDrink))  // Pass the whole Drink object
                {
                    if (detailsForm.ShowDialog() == DialogResult.OK)
                    {
                        // If a drink was deleted, remove it from the comboBox
                        if (detailsForm.DrinkDeleted)
                        {
                            drinks.Remove(selectedDrink);
                            comboBox1.Items.Remove(selectedDrink);
                        }
                    }
                }
            }
        }
    }
}
