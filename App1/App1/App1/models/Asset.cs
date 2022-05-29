using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class Asset
    {
        public int ID { get; set; }
        public string AssetSN { get; set; }
        public string AssetName { get; set; }
        public long LocationID { get; set; }
        public long DepartmentID { get; set; }
        public long EmployeeID { get; set; }
        public long AssetGroupID { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> WarrantyDate { get; set; }
    }
}
