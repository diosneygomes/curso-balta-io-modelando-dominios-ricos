using Flunt.Validations;


namespace PaymentContext.Domain.ValuesObjects.Contracts
{
    public class CreateAddressContract : Contract<Address>
    {
        public CreateAddressContract(Address address)
        {
            Requires()
                .IsMinValue(3, address.Street, "A rua deve conter pelo menos 3 caracteres.");
        }
    }
}
