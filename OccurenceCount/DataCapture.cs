using System;

namespace OccurenceCount
{
    public class DataCapture
    {
        public static Data Capture() 
        {
            Data data = new Data();

            Console.Write("What is the Lower Limit: ");
            data.LowerLimit = int.Parse(Console.ReadLine());


            Console.Write("What is the Upper Limit: ");
            data.UpperLimit = int.Parse(Console.ReadLine());


            Console.Write("What is the search integer: ");
            data.Value = int.Parse(Console.ReadLine());

            return data;
        }
    }
}