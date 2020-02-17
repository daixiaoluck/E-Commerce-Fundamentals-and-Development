using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace E_Commerce_Project_Three.Data
{
    public class PDTHttpClient
    {
        private HttpClient _pdtHttpClient
        { get; set; }
        public string responseData
        { get; set; }
        public PDTHttpClient()
        {
            _pdtHttpClient = new HttpClient();
        }
        //在Controller的Action里给它传递tx
        public void SessionWithPDT(string tx)
        {
            string url = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            string originalData = $"cmd=_notify-synch&tx={tx}&at=szmEEN3FKtR3bmvPOGBnek1c399icja7ikuVh2ZMVO_9F9Yv_Ch80oaB1YO";
            var finalData = new StringContent(originalData);
            responseData = _pdtHttpClient.PostAsync(url, finalData).Result.Content.ReadAsStringAsync().Result;
        }
    }
}