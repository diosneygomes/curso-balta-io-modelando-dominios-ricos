using Flunt.Validations;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.ValuesObjects.Contracts
{
    public class CreatePaymentContract : Contract<Payment>
    {
        public CreatePaymentContract(Payment payment)
        {
            Requires()
                .IsGreaterThan(DateTime.UtcNow, payment.PaidDate, "Payment", "A data do pagamento deve ser futura.")
                .IsGreaterThan(0, payment.Total, "Payment.Total", "O Total não pode ser zero.")
                .IsGreaterOrEqualsThan(payment.Total, payment.TotalPaid, "Payment.Paid", "O valor pago é menor que o valor do pagamento.");
        }
    }
}
