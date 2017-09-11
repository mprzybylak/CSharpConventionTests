using System;
namespace minefield.ECommerce
{
    public struct Customer
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Customer(string firstName, string lastName) {
            LastName = lastName;
            FirstName = firstName;
        }
    }
}
