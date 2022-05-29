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
        string url = "http://10.130.7.45:45455/api/get";
        HttpClient conn = new HttpClient();

        public async Task<ObservableCollection<AssetClass>> getAssetRecord()
        {
            try
            {
                string url = $"{this.url}/getAssetRecord";
                var response =  await conn.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<ObservableCollection<AssetClass>>(response);
                return new ObservableCollection<AssetClass>(result);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
        public async Task<ObservableCollection<AssetClass>> getAssetRecord(int did, int aid, string sdate, string edate, string stext)
        {
            try
            {
                string url = $"{this.url}/getAssetRecord?did={did}&aid={aid}&sdate={sdate}&edate={edate}&stext={stext}";
                var response = await conn.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<ObservableCollection<AssetClass>>(response);
                return new ObservableCollection<AssetClass>(result);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<ObservableCollection<TransferHistoryClass>> getTransferHistory(int id)
        {
            try
            {
                string url = $"{this.url}/getTransferHistory?id={id}";
                var response = await conn.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<ObservableCollection<TransferHistoryClass>>(response);
                return new ObservableCollection<TransferHistoryClass>(result);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<string> addAsset(int? assetId, string assetname, string desc, int did, int lid, int aid, int eid, string edate, string assetsn)
        {
            // string assetname, string desc, int did, int lid, int aid, int eid, string edate, string assetsn
            try
            {
                string url = $"{this.url}/addAsset?assetId={assetId}&assetname={assetname}&desc={desc}&did={did}&lid={lid}&aid={aid}&eid={eid}&edate={edate}&assetsn={assetsn}";
                var response = await conn.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<string>(response);
                return result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public async Task<Asset> getAsset(int id)
        {
            try
            {
                string url = $"{this.url}/getAsset?id={id}";
                var response = await conn.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<Asset>(response);
                return result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

    }
}
