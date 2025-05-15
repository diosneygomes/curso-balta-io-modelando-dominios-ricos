using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValuesObjects
{
    public class Name : ValueObject
    {
        public Name(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if(string.IsNullOrWhiteSpace(FirstName))
                AddNotification("","Nome inválido.");

        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}