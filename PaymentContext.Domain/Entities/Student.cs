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
        }

        public Name Name { get; set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {

            foreach (var sub in Subscriptions)
            {
                sub.Inactivate();
            }

            _subscription.Add(subscription);
        }
    }
}