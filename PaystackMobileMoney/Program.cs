using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PaystackMobileMoney
{
    
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string a = "wb-1013000005-b32dffab";

            Console.WriteLine(a.StartsWith("wb"));

            string payStackSecretGhana = "sk_test_dd8c0bb5945881c0df4637ee3e195f6ef2d62ce3";
            string payStackChargeAPI = "https://api.paystack.co/charge";

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", payStackSecretGhana);

                MobileMoneyDTO mobileMoney = new MobileMoneyDTO
                {
                    amount = 200,
                    currency = "GHS",
                    email = "azeez.oladejo@giglogistics.ng",
                    reference = "wb-1013000005-b32dffab",
                    mobile_money = new Mobile_Money
                    {
                        phone = "0551234987",
                        provider = "mtn"
                    }
                };

                var json = JsonConvert.SerializeObject(mobileMoney);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(payStackChargeAPI, data);
                string result = await response.Content.ReadAsStringAsync();

                var jObject = JsonConvert.DeserializeObject<PaystackWebhookDTO>(result);

                Console.WriteLine(jObject.Status);
                Console.WriteLine(jObject.Message);

                Console.WriteLine(result);
            }
        }
    }

    public class MobileMoneyDTO
    {
        public MobileMoneyDTO()
        {
            mobile_money = new Mobile_Money();
        }

        public string reference { get; set; }

        public decimal amount { get; set; }
        public string currency { get; set; }
        public string email { get; set; }

        public Mobile_Money mobile_money { get; set; }
    }

    public class Mobile_Money
    {
        public string phone { get; set; }
        public string provider { get; set; }
    }

    public class PaystackWebhookDTO
    {
        public PaystackWebhookDTO()
        {
            data = new Data();
        }
        public string Event { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string Status { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public string Gateway_Response { get; set; }
        public string Display_Text { get; set; }
        public string Message { get; set; }
    }

    public class PaymentResponse
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public string GatewayResponse { get; set; }
        public string Status { get; set; }
    }
}
