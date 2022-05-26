using App1.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.viewmodels
{
    public class MainPageViewModel : BindableObject
    {
        services.GetService service = new services.GetService();
        public ObservableCollection<Temp> DeparmentList { set; get; }

        public Temp SelectedDepartment { set; get; }
        public ObservableCollection<Temp> AssetGroupList { set; get; }
        public Temp SelectedAssetGroup { set; get; }

        public DateTime StartDate { set; get; } = DateTime.Now.Date;

        public DateTime EndDate { set; get; } = DateTime.Now.Date;

        public string SearchText { set; get; } = string.Empty;


        public int initcount = 0;

        private string _recordCount;
        public string recordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; OnPropertyChanged(); }
        }

        private ObservableCollection<AssetClass> _assetClasses;

        public ObservableCollection<AssetClass> AssetClasses 
        { 
            get { return _assetClasses; } 
            set { _assetClasses = value; OnPropertyChanged(); } 
        }

        public MainPageViewModel()
        {
            DeparmentList = new ObservableCollection<Temp>();
            DeparmentList.Add(new Temp { Id = 1, Name = "Exploration" });
            DeparmentList.Add(new Temp { Id = 2, Name = "Production" });
            DeparmentList.Add(new Temp { Id = 3, Name = "Transportation" });
            DeparmentList.Add(new Temp { Id = 4, Name = "R&D" });
            DeparmentList.Add(new Temp { Id = 5, Name = "Distribution" });
            DeparmentList.Add(new Temp { Id = 6, Name = "QHSE" });

            AssetGroupList = new ObservableCollection<Temp>();
            AssetGroupList.Add(new Temp { Id = 1, Name = "Hydraulic" });
            AssetGroupList.Add(new Temp { Id = 3, Name = "Electrical" });
            AssetGroupList.Add(new Temp { Id = 4, Name = "Mechanical" });
        }

        public async Task getFirstScreenAssetRecord()
        {
            var responce = await service.getAssetRecord();
            AssetClasses = new ObservableCollection<AssetClass>(responce);
            initcount = AssetClasses.Count;
            recordCount = AssetClasses.Count.ToString() + " assets from " + initcount.ToString();
        }

        public async Task getSearchAsset()
        {
            //int aId, int dId, string sDate, string eDate, string sText
            var responce = await service.getAssetRecord(SelectedAssetGroup?.Id != null ? SelectedAssetGroup.Id : 0, SelectedDepartment?.Id != null ? SelectedDepartment.Id : 0, StartDate.Date.ToString("yyyy/MM/dd"), EndDate.Date.ToString("yyyy/MM/dd"), SearchText != string.Empty? SearchText : string.Empty);
            AssetClasses = new ObservableCollection<AssetClass>(responce);
            recordCount = AssetClasses.Count.ToString() + " assets from " + initcount.ToString();
        }
    }
}
