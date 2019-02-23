using System;
using System.Collections.Generic;
using System.Text;

namespace PotterLogic.Models
{
    public class Book
    {
        private int _idBook;
        private Prize _prizeBook;
        private double _discount;

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

        public Book(int idBook, Prize prizeBook, double discount = 1)
        {
            _idBook = idBook;
            _prizeBook = prizeBook;
            _discount = discount;
        }

        internal void SetDiscount(double discount)
        {
            _discount = discount;
        }
    }
}
