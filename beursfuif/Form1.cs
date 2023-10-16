
namespace beursfuif
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Beursfuif";


            // Form properties
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            // Label properties

            // TextBox properties

            // Button properties
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void titleBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void titleBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void titleBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

    }
}
