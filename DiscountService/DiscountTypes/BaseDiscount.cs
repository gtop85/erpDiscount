namespace DiscountServiceImplementation
{
    public abstract class BaseDiscount
    {
        public string name;
        public string type;
        public int priority;

        public BaseDiscount(string name)
        {
            this.name = name;
            type = null;
            priority = 0;
        }

        public abstract Result CalculateTotalDiscount(decimal orderAmount, BaseDiscount discount, Result result);
    }
}
