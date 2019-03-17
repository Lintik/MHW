using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MHW.ViewModels;

namespace MHW.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DatabasePage : ContentPage
	{
		public DatabasePage ()
		{
			InitializeComponent ();
		}

         private void Search_Clicked(object sender, EventArgs e)
        {
            
        }

        private void FilterItem_Clicked(object sender, EventArgs e)
        {

        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {

        }

        private void Settings_Clicked(object sender, EventArgs e)
        {

        }

    }

    public class TextChangedBehavior : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((SearchBar)sender).SearchCommand?.Execute(e.NewTextValue);
        }
    }
}