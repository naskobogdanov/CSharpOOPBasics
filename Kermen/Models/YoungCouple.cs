﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class YoungCouple : Couple
    {
        private const int NumberOfRooms = 2; 
        private const decimal RoomElectricity = 20;

        private decimal laptopCost;

        public YoungCouple(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost) 
            : base(NumberOfRooms, RoomElectricity, salaryOne + salaryTwo, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }

        protected YoungCouple(int numberOfRooms, decimal roomElectricity, decimal income, decimal tvCost,
            decimal fridgeCost, decimal laptopCost)
            : base(numberOfRooms, roomElectricity, income, tvCost, fridgeCost)
        {
            this.laptopCost = laptopCost;
        }
        public override decimal Consumption {
            get { return this.laptopCost*2 + base.Consumption; }
        }
    }
}