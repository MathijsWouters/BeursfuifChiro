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
        private const int MAX_DATAPOINTS = 12;
        private OxyColor ConvertToOxyColor(System.Drawing.Color color)
        {
            return OxyColor.FromArgb(color.A, color.R, color.G, color.B);
        }

        public Beurs(List<Drink> initialDrinks, Form1 mainForm)
        {
            InitializeComponent();
            mainForm.DrinksUpdated += MainForm_DrinksUpdated;
            this.Text = "Secondary Window";
            this.BackColor = System.Drawing.Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            plotModel = new PlotModel
            {
                Title = "Beurs Live Chart",
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
                }
                var queue = drinkDataPoints[drink.Name];
                queue.Enqueue(new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now), (double)drink.CurrentPrice));
                while (queue.Count > MAX_DATAPOINTS)
                {
                    queue.Dequeue();
                }

                foreach (var dataPoint in queue)
                {
                    lineSeries.Points.Add(dataPoint);
                }

                plotModel.Series.Add(lineSeries);
            }
            var dateTimeAxis = (DateTimeAxis)plotModel.Axes.FirstOrDefault(a => a is DateTimeAxis);
            if (dateTimeAxis != null)
            {
                dateTimeAxis.Maximum = OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now);
                dateTimeAxis.Minimum = OxyPlot.Axes.DateTimeAxis.ToDouble(DateTime.Now.AddMinutes(-60));
            }

            plotModel.InvalidatePlot(true);
        }


    }
}
