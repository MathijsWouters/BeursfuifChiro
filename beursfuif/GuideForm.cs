using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace beursfuif
{
    public partial class GuideForm : Form
    {
        public GuideForm()
        {
            InitializeComponent();
            this.Resize += GuideForm_Resize;
        }
        private void GuideForm_Resize(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(this.ClientSize.Width, (int)(this.ClientSize.Height * 0.95));
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (dontShowAgainCheckbox.Checked)
            {
                // Save the preference to not show the guide again
                Properties.Settings.Default.ShowGuide = false;
                Properties.Settings.Default.Save();
            }

            this.Close(); // Close the GuideForm
        }
        private void PositionControls()
        {
            int combinedWidth = closeButton.Width + 20 + dontShowAgainCheckbox.PreferredSize.Width;
            int startX = (this.ClientSize.Width - combinedWidth) / 2;
            int startY = (int)(this.ClientSize.Height * 0.95);
            int closeBtnY = startY + ((int)(this.ClientSize.Height * 0.05) - closeButton.Height) / 2;
            closeButton.Location = new Point(startX, closeBtnY);
            int checkboxY = startY + ((int)(this.ClientSize.Height * 0.05) - dontShowAgainCheckbox.Height) / 2;
            dontShowAgainCheckbox.Location = new Point(startX + closeButton.Width + 20, checkboxY);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PositionControls();
        }
    }
}
