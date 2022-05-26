using System;
using System.Collections.Generic;
using System.Text;

namespace App1.models
{
    public class TransferLogClass
    {
        public string TransferDate { set; get; }
        public string FromAssetSN { set; get; }
        public string ToAssetSN { set; get; }
        public string FromDepartmentLocation { set; get; }
        public string ToDepartmentLocation { set; get; }
    }
}
