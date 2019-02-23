using PotterLogic.Models;
using PotterLogic.Utils;
using System;
using System.Collections.Generic;

namespace PotterLogic
{
    public class CalculatePrizeService
    {
        private readonly Prize prizeConstant = new Prize(8);


        private Dictionary<int, Double> discountRules = 
            new Dictionary<int, double>() {
                { 1, 1 },
                { 2, 0.95 },
                { 3, 0.90 },
                { 4, 0.8 },
                { 5, 0.75 }
            };

        public Prize PrizeBooks(CollectionBooks bookList)
        {
            if (bookList.Any())
                return PrizeSomeBooks(bookList);

            return new Prize(0);
        }

        private Prize PrizeSomeBooks(CollectionBooks bookList)
        {

            var prizeConstantInstance = prizeConstant;

            ApplyDiscount(bookList, discountRules);

            return bookList.SumPrize();
        }

        private void ApplyDiscount(CollectionBooks bookList, Dictionary<int, double> discountRules)
        {
            int numDistinct=bookList.NumBooksDistinct();
            bookList.ApplyDiscount(discountRules[numDistinct]);            
        }
    }
}
