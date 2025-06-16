using PaymentContext.Shared.ValueObjects;
using PaymentContext.Shared.ValueObjects.Contracts;

namespace PaymentContext.Domain.ValuesObjects {
    public class Email : ValueObject {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new CreateEmailContract(this));
        }
                
        public string Address { get; private set; }
    }
}