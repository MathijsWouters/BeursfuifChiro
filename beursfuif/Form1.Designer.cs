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
            closeButton = new Button();
            minimizeButton = new Button();
            maximizeButton = new Button();
            titleBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleBarPanel
            // 
            titleBarPanel.BackColor = Color.FromArgb(35, 35, 38);
            titleBarPanel.Controls.Add(closeButton);
            titleBarPanel.Controls.Add(minimizeButton);
            titleBarPanel.Controls.Add(maximizeButton);
            titleBarPanel.Dock = DockStyle.Top;
            titleBarPanel.Location = new Point(0, 0);
            titleBarPanel.Name = "titleBarPanel";
            titleBarPanel.Size = new Size(1475, 30);
            titleBarPanel.TabIndex = 0;
            titleBarPanel.MouseDown += titleBarPanel_MouseDown;
            titleBarPanel.MouseMove += titleBarPanel_MouseMove;
            titleBarPanel.MouseUp += titleBarPanel_MouseUp;
            // Title label
            Label titleLabel = new Label();
            titleLabel.Text = "Beursfuif";
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.ForeColor = Color.White;
            titleBarPanel.Controls.Add(titleLabel);
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.ForeColor = SystemColors.Control;
            closeButton.Location = new Point(1250, 0);
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
            minimizeButton.Location = new Point(1325, 0);
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
            maximizeButton.Location = new Point(1400, 0);
            maximizeButton.Name = "maximizeButton";
            maximizeButton.Size = new Size(75, 30);
            maximizeButton.TabIndex = 2;
            maximizeButton.Text = "[]";
            maximizeButton.Click += maximizeButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1475, 637);
            Controls.Add(titleBarPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            titleBarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel titleBarPanel;
        private Button closeButton;
        private Button minimizeButton;
        private Button maximizeButton;
    }
}