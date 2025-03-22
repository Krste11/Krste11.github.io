namespace _13.Modals
{
    public class CreditCard
    {
        public CreditCard(string firstName, string lastName, string number, string pin, double balance)
        {
            FirstName = firstName;
            LastName = lastName;
            CreditCardNumber = number;
            CreditCardPin = pin;
            Balance = balance;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardPin { get; private set; }
        public double Balance { get; private set; }
    }
}
