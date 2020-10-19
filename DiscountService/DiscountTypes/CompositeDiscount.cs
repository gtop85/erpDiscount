using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountServiceImplementation
{
    public class CompositeDiscount : BaseDiscount, IDiscountOperations
    {
        private List<BaseDiscount> _discounts;

        public CompositeDiscount(string name) : base(name)
        {
            _discounts = new List<BaseDiscount>();
        }

        public void Add(BaseDiscount discount)
        {
            _discounts.Add(discount);
        }

        public void Remove(BaseDiscount discount)
        {
            _discounts.Remove(discount);
        }


        public override Result CalculateTotalDiscount(decimal orderAmount, BaseDiscount discount, Result result)
        {
            if (orderAmount <= 0) throw new Exception("Invalid amount");

            _discounts = _discounts.OrderBy(x => x.priority).ToList();

            foreach (var disc in _discounts)
            {
                result = disc.CalculateTotalDiscount(orderAmount, disc, result);
                result.FinalAmount = decimal.Round(result.FinalAmount, 2, MidpointRounding.AwayFromZero);
                orderAmount = result.FinalAmount;
            }
            return result;
        }
    }
}
