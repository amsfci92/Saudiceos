using Cigarette.Enterprise.ViewModels.ViewModels.SmsGateway;
using OtpNet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.Notifications
{
    public class SMSSendMethod
    {
        public const string POST = "POST";
        public const string GET = "GET";

    }
    public class SMSManager
    {
        private const string optSecret = "sdfdfssdfsdfsdfasadfa";

        private RestClient client;
        private HttpWebRequest smsRequest;
        private string gateway;
        private Method method;
        SmsGatewayVM _gateway;
        string numbers;
        string token;
        string otp;
        string message;
        public SMSManager(SmsGatewayVM gateway)
        {
            this.gateway = gateway.UrlDescription;
            _gateway = gateway;
            client = new RestClient();
        }
        public SMSManager PostRequest()
        {
            this.method = Method.POST;
            return this;
        }


        public SMSManager GetRequest()
        {
            this.method = Method.GET;
            return this;
        }
        public SMSManager Numbers(string numbers)
        {
            this.numbers = numbers;
            return this;
        }

        public SMSManager Token(string message = "")
        {

            var secretKey = Base32Encoding.ToBytes(optSecret);
            var totp = new Totp(secretKey);
            this.otp = totp.ComputeTotp();
            this.token = string.Format("{0} {1}", message, this.otp);
            return this;
        }

        public SMSManager Message(string message)
        {
            this.message = message;
            return this;
        }

        public static string GetOTPToken()
        {
            var secretKey = Base32Encoding.ToBytes(optSecret);
            var totp = new Totp(secretKey);
            var otp = totp.ComputeTotp();

            return otp;
        }

        public IRestResponse Send()
        {
            var request = new RestRequest(this.method);

            request.AddHeader("content-type", "application/json");
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);

            var gatewaySmsLink = String.Format(this.gateway, token ?? message, numbers);

            client.BaseUrl = new Uri(gatewaySmsLink);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response;
            }
            return null;
        }

        public string GetToken()
        {
            return this.otp;
        }
    }
}
