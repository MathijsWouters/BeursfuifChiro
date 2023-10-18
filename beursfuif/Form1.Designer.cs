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
            openBeursButton = new Button();
            closeButton = new Button();
            minimizeButton = new Button();
            maximizeButton = new Button();
            titleLabel = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            deleteDrinksButton = new Button();
            titleBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleBarPanel
            // 
            titleBarPanel.BackColor = Color.FromArgb(35, 35, 38);
            titleBarPanel.Controls.Add(deleteDrinksButton);
            titleBarPanel.Controls.Add(addDrinksButton);
            titleBarPanel.Controls.Add(openBeursButton);
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
            // addDrinksButton
            // 
            addDrinksButton.ForeColor = Color.White;
            addDrinksButton.Location = new Point(92, 3);
            addDrinksButton.Name = "addDrinksButton";
            addDrinksButton.Size = new Size(84, 21);
            addDrinksButton.TabIndex = 4;
            addDrinksButton.Text = "Add drinks";
            addDrinksButton.Click += AddDrinksButton_Click;
            // 
            // openBeursButton
            // 
            openBeursButton.ForeColor = Color.White;
            openBeursButton.Location = new Point(3, 3);
            openBeursButton.Name = "openBeursButton";
            openBeursButton.Size = new Size(84, 21);
            openBeursButton.TabIndex = 0;
            openBeursButton.Text = "Beurs";
            openBeursButton.Click += OpenBeursButton_Click;
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
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(0, 56);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(10);
            flowLayoutPanel.Size = new Size(650, 315);
            flowLayoutPanel.TabIndex = 1;
            // 
            // deleteDrinksButton
            // 
            deleteDrinksButton.ForeColor = Color.White;
            deleteDrinksButton.Location = new Point(182, 3);
            deleteDrinksButton.Name = "deleteDrinksButton";
            deleteDrinksButton.Size = new Size(84, 21);
            deleteDrinksButton.TabIndex = 5;
            deleteDrinksButton.Text = "Delete drinks";
            deleteDrinksButton.Click += deleteDrinksButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1409, 611);
            Controls.Add(titleBarPanel);
            Controls.Add(flowLayoutPanel);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button openBeursButton;
        private Button addDrinksButton;
        private Button deleteDrinksButton;
    }
}