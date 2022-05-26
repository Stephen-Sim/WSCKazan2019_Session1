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
    public partial class RegisterAssetPage : ContentPage
    {
        viewmodels.ResgisterAssetViewModel vm;
        public RegisterAssetPage()
        {
            InitializeComponent();
            vm = new viewmodels.ResgisterAssetViewModel();
            this.BindingContext = vm;

            dpikcer.SelectedIndex = 0;
            apicker.SelectedIndex = 0;
            lpicker.SelectedIndex = 0;
            epicker.SelectedIndex = 0;
            
            this.Title = "Asset Information";
        }

        private async void SubButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(adEditor.Text) && !string.IsNullOrEmpty(anEditor.Text))
            {
                vm.SelectedAssetGroup = (Temp)apicker.SelectedItem;
                vm.SelectedDepartment = (Temp)dpikcer.SelectedItem;
                vm.SelectedLocation = (Temp)lpicker.SelectedItem;
                vm.SelectedEmployee = (Temp)epicker.SelectedItem;

                vm.AssetDesc = adEditor.Text;
                vm.AssetName = anEditor.Text;

                int num = new Random().Next(1000, 9999);

                string asn = $"{vm.SelectedLocation.Id}/{vm.SelectedAssetGroup.Id}/{num}";

                string result = await vm.storeAssetAsync(asn);

                if (result.ToString() == "success")
                {
                    await DisplayAlert("Alert", "Asset Is Added!!!", "Ok");

                    App.Current.MainPage = new NavigationPage();
                    App.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
                else
                {
                    return;
                }


            }
            else
            {
                DisplayAlert("Alert", "all field is required!", "Ok");
            }
        }

        private void CanButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}