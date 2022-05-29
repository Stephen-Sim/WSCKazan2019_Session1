using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class TransferHistoryClass
    {
        public string date { set; get; }
        public string oldDepartment { set; get; }
        public string oldAssetSN { set; get; }
        public string newDepartment { set; get; }
        public string newAssetSN { set; get; }
    }
}
