using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValuesObjects {
    public class Document : ValueObject {
        public string Number { get; private set; }
    }
}