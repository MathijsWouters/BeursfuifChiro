namespace beursfuif
{
    partial class AddDrinksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Drink = new TextBox();
            ColorPicker = new Button();
            Min = new NumericUpDown();
            Max = new NumericUpDown();
            Interval = new NumericUpDown();
            SaveButton = new Button();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)Min).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Interval).BeginInit();
            SuspendLayout();
            // 
            // Drink
            // 
            Drink.AccessibleName = "Drink name";
            Drink.BackColor = Color.White;
            Drink.ForeColor = Color.Black;
            Drink.Location = new Point(360, 12);
            Drink.Name = "Drink";
            Drink.Size = new Size(137, 27);
            Drink.TabIndex = 0;
            Drink.TextChanged += Drink_TextChanged;
            // 
            // ColorPicker
            // 
            ColorPicker.BackColor = Color.White;
            ColorPicker.ForeColor = Color.Black;
            ColorPicker.Location = new Point(360, 45);
            ColorPicker.Name = "ColorPicker";
            ColorPicker.Size = new Size(136, 29);
            ColorPicker.TabIndex = 1;
            ColorPicker.Text = "Kleur";
            ColorPicker.UseVisualStyleBackColor = false;
            ColorPicker.Click += ColorPicker_Click;
            // 
            // Min
            // 
            Min.AccessibleDescription = "";
            Min.AccessibleName = "Min";
            Min.DecimalPlaces = 2;
            Min.Location = new Point(269, 99);
            Min.Name = "Min";
            Min.Size = new Size(137, 27);
            Min.TabIndex = 2;
            Min.ValueChanged += Min_ValueChanged;
            // 
            // Max
            // 
            Max.AccessibleName = "Max";
            Max.DecimalPlaces = 2;
            Max.Location = new Point(445, 99);
            Max.Name = "Max";
            Max.Size = new Size(137, 27);
            Max.TabIndex = 3;
            Max.ValueChanged += Max_ValueChanged;
            // 
            // Interval
            // 
            Interval.AccessibleDescription = "";
            Interval.AccessibleName = "Min";
            Interval.DecimalPlaces = 2;
            Interval.Location = new Point(360, 154);
            Interval.Name = "Interval";
            Interval.Size = new Size(137, 27);
            Interval.TabIndex = 4;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(380, 225);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // AddDrinksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(861, 560);
            Controls.Add(SaveButton);
            Controls.Add(Interval);
            Controls.Add(Max);
            Controls.Add(Min);
            Controls.Add(ColorPicker);
            Controls.Add(Drink);
            ForeColor = Color.Black;
            Name = "AddDrinksForm";
            Text = "AddDrinksForm";
            ((System.ComponentModel.ISupportInitialize)Min).EndInit();
            ((System.ComponentModel.ISupportInitialize)Max).EndInit();
            ((System.ComponentModel.ISupportInitialize)Interval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Drink;
        private Button ColorPicker;
        private NumericUpDown Min;
        private NumericUpDown Max;
        private NumericUpDown Interval;
        private Button SaveButton;
        private ColorDialog colorDialog1;
    }
}