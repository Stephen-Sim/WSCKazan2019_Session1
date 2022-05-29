using System;
using System.Collections;
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
        public object test()
        {
            return Ok("success");
        }

        [HttpGet]
        public object getAssetRecord()
        {
            var alldata = ent.Assets.ToList().Select(x => new { 
                Id = x.ID,
                AssetName = x.AssetName,
                AssetSN = x.AssetSN,
                Location = x.DepartmentLocation.Location.Name
            });

            return alldata;
        }

        [HttpGet]
        public object getAssetRecord(int did, int aid, string sdate, string edate, string stext)
        {
            var alldata = ent.Assets.ToList();

            DateTime d1 = DateTime.ParseExact(sdate, "yyyy/MM/dd", null);
            DateTime d2 = DateTime.ParseExact(edate, "yyyy/MM/dd", null);

            alldata = alldata.Where(x => x.WarrantyDate >= d1 && x.WarrantyDate <= d2).ToList();

            if (did != null && aid != null)
            {
                alldata = alldata.Where(x => x.AssetGroupID == aid && x.DepartmentLocation.DepartmentID == did).ToList();
            }

            if (!string.IsNullOrEmpty(stext))
            {
                alldata = alldata.Where(x => x.AssetName.Contains(stext)).ToList();
            }

            return alldata.Select(x => new {
                Id = x.ID,
                AssetName = x.AssetName,
                AssetSN = x.AssetSN,
                Location = x.DepartmentLocation.Location.Name
            });
        }

        [HttpGet]
        public object getTransferHistory(int id)
        {
            var allData = ent.AssetTransferLogs.Where(x => x.AssetID == id).ToList().Select(x => new
            {
                date = x.TransferDate.ToShortDateString(),
                oldDepartment = ent.DepartmentLocations.Where(y => y.ID == x.FromDepartmentLocationID).FirstOrDefault().Department.Name,
                oldAssetSN = x.FromAssetSN,
                newDepartment = ent.DepartmentLocations.Where(y => y.ID == x.ToDepartmentLocationID).FirstOrDefault().Department.Name,
                newAssetSN = x.ToAssetSN
            });

            return allData;
        }

        [HttpGet]
        public object addAsset(int? assetId, string assetname, string desc, int did, int lid, int aid, int eid, string edate, string assetsn)
        {
            try
            {
                var asset = (assetId == null ? new Asset() : ent.Assets.Where(x => x.ID == assetId).First());

                asset.AssetName = assetname;
                asset.Description = desc;
                asset.AssetSN = assetsn;
                asset.EmployeeID = eid;
                asset.WarrantyDate = DateTime.ParseExact(edate, "yyyy/MM/dd", null);
                asset.AssetGroupID = aid;
                asset.DepartmentLocationID = ent.DepartmentLocations.Where(x => x.DepartmentID == did).FirstOrDefault().ID;

                if (assetId == null)
                {
                    ent.Assets.Add(asset);
                }
                else
                {
                    ent.Assets.Append(asset);
                }

                ent.SaveChanges();
                return Ok("success");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public object getAsset(int id)
        {
            return ent.Assets.Where(x => x.ID == id).ToList().Select(x => new
            {
                x.ID,
                x.AssetSN,
                x.AssetName,
                LocationID = x.DepartmentLocation.Location.ID,
                DepartmentID = x.DepartmentLocation.Department.ID,
                x.EmployeeID,
                x.AssetGroupID,
                x.Description,
                x.WarrantyDate
            }).FirstOrDefault();
        }
    }
}
