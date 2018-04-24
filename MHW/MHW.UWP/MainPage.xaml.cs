namespace MHW.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            string dbPath = FileAccessHelper.GetLocalFilePath("MHWDB.db3");
            this.InitializeComponent();

            LoadApplication(new MHW.App(dbPath));
        }
    }
}
