using System;

namespace DiscountServiceImplementation
{
    public class Promotion : BaseDiscount
    {
        public Promotion(string name) : base(name)
        {
            type = DiscountType.FixedAmount;
            priority = 2;
        }

        public override Result CalculateTotalDiscount(decimal orderAmount, BaseDiscount discount, Result result)
        {
            var promotionAmount = 0.1m; // can be retrieved from a CRM, database etc for a specific discount name or customer
            var promotionValue = orderAmount * promotionAmount;
            promotionValue = decimal.Round(promotionValue, 2, MidpointRounding.AwayFromZero);

            result.FinalAmount = orderAmount - promotionValue;
            result.TextResultAnalysis += $"{discount.name}: -{promotionValue}\u20AC ({(int)(promotionAmount * 100)}%) \n\n";
            
            return result;
        }
    }
}
