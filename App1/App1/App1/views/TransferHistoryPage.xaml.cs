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
    public partial class TransferHistory : ContentPage
    {

        public ObservableCollection<TransferHistoryClass> _historyClass = new ObservableCollection<TransferHistoryClass>();
        public ObservableCollection<TransferHistoryClass> HistoryClasses
        {
            get
            {
                return _historyClass;
            }

            set
            {
                _historyClass = value;
                OnPropertyChanged();
            }
        }
        public TransferHistory()
        {
            InitializeComponent();
        }

        public TransferHistory(int id)
        {
            InitializeComponent();
            this.loadDataAsync(id);
            this.Title = "Transfer History";
            this.Title = "Transfer History";
            this.BindingContext = this;
        }

        services.GetService service = new services.GetService();

        public async Task loadDataAsync(int id)
        {
            var res = await service.getTransferHistory(id);
            HistoryClasses = new ObservableCollection<TransferHistoryClass>(res);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}