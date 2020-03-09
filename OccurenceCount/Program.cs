using System;
using System.Text;

namespace OccurenceCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;

            Data data = DataCapture.Capture();

            StringBuilder builder = new StringBuilder();

            //0(N)
            while(data.LowerLimit <= data.UpperLimit)
            {
                builder.Append(data.LowerLimit);
                data.LowerLimit++;
            }

            string search = builder.ToString();
            char value = Convert.ToChar(data.Value.ToString());  //search value 0 - 9
           
            //0(N)
            foreach (char c in search)
            {
                if (value.Equals(c))
                {
                    count++;
                }
            }
            Console.WriteLine($"Occur in {count} times");
        }
    }
}
