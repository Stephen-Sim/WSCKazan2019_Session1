using App1.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Temp> dList { set; get; }
        public ObservableCollection<Temp> agList { set; get; }

        public Temp selectedD { set; get; }
        public Temp selectedAG { set; get; }

        public ObservableCollection<Temp> eList { set; get; }
        public ObservableCollection<Temp> lList { set; get; }

        public Temp selectedE { set; get; }
        public Temp selectedL { set; get; }

        public DateTime eDate { set; get; } = DateTime.Now;

        public RegisterAssetPage()
        {
            InitializeComponent();
            this.Title = "Asset Information";
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

            lList = new ObservableCollection<Temp>();
            lList.Add(new Temp { Id = 1, Name = "Kazan" });
            lList.Add(new Temp { Id = 2, Name = "Volka" });
            lList.Add(new Temp { Id = 3, Name = "Moscow " });

            eList = new ObservableCollection<Temp>();
            eList.Add(new Temp { Id = 1, Name = "Martina Winegarden" });
            eList.Add(new Temp { Id = 1, Name = "Martina Winegarden" });
            eList.Add(new Temp { Id = 2, Name = "Rashida Brammer" });
            eList.Add(new Temp { Id = 3, Name = "Mohamed Krall" });
            eList.Add(new Temp { Id = 4, Name = "Shante Karr" });
            eList.Add(new Temp { Id = 5, Name = "Rosaura Rames" });
            eList.Add(new Temp { Id = 6, Name = "Toi Courchesne" });
            eList.Add(new Temp { Id = 7, Name = "Precious Wismer" });
            eList.Add(new Temp { Id = 7, Name = "Precious Wismer" });
            eList.Add(new Temp { Id = 8, Name = "Josefa Otte" });
            eList.Add(new Temp { Id = 9, Name = "Afton Harrington" });
            eList.Add(new Temp { Id = 10, Name = "Daphne Morrow" });
            eList.Add(new Temp { Id = 11, Name = "Dottie Polson" });
            eList.Add(new Temp { Id = 12, Name = "Alleen Nally" });
            eList.Add(new Temp { Id = 13, Name = "Hilton Odom" });
            eList.Add(new Temp { Id = 14, Name = "Shawn Hillebrand" });
            eList.Add(new Temp { Id = 15, Name = "Lorelei Kettler" });
            eList.Add(new Temp { Id = 16, Name = "Jalisa Gossage" });
            eList.Add(new Temp { Id = 17, Name = "Germaine Sim" });
            eList.Add(new Temp { Id = 18, Name = "Suzanna Wollman" });
            eList.Add(new Temp { Id = 19, Name = "Jennette Besse" });
            eList.Add(new Temp { Id = 20, Name = "Margherita Anstine" });
            eList.Add(new Temp { Id = 21, Name = "Earleen Lambright" });
            eList.Add(new Temp { Id = 22, Name = "Lyn Valdivia" });
            eList.Add(new Temp { Id = 23, Name = "Alycia Couey" });
            eList.Add(new Temp { Id = 24, Name = "Lewis Rousey" });
            eList.Add(new Temp { Id = 24, Name = "Lewis Rousey" });
            eList.Add(new Temp { Id = 25, Name = "Tanja Profitt" });
            eList.Add(new Temp { Id = 26, Name = "Cherie Whyte" });
            eList.Add(new Temp { Id = 26, Name = "Cherie Whyte" });
            eList.Add(new Temp { Id = 27, Name = "Efren Leaf" });
            eList.Add(new Temp { Id = 28, Name = "Delta Darcangelo" });
            eList.Add(new Temp { Id = 29, Name = "Jess Bodnar" });
            eList.Add(new Temp { Id = 30, Name = "Sudie Parkhurst" });

            this.BindingContext = this;
        }

        Asset asset;

        services.GetService service = new services.GetService();

        public RegisterAssetPage(int id)
        {
            InitializeComponent();
            this.Title = "Asset Information";
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

            lList = new ObservableCollection<Temp>();
            lList.Add(new Temp { Id = 1, Name = "Kazan" });
            lList.Add(new Temp { Id = 2, Name = "Volka" });
            lList.Add(new Temp { Id = 3, Name = "Moscow " });

            eList = new ObservableCollection<Temp>();
            eList.Add(new Temp { Id = 1, Name = "Martina Winegarden" });
            eList.Add(new Temp { Id = 1, Name = "Martina Winegarden" });
            eList.Add(new Temp { Id = 2, Name = "Rashida Brammer" });
            eList.Add(new Temp { Id = 3, Name = "Mohamed Krall" });
            eList.Add(new Temp { Id = 4, Name = "Shante Karr" });
            eList.Add(new Temp { Id = 5, Name = "Rosaura Rames" });
            eList.Add(new Temp { Id = 6, Name = "Toi Courchesne" });
            eList.Add(new Temp { Id = 7, Name = "Precious Wismer" });
            eList.Add(new Temp { Id = 7, Name = "Precious Wismer" });
            eList.Add(new Temp { Id = 8, Name = "Josefa Otte" });
            eList.Add(new Temp { Id = 9, Name = "Afton Harrington" });
            eList.Add(new Temp { Id = 10, Name = "Daphne Morrow" });
            eList.Add(new Temp { Id = 11, Name = "Dottie Polson" });
            eList.Add(new Temp { Id = 12, Name = "Alleen Nally" });
            eList.Add(new Temp { Id = 13, Name = "Hilton Odom" });
            eList.Add(new Temp { Id = 14, Name = "Shawn Hillebrand" });
            eList.Add(new Temp { Id = 15, Name = "Lorelei Kettler" });
            eList.Add(new Temp { Id = 16, Name = "Jalisa Gossage" });
            eList.Add(new Temp { Id = 17, Name = "Germaine Sim" });
            eList.Add(new Temp { Id = 18, Name = "Suzanna Wollman" });
            eList.Add(new Temp { Id = 19, Name = "Jennette Besse" });
            eList.Add(new Temp { Id = 20, Name = "Margherita Anstine" });
            eList.Add(new Temp { Id = 21, Name = "Earleen Lambright" });
            eList.Add(new Temp { Id = 22, Name = "Lyn Valdivia" });
            eList.Add(new Temp { Id = 23, Name = "Alycia Couey" });
            eList.Add(new Temp { Id = 24, Name = "Lewis Rousey" });
            eList.Add(new Temp { Id = 24, Name = "Lewis Rousey" });
            eList.Add(new Temp { Id = 25, Name = "Tanja Profitt" });
            eList.Add(new Temp { Id = 26, Name = "Cherie Whyte" });
            eList.Add(new Temp { Id = 26, Name = "Cherie Whyte" });
            eList.Add(new Temp { Id = 27, Name = "Efren Leaf" });
            eList.Add(new Temp { Id = 28, Name = "Delta Darcangelo" });
            eList.Add(new Temp { Id = 29, Name = "Jess Bodnar" });
            eList.Add(new Temp { Id = 30, Name = "Sudie Parkhurst" });

            getAsset(id);

            this.BindingContext = this;
        }

        private async Task getAsset(int id)
        {
            asset =  await service.getAsset(id);

            this.AssetNameEditor.Text = asset.AssetName;
            this.dpicker.SelectedItem = dList.Where(x => x.Id == asset.DepartmentID).FirstOrDefault();
            this.lpicker.SelectedItem = lList.Where(x => x.Id == asset.LocationID).FirstOrDefault();
            this.apicker.SelectedItem = agList.Where(x => x.Id == asset.AssetGroupID).FirstOrDefault();
            this.epicker.SelectedItem = eList.Where(x => x.Id == asset.EmployeeID).FirstOrDefault();
            this.eDatePicker.Date = (DateTime)asset.WarrantyDate;
            AssetDesc.Text = asset.Description;
        }


        private async Task Button_ClickedAsync()
        {
            string name = AssetNameEditor.Text, desc = AssetDesc.Text, edate = eDatePicker.Date.ToString("yyyy/MM/dd");
            int did = selectedD.Id, aid = selectedAG.Id, eid = selectedE.Id, lid = selectedL.Id;
            // string assetname, string desc, int did, int lid, int aid, int eid, string edate, string assetsn
            // string assetname, string desc, int did, int lid, int aid, int eid, string edate, string assetsn
            Random r = new Random();
            string assetsn = $"0{aid}/0{did}/{r.Next(1000, 9999)}";

            var res = await service.addAsset(asset?.ID, name, desc, did, lid, aid, eid, edate, assetsn);

            if (res == "success")
            {
                await DisplayAlert("Alert", "Asset is added", "ok");
                App.Current.MainPage = new NavigationPage();
                App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Button_ClickedAsync();
        }
    }
}