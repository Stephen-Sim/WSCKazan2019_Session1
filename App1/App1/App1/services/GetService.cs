using App1.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.services
{
    public class GetService
    {
        string url = "http://10.130.7.170:45455/api/get";

        HttpClient conn = new HttpClient();

        public async Task<List<AssetClass>> getAssetRecord()
        {
            try
            {
                string url = $"{this.url}/getAssetRecord";

                var responce = await conn.GetStringAsync(url);
                var _assetClass = JsonConvert.DeserializeObject<List<AssetClass>>(responce);
                return new List<AssetClass>(_assetClass);
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                return null;
            }
        }

        public async Task<List<AssetClass>> getAssetRecord(int aId, int dId, string sDate, string eDate, string sText)
        {
            try
            {
                string url = $"{this.url}/getAssetRecord?aId={aId}&dId={dId}&sDate={sDate}&eDate={eDate}&sText={sText}";

                var responce = await conn.GetStringAsync(url);
                var _assetClass = JsonConvert.DeserializeObject<List<AssetClass>>(responce);
                return new List<AssetClass>(_assetClass);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<TransferLogClass>> getHistoryTransfer(int id)
        { 
            try
            {
                string url = $"{this.url}/getHistoryTransfer?Id={id}";

                var responce = await conn.GetStringAsync(url);
                var transferLogClasses = JsonConvert.DeserializeObject<List<TransferLogClass>>(responce);
                return new List<TransferLogClass>(transferLogClasses);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> storeAsset(string an, int did, int lid, int aid, int eid, string desc, string edate, string asn)
        {
            string url = $"{this.url}/storeAsset?an={an}&did={did}&lid={lid}&aid={aid}&eid={eid}&desc={desc}&edate={edate}&asn={asn}";
            var responce = await conn.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<string>(responce);
            return result;
        }
    }
}
