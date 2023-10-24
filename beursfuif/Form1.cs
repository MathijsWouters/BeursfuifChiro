
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;
using Newtonsoft.Json;
using System.Data;
using System.Data.SQLite;
using System.IO;
using static beursfuif.AddDrinksForm;
using System.Collections.Generic;

namespace beursfuif
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private double totalIncome = 0.0;
        private int countdown = 10;
        private Point lastLocation;
        private Beurs beursForm;
        private ListBox reciptDrinkListBox;
        private FlowLayoutPanel flowLayoutPanel;
        private bool partyModeActive = false;
        private Color originalCrashButtonColor;
        private bool isOriginalColor = true;
        private Stack<Drink> lastAddedDrinks = new Stack<Drink>();
        public delegate void DrinksUpdatedEventHandler(List<Drink> updatedDrinks);
        public event DrinksUpdatedEventHandler DrinksUpdated;
        List<Control> associatedControls = new List<Control>();
        private List<Drink> drinks = new List<Drink>();
        public event Action<Drink, string> DrinkChanged;
        private Dictionary<Drink, int> orderedDrinks = new Dictionary<Drink, int>();
        public bool DeleteModeEnabled { get; set; } = false;
        public event DrinkAddedEventHandler DrinkAdded;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Beursfuif";
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.KeyPreview = true;
            this.Resize += Form1_Resize;
            CrashButton.Location = new Point((this.ClientSize.Width - CrashButton.Width) / 2,
                     this.ClientSize.Height - CrashButton.Height - 50);
            this.Resize += (s, e) =>
            {
                CrashButton.Location = new Point((this.ClientSize.Width - CrashButton.Width) / 2,
                                                 this.ClientSize.Height - CrashButton.Height - 50);
            };
            if (!this.Controls.Contains(CrashButton))
            {
                this.Controls.Add(CrashButton);
            }

            reciptDrinkListBox.Font = new Font(reciptDrinkListBox.Font.FontFamily, reciptDrinkListBox.Font.Size + 3, FontStyle.Bold);

            lblTotal.Font = new Font(lblTotal.Font.FontFamily, lblTotal.Font.Size + 4, FontStyle.Bold);
            lblVakjes.Font = new Font(lblVakjes.Font.FontFamily, lblVakjes.Font.Size + 4, FontStyle.Bold);
            priceUpdateTimer.Interval = 300000;
            priceUpdateTimer.Tick += PriceUpdateTimer_Tick;
            partyModeTimer.Interval = 500;
            partyModeTimer.Tick += PartyModeTimer_Tick;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyDown += Form1_KeyDown;
            string databaseFileName = "DrinksDB.db";
            string connectionString = $"Data Source={databaseFileName};Version=3;Mode=ReadWrite";

            try
            {
                if (!File.Exists(databaseFileName))
                {
                    SQLiteConnection.CreateFile(databaseFileName);

                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        string createDrinksSoldTable = "CREATE TABLE DrinksSold (DrinkName TEXT, QuantitySold INTEGER)";
                        string createTotalIncomeTable = "CREATE TABLE TotalIncome (Inkomsten REAL)";

                        using (SQLiteCommand cmd = new SQLiteCommand(createDrinksSoldTable, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        using (SQLiteCommand cmd = new SQLiteCommand(createTotalIncomeTable, connection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                string jsonFileName = "drinksData.json";
                if (File.Exists("drinksData.json"))
                {
                    string json = File.ReadAllText(jsonFileName);
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
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            PositionLabels();
            PositionTimerLabel();
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
            if (!flowLayoutPanel.Controls.OfType<CustomButton>().Any())
            {
                MessageBox.Show("Voeg eens even snel drankjes toe anders gaat de beurs niet open hoor!", "Geen beurs zonder drinken", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (beursForm == null || beursForm.IsDisposed)
            {
                beursForm = new Beurs(drinks, this);
                beursForm.Show();
            }
            else
            {
                if (beursForm.WindowState == FormWindowState.Minimized)
                {
                    beursForm.WindowState = FormWindowState.Maximized;
                }
                beursForm.BringToFront();
            }
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
            DrinkChanged?.Invoke(newDrink, "Add");
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
                if (DeleteModeEnabled) 
                {
                    Selected = !Selected;
                    this.BackColor = Selected ? Color.Red : Color.FromArgb(45, 45, 48); 
                }
            }
            public Color LeftColor { get; set; } = Color.Blue; 
            public Color RightColor { get; set; } = Color.FromArgb(30, 0, 0, 0); 
            protected override void OnPaint(PaintEventArgs pevent)
            {
                pevent.Graphics.Clear(this.BackColor);
                using (SolidBrush brush = new SolidBrush(LeftColor))
                {
                    pevent.Graphics.FillRectangle(brush, 0, 0, this.Width / 5, this.Height);
                }
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(30, 0, 0, 0))) 
                {
                    pevent.Graphics.FillRectangle(brush, this.Width / 5, 0, 4 * this.Width / 5, this.Height);
                }
                string[] textLines = this.Text.Split('\n');
                if (textLines.Length >= 3)
                {
                    Rectangle numberRect = new Rectangle((int)(this.Width * 0.25), (int)(this.Height / 4), (int)(this.Width * 0.25), (int)(this.Height / 2));
                    Rectangle nameRect = new Rectangle((int)(this.Width / 5), (int)(this.Height / 4), (int)(4 * this.Width / 5), (int)(this.Height / 2));
                    Rectangle priceRect = new Rectangle(0, (int)(this.Height - 30), this.Width - 5, 25);
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0))) 
                    {
                        pevent.Graphics.FillRectangle(brush, numberRect);
                    }

                    Font biggerFont = new Font(this.Font.FontFamily, (this.Font.Size + 5), FontStyle.Bold);
                    Font nameFont = new Font(this.Font.FontFamily, (this.Font.Size + 1), FontStyle.Bold);
                    TextRenderer.DrawText(pevent.Graphics, textLines[0], biggerFont, numberRect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    TextRenderer.DrawText(pevent.Graphics, textLines[1], nameFont, nameRect, this.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                    TextRenderer.DrawText(pevent.Graphics, textLines[2], this.Font, priceRect, this.ForeColor, TextFormatFlags.Right | TextFormatFlags.Bottom);
                }
                using (Pen pen = new Pen(Color.White, 3)) 
                {
                    pevent.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            }
        }
        private CustomButton CreateDrinkButton(Drink drink, int drinkNumber)
        {
            CustomButton drinkButton = new CustomButton();
            drinkButton.Width = 300;
            drinkButton.Height = 95;
            drinkButton.LeftColor = drink.Color;  // Assigning the drink's color to LeftColor
            drinkButton.Margin = new Padding(20);
            drink.CurrentPrice = (drink.MinPrice + drink.MaxPrice) / 2;
            string buttonText = $"{drinkNumber}\n{drink.Name}\n{drink.CurrentPrice.ToString("F2")} EUR";
            drinkButton.Text = buttonText;
            drinkButton.Font = new Font(drinkButton.Font.FontFamily, drinkButton.Font.Size * 1.5f, FontStyle.Bold);
            drinkButton.AssociatedDrink = drink;
            drinkButton.Click += (s, e) =>

            {
                var btn = s as CustomButton;

                if (btn == null) 
                    return;
                if (DeleteModeEnabled)
                {
                    btn.Selected = !btn.Selected;
                    btn.BackColor = btn.Selected ? Color.Red : Color.FromArgb(45, 45, 48);
                }
                else
                {
                    if (orderedDrinks.ContainsKey(btn.AssociatedDrink))
                    {
                        orderedDrinks[btn.AssociatedDrink]++;
                    }
                    else
                    {
                        orderedDrinks[btn.AssociatedDrink] = 1;
                    }

                    RefreshOrderList();
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
                var drinksToDelete = flowLayoutPanel.Controls.OfType<CustomButton>().Where(b => b.Selected).ToList();
                foreach (var btn in drinksToDelete)
                {
                    if (btn.AssociatedDrink != null)
                    {
                        drinks.Remove(btn.AssociatedDrink);
                        DrinkChanged?.Invoke(btn.AssociatedDrink, "Delete");
                    }
                    flowLayoutPanel.Controls.Remove(btn);
                    btn.Dispose(); 
                }
                RefreshDrinkLayout();
                SaveDrinksToFile();
            }
            DeleteModeEnabled = !DeleteModeEnabled;
            deleteDrinksButton.Text = DeleteModeEnabled ? "Confirm Deletion" : "Delete Drinks";
        }
        private void RefreshDrinkLayout()
        {
            int counter = 1;
            foreach (var control in flowLayoutPanel.Controls.OfType<CustomButton>())
            {
                string[] lines = control.Text.Split('\n');
                if (lines.Length > 1)
                {
                    string drinkName = lines[1].Trim();
                    Drink correspondingDrink = drinks.FirstOrDefault(d => d.Name == drinkName);
                    if (correspondingDrink != null)
                    {
                        string updatedPriceText = $"{correspondingDrink.CurrentPrice:C2}"; 
                        control.Text = $"{counter}\n{drinkName}\n{updatedPriceText}";
                    }
                }
                counter++;
            }
        }

        private void SaveDrinksToFile()
        {
            try
            {
                string jsonFileName = "drinksData.json";  

                string json = JsonConvert.SerializeObject(drinks);
                File.WriteAllText(jsonFileName, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteLastItem(sender, e);
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Tab)
            {
                CrashButton_Click(sender, e);
                e.Handled = true;
            }
            int numberPressed = -1;
            switch (e.KeyCode)
            {
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
            foreach (Control ctrl in flowLayoutPanel.Controls)
            {
                if (ctrl is CustomButton)
                {
                    CustomButton btn = (CustomButton)ctrl;
                    string firstLine = btn.Text.Split('\n').FirstOrDefault();
                    if (int.TryParse(firstLine, out int parsedNumber) && parsedNumber == number)
                    {
                        return btn;
                    }
                }
            }
            return null;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            AdjustListBoxPosition();
            PositionTimerLabel();
        }
        private void AdjustListBoxPosition()
        {
            int marginRight = 20; 
            int marginTop = 75;
            reciptDrinkListBox.Location = new Point(this.ClientSize.Width - reciptDrinkListBox.Width - marginRight, marginTop);
            int padding = 10;
            int lblTotalY = reciptDrinkListBox.Top + reciptDrinkListBox.Height + padding;
            int lblX = this.ClientSize.Width - this.lblTotal.Width - 20;
            lblTotal.Location = new Point(lblX, lblTotalY);
            int lblVakjesY = lblTotalY + this.lblTotal.Height + padding;
            lblVakjes.Location = new Point(lblX, lblVakjesY);
        }
        private void RefreshOrderList()
        {
            reciptDrinkListBox.Items.Clear();
            decimal totalOrder = 0m;
            countdown = 10;
            UpdateTimerLabel();
            timer1.Start();
            lastAddedDrinks.Clear();

            foreach (var order in orderedDrinks)
            {
                Drink drink = order.Key;
                int count = order.Value;
                decimal total = drink.CurrentPrice * count;
                totalOrder += total;
                reciptDrinkListBox.Items.Add($"{drink.Name} x {count} = {total.ToString("F2")}€");

                for (int i = 0; i < count; i++)
                {
                    lastAddedDrinks.Push(drink);
                }
            }
            lblTotal.Text = $"Total: {totalOrder.ToString("F2")}€";

            int vakjes = (int)(totalOrder / 0.25m);
            lblVakjes.Text = $"Vakjes: {vakjes.ToString("F2")}";
        }
        private void PositionLabels()
        {
            int padding = 10;
            int lblTotalY = reciptDrinkListBox.Top + reciptDrinkListBox.Height + padding;
            int lblVakjesY = lblTotalY + lblTotal.Height + padding;
            int lblX = reciptDrinkListBox.Left;
            lblTotal.Location = new Point(lblX, lblTotalY);
            lblVakjes.Location = new Point(lblX, lblVakjesY);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            countdown--;

            if (countdown <= 0)
            {
                ClearDrinks();
            }
            else
            {
                UpdateTimerLabel();
            }
        }
        private void UpdateTimerLabel()
        {
            lblTimer.Text = $"Time remaining: {countdown} seconds";
        }
        private void ClearDrinks()
        {
            string databaseFilePath = "DrinksDB.db";
            string connectionString = $"Data Source={databaseFilePath};Version=3;Mode=ReadWrite";
            double totalIncome = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                foreach (string order in reciptDrinkListBox.Items)
                {
                    if (!order.Contains(" x ") || !order.Contains("="))
                        continue; 

                    string[] parts = order.Split(new[] { " x " }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        string drinkName = parts[0].Trim();
                        int quantity;
                        if (int.TryParse(parts[1].Split('=')[0].Trim(), out quantity))
                        {
                            var drinkToUpdate = drinks.FirstOrDefault(d => d.Name == drinkName);
                            if (drinkToUpdate != null)
                            {
                                drinkToUpdate.CurrentAmountPurchased += quantity;
                            }
                            string checkQuery = $"SELECT COUNT(*) FROM DrinksSold WHERE DrinkName = '{drinkName}'";
                            using (SQLiteCommand cmdCheck = new SQLiteCommand(checkQuery, connection))
                            {
                                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                                if (count == 0) 
                                {
                                    string insertQuery = $"INSERT INTO DrinksSold (DrinkName, QuantitySold) VALUES ('{drinkName}', {quantity})";
                                    using (SQLiteCommand cmdInsert = new SQLiteCommand(insertQuery, connection))
                                    {
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                                else 
                                {
                                    string updateQuery = $"UPDATE DrinksSold SET QuantitySold = QuantitySold + {quantity} WHERE DrinkName = '{drinkName}'";
                                    using (SQLiteCommand cmdUpdate = new SQLiteCommand(updateQuery, connection))
                                    {
                                        cmdUpdate.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
                string totalString = lblTotal.Text.Replace("Total: ", "").Replace("€", "").Trim();
                if (double.TryParse(totalString, out totalIncome))
                {

                }
                else
                {
                    totalIncome = 0;
                }

                string checkIncomeQuery = "SELECT COUNT(*) FROM TotalIncome";
                using (SQLiteCommand cmdCheckIncome = new SQLiteCommand(checkIncomeQuery, connection))
                {
                    int count = Convert.ToInt32(cmdCheckIncome.ExecuteScalar());
                    if (count == 0) 
                    {
                        string incomeQuery = $"INSERT INTO TotalIncome (Inkomsten) VALUES ({totalIncome})";
                        using (SQLiteCommand cmdInsert = new SQLiteCommand(incomeQuery, connection))
                        {
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                    else 
                    {
                        string formattedIncome = totalIncome.ToString(CultureInfo.InvariantCulture);
                        string incomeQuery = $"UPDATE TotalIncome SET Inkomsten = Inkomsten + {formattedIncome}";
                        using (SQLiteCommand cmdUpdate = new SQLiteCommand(incomeQuery, connection))
                        {
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                }
                reciptDrinkListBox.Items.Clear();
                orderedDrinks.Clear();
                timer1.Stop();
                countdown = 10;
                lblTotal.Text = "Total: €0.00";
                lblVakjes.Text = "Vakjes: 0";
                UpdateTimerLabel();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                ClearDrinks();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void PositionTimerLabel()
        {

            lblTimer.AutoSize = true;
            lblTimer.Text = "Time remaining: 10 seconds";
            Font currentFont = lblTimer.Font;
            lblTimer.Font = new Font(currentFont.FontFamily, currentFont.Size, FontStyle.Bold);
            lblTimer.Left = reciptDrinkListBox.Left + (reciptDrinkListBox.Width - lblTimer.Width) / 2;
            lblTimer.Top = reciptDrinkListBox.Top - lblTimer.Height - 10;
        }
        private void UpdateDrinkPrices()
        {
            if (partyModeActive)
            {
                partyModeTimer.Stop();
                CrashButton.BackColor = originalCrashButtonColor;
                partyModeActive = false;
            }
            foreach (var drink in drinks)
            {
                decimal originalPrice = drink.CurrentPrice;

                if (drink.CurrentAmountPurchased > drink.Threshold)
                {
                    var priceIncrease = drink.PriceInterval * RandomChance();
                    drink.CurrentPrice += priceIncrease;
                }
                else
                {
                    drink.CurrentPrice -= drink.PriceInterval * RandomChance();
                }
                drink.CurrentPrice = Math.Max(drink.MinPrice, Math.Min(drink.CurrentPrice, drink.MaxPrice));

                if (originalPrice != drink.CurrentPrice)
                {
                    DrinkChanged?.Invoke(drink, "Update");
                }

                drink.CurrentAmountPurchased = 0;
            }
            DrinksUpdated?.Invoke(drinks);
            RefreshDrinkLayout();
        }
        private int RandomChance()
        {
            Random rand = new Random();
            double randomValue = rand.NextDouble();

            if (randomValue < 0.3333)
                return 0;
            else if (randomValue < 0.6666)
                return 1;
            else
                return 2;
        }
        private void StartTimerButton_Click(object sender, EventArgs e)
        {
            priceUpdateTimer.Start();
            startTimerButton.BackColor = Color.Green;
        }
        private void PriceUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (partyModeActive)
            {
                ResetPricesToAverage();
            }
            UpdateDrinkPrices();
            priceUpdateTimer.Stop();
            priceUpdateTimer.Start();
        }
        private void stopfeest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to end the party?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string databaseFileName = "DrinksDB.db";
                string connectionString = $"Data Source={databaseFileName};Version=3;";

                var workbook = new ClosedXML.Excel.XLWorkbook();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Export DrinksSold table to Excel
                    SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM DrinksSold", connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    workbook.Worksheets.Add(dt, "Drinks Sold");

                    // Export TotalIncome table to Excel
                    da = new SQLiteDataAdapter("SELECT * FROM TotalIncome", connection);
                    dt = new DataTable();
                    da.Fill(dt);
                    workbook.Worksheets.Add(dt, "Total Income");

                    // Empty the DrinksSold and TotalIncome tables
                    string clearQuery = "DELETE FROM DrinksSold";
                    using (SQLiteCommand cmd = new SQLiteCommand(clearQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    clearQuery = "DELETE FROM TotalIncome";
                    using (SQLiteCommand cmd = new SQLiteCommand(clearQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
                string excelFileName = Path.Combine(downloadsPath, "Beursfuifdata.xlsx");
                workbook.SaveAs(excelFileName);
                MessageBox.Show($"Data exported to {excelFileName} and database cleared.");
                this.Close();
            }
        }
        private void DeleteLastItem(object sender, EventArgs e)
        {
            if (lastAddedDrinks.Count > 0)
            {
                Drink lastDrink = lastAddedDrinks.Pop();
                for (int i = 0; i < reciptDrinkListBox.Items.Count; i++)
                {
                    string listItem = reciptDrinkListBox.Items[i].ToString();
                    string[] parts = listItem.Split(new[] { " x " }, StringSplitOptions.None);

                    if (parts.Length == 2 && parts[0].Trim() == lastDrink.Name)
                    {
                        string drinkNameString = parts[0].Trim();
                        double totalPriceForItem;
                        int quantity;

                        if (int.TryParse(parts[1].Split('=')[0].Trim(), out quantity)
                            && double.TryParse(parts[1].Split('=')[1].Replace("€", "").Trim(), out totalPriceForItem))
                        {
                            double pricePerUnit = totalPriceForItem / quantity;
                            string totalString = lblTotal.Text.Replace("Total: ", "").Replace("€", "").Trim();

                            if (double.TryParse(totalString, out double totalOrder))
                            {
                                totalOrder -= pricePerUnit;
                                lblTotal.Text = $"Total: {totalOrder.ToString("F2")}€";
                            }

                            if (quantity > 1)
                            {
                                quantity--;
                                reciptDrinkListBox.Items[i] = $"{drinkNameString} x {quantity} = {(pricePerUnit * quantity).ToString("F2")}€";
                                if (orderedDrinks.ContainsKey(lastDrink))
                                {
                                    orderedDrinks[lastDrink] = quantity;
                                }
                            }
                            else
                            {
                                reciptDrinkListBox.Items.RemoveAt(i);
                                if (orderedDrinks.ContainsKey(lastDrink))
                                {
                                    orderedDrinks.Remove(lastDrink);
                                }
                            }

                            int vakjes = (int)(totalOrder / 0.25);
                            lblVakjes.Text = $"Vakjes: {vakjes}";
                        }
                        break;
                    }
                }
                timer1.Stop();  
                countdown = 10; 
                UpdateTimerLabel();
            }
        }
        private void CrashPrices()
        {
            foreach (var drink in drinks)
            {
                drink.CurrentPrice = drink.MinPrice;
                DrinkChanged?.Invoke(drink, "Update");
            }
            DrinksUpdated?.Invoke(drinks);
            RefreshDrinkLayout();

        }

        private void CrashButton_Click(object sender, EventArgs e)
        {
            partyModeActive = true;
            CrashPrices();
            partyModeTimer.Start();
            ResetPriceUpdateTimer();
        }
        private void ResetPriceUpdateTimer()
        {
            if (priceUpdateTimer != null)
            {
                priceUpdateTimer.Stop();
                priceUpdateTimer.Start();
            }
        }
        private void PartyModeTimer_Tick(object sender, EventArgs e)
        {
            if (isOriginalColor)
            {
                CrashButton.BackColor = GetRandomColor();
            }
            else
            {
                CrashButton.BackColor = originalCrashButtonColor;
            }
            isOriginalColor = !isOriginalColor; // Toggle the flag
        }
        private Color GetRandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
        private void ResetPricesToAverage()
        {
            foreach (var drink in drinks)
            {
                drink.CurrentPrice = (drink.MinPrice + drink.MaxPrice) / 2 + drink.PriceInterval;
            }
            DrinksUpdated?.Invoke(drinks);
            RefreshDrinkLayout();
        }
    }
}
