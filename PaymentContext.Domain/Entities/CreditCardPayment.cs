namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            string cardHoldername,
            string cardNumber,
            string lastTransactionNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            string document,
            string email,
            string address) : base(
                paidDate,
                expireDate,
                total,
                totalPaid,
                payer,
                document,
                email,
                address)            
        {
            CardHoldername = cardHoldername;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHoldername { get; private set; }

        public string CardNumber { get; private set; }

        public string LastTransactionNumber { get; private set; }
    }
}