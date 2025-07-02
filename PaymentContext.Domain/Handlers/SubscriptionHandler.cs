using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValuesObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : 
        Notifiable<Notification>,
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;
        public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();

            if (command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            if (_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            if (_studentRepository.EmailExists(command.Email))
                AddNotification("Email", "Este Email já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.UtcNow.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.Payer, command.PayerDocumentType), email, address);


            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            _emailService.Send(name.ToString(), student.Email.Address, "Bem vindo ao balta.io", "Sua assinatura foi criada.");

            return new CommandResult(true, "Assinatura realizada com suceso.");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            command.Validate();

            if (command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            if (_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            if (_studentRepository.EmailExists(command.Email))
                AddNotification("Email", "Este Email já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.UtcNow.AddMonths(1));
            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.Payer, command.PayerDocumentType), email, address);


            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            if(!IsValid)
                return new CommandResult(false, "Não foi possível realizar a sua assinatura.");


            _emailService.Send(name.ToString(), student.Email.Address, "Bem vindo ao balta.io", "Sua assinatura foi criada.");

            return new CommandResult(true, "Assinatura realizada com suceso.");
        }
    }
}
