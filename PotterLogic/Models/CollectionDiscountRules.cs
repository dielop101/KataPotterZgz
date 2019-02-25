using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterLogic.Models
{
    public class CollectionDiscountRules
    {
        private List<DiscountRules> _collectionDiscountRules = new List<DiscountRules>();

        //todo: comprobar que no se mete 2 veces un discount con el mismo numberOfBooks
        public void AddDiscountRules(DiscountRules discount)
        {
            if (_collectionDiscountRules == null)
                _collectionDiscountRules = new List<DiscountRules>();

            if (discount != null)
                _collectionDiscountRules.Add(discount);
        }

        public DiscountRules GetDiscountRuleByNumBooks(int numBooks)
        {
            return _collectionDiscountRules.Where(disc => disc.GetNumOfBooks() == numBooks).FirstOrDefault();
        }
    }
}
