using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Party_planner
{
    class Party
    {
        const int CostOfFoodPerPerson = 25;
        private bool fancyDecorations;
        public decimal CostOfDecorations = 0;

        public Party(int numberOfPeople, bool fancyDecorations)
        {
            this.fancyDecorations = fancyDecorations;
            this.NumberOfPeople = numberOfPeople;
        }

        private int numberOfPeople;
        public virtual int NumberOfPeople
        {
            get { return numberOfPeople; }
            set
            {
                numberOfPeople = value;
                CalculateCostOfDecorations(fancyDecorations);
            }
        }

        public void CalculateCostOfDecorations(bool fancy)
        {
            fancyDecorations = fancy;
            if (fancy)
                CostOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            else
                CostOfDecorations = (NumberOfPeople * 7.50M) + 30M;
        }

        public virtual decimal CalculateCost()
        {
            decimal TotalCost = CostOfDecorations + (CostOfFoodPerPerson * NumberOfPeople);
            if (NumberOfPeople > 12)
            {
                TotalCost += 100M;
            }
            return TotalCost;
        }
    }
}
