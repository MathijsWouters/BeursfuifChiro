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
            Drinkname = new TextBox();
            ColorPicker = new Button();
            Min = new NumericUpDown();
            Max = new NumericUpDown();
            Interval = new NumericUpDown();
            SaveButton = new Button();
            colorDialog1 = new ColorDialog();
            lblTimer = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Threshold = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Min).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Interval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Threshold).BeginInit();
            SuspendLayout();
            // 
            // Drinkname
            // 
            Drinkname.AccessibleName = "Drink name";
            Drinkname.BackColor = Color.White;
            Drinkname.ForeColor = Color.Black;
            Drinkname.Location = new Point(316, 43);
            Drinkname.Margin = new Padding(3, 2, 3, 2);
            Drinkname.Name = "Drinkname";
            Drinkname.Size = new Size(120, 23);
            Drinkname.TabIndex = 0;
            // 
            // ColorPicker
            // 
            ColorPicker.BackColor = Color.White;
            ColorPicker.ForeColor = Color.Black;
            ColorPicker.Location = new Point(316, 68);
            ColorPicker.Margin = new Padding(3, 2, 3, 2);
            ColorPicker.Name = "ColorPicker";
            ColorPicker.Size = new Size(119, 22);
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
            Min.Location = new Point(239, 124);
            Min.Margin = new Padding(3, 2, 3, 2);
            Min.Name = "Min";
            Min.Size = new Size(120, 23);
            Min.TabIndex = 2;
            // 
            // Max
            // 
            Max.AccessibleName = "Max";
            Max.DecimalPlaces = 2;
            Max.Location = new Point(393, 124);
            Max.Margin = new Padding(3, 2, 3, 2);
            Max.Name = "Max";
            Max.Size = new Size(120, 23);
            Max.TabIndex = 3;
            // 
            // Interval
            // 
            Interval.AccessibleDescription = "";
            Interval.AccessibleName = "Interval";
            Interval.DecimalPlaces = 2;
            Interval.Location = new Point(316, 178);
            Interval.Margin = new Padding(3, 2, 3, 2);
            Interval.Name = "Interval";
            Interval.Size = new Size(120, 23);
            Interval.TabIndex = 4;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(338, 248);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(82, 22);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.Transparent;
            lblTimer.Location = new Point(353, 26);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(47, 15);
            lblTimer.TabIndex = 6;
            lblTimer.Text = "Drankje";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(279, 106);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 7;
            label2.Text = "Min";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(435, 106);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 8;
            label3.Text = "Max";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(353, 161);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 9;
            label4.Text = "Interval";
            // 
            // Threshold
            // 
            Threshold.AccessibleDescription = "";
            Threshold.AccessibleName = "Threshold";
            Threshold.DecimalPlaces = 2;
            Threshold.Location = new Point(316, 221);
            Threshold.Margin = new Padding(3, 2, 3, 2);
            Threshold.Name = "Threshold";
            Threshold.Size = new Size(120, 23);
            Threshold.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(347, 204);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 11;
            label1.Text = "Threshold";
            // 
            // AddDrinksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(753, 420);
            Controls.Add(label1);
            Controls.Add(Threshold);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblTimer);
            Controls.Add(SaveButton);
            Controls.Add(Interval);
            Controls.Add(Max);
            Controls.Add(Min);
            Controls.Add(ColorPicker);
            Controls.Add(Drinkname);
            ForeColor = Color.Black;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddDrinksForm";
            Text = "AddDrinksForm";
            ((System.ComponentModel.ISupportInitialize)Min).EndInit();
            ((System.ComponentModel.ISupportInitialize)Max).EndInit();
            ((System.ComponentModel.ISupportInitialize)Interval).EndInit();
            ((System.ComponentModel.ISupportInitialize)Threshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Drinkname;
        private Button ColorPicker;
        private NumericUpDown Min;
        private NumericUpDown Max;
        private NumericUpDown Interval;
        private Button SaveButton;
        private ColorDialog colorDialog1;
        private Label lblTimer;
        private Label label2;
        private Label label3;
        private Label label4;
        private NumericUpDown Threshold;
        private Label label1;

        public event Action<Drink> DrinkAdded;
    }
}