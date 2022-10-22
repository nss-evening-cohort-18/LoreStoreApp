using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> GetPaymentMethods();
        List<PaymentMethod> GetPaymentMethod(int id);
    }
}