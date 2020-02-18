using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace date_different
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    string result = null;

        //    var startDate = DateTime.Now;
        //    var customerWeekDate = Convert.ToDateTime(ConfigurationManager.AppSettings["CustomerWeekDate"]);

        //    var shipmentCount = ConfigurationManager.AppSettings["ShipmentCount"];

        //    int[] shipmentCountArray = shipmentCount.Split(',').Select(x => int.Parse(x.Trim())).ToArray();



        //    if (startDate.ToLongDateString() == customerWeekDate.ToLongDateString())
        //    {
        //        result = "true";
        //    }

        //    Console.WriteLine($"{startDate}" + " " + $"{customerWeekDate}");
        //    Console.WriteLine($"{result}");
        //    Console.WriteLine($"{string.Join(",", shipmentCountArray.ToList())}");
        //}

        static void Main(string[] args)
        {
            int DayDifferent = 0;

            DateTime LastUpdatePasswordDate = new DateTime(2018, 11, 01);
            DateTime TodayDate = DateTime.Now.Date;
            DayDifferent = (TodayDate - LastUpdatePasswordDate).Days;
            Console.WriteLine(DayDifferent);

            if (DayDifferent > 30)
            {
                Console.WriteLine("Password reset require");
            }

            int daysBackward = 500;

            //Ogo Sms
            string result = "";
            //string responseMessage = null;

            var finalURL = "https://www.ogosms.net/dynamicapi/?username=gigl&password=language3447****1234&sender=GIGL&numbers=08035324958&message= Testing for Error Message&response=json&unicode=0";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(finalURL);

            using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                //result = httpResponse.StatusCode.ToString();

                using (var sr = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
            }

            string response = result;

            result = ConfigurationManager.AppSettings[result];

            if (result == null)
            {
                result = response;
            }

            Console.WriteLine($"{daysBackward}" + " " + $"{TodayDate.AddDays(-daysBackward)}");
            Console.WriteLine($"{result}");
        }

        public string GetOGOSMSCodeMessage(string code)
        {
            string result = ConfigurationManager.AppSettings["${code}"];
            return result;
        }
    }
}