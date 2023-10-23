namespace beursfuif
{
    partial class Beurs
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
            Beursgraph = new OxyPlot.WindowsForms.PlotView();
            SuspendLayout();
            // 
            // Beursgraph
            // 
            Beursgraph.Location = new Point(-1, 0);
            Beursgraph.Margin = new Padding(3, 2, 3, 2);
            Beursgraph.Name = "Beursgraph";
            Beursgraph.PanCursor = Cursors.Hand;
            Beursgraph.Size = new Size(701, 338);
            Beursgraph.TabIndex = 0;
            Beursgraph.Text = "Beursgraph";
            Beursgraph.ZoomHorizontalCursor = Cursors.SizeWE;
            Beursgraph.ZoomRectangleCursor = Cursors.SizeNWSE;
            Beursgraph.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // Beurs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(Beursgraph);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Beurs";
            Text = "Beurs";
            this.Resize += new System.EventHandler(this.Beurs_Resize); // Attach the Resize event handler
            ResumeLayout(false);
        }

        #endregion
        private void Beurs_Resize(object sender, EventArgs e)
        {
            Beursgraph.Width = this.ClientSize.Width; 
            Beursgraph.Height = (int)(this.ClientSize.Height * 0.8); 
            Beursgraph.Top = 0; 
        }
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private OxyPlot.WindowsForms.PlotView Beursgraph;
    }
}