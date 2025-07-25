using PaymentContext.Domain.ValuesObjects.Contracts;
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

            AddNotifications(new CreateNameContract(this));

        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString() {

            return $"{FirstName} {LastName}";
        }
    }
}