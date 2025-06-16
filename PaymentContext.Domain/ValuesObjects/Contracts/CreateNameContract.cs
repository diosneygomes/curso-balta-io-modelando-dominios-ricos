using Flunt.Validations;

namespace PaymentContext.Domain.ValuesObjects.Contracts
{
    public class CreateNameContract : Contract<Name>
    {
        public CreateNameContract(Name name)
        {
            Requires()
                .IsMinValue(3, name.FirstName, "O Nome deve conter pelo menos 3 caracteres.")
                .IsMaxValue(40, name.FirstName, "O Nome deve conter até 40 caracteres.");

            Requires()
                .IsMinValue(3, name.LastName, "O Sobrenome deve conter pelo menos 3 caracteres.");
        }
    }
}
