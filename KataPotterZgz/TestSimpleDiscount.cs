using PotterLogic;
using PotterLogic.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace KataPotterZgz
{
    public class TestSimpleDiscount
    {
        private CalculatePrizeService potterService = new CalculatePrizeService();
        private readonly Prize prizeConstant = new Prize(8);

        [Fact]
        public void TestDiscountTwoDistinctBooks()
        {
            var bookList = new CollectionBooks();
            var bookZero = new Book(0, prizeConstant);
            bookList.AddBook(bookZero);
            var bookOne = new Book(1, prizeConstant);
            bookList.AddBook(bookOne);


            Assert.Equal(new Prize(8 * 2 * 0.95), potterService.PrizeBooks(bookList));
        }

        [Fact]
        public void TestDiscountTreeDistinctBooks()
        {
            var bookList = new CollectionBooks();
            var book1 = new Book(0, prizeConstant);
            bookList.AddBook(book1);
            var book2 = new Book(2, prizeConstant);
            bookList.AddBook(book2);
            var book4 = new Book(4, prizeConstant);
            bookList.AddBook(book4);


            Assert.Equal(new Prize(8 * 3 * 0.9), potterService.PrizeBooks(bookList));
        }
    }
}
