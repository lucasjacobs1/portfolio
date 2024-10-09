using Group_Project_Website;
using Group_Project_Website.Logic;
using MediaBazaarWeb.DataLayer;

namespace MediaBazaarWeb.LogicLayer
{
    public class PersonalInformationLogic
    {
        public bool CheckValidationUpdate(string firstname, string lastname, string email, string street, string city, string housenumber, string postalcode, int phonenumber)
        {
            if(firstname != null && firstname.Length >= 2 && lastname != null && lastname.Length >= 2)
            {
                UserHelper userHelper = new UserHelper();
                if (userHelper.IsValidEmail(email))
                {
                    if(street != string.Empty && city != string.Empty && housenumber != string.Empty && postalcode != string.Empty)
                    {
                        if(phonenumber > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckSameData(string currentmail, string firstname, string lastname, string email, string street, string city, string housenumber, string postalcode, int phonenumber)
        {
            EmployeeManagement employeeManagement  = new EmployeeManagement();
            Employee e = employeeManagement.GetEmployeeByEmail(currentmail);
            if(firstname == e.FirstName && lastname == e.LastName && email == e.Email && street == e.Street && city == e.City && housenumber == e.HouseNumber && postalcode == e.PostalCode && phonenumber == e.Phonenumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckValContactPerson(ContactPerson contactPerson)
        {
            UserHelper userHelper = new UserHelper();
            if (userHelper.IsValidEmail(contactPerson.Email))
            {
                if(contactPerson.Name.Length >= 2)
                {
                    if(contactPerson.Phone > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        

        /*public void UpdateEmployee(string name, string email, string address, int phonenumber)
        {
            PersonalInformationManagement personalInformation = new PersonalInformationManagement();
            personalInformation.UpdateAccountInformation(email, address, phonenumber);
        }*/

        public bool checkUpdatedValidation(int id, string email, string currentEmail)
        {
            PersonalInformationManagement personalInformationManagement = new PersonalInformationManagement();
            Employee updatedVariant = personalInformationManagement.GetPotentialUpdateInformationEmpByID(id);
            EmployeeManagement employeeManagement = new EmployeeManagement();
            Employee e = employeeManagement.GetEmployeeByEmail(currentEmail);
            if(e.Phonenumber == updatedVariant.Phonenumber && e.Email == updatedVariant.Email && e.HouseNumber == updatedVariant.HouseNumber && e.City == updatedVariant.City && e.PostalCode == updatedVariant.PostalCode && e.Street == updatedVariant.Street)
            {
                personalInformationManagement.DeleteRequestUpdateInformationEmp(id);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
