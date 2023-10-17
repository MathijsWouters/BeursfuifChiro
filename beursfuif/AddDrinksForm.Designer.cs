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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)Min).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Interval).BeginInit();
            SuspendLayout();
            // 
            // Drink
            // 
            Drinkname.AccessibleName = "Drink name";
            Drinkname.BackColor = Color.White;
            Drinkname.ForeColor = Color.Black;
            Drinkname.Location = new Point(361, 57);
            Drinkname.Name = "Drink";
            Drinkname.Size = new Size(137, 27);
            Drinkname.TabIndex = 0;
            
            // 
            // ColorPicker
            // 
            ColorPicker.BackColor = Color.White;
            ColorPicker.ForeColor = Color.Black;
            ColorPicker.Location = new Point(361, 91);
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
            Min.Location = new Point(273, 165);
            Min.Name = "Min";
            Min.Size = new Size(137, 27);
            Min.TabIndex = 2;
            
            // 
            // Max
            // 
            Max.AccessibleName = "Max";
            Max.DecimalPlaces = 2;
            Max.Location = new Point(449, 165);
            Max.Name = "Max";
            Max.Size = new Size(137, 27);
            Max.TabIndex = 3;
            
            // 
            // Interval
            // 
            Interval.AccessibleDescription = "";
            Interval.AccessibleName = "Interval";
            Interval.DecimalPlaces = 2;
            Interval.Location = new Point(361, 237);
            Interval.Name = "Interval";
            Interval.Size = new Size(137, 27);
            Interval.TabIndex = 4;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(381, 269);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(403, 35);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 6;
            label1.Text = "Drankje";
            
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(319, 142);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 7;
            label2.Text = "Min";
            
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(497, 142);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 8;
            label3.Text = "Max";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(405, 214);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 9;
            label4.Text = "Interval";
            // 
            // AddDrinksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(861, 560);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(Interval);
            Controls.Add(Max);
            Controls.Add(Min);
            Controls.Add(ColorPicker);
            Controls.Add(Drinkname);
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

        private TextBox Drinkname;
        private Button ColorPicker;
        private NumericUpDown Min;
        private NumericUpDown Max;
        private NumericUpDown Interval;
        private Button SaveButton;
        private ColorDialog colorDialog1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        public event Action<Drink> DrinkAdded;
    }
}