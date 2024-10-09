namespace Group_Project_Website
{
    public class ContactPerson
    {
        private int id;
        private int employeeId;
        private string name;
        private int phone;
        private string email;

        public ContactPerson()
        {

        }
        public ContactPerson(int id, int employeeId, string name, int phone, string email)
        {
            this.id = id;
            this.employeeId = employeeId;
            this.name = name;
            this.phone = phone;
            this.email = email;
        }
        #region
        public int Id { get { return id; }}
        public int EmployeeId { get { return employeeId; }}
        public string Name { get { return name; } set { this.name = value; } }
        public int Phone { get { return phone; } set { this.phone = value; } }
        public string Email { get { return email; } set { this.email = value; } }
        #endregion
    }
}
