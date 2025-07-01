using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using ICommand = PaymentContext.Shared.Commands.ICommand;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }
        
        public string Email { get; set; }


        public string BarCode { get;  set; }

        public string BoletoNumber { get; set; }


        public string PaymentNumber { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public string Payer { get; set; }

        public string DocumentPayer { get; set; }

        public EDocumentType PayerDocumentType { get; set; }

        
        public string PayerEmail { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public void Validate()
        {

            AddNotifications(new Contract<CreateBoletoSubscriptionCommand>()
                .Requires()
                    .IsMinValue(3, FirstName, "O Nome deve conter pelo menos 3 caracteres.")
                    .IsMaxValue(40, FirstName, "O Nome deve conter até 40 caracteres."));

            AddNotifications(new Contract<CreateBoletoSubscriptionCommand>()
                .Requires()
                    .IsMinValue(3, LastName, "O Sobrenome deve conter pelo menos 3 caracteres."));
        }
    }
}
