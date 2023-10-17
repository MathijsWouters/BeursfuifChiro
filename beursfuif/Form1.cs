
using System.Windows.Forms;

namespace beursfuif
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        List<Control> associatedControls = new List<Control>();

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
            UpdateAddButtonPosition();
            // Label properties

            // TextBox properties


            // Button properties
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
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (drinkTextBoxes.Count < 9)
            {
                int yOffset = 80 + drinkTextBoxes.Count * 30;
                int minLocationX = this.ClientSize.Width - 700;
                int normalLocationX = minLocationX + 100;
                int maxLocationX = normalLocationX + 100;
                int textBoxLocationX = maxLocationX + 100;
                int deleteButtonLocationX = textBoxLocationX + 200;
                // Drink TextBox
                TextBox newTextBox = new TextBox();
                newTextBox.Location = new Point(textBoxLocationX, yOffset);
                SetPlaceholder(newTextBox, "Drink");
                newTextBox.Enter += (s, ev) => ClearPlaceholder(newTextBox, "Drink");
                newTextBox.Leave += (s, ev) => SetPlaceholder(newTextBox, "Drink");
                drinkTextBoxes.Add(newTextBox);
                this.Controls.Add(newTextBox);

                // Min Price NumericUpDown and Label
                var minPriceControls = CreatePriceControl(minLocationX, yOffset, "Min");
                // Normal Price NumericUpDown and Label
                var normalPriceControls = CreatePriceControl(normalLocationX, yOffset, "Normal");
                // Max Price NumericUpDown and Label
                var maxPriceControls = CreatePriceControl(maxLocationX, yOffset, "Max");

                associatedControls.Add(newTextBox);
                associatedControls.Add(minPriceControls.Item1); // Add Label
                associatedControls.Add(minPriceControls.Item2); // Add NumericUpDown
                associatedControls.Add(normalPriceControls.Item1);
                associatedControls.Add(normalPriceControls.Item2);
                associatedControls.Add(maxPriceControls.Item1);
                associatedControls.Add(maxPriceControls.Item2);

                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.Location = new Point(deleteButtonLocationX, yOffset);
                deleteButton.Tag = associatedControls;  // Here's the change
                deleteButton.Click += DeleteButton_Click;
                deleteButtons.Add(deleteButton);
                this.Controls.Add(deleteButton);
                // Update the position of addButton
                UpdateAddButtonPosition();

                if (drinkTextBoxes.Count == 9)
                {
                    addButton.Visible = false;
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) // For number keys above letters
            {
                int index = e.KeyCode - Keys.D1; // Gets index from 0-8
                HandleDrinkSelection(index);
            }
            else if (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9) // For numeric keypad
            {
                int index = e.KeyCode - Keys.NumPad1; // Gets index from 0-8
                HandleDrinkSelection(index);
            }
        }
        private void HandleDrinkSelection(int index)
        {
            if (index >= 0 && index < drinkTextBoxes.Count)
            {
                string drinkName = drinkTextBoxes[index].Text;

                // Handle the selected drink
                MessageBox.Show($"You selected: {drinkName}");
            }
        }
        private void UpdateAddButtonPosition()
        {
            // Adjust the positioning so the button is always above the latest TextBox
            int yOffset = 80 + drinkTextBoxes.Count * 30;
            addButton.Location = new Point(this.ClientSize.Width - 300, yOffset);
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = sender as Button;
            List<Control> associatedControls = deleteButton.Tag as List<Control>;

            foreach (Control ctrl in associatedControls)
            {
                this.Controls.Remove(ctrl);
                if (ctrl is TextBox)
                {
                    drinkTextBoxes.Remove(ctrl as TextBox);
                }
            }
            this.Controls.Remove(deleteButton);
            deleteButtons.Remove(deleteButton);

            // Rearrange the remaining TextBoxes and Delete buttons
            for (int i = 0; i < drinkTextBoxes.Count; i++)
            {
                drinkTextBoxes[i].Location = new Point(this.ClientSize.Width - 300, 80 + i * 30);
                deleteButtons[i].Location = new Point(this.ClientSize.Width - 200, 80 + i * 30);
            }

            // If there are less than 9 TextBoxes, make the addButton visible again
            if (drinkTextBoxes.Count < 9)
            {
                addButton.Visible = true;
            }

            // Update the position of addButton
            UpdateAddButtonPosition();
        }
        private void SetPlaceholder(TextBox tb, string placeholder)
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = placeholder;
                tb.ForeColor = Color.Gray;
            }
        }
        private void ClearPlaceholder(TextBox tb, string placeholder)
        {
            if (tb.Text == placeholder)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black; // Or whatever your default color is
            }
        }
        private void SetPlaceholder(NumericUpDown nud, Label lbl, string placeholder)
        {
            if (nud.Value == 0 && nud.Tag.ToString() == placeholder)
            {
                lbl.Visible = true;
            }
        }
        private void ClearPlaceholder(NumericUpDown nud, Label lbl, string placeholder)
        {
            if (nud.Value == 0)
            {
                lbl.Visible = false;
                nud.Tag = placeholder;
            }
        }
        private Tuple<Label, NumericUpDown> CreatePriceControl(int xLocation, int yOffset, string type)
        {
            Label label = new Label();
            label.Text = type;
            label.ForeColor = Color.Gray;
            label.Location = new Point(xLocation, yOffset);
            this.Controls.Add(label);

            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Location = new Point(xLocation + 40, yOffset); // Place it 40 pixels to the right of the label
            numericUpDown.Tag = type;
            numericUpDown.Enter += (s, ev) => ClearPlaceholder(numericUpDown, label, type);
            numericUpDown.Leave += (s, ev) => SetPlaceholder(numericUpDown, label, type);
            this.Controls.Add(numericUpDown);

            return new Tuple<Label, NumericUpDown>(label, numericUpDown);
        }

    }
}
