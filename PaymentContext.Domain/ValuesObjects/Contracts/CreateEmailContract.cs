using Flunt.Validations;
using PaymentContext.Domain.ValuesObjects;

namespace PaymentContext.Shared.ValueObjects.Contracts
{
    public class CreateEmailContract : Contract<Email>
    {
        public CreateEmailContract(Email email)
        {
            Requires()
                .IsEmail(email.Address, "Email");
        }
    }
}
