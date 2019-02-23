using PotterLogic;
using PotterLogic.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace KataPotterZgz
{
    public class TestBasics
    {
        private CalculatePrizeService potterService = new CalculatePrizeService();
        private readonly Prize prizeConstant = new Prize(8);

        [Fact]
        public void TestNoneBook()
        {
            var bookList = new CollectionBooks();
            Assert.Equal(new Prize(0), potterService.PrizeBooks(bookList));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestBookByType(int idBook)
        {
            var bookList = new CollectionBooks();
            var book = new Book(idBook, prizeConstant);
            bookList.AddBook(book);

            Assert.Equal(new Prize(8), potterService.PrizeBooks(bookList));
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 3)]
        public void TestBookCollection(int idBook, int numTimes)
        {
            var bookList = new CollectionBooks();
            var bookType = new Book(idBook, prizeConstant);
            for (var i = 0; i < numTimes; i++)
            {
                bookList.AddBook(bookType);
            }

            var prize = new Prize(8 * numTimes);
            Assert.Equal(prize, potterService.PrizeBooks(bookList));
        }
    }
}
