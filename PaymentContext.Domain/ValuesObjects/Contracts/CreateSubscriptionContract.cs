using Flunt.Validations;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.ValuesObjects.Contracts
{
    public class CreateSubscriptionContract : Contract<Subscription>
    {
        public CreateSubscriptionContract(Subscription subscription)
        {
            Requires()
                .IsFalse(subscription.Active, "Student.Subscriptions", "Você já tem uma assinatura ativa.")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscriptions.Payments", "Esta assinatura não possui pagamentos.");
        }
    }
}
