using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.GeoLocation
{
    public class GeoLocationManager
    {
        #region Fields
        private RestClient client;
        private string _gateway;
        #endregion
        public GeoLocationManager()
        {
            _gateway = "http://www.geoplugin.net/json.gp?ip={0}";
            client = new RestClient();
        }
        public GeoDetails GetCountryData(string ip)
        {
            var request = new RestRequest(Method.GET);
   
            request.AddHeader("content-type", "application/json"); 

            var gatewayIpLink = String.Format(this._gateway, ip);

            client.BaseUrl = new Uri(gatewayIpLink);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    var geoDetails = JsonConvert.DeserializeObject<GeoDetails>(response.Content);
           
                    return geoDetails;
                }
                catch (Exception e)
                {
                    return null;
                }
                
            }
            return null;
        }
    }

    public class GeoDetails {
        public string geoplugin_request { get; set; }
        public string geoplugin_status { get; set; }
        public string geoplugin_delay { get; set; }
        public string geoplugin_credit { get; set; }
        public string geoplugin_city { get; set; }
        public string geoplugin_region { get; set; }
        public string geoplugin_regionCode { get; set; }
        public string geoplugin_regionName { get; set; }
        public string geoplugin_areaCode { get; set; }
        public string geoplugin_dmaCode { get; set; }
        public string geoplugin_countryCode { get; set; }
        public string geoplugin_countryName { get; set; }
        public string geoplugin_inEU { get; set; }
        public string geoplugin_euVATrate { get; set; }
        public string geoplugin_continentCode { get; set; }
        public string geoplugin_continentName { get; set; }
        public string geoplugin_latitude { get; set; }
        public string geoplugin_longitude { get; set; }
        public string geoplugin_locationAccuracyRadius { get; set; }
        public string geoplugin_timezone { get; set; }
        public string geoplugin_currencyCode { get; set; }
        public string geoplugin_currencySymbol { get; set; }
        public string geoplugin_currencySymbol_UTF8 { get; set; }
        public string geoplugin_currencyConverter { get; set; }

    }
}
