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

        public Beurs(List<Drink> initialDrinks, Form1 mainForm)
        {
            InitializeComponent();
            mainForm.DrinksUpdated += MainForm_DrinksUpdated;
            this.Text = "Secondary Window";
            this.BackColor = System.Drawing.Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            plotModel = new PlotModel { Title = "Beurs Live Chart" };
            Beursgraph.Model = plotModel;
            UpdateChart(initialDrinks);
        }
       
        private void MainForm_DrinksUpdated(List<Drink> updatedDrinks)
        {
            UpdateChart(updatedDrinks);
        }
        private void UpdateChart(List<Drink> drinks)
        {
            var columnSeries = new ColumnSeries
            {
                Title = "Drink Prices",
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };

            // Add items to the column series
            foreach (var drink in drinks)
            {
                columnSeries.Items.Add(new ColumnItem { Value = (double)drink.CurrentPrice });
            }

            plotModel.Series.Clear();
            plotModel.Series.Add(columnSeries);

            // Setting up category axis
            var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom };

            foreach (var drink in drinks)
            {
                categoryAxis.Labels.Add(drink.Name);
            }

            plotModel.Axes.Clear();
            plotModel.Axes.Add(categoryAxis);
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0, AbsoluteMinimum = 0 });

            // Add annotations for drink names and prices
            for (int i = 0; i < drinks.Count; i++)
            {
                var drink = drinks[i];
                var annotation = new TextAnnotation
                {
                    TextPosition = new DataPoint(i, (double)drink.CurrentPrice),
                    Text = $"{drink.Name} - {drink.CurrentPrice}",
                    TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center,
                    TextVerticalAlignment = VerticalAlignment.Bottom,
                    Stroke = OxyColors.Transparent
                };
                plotModel.Annotations.Add(annotation);
            }

            plotModel.InvalidatePlot(true);
        }
    }
}
