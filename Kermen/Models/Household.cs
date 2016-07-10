using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public abstract class HouseHold
    {
        private int numberOfRooms;
        private decimal roomElectricity;
        private readonly decimal income;
        private decimal money;

        public HouseHold(decimal income, int numberOfRooms, decimal roomElectricity)
        {
            this.numberOfRooms = numberOfRooms;
            this.roomElectricity = roomElectricity;
            this.income = income;
            this.money = 0;
        }

        public virtual int Population
        {
            get { return 1; }
        }

        public virtual decimal Consumption
        {
            get { return this.roomElectricity * this.numberOfRooms; }
        }

        public void GetIncome()
        {
            this.money += this.income;
        }

        public bool CanPayBills()
        {
           return this.money >= this.Consumption;
        }

        public void PayBills()
        {
            this.money -= this.Consumption;
        }
    }
}