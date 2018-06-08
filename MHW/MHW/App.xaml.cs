using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using SQLite;
using System.Diagnostics;
using MHW.Views;

namespace MHW
{
	public partial class App : Application
	{

        public static string DBPath = "";
        public App (string path)
		{
			InitializeComponent();

            DBPath = path;

            MainPage = new NavigationPage(new MainPage() { Title = "MHW" });

        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart ()
		{
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
