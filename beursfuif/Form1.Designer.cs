using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

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
            components = new System.ComponentModel.Container();
            titleBarPanel = new Panel();
            stopfeest = new Button();
            startTimerButton = new Button();
            deleteDrinksButton = new Button();
            addDrinksButton = new Button();
            openBeursButton = new Button();
            closeButton = new Button();
            minimizeButton = new Button();
            maximizeButton = new Button();
            titleLabel = new Label();
            flowLayoutPanel = new FlowLayoutPanel();
            lblTotal = new Label();
            lblVakjes = new Label();
            reciptDrinkListBox = new ListBox();
            timer1 = new System.Windows.Forms.Timer(components);
            priceUpdateTimer = new System.Windows.Forms.Timer(components);
            lblTimer = new Label();
            CrashButton = new Button();
            titleBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleBarPanel
            // 
            titleBarPanel.BackColor = Color.FromArgb(35, 35, 38);
            titleBarPanel.Controls.Add(stopfeest);
            titleBarPanel.Controls.Add(startTimerButton);
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
            titleBarPanel.Size = new Size(1689, 30);
            titleBarPanel.TabIndex = 0;
            titleBarPanel.MouseDown += titleBarPanel_MouseDown;
            titleBarPanel.MouseMove += titleBarPanel_MouseMove;
            titleBarPanel.MouseUp += titleBarPanel_MouseUp;
            // 
            // stopfeest
            // 
            stopfeest.ForeColor = Color.White;
            stopfeest.Location = new Point(1135, 4);
            stopfeest.Name = "stopfeest";
            stopfeest.Size = new Size(84, 21);
            stopfeest.TabIndex = 6;
            stopfeest.Text = "Stop feest";
            stopfeest.Click += stopfeest_Click;
            // 
            // startTimerButton
            // 
            startTimerButton.BackColor = Color.Red;
            startTimerButton.ForeColor = Color.White;
            startTimerButton.Location = new Point(1048, 3);
            startTimerButton.Name = "startTimerButton";
            startTimerButton.Size = new Size(81, 23);
            startTimerButton.TabIndex = 0;
            startTimerButton.Text = "Start feestje";
            startTimerButton.UseVisualStyleBackColor = false;
            startTimerButton.Click += StartTimerButton_Click;
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
            closeButton.Location = new Point(1464, 0);
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
            minimizeButton.Location = new Point(1539, 0);
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
            maximizeButton.Location = new Point(1614, 0);
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
            titleLabel.Size = new Size(1689, 30);
            titleLabel.TabIndex = 3;
            titleLabel.Text = "Beursfuif";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(0, 56);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(10);
            flowLayoutPanel.Size = new Size(890, 405);
            flowLayoutPanel.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.Location = new Point(1157, 258);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(300, 30);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total: €0.00";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVakjes
            // 
            lblVakjes.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblVakjes.Location = new Point(1157, 307);
            lblVakjes.Name = "lblVakjes";
            lblVakjes.Size = new Size(300, 30);
            lblVakjes.TabIndex = 6;
            lblVakjes.Text = "Vakjes: 0";
            lblVakjes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // reciptDrinkListBox
            // 
            reciptDrinkListBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            reciptDrinkListBox.BackColor = Color.FromArgb(45, 45, 48);
            reciptDrinkListBox.ForeColor = Color.White;
            reciptDrinkListBox.ItemHeight = 15;
            reciptDrinkListBox.Location = new Point(1157, 36);
            reciptDrinkListBox.Name = "reciptDrinkListBox";
            reciptDrinkListBox.Size = new Size(300, 199);
            reciptDrinkListBox.TabIndex = 0;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(0, 0);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(0, 15);
            lblTimer.TabIndex = 7;
            // 
            // CrashButton
            // 
            CrashButton.Font = new Font("Arial", 36F, FontStyle.Bold, GraphicsUnit.Point);
            CrashButton.ForeColor = Color.White;
            CrashButton.Location = new Point(0, 0);
            CrashButton.Name = "CrashButton";
            CrashButton.Size = new Size(300, 100);
            CrashButton.TabIndex = 7;
            CrashButton.Text = "Crash!";
            CrashButton.Click += CrashButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1689, 634);
            Controls.Add(CrashButton);
            Controls.Add(lblVakjes);
            Controls.Add(lblTotal);
            Controls.Add(lblTimer);
            Controls.Add(titleBarPanel);
            Controls.Add(reciptDrinkListBox);
            Controls.Add(flowLayoutPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Load += Form1_Load;
            titleBarPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private Label lblTotal;
        private Label lblVakjes;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer priceUpdateTimer;
        private System.Windows.Forms.Timer partyModeTimer = new System.Windows.Forms.Timer();
        private Label lblTimer;
        private Button startTimerButton;
        private Button stopfeest;
        private Button CrashButton;
    }
}