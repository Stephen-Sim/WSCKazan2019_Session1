using App1.models;
using App1.viewmodels;
using App1.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            vm = new viewmodels.MainPageViewModel();
            this.BindingContext = vm;
            vm.getFirstScreenAssetRecord();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            vm.SelectedAssetGroup = (Temp) aPicker.SelectedItem;
            vm.SelectedDepartment = (Temp) dPicker.SelectedItem;

            vm.getSearchAsset();
        }

        private void StartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (sDatePicker.Date < eDatePicker.Date)
            {
                vm.StartDate = e.NewDate;
                vm.getSearchAsset();
            }
            else
            {
                DisplayAlert("Alert", "start date cannot greater than end date", "OK");
            }
            
        }
        private void EndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (sDatePicker.Date < eDatePicker.Date)
            {
                vm.EndDate = e.NewDate;
                vm.getSearchAsset();
            }
            else
            {
                DisplayAlert("Alert", "start date cannot greater than end date", "OK");
            }
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm.SearchText = sEditor.Text;
            vm.getSearchAsset();
        }

        private void HistoryImageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new TransferLogPage((int)(sender as ImageButton).CommandParameter));
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new RegisterAssetPage());
        }
    }
}
