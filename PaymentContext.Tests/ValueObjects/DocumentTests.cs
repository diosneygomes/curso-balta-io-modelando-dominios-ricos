using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValuesObjects;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTests
    {

        [Fact]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("999", EDocumentType.CNPJ);
            Assert.False(document.Validate());
        }

        [Fact]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("95240579000176", EDocumentType.CNPJ);
            Assert.True(document.Validate());
        }

        [Fact]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("999", EDocumentType.CPF);
            Assert.False(document.Validate());
        }

        [Fact]
        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            var document = new Document("46296925093", EDocumentType.CPF);
            Assert.True(document.Validate());
        }        
    }

}