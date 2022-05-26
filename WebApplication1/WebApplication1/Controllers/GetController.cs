using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class GetController : ApiController
    {
        Session1Entities ent = new Session1Entities();
        [HttpGet]
        public object getAssetRecord()
        {
            var allData = ent.Assets.ToList().Select(x => new
            {
                AssetId = x.ID,
                x.AssetName,
                x.AssetSN,
                Location = x.DepartmentLocation.Location.Name
            });
            return allData;
        }

        [HttpGet]
        public object getAssetRecord(int aId, int dId, string sDate, string eDate, string sText)
        {
            var allData = ent.Assets.ToList();

            DateTime d1 = DateTime.ParseExact(sDate, "yyyy/MM/dd", null);
            DateTime d2 = DateTime.ParseExact(eDate, "yyyy/MM/dd", null);

            allData = allData.Where(x => x.WarrantyDate >= d1 && x.WarrantyDate <= d2).ToList();

            if (aId != 0 && dId != 0)
            {
                allData = allData.Where(x => x.AssetGroupID == aId && x.DepartmentLocation.DepartmentID == dId).ToList();
            }

            if (!string.IsNullOrEmpty(sText))
            {
                allData = allData.Where(x => x.AssetName.Contains(sText)).ToList();
            }

            return allData.Select(x => new
            {
                AssetId = x.ID,
                x.AssetName,
                x.AssetSN,
                Location = x.DepartmentLocation.Location.Name
            });
        }

        [HttpGet]
        public object getHistoryTransfer(int id)
        {
            var allData = ent.AssetTransferLogs.Where(x => x.AssetID == id).ToList().Select(x => new
            {
                TransferDate = x.TransferDate.ToString("MM/dd/yyyy"),
                FromAssetSN = x.FromAssetSN,
                ToAssetSN = x.ToAssetSN,
                FromDepartmentLocation = ent.DepartmentLocations.Where(y => y.ID == x.FromDepartmentLocationID).FirstOrDefault().Location.Name.ToString(),
                ToDepartmentLocation = ent.DepartmentLocations.Where(y => y.ID == x.ToDepartmentLocationID).FirstOrDefault().Location.Name.ToString(),
            });

            return allData.ToList();
        }

        [HttpGet]
        public object storeAsset(string an, int did, int lid, int aid, int eid, string desc, string edate, string asn)
        {
            DateTime d1 = DateTime.ParseExact(edate, "yyyy/MM/dd", null);
            try
            {
                var asset = new Asset();
                asset.AssetSN = asn;
                asset.AssetName = an;
                asset.DepartmentLocationID = ent.DepartmentLocations.Where(x => x.DepartmentID == did).FirstOrDefault().ID;
                asset.EmployeeID = eid;
                asset.AssetGroupID = aid;
                asset.Description = desc;
                asset.WarrantyDate = d1;

                ent.Assets.Add(asset);
                ent.SaveChanges();
            }
            catch (Exception)
            {
                return Ok("failed");
            }

            return Ok("success");
        }

        [HttpGet]
        public object test()
        {
            return Ok("success");
        }
    }
}
