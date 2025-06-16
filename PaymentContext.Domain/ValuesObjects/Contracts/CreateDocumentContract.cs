using Flunt.Validations;

namespace PaymentContext.Domain.ValuesObjects.Contracts
{
    public class CreateDocumentContract : Contract<Document>
    {
        public CreateDocumentContract(Document document)
        {
            Requires()
                .IsTrue(document.Validate(), "Document.Number", "Documento inválido.");  
        }
    }
}
