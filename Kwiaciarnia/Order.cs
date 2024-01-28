namespace Kwiaciarnia
{
    internal class Order
    {
        public int orderId { get; set; }

        private int flowerId, quantity;
        private string firstName, lastName, address, date, phone;

        public int FlowerId { get { return flowerId; } set { flowerId = value; } }

        public int Quantity { get { return quantity; } set { quantity = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Date { get { return date; } set { date = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }

        public Order() { }

        public Order(int flowerId, int quantity, string address, string date, string phone, string firstName, string lastName)
        {
            this.flowerId = flowerId;
            this.quantity = quantity;
            this.address = address;
            this.date = date;
            this.phone = phone;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
