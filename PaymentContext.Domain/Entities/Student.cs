using PaymentContext.Domain.ValuesObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{

    public class Student : Entity
    {
        private List<Subscription> _subscription { get; set; }

        public Student(
            Name name,
            Document document,
            Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            _subscription = [];

            AddNotifications(name, document, email);
        }

        public Name Name { get; set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;

            foreach (var sub in _subscription)
            {
                if(sub.Active)
                   hasSubscriptionActive = true;
            }

            if (hasSubscriptionActive)
                AddNotification("Student.Subscriptions","Você já tem uma assinatura ativa.");

        }
    }
}