using System;
using System.Linq;

namespace CountryPhone
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            string phoneNumber1 = "0575320938";
            string phoneNumber2 = "233575320938";
            string phoneNumber3 = "+233575320938";
            string phoneNumber4 = "+2330575320938";
            string phoneNumber5 = "2330575320938";
            string phoneNumber6 = "575320938";

            string phoneNumber7 = "234+2349022736119";
            
            phoneNumber7 = phoneNumber7.Split('+').Last();

            Console.WriteLine($"Result: {phoneNumber7}");

            Console.WriteLine($"Result: {phoneNumber1.Substring(1, phoneNumber1.Length - 1)}");

            Console.WriteLine("Hello World!");

            string result = p.ReturnPhoneNumber(phoneNumber1, "+233");
            string result2 = p.ReturnPhoneNumber(phoneNumber2, "+233");
            string result3 = p.ReturnPhoneNumber(phoneNumber3, "+233");
            string result4 = p.ReturnPhoneNumber(phoneNumber4, "+233");
            string result5 = p.ReturnPhoneNumber(phoneNumber5, "+233");
            string result6 = p.ReturnPhoneNumber(phoneNumber6, "+233");

            Console.WriteLine($"Result 1 {result}");
            Console.WriteLine($"Result 2 {result2}");
            Console.WriteLine($"Result 3 {result3}");
            Console.WriteLine($"Result 4 {result4}");
            Console.WriteLine($"Result 5 {result5}");
            Console.WriteLine($"Result 6 {result6}");

            Console.ReadLine();
        }

        private string ReturnPhoneNumber(string customerPhoneNumber, string countryPhoneCode)
        {
            string phone = customerPhoneNumber.Trim();
            string countryCodeWithoutPlusAndZero = countryPhoneCode + 0;

            //1
            if (phone.StartsWith("0")) //07011111111
            {
                phone = phone.Substring(1, phone.Length - 1);
                phone = $"{countryPhoneCode}{phone}";
            }

            //2
            if (!phone.StartsWith("+"))  //2347011111111
            {
                phone = $"+{phone}";
            }

            //3
            if (phone.StartsWith(countryCodeWithoutPlusAndZero))  //+23307011111111
            {
                phone = phone.Remove(0, 5);
                phone = $"{countryPhoneCode}{phone}";
            }

            //4
            if (!phone.StartsWith(countryPhoneCode))  //7011111111
            {
                phone = phone.Remove(0, 1);
                phone = $"{countryPhoneCode}{phone}";
            }

            return phone;
        }

        //private int returnDifferent (string customerPhoneNumber)
        //{
            
        //}
    }
}
