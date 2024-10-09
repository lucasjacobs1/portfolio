
namespace LogicLayer
{
    public class User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private int role;

        #region Properties
        public int Id { get { return this.id; } }
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
        public int Role { get { return this.role; } set { this.role = value; } }

        #endregion

        public User() { }
        public User(string firstName, string lastName, string email, string password, int role)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.role = role;
        }

        public User(int id, string firstName, string lastName, string email, string password, int role)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.role = role;
        }
    }
}
