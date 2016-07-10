using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kermen.Factories;

namespace Kermen
{
    class Kermen
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<HouseHold> kermen = new List<HouseHold>();
            int counter = 0;

            while (input != "Democracy")
            {
                counter++;

                try
                {
                    HouseHold entity = HouseHoldFactory.CreateHouseHold(input);
                    kermen.Add(entity);
                }
                catch (Exception)
                {
                    
                }

                if (counter % 3 == 0)
                {
                    kermen.ForEach(x => x.GetIncome());
                }

                if (input == "EVN bill")
                {
                    kermen.RemoveAll(x => !x.CanPayBills());
                    kermen.ForEach(x => x.PayBills());
                }
                else if (input == "EVN")
                {
                    Console.WriteLine("Total consumption: {0}", kermen.Sum(x => x.Consumption));
                }
                

                input = Console.ReadLine();
            }

            Console.WriteLine("Total population: {0}", kermen.Sum(x => x.Population));
        }
    }
}
