﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MHW.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MHW
{
	public partial class App : Application
	{

        public static string DBPath = "";
        public App (string path)
		{
			InitializeComponent();

            DBPath = path;

            MainPage = new MainPage();
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
