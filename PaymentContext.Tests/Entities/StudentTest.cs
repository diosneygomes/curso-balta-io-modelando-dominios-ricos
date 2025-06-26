using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValuesObjects;

namespace PaymentContext.Tests.Entities
{
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        
        public StudentTest()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("28103508098", EDocumentType.CPF);
            _email = new Email("batman@cd.com");
            _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }


        [Fact]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678",DateTime.UtcNow, DateTime.UtcNow.AddDays(5),10, 10, "WAYNE CORP", _document, _email, _address);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.False(_student.IsValid);
        }

        [Fact]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.False(_student.IsValid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678",DateTime.UtcNow, DateTime.UtcNow.AddDays(5),10, 10, "WAYNE CORP", _document, _email, _address);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.True(_student.IsValid);
        }
    }

}