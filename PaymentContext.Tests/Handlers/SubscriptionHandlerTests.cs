using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValuesObjects;
using PaymentContext.Tests.Mocks;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PaymentContext.Tests.Handlers
{
    public class SubscriptionHandlerTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public SubscriptionHandlerTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("28103508098", EDocumentType.CPF);
            _email = new Email("batman@cd.com");
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }


        [Fact]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Email = "hello@balta.io2";
            command.BarCode = "123456789";
            command.BoletoNumber = "234235654";
            command.PaymentNumber = "234234";
            command.PaidDate = DateTime.UtcNow;
            command.ExpireDate = DateTime.UtcNow.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "WAYNE CORP";
            command.DocumentPayer = "123456789";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";
            command.Street = "asdf";
            command.Number = "asdffgf";
            command.Neighborhood = "fghdfghd";
            command.City = "wersdfsd";
            command.State = "dfgsdf";
            command.Country = "hghg";
            command.ZipCode = "098789676";

            handler.Handle(command);

            Assert.False(handler.IsValid);
        }
    }
}
