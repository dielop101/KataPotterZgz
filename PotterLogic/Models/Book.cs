using System;
using System.Collections.Generic;
using System.Text;

namespace PotterLogic.Models
{
    public class Book
    {
        private int _idBook;
        private Prize _prizeBook;
        private DiscountRules _discount;

        public int GetIdBook()
        {
            return _idBook;
        }
        public Prize GetRealPrize()
        {
            var prizeWithDiscount = _prizeBook.Clone() as Prize; 
            prizeWithDiscount.ApplyDiscount(_discount);
            return prizeWithDiscount;
        }

        public Book(int idBook, Prize prizeBook, DiscountRules discount = null)
        {
            _idBook = idBook;
            _prizeBook = prizeBook;
            _discount = discount == null ? new DiscountRules(1, 1) : discount;
        }

        public void SetDiscount(DiscountRules discount)
        {
            _discount = discount;
        }

        internal Book Clone()
        {
            return new Book(_idBook, _prizeBook, _discount);
        }
    }
}
