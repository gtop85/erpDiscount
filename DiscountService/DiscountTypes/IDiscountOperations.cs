using System;

namespace DiscountServiceImplementation
{
    public interface IDiscountOperations
    {
        void Add(BaseDiscount discount);
        void Remove(BaseDiscount discount);
    }
}
