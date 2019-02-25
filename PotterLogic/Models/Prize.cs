using System;
using System.Collections.Generic;
using System.Text;

namespace PotterLogic.Models
{
    public class Prize: ICloneable
    {
        private double _prizeValue;

        public Prize(double prizeValue)
        {
            _prizeValue = prizeValue;
        }

        
        public void ApplyDiscount(DiscountRules discount)
        {
            _prizeValue = _prizeValue * discount.GetDiscount();
        }

        public void AddPrizeBook(double prizeValue)
        {
            _prizeValue += prizeValue;
        }

        public Prize AddPriceBook(Prize priceValue)
        {
            _prizeValue += priceValue._prizeValue;

            return this;
        }

        public override bool Equals(object prize)
        {
            if (prize == null || GetType() != prize.GetType())
            {
                return false;
            }

            var prizeObject = prize as Prize;
            return prizeObject._prizeValue == this._prizeValue;
        }
        

        internal void Sum(Prize prizeToSum)
        {
            _prizeValue += prizeToSum._prizeValue;
        }

        internal void MultPrize(int v)
        {

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {            
            return  new Prize(_prizeValue);
        }
    }
}
