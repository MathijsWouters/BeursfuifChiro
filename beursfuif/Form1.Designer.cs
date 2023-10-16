﻿namespace beursfuif
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
            openForm2Button = new Button();
            closeButton = new Button();
            minimizeButton = new Button();
            maximizeButton = new Button();
            titleLabel = new Label();
            addButton = new Button();
            titleBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleBarPanel
            // 
            titleBarPanel.BackColor = Color.FromArgb(35, 35, 38);
            titleBarPanel.Controls.Add(openForm2Button);
            titleBarPanel.Controls.Add(closeButton);
            titleBarPanel.Controls.Add(minimizeButton);
            titleBarPanel.Controls.Add(maximizeButton);
            titleBarPanel.Controls.Add(titleLabel);
            titleBarPanel.Dock = DockStyle.Top;
            titleBarPanel.Location = new Point(0, 0);
            titleBarPanel.Name = "titleBarPanel";
            titleBarPanel.Size = new Size(1409, 30);
            titleBarPanel.TabIndex = 0;
            titleBarPanel.MouseDown += titleBarPanel_MouseDown;
            titleBarPanel.MouseMove += titleBarPanel_MouseMove;
            titleBarPanel.MouseUp += titleBarPanel_MouseUp;
            // 
            // openForm2Button
            // 
            openForm2Button.ForeColor = Color.White;
            openForm2Button.Location = new Point(3, 4);
            openForm2Button.Name = "openForm2Button";
            openForm2Button.Size = new Size(75, 23);
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
            closeButton.Location = new Point(1184, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 30);
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
            minimizeButton.Location = new Point(1259, 0);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(75, 30);
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
            maximizeButton.Location = new Point(1334, 0);
            maximizeButton.Name = "maximizeButton";
            maximizeButton.Size = new Size(75, 30);
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
            titleLabel.Size = new Size(1409, 30);
            titleLabel.TabIndex = 3;
            titleLabel.Text = "Beursfuif";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            addButton = new Button();
            addButton.Text = "Add Drink";
            UpdateAddButtonPosition();
            addButton.Click += AddButton_Click;
            this.Controls.Add(addButton);

            this.KeyDown += Form1_KeyDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1409, 611);
            Controls.Add(titleBarPanel);
            Controls.Add(addButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
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
        private List<TextBox> drinkTextBoxes = new List<TextBox>();
        private List<Button> deleteButtons = new List<Button>();
        private Button addButton;
    }
}