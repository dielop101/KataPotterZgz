using System;
using System.Collections.Generic;
using System.Text;

namespace PotterLogic.Models
{
    public class DiscountRules
    {
        private int _numberOfBooks;
        private double _discount;

        public DiscountRules(int numberOfBooks, double discount)
        {
            _numberOfBooks = numberOfBooks;
            _discount = discount;
        }

        public int GetNumOfBooks()
        {
            return _numberOfBooks;
        }

        internal double GetDiscount()
        {
            return _discount;
        }
    }
}
