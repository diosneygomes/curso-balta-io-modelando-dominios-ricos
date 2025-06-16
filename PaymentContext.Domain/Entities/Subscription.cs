using PaymentContext.Domain.ValuesObjects.Contracts;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription: Entity
    {
        private List<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.UtcNow;
            LastUpdateDate = DateTime.UtcNow;
            ExpireDate = expireDate;
            Active = true;

            _payments = [];
        }

        public DateTime CreateDate { get; private set; }

        public DateTime LastUpdateDate { get; private set; }

        public DateTime? ExpireDate { get; private set; }

        public bool Active { get; private set; }

        public IReadOnlyCollection<Payment> Payments { get; private set; }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new CreatePaymentContract(payment));

            _payments.Add(payment);
        }

        public void Activate(){
            Active = true;
            LastUpdateDate = DateTime.UtcNow;
        }

        public void Inactivate(){
            Active = false;
            LastUpdateDate = DateTime.UtcNow;
        }        
    }
}