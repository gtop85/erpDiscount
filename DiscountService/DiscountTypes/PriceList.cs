using System;

namespace DiscountServiceImplementation
{
    public class PriceList : BaseDiscount
    {
        public PriceList(string name) : base(name)
        {
            type = DiscountType.Percentage;
            priority = 1;
        }

        public override Result CalculateTotalDiscount(decimal orderAmount, BaseDiscount discount, Result result)
        {
            var priceListAmount = 0.05m; // can be retrieved from a CRM, database etc for a specific discount name or customer
            var priceListValue = orderAmount * priceListAmount;
            priceListValue = decimal.Round(priceListValue, 2, MidpointRounding.AwayFromZero);

            result.FinalAmount = orderAmount - priceListValue;
            result.TextResultAnalysis += $"{discount.name}: -{priceListValue}\u20AC ({(int)(priceListAmount * 100)}%) \n\n";

            return result;
        }
    }
}
