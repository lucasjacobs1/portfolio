using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MediaBazaar
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private string email;
        private string street;
        private string city;
        private string postalCode;
        private string houseNumber;
        private string password;
        private int id;
        private int role;
        private double salary;
        private int bsn;
        private int phonenumber;
        private double fte;
        #region Properties
        public int ID { get { return id; } set { id = value; } }
        public int Role { get { return role; } set { role = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string PassWord { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Street { get { return street; } set { street = value; } }
        public string City { get { return city; } set { city = value; } }
        public string PostalCode { get { return postalCode; } set { postalCode = value; } }
        public string HouseNumber { get { return houseNumber; } set { houseNumber = value; } }
        public int Bsn { get { return bsn; } set { bsn = value; } }
        public int Phonenumber { get { return phonenumber; } set { phonenumber = value; } }
        public double Salary { get { return salary; } set { salary = value; } }
        public double FTE { get { return fte; } set { fte = value; } }

        #endregion

        public Employee(string email, double salary, int phonenumber, int role)
        {
            this.role = role;
            this.salary = salary;
            this.phonenumber = phonenumber;
            this.email = email;

        }
        public Employee() { }
        public Employee(string firstName, string lastname, string street, string city, string postalcode, string housenumber, string email, double salary, int bSN, int phonenumber, int role)
        {
            this.firstName = firstName;
            this.lastName = lastname;
            this.street = street;
            this.city = city;
            this.postalCode = postalcode;
            this.houseNumber = housenumber;
            this.email = email;
            this.salary = salary;
            bsn = bSN;
            this.phonenumber = phonenumber;
            this.role = role;
        }
        public Employee(int id, string firstName, string lastname, string street, string city, string postalcode, string housenumber, string email, double salary, int bSN, int phonenumber, int role)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastname;
            this.street = street;
            this.city = city;
            this.postalCode = postalcode;
            this.houseNumber = housenumber;
            this.email = email;
            this.salary = salary;
            this.bsn = bSN;
            this.phonenumber = phonenumber;
            this.role = role;
        }

        public Employee(int id, string firstName, string lastname, string street, string city, string postalcode, string housenumber, string email, double salary, int bSN, int phonenumber, int role, double fte)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastname;
            this.street = street;
            this.city = city;
            this.postalCode = postalcode;
            this.houseNumber = housenumber;
            this.email = email;
            this.salary = salary;
            this.bsn = bSN;
            this.phonenumber = phonenumber;
            this.role = role;
            this.fte = fte;
        }

        public Employee(int id, string email, string street, string city, string postalcode, string housenumber, int phonenumber)
        {
            this.id = id;
            this.email = email;
            this.street = street;
            this.city = city;
            this.postalCode = postalcode;
            this.houseNumber = housenumber;
            this.phonenumber = phonenumber;
        }
        public string GetRole()
        {
            var enumDisplayStatus = (RolesEnumeration)Role;
            string stringRole = enumDisplayStatus.ToString();
            return stringRole;
        }
        public enum RolesEnumeration
        {
            Administrator = 0,
            Manager = 1,
            [Description("HR Manager")]
            HRManager = 2,
            [Description("Store Employee")]
            StoreEmployee = 3,
            [Description("Depot Worker")]
            DepotWorker = 4
        }
    }
}


