using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterLogic.Models
{
    public class CollectionBooks
    {
        private List<Book> _books;

        public List<Book> GetCollectionBooks()
        {
            return _books;
        }

        public bool Any()
        {
            return _books.Any();
        }

        public CollectionBooks()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        internal Prize SumPrize()
        {
            var prizeCollection = new Prize(0);
            this._books.ForEach(book=> prizeCollection.Sum(book.GetRealPrize()));

            return prizeCollection;
        }

        public int NumBooks()
        {
            return this._books.Count();
        }

        public int NumBooksDistinct()
        {
            return _books.Distinct().Count();
        }
        

        internal void ApplyDiscount(double discount)
        {
            this._books.ForEach(book => book.SetDiscount(discount));
        }
    }
}
