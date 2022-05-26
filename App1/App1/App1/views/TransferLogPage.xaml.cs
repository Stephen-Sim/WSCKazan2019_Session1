using App1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferLogPage : ContentPage
    {
        viewmodels.TransferLogViewModel vm;
        public TransferLogPage(int id)
        {
            InitializeComponent();
            this.Title = "Transfer History";
            vm = new viewmodels.TransferLogViewModel(id);
            this.BindingContext = vm;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}