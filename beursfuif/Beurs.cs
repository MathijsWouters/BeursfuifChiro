using DocumentFormat.OpenXml.Spreadsheet;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
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
using static beursfuif.AddDrinksForm;


namespace beursfuif
{
    public partial class Beurs : Form
    {
        private PlotModel plotModel;
        private Dictionary<string, Queue<DataPoint>> drinkDataPoints = new Dictionary<string, Queue<DataPoint>>();
        private FlowLayoutPanel drinksPanel;
        private const int MAX_DATAPOINTS = 12;
        private OxyColor ConvertToOxyColor(System.Drawing.Color color)
        {
            return OxyColor.FromArgb(color.A, color.R, color.G, color.B);
        }

        public Beurs(List<Drink> initialDrinks, Form1 mainForm)
        {
            InitializeComponent();
            mainForm.DrinksUpdated += MainForm_DrinksUpdated;
            mainForm.DrinkChanged += MainForm_DrinkChanged;
            this.Text = "Secondary Window";
            this.BackColor = System.Drawing.Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            plotModel = new PlotModel
            {
                Title = "Beursfuif",
                TitleFontSize = 36,
                Background = OxyColors.Black,
                TextColor = OxyColors.White 
            };

            var timeAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "HH:mm",
                IntervalType = DateTimeIntervalType.Minutes,
                IntervalLength = 5,
                Minimum = OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now.AddMinutes(-60)),
                Maximum = OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now),
                MajorTickSize = 0,  
                MinorTickSize = 0,  
                LabelFormatter = (double s) => "",
                AxislineColor = OxyColors.White,  
                TicklineColor = OxyColors.White,
                AxislineStyle = LineStyle.Solid,
                IsZoomEnabled = false,  
            };

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 5,
                MajorStep = 0.5,
                MinorStep = 0.25,
                AxislineStyle = LineStyle.Solid,
                AxislineColor = OxyColors.White,
                TextColor = OxyColors.White,
                TicklineColor = OxyColors.White,
                IsZoomEnabled = false,  
            };

            plotModel.Axes.Add(timeAxis);
            plotModel.Axes.Add(valueAxis);
            Beursgraph.Model = plotModel;
            UpdateChart(initialDrinks);

            drinksPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = (int)(this.Height * 0.2),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            this.Controls.Add(drinksPanel);
            foreach (var drink in initialDrinks)
            {
                AddDrinkButton(drink);
            }
        }
       
        private void MainForm_DrinksUpdated(List<Drink> updatedDrinks)
        {
            UpdateChart(updatedDrinks);
        }
        private void UpdateChart(List<Drink> drinks)
        {
            plotModel.Series.Clear();

            foreach (var drink in drinks)
            {
                var lineSeries = new LineSeries
                {
                    Title = drink.Name,
                    Color = ConvertToOxyColor(drink.Color)
                };

                if (!drinkDataPoints.ContainsKey(drink.Name))
                {
                    drinkDataPoints[drink.Name] = new Queue<DataPoint>(MAX_DATAPOINTS);
                    var minutesToAdd = new List<int> { -59, -50, -45, -40, -35, -30, -25, -20, -15, -10, -5 };
                    Random rand = new Random();

                    foreach (var minute in minutesToAdd)
                    {
                        int randomNumber = rand.Next(-1, 2);  
                        decimal priceAdjustment = drink.PriceInterval * randomNumber;

                        drinkDataPoints[drink.Name].Enqueue(new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now.AddMinutes(minute)), (double)(drink.CurrentPrice + priceAdjustment)));
                    }
                }
                var queue = drinkDataPoints[drink.Name];
                queue.Enqueue(new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now), (double)drink.CurrentPrice));

                var oneHourAgo = OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now.AddMinutes(-60));
                while (queue.Any() && queue.Peek().X < oneHourAgo)
                {
                    queue.Dequeue();
                }

                foreach (var dataPoint in queue.Where(dp => dp.X >= oneHourAgo))
                {
                    lineSeries.Points.Add(dataPoint);
                }

                plotModel.Series.Add(lineSeries);
            }

            var dateTimeAxis = (DateTimeAxis)plotModel.Axes.FirstOrDefault(a => a is DateTimeAxis);
            if (dateTimeAxis != null)
            {
                dateTimeAxis.Maximum = OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now);
                var lastDataPointTime = drinkDataPoints.Values.SelectMany(q => q).Max(dp => dp.X);
                dateTimeAxis.Minimum = lastDataPointTime - TimeSpan.FromMinutes(60).TotalDays;
            }

            plotModel.InvalidatePlot(true);
        }
        private void MainForm_DrinkChanged(Drink drink, string actionType)
        {
            switch (actionType)
            {
                case "Add":
                    AddDrinkButton(drink);
                    break;
                case "Delete":
                    RemoveDrinkButton(drink);
                    break;
                case "Update":
                    UpdateDrinkButton(drink);
                    break;
            }
        }
        private void AddDrinkButton(Drink drink)
        {
            Button btn = new Button();
            btn.Text = $"{drink.Name}\n{drink.CurrentPrice:C}"; 
            btn.BackColor = drink.Color;
            btn.Width = 190;  // Adjusted size
            btn.Height = 150;  // Adjusted size
            btn.Font = new System.Drawing.Font(btn.Font.FontFamily, 20, System.Drawing.FontStyle.Bold);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Margin = new Padding(10);
            btn.Click += (s, e) => { };

            drinksPanel.Controls.Add(btn);
            CenterButtonsInPanel(); 
        }

        private void RemoveDrinkButton(Drink drink)
        {
            Button btnToRemove = drinksPanel.Controls
                .OfType<Button>()
                .FirstOrDefault(btn => btn.Text.StartsWith(drink.Name)); 

            if (btnToRemove != null)
            {
                drinksPanel.Controls.Remove(btnToRemove);
                btnToRemove.Dispose();
            }

            CenterButtonsInPanel(); 
        }

        private void UpdateDrinkButton(Drink drink)
        {
            Button btnToUpdate = drinksPanel.Controls
                .OfType<Button>()
                .FirstOrDefault(btn => btn.Text.StartsWith(drink.Name)); 

            if (btnToUpdate != null)
            {
                btnToUpdate.BackColor = drink.Color;
                btnToUpdate.Text = $"{drink.Name}\n{drink.CurrentPrice:C}"; 
            }
        }
        private void CenterButtonsInPanel()
        {

            int totalButtonWidth = drinksPanel.Controls.OfType<Button>().Sum(b => b.Width);
            int totalSpacing = drinksPanel.Width - totalButtonWidth;
            int spacingPerButton = totalSpacing / (drinksPanel.Controls.Count + 1);

            int currentPosition = spacingPerButton;
            foreach (System.Windows.Forms.Control btn in drinksPanel.Controls)
            {
                btn.Left = currentPosition;
                currentPosition += btn.Width + spacingPerButton;
            }
        }
    }
}
