using App1.models;
using App1.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {

        services.GetService service = new services.GetService();
        public ObservableCollection<Temp> dList { set; get; }
        public ObservableCollection<Temp> agList { set; get; }

        public Temp selectedD { set; get; }
        public Temp selectedAG { set; get; }

        public DateTime sDate { set; get; } = DateTime.Now;
        public DateTime eDate { set; get; } = DateTime.Now;

        public string searchT { set; get; }

        public int initAssetCount = 0;

        public string _totalAsset = "3 asets from 35";

        public string totalAsset
        {
            get
            {
                return _totalAsset;
            }

            set
            {
                _totalAsset = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<AssetClass> _assetClass = new ObservableCollection<AssetClass>();
        public ObservableCollection<AssetClass> AssetClasses
        {
            get
            {
                return _assetClass;
            }

            set
            {
                _assetClass = value;
                OnPropertyChanged();
            }
        }
        public MainPage()
        {
            InitializeComponent();
            dList = new ObservableCollection<Temp>();
            dList.Add(new Temp { Id = 1, Name = "Exploration" });
            dList.Add(new Temp { Id = 2, Name = "Production" });
            dList.Add(new Temp { Id = 3, Name = "Transportation" });
            dList.Add(new Temp { Id = 4, Name = "R&D" });
            dList.Add(new Temp { Id = 5, Name = "Distribution" });
            dList.Add(new Temp { Id = 6, Name = "QHSE" });

            agList = new ObservableCollection<Temp>();
            agList.Add(new Temp { Id = 1, Name = "Hydraulic" });
            agList.Add(new Temp { Id = 3, Name = "Electrical" });
            agList.Add(new Temp { Id = 4, Name = "Mechanical " });

            this.getFirstListViewAsync();

            this.BindingContext = this;
        }

        public async Task getFirstListViewAsync()
        {
            var res = await service.getAssetRecord();
            AssetClasses = new ObservableCollection<AssetClass>(res);

            initAssetCount = AssetClasses.Count;
            totalAsset = $"{AssetClasses.Count} asset from {initAssetCount}";
        }

        public async Task getListViewAsync()
        {
            var res = await service.getAssetRecord(selectedD.Id, selectedAG.Id, sDate.Date.ToString("yyyy/MM/dd"), eDate.Date.ToString("yyyy/MM/dd"), searchT);
            AssetClasses = new ObservableCollection<AssetClass>(res);
            totalAsset = $"{AssetClasses.Count} asset from {initAssetCount}";
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpicker.SelectedItem = (Temp)selectedD;
            apicker.SelectedItem = (Temp)selectedAG;
            this.getListViewAsync();

        }

        private void startDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            if(sDate > eDate)
            {
                DisplayAlert("Alert", "Invalid Date", "OK");
                return;
            }

            sDate = e.NewDate;
            this.getListViewAsync();
        }

        private void endDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (sDate > eDate)
            {
                DisplayAlert("Alert", "Invalid Date", "OK");
                return;
            }

            eDate = e.NewDate;
            this.getListViewAsync();
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchT = sEditor.Text;
            this.getListViewAsync();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new TransferHistory((int)(sender as ImageButton).CommandParameter));
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new RegisterAssetPage());
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new RegisterAssetPage((int) (sender as ImageButton).CommandParameter));
        }
    }
}
