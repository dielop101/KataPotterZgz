using PotterLogic;
using PotterLogic.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace KataPotterZgz
{
    public class TestSeveralDiscounts
    {
        private CalculatePrizeService potterService = new CalculatePrizeService();
        private readonly Prize prizeConstant = new Prize(8);

        [Fact]
        public void TestZeroZeroOne()
        {
            var bookList = new CollectionBooks();
            var bookZero = new Book(0, prizeConstant);
            bookList.AddBook(bookZero);
            bookList.AddBook(bookZero);
            var bookOne = new Book(1, prizeConstant);
            bookList.AddBook(bookOne);

            Assert.Equal(new Prize(8 + (8 * 2 * 0.95)), potterService.PrizeBooks(bookList));
        }

        [Fact]
        public void TestZeroZeroOneTwoTwoThree()
        {
            var bookList = new CollectionBooks();
            var bookZero = new Book(0, prizeConstant);
            bookList.AddBook(bookZero);
            bookList.AddBook(bookZero);
            var bookOne = new Book(1, prizeConstant);
            bookList.AddBook(bookOne);
            var bookTwo = new Book(2, prizeConstant);
            bookList.AddBook(bookTwo);
            bookList.AddBook(bookTwo);
            var bookThree = new Book(3, prizeConstant);
            bookList.AddBook(bookThree);

            Assert.Equal(new Prize((8 * 4 * 0.8) + (8 * 2 * 0.95)), potterService.PrizeBooks(bookList));
        }
    }
}
