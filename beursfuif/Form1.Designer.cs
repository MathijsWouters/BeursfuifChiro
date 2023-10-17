namespace beursfuif
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleBarPanel = new Panel();
            addDrinksButton = new Button();
            openForm2Button = new Button();
            closeButton = new Button();
            minimizeButton = new Button();
            maximizeButton = new Button();
            titleLabel = new Label();
            comboBox1 = new ComboBox();
            titleBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleBarPanel
            // 
            titleBarPanel.BackColor = Color.FromArgb(35, 35, 38);
            titleBarPanel.Controls.Add(comboBox1);
            titleBarPanel.Controls.Add(addDrinksButton);
            titleBarPanel.Controls.Add(openForm2Button);
            titleBarPanel.Controls.Add(closeButton);
            titleBarPanel.Controls.Add(minimizeButton);
            titleBarPanel.Controls.Add(maximizeButton);
            titleBarPanel.Controls.Add(titleLabel);
            titleBarPanel.Dock = DockStyle.Top;
            titleBarPanel.Location = new Point(0, 0);
            titleBarPanel.Margin = new Padding(3, 4, 3, 4);
            titleBarPanel.Name = "titleBarPanel";
            titleBarPanel.Size = new Size(1610, 40);
            titleBarPanel.TabIndex = 0;
            titleBarPanel.MouseDown += titleBarPanel_MouseDown;
            titleBarPanel.MouseMove += titleBarPanel_MouseMove;
            titleBarPanel.MouseUp += titleBarPanel_MouseUp;
            // 
            // addDrinksButton
            // 
            addDrinksButton.ForeColor = Color.White;
            addDrinksButton.Location = new Point(105, 4);
            addDrinksButton.Margin = new Padding(3, 4, 3, 4);
            addDrinksButton.Name = "addDrinksButton";
            addDrinksButton.Size = new Size(96, 28);
            addDrinksButton.TabIndex = 4;
            addDrinksButton.Text = "Add drinks";
            addDrinksButton.Click += AddDrinksButton_Click;
            // 
            // openForm2Button
            // 
            openForm2Button.ForeColor = Color.White;
            openForm2Button.Location = new Point(3, 4);
            openForm2Button.Margin = new Padding(3, 4, 3, 4);
            openForm2Button.Name = "openForm2Button";
            openForm2Button.Size = new Size(96, 28);
            openForm2Button.TabIndex = 0;
            openForm2Button.Text = "Beurs";
            openForm2Button.Click += OpenForm2Button_Click;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.ForeColor = SystemColors.Control;
            closeButton.Location = new Point(1352, 0);
            closeButton.Margin = new Padding(3, 4, 3, 4);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(86, 40);
            closeButton.TabIndex = 0;
            closeButton.Text = "X";
            closeButton.Click += closeButton_Click;
            // 
            // minimizeButton
            // 
            minimizeButton.Dock = DockStyle.Right;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.ForeColor = SystemColors.Control;
            minimizeButton.Location = new Point(1438, 0);
            minimizeButton.Margin = new Padding(3, 4, 3, 4);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(86, 40);
            minimizeButton.TabIndex = 1;
            minimizeButton.Text = "-";
            minimizeButton.Click += minimizeButton_Click;
            // 
            // maximizeButton
            // 
            maximizeButton.Dock = DockStyle.Right;
            maximizeButton.FlatAppearance.BorderSize = 0;
            maximizeButton.FlatStyle = FlatStyle.Flat;
            maximizeButton.ForeColor = SystemColors.Control;
            maximizeButton.Location = new Point(1524, 0);
            maximizeButton.Margin = new Padding(3, 4, 3, 4);
            maximizeButton.Name = "maximizeButton";
            maximizeButton.Size = new Size(86, 40);
            maximizeButton.TabIndex = 2;
            maximizeButton.Text = "[]";
            maximizeButton.Click += maximizeButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1610, 40);
            titleLabel.TabIndex = 3;
            titleLabel.Text = "Beursfuif";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Black;
            comboBox1.ForeColor = Color.White;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(206, 4);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(96, 28);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Drinks";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1610, 815);
            Controls.Add(titleBarPanel);
            Name = "Form1";
            Load += Form1_Load;
            titleBarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel titleBarPanel;
        private Button closeButton;
        private Button minimizeButton;
        private Button maximizeButton;
        private Label titleLabel;
        private Button openForm2Button;
        private Button addDrinksButton;
        private ComboBox comboBox1;
    }
}