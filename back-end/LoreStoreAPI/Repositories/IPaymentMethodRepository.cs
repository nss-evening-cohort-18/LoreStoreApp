using LoreStoreAPI.Models;

namespace LoreStoreAPI.Repositories
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> GetPaymentMethods();
        List<PaymentMethod> GetPaymentMethod(int id);
        PaymentMethod GetPaymentMethodByUserId(int id);
        void AddPaymentMethod(PaymentMethod paymentMethod);
        int UpdatePaymentMethod(int id, PaymentMethod paymentMethod);
        int DeletePaymentMethod(int paymentMethodId);
    }
}