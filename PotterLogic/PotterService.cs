using PotterLogic.Models;
using PotterLogic.Utils;
using System;
using System.Collections.Generic;

namespace PotterLogic
{
    public class CalculatePrizeService
    {
        private readonly Prize prizeConstant = new Prize(8);
        private readonly CollectionDiscountRules _colDiscountRules = new CollectionDiscountRules();

        public CalculatePrizeService()
        {
            InicializeCollectionDiscountRules();
        }

        public Prize PrizeBooks(CollectionBooks bookList)
        {
            if (bookList.Any())
                return PrizeSomeBooks(bookList);

            return new Prize(0);
        }

        private void InicializeCollectionDiscountRules()
        {
            var disc1 = new DiscountRules(1, 1);
            var disc2 = new DiscountRules(2, 0.95);
            var disc3 = new DiscountRules(3, 0.9);
            var disc4 = new DiscountRules(4, 0.8);
            var disc5 = new DiscountRules(5, 0.75);
            _colDiscountRules.AddDiscountRules(disc1);
            _colDiscountRules.AddDiscountRules(disc2);
            _colDiscountRules.AddDiscountRules(disc3);
            _colDiscountRules.AddDiscountRules(disc4);
            _colDiscountRules.AddDiscountRules(disc5);
        }

        private Prize PrizeSomeBooks(CollectionBooks bookList, Prize price = null)
        {
            if (price == null)
                price = new Prize(0);

            if (bookList == null || !bookList.Any())
                return price;

            //separamos los libros en lista de libros distintos
            var newBookCol = new CollectionBooks();
            foreach (var book in bookList.GetCollectionBooks())
            {
                if (!newBookCol.HasBook(book))
                {
                    newBookCol.AddBook(book.Clone());
                }
            }

            //aplicamos el descuento a un grupo de libros distintos
            ApplyDiscount(newBookCol, _colDiscountRules);

            //sumamos los precios de los libros con los descuentos
            price = price.AddPriceBook(newBookCol.SumPrize());

            //eliminamos los libros que ya hemos procesado
            var colRemovedProcesed = bookList.RemoveCollection(newBookCol);

            //recursividad con libros que faltan por procesar y el precio acumulado
            return PrizeSomeBooks(colRemovedProcesed, price);
        }

        private void ApplyDiscount(CollectionBooks bookList, CollectionDiscountRules _colDiscountRules)
        {
            var numBooksDistinct = bookList.NumBooksDistinct();

            var discount = _colDiscountRules.GetDiscountRuleByNumBooks(numBooksDistinct);
            bookList.ApplyDiscount(discount);            
        }
    }
}
