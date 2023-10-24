namespace beursfuif
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            bool showGuide = true;
            if (showGuide)
            {
                using (GuideForm guide = new GuideForm())
                {
                    guide.ShowDialog(); 
                }
            }
            Application.Run(new Form1());
        }
    }
}