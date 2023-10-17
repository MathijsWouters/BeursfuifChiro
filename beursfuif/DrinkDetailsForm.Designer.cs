namespace beursfuif
{
    partial class DrinkDetailsForm
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            saveChangesButton = new Button();
            intervalNumericUpDown = new NumericUpDown();
            maxPriceNumericUpDown = new NumericUpDown();
            minPriceNumericUpDown = new NumericUpDown();
            drinkColorDisplay = new Button();
            drinkNameTextBox = new TextBox();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)intervalNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxPriceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minPriceNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(378, 183);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 19;
            label4.Text = "Interval";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(459, 129);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 18;
            label3.Text = "Max";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(303, 129);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 17;
            label2.Text = "Min";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(377, 49);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 16;
            label1.Text = "Drankje";
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(303, 228);
            saveChangesButton.Margin = new Padding(3, 2, 3, 2);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(82, 22);
            saveChangesButton.TabIndex = 15;
            saveChangesButton.Text = "Save";
            saveChangesButton.UseVisualStyleBackColor = true;
            saveChangesButton.Click += saveChangesButton_Click;
            // 
            // intervalNumericUpDown
            // 
            intervalNumericUpDown.AccessibleDescription = "";
            intervalNumericUpDown.AccessibleName = "intervalNumericUpDown";
            intervalNumericUpDown.DecimalPlaces = 2;
            intervalNumericUpDown.Location = new Point(340, 201);
            intervalNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            intervalNumericUpDown.Name = "intervalNumericUpDown";
            intervalNumericUpDown.Size = new Size(120, 23);
            intervalNumericUpDown.TabIndex = 14;
            // 
            // maxPriceNumericUpDown
            // 
            maxPriceNumericUpDown.AccessibleName = "maxPriceNumericUpDown";
            maxPriceNumericUpDown.DecimalPlaces = 2;
            maxPriceNumericUpDown.Location = new Point(417, 147);
            maxPriceNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            maxPriceNumericUpDown.Name = "maxPriceNumericUpDown";
            maxPriceNumericUpDown.Size = new Size(120, 23);
            maxPriceNumericUpDown.TabIndex = 13;
            // 
            // minPriceNumericUpDown
            // 
            minPriceNumericUpDown.AccessibleDescription = "";
            minPriceNumericUpDown.AccessibleName = "minPriceNumericUpDown";
            minPriceNumericUpDown.DecimalPlaces = 2;
            minPriceNumericUpDown.Location = new Point(263, 147);
            minPriceNumericUpDown.Margin = new Padding(3, 2, 3, 2);
            minPriceNumericUpDown.Name = "minPriceNumericUpDown";
            minPriceNumericUpDown.Size = new Size(120, 23);
            minPriceNumericUpDown.TabIndex = 12;
            // 
            // drinkColorDisplay
            // 
            drinkColorDisplay.BackColor = Color.White;
            drinkColorDisplay.ForeColor = Color.Black;
            drinkColorDisplay.Location = new Point(340, 91);
            drinkColorDisplay.Margin = new Padding(3, 2, 3, 2);
            drinkColorDisplay.Name = "drinkColorDisplay";
            drinkColorDisplay.Size = new Size(119, 22);
            drinkColorDisplay.TabIndex = 11;
            drinkColorDisplay.Text = "Kleur";
            drinkColorDisplay.UseVisualStyleBackColor = false;
            // 
            // drinkNameTextBox
            // 
            drinkNameTextBox.AccessibleName = "Drink name";
            drinkNameTextBox.BackColor = Color.White;
            drinkNameTextBox.ForeColor = Color.Black;
            drinkNameTextBox.Location = new Point(340, 66);
            drinkNameTextBox.Margin = new Padding(3, 2, 3, 2);
            drinkNameTextBox.Name = "drinkNameTextBox";
            drinkNameTextBox.Size = new Size(120, 23);
            drinkNameTextBox.TabIndex = 10;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(407, 228);
            deleteButton.Margin = new Padding(3, 2, 3, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(82, 22);
            deleteButton.TabIndex = 20;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // DrinkDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(saveChangesButton);
            Controls.Add(intervalNumericUpDown);
            Controls.Add(maxPriceNumericUpDown);
            Controls.Add(minPriceNumericUpDown);
            Controls.Add(drinkColorDisplay);
            Controls.Add(drinkNameTextBox);
            Name = "DrinkDetailsForm";
            Text = "DrinkDetailsForm";
            ((System.ComponentModel.ISupportInitialize)intervalNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxPriceNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)minPriceNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button saveChangesButton;
        private NumericUpDown intervalNumericUpDown;
        private NumericUpDown maxPriceNumericUpDown;
        private NumericUpDown minPriceNumericUpDown;
        private Button drinkColorDisplay;
        private TextBox drinkNameTextBox;
        private Button deleteButton;
    }
}