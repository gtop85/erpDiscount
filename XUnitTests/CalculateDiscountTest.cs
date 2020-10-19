using DiscountServiceImplementation;
using Xunit;

namespace XUnitTests
{
    public class CalculateDiscountTest
    {
        [Fact]
        public void CalculateDiscountTestForCustomer()
        {
            var rootDiscount = new CompositeDiscount("Discounts 2020");
            var priceList = new PriceList("Pricelist 2020");
            var promotion = new Promotion("Promotion 2020");
            var coupon = new Coupon("Coupon 2020");

            rootDiscount.Add(coupon);
            rootDiscount.Add(priceList);
            rootDiscount.Add(promotion);

            var result = rootDiscount.CalculateTotalDiscount(340m, rootDiscount, new Result());
            Assert.True(result.FinalAmount == 280.70m);
            Assert.NotNull(result.TextResultAnalysis);
        }
    }
}
