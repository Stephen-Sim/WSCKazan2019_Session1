using App1.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.viewmodels
{
    public class ResgisterAssetViewModel : BindableObject
    {
        services.GetService service = new services.GetService();
        public ObservableCollection<Temp> DeparmentList { set; get; }

        public Temp SelectedDepartment { set; get; }

        public ObservableCollection<Temp> LocationList { set; get; }

        public Temp SelectedLocation{ set; get; }

        public ObservableCollection<Temp> EmployeeList { set; get; }

        public Temp SelectedEmployee { set; get; }
        public ObservableCollection<Temp> AssetGroupList { set; get; }
        public Temp SelectedAssetGroup { set; get; }

        public string AssetName { set; get; }
        public string AssetDesc { set; get; }

        public DateTime ExpiredDate { set; get; } = DateTime.Now;

        public ResgisterAssetViewModel()
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

            LocationList = new ObservableCollection<Temp>();
            LocationList.Add(new Temp { Id = 1, Name = "Kazan" });
            LocationList.Add(new Temp { Id = 2, Name = "Volka" });
            LocationList.Add(new Temp { Id = 3, Name = "Moscow" });

            EmployeeList = new ObservableCollection<Temp>();
            EmployeeList.Add(new Temp { Id = 1, Name = "Martina Winegarden" });
            EmployeeList.Add(new Temp { Id = 2, Name = "Rashida Brammer" });
            EmployeeList.Add(new Temp { Id = 3, Name = "Mohamed Krall" });
            EmployeeList.Add(new Temp { Id = 4, Name = "Shante Karr" });
            EmployeeList.Add(new Temp { Id = 5, Name = "Rosaura Rames" });
            EmployeeList.Add(new Temp { Id = 6, Name = "Toi Courchesne" });
            EmployeeList.Add(new Temp { Id = 7, Name = "Precious Wismer" });
            EmployeeList.Add(new Temp { Id = 8, Name = "Josefa Otte" });
            EmployeeList.Add(new Temp { Id = 9, Name = "Afton Harrington" });
            EmployeeList.Add(new Temp { Id = 10, Name = "Daphne Morrow" });
            EmployeeList.Add(new Temp { Id = 11, Name = "Dottie Polson" });
            EmployeeList.Add(new Temp { Id = 12, Name = "Alleen Nally" });
            EmployeeList.Add(new Temp { Id = 13, Name = "Hilton Odom" });
            EmployeeList.Add(new Temp { Id = 14, Name = "Shawn Hillebrand" });
            EmployeeList.Add(new Temp { Id = 15, Name = "Lorelei Kettler" });
            EmployeeList.Add(new Temp { Id = 16, Name = "Jalisa Gossage" });
            EmployeeList.Add(new Temp { Id = 17, Name = "Germaine Sim" });
            EmployeeList.Add(new Temp { Id = 18, Name = "Suzanna Wollman" });
            EmployeeList.Add(new Temp { Id = 19, Name = "Jennette Besse" });
            EmployeeList.Add(new Temp { Id = 20, Name = "Margherita Anstine" });
            EmployeeList.Add(new Temp { Id = 21, Name = "Earleen Lambright" });
            EmployeeList.Add(new Temp { Id = 22, Name = "Lyn Valdivia" });
            EmployeeList.Add(new Temp { Id = 23, Name = "Alycia Couey" });
            EmployeeList.Add(new Temp { Id = 24, Name = "Lewis Rousey" });
            EmployeeList.Add(new Temp { Id = 25, Name = "Tanja Profitt" });
            EmployeeList.Add(new Temp { Id = 26, Name = "Cherie Whyte" });
            EmployeeList.Add(new Temp { Id = 27, Name = "Efren Leaf" });
            EmployeeList.Add(new Temp { Id = 28, Name = "Delta Darcangelo" });
            EmployeeList.Add(new Temp { Id = 29, Name = "Jess Bodnar" });
            EmployeeList.Add(new Temp { Id = 30, Name = "Sudie Parkhurst" });
        }

        public async Task<string> storeAssetAsync(string asn)
        {
            // storeAsset(string an, int did, int lid, int aid, int eid, string desc, string edate, string asn)
            return await service.storeAsset(
                AssetName, 
                SelectedDepartment.Id, 
                SelectedLocation.Id, 
                SelectedAssetGroup.Id, 
                SelectedEmployee.Id,
                AssetDesc,
                ExpiredDate.Date.ToString("yyyy/MM/dd"), 
                asn);
        }
    }
}
