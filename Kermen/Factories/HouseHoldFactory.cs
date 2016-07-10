using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kermen.Factories
{
    static class HouseHoldFactory
    {
        public static HouseHold CreateHouseHold(string input)
        {
            string pattern = @"(\w+)\(([\d\.\s,]+)\)";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);
            if (rgx.IsMatch(input))
            {
                string houseHoldType = matches[0].Groups[1].Value;
                if (houseHoldType == "YoungCouple")
                {
                    decimal[] salaries = matches[0].Groups[2].Value.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(decimal.Parse)
                        .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

                    return new YoungCouple(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost);
                }
                else if (houseHoldType == "YoungCoupleWithChildren")
                {
                    decimal[] salaries = matches[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(decimal.Parse)
                        .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal laptopCost = decimal.Parse(matches[3].Groups[2].Value);

                    Child[] children = new Child[matches.Count - 4];
                    for (int i = 4; i <  matches.Count; i++)
                    {
                        decimal[] consumptions = matches[i].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(decimal.Parse)
                        .ToArray();
                        children[i - 4] = new Child(consumptions);
                    }

                    return new YoungCoupleWithChildren(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost,
                        children);
                }
                else if (houseHoldType == "AloneYoung")
                {
                    decimal salary = decimal.Parse(matches[0].Groups[2].Value);
                    decimal laptop = decimal.Parse(matches[1].Groups[2].Value);

                    return new AloneYoung(salary, laptop);
                }
                else if (houseHoldType == "OldCouple")
                {
                    decimal[] pensions = matches[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(decimal.Parse)
                        .ToArray();
                    decimal tvCost = decimal.Parse(matches[1].Groups[2].Value);
                    decimal fridgeCost = decimal.Parse(matches[2].Groups[2].Value);
                    decimal stoveCost = decimal.Parse(matches[3].Groups[2].Value);

                    return new OldCouple(pensions[0], pensions[1], tvCost, fridgeCost, stoveCost);

                }
                else if (houseHoldType == "AloneOld")
                {
                    decimal pension = decimal.Parse(matches[0].Groups[2].Value);

                    return new AloneOld(pension);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            throw new ArgumentException("Invalid household");
        }
    }
}
