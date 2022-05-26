using App1.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.viewmodels
{
    public class TransferLogViewModel : BindableObject
    {
        services.GetService service = new services.GetService();

        private ObservableCollection<TransferLogClass> _transferLogList;

        public ObservableCollection<TransferLogClass> TransferLogList
        { 
            get { return _transferLogList; } 
            set { _transferLogList = value; OnPropertyChanged(); } 
        }

        public TransferLogViewModel()
        {
            
        }

        public TransferLogViewModel(int id)
        {
            service = new services.GetService();
            this.loadDataAsync(id);
        }

        public async Task loadDataAsync(int id)
        {
            var response = await service.getHistoryTransfer(id);
            TransferLogList = new ObservableCollection<TransferLogClass>(response);
        }
    }
}
