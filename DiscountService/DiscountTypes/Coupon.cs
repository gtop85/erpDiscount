using System;

namespace DiscountServiceImplementation
{
    public class Coupon : BaseDiscount
    {
        public Coupon(string name) : base(name)
        {
            type = DiscountType.FixedAmount;
            priority = 3;
        }

        public override Result CalculateTotalDiscount(decimal orderAmount, BaseDiscount discount, Result result)
        {
            var couponValue = 10m; // can be retrieved from a CRM, database etc for a specific discount name or customer
            result.FinalAmount = orderAmount - couponValue;
            result.TextResultAnalysis += $"{discount.name} : -{couponValue}\u20AC";

            return result;
        }

    }
}
