namespace MHW.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string dbPath = FileAccessHelper.GetLocalFilePath("MHWDB.db");
            LoadApplication(new MHW.App(dbPath));
        }
    }
}
