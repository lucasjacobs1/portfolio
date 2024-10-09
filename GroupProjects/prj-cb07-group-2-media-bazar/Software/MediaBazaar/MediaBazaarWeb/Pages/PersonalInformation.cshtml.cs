using AspNetCoreHero.ToastNotification.Abstractions;
using Group_Project_Website;
using MediaBazaarWeb.DataLayer;
using MediaBazaarWeb.LogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MediaBazaarWeb.Pages
{
    [Authorize]
    public class PersonalInformationModel : PageModel
    {
        [BindProperty]
        public Employee employee { get; set; }
        public Employee UpdatedEmployee { get; set; }
        [BindProperty]
        public ContactPerson ContactPerson { get; set; }

        private readonly INotyfService Notyf;

        public PersonalInformationModel(INotyfService notyfService)
        {
            this.Notyf = notyfService;
        }
        public IActionResult OnGet()
        {
            EmployeeManagement employeeManagement = new EmployeeManagement();
            employee = employeeManagement.GetEmployeeByEmail(User.Identity.Name);
            ContactPersonManagement contactPersonManagement = new ContactPersonManagement();
            this.ContactPerson = contactPersonManagement.GetContactPersonByEmployeeId(employee.ID);
            PersonalInformationManagement personalInformationManagement = new PersonalInformationManagement();
            if(personalInformationManagement.GetUpdatedInformationById(employee.ID) != null)
            {
                string PotentialUpdate = "Pending change: ";
                this.UpdatedEmployee = personalInformationManagement.GetUpdatedInformationById(employee.ID);
                if(UpdatedEmployee.Email != employee.Email){ViewData["Email"] = PotentialUpdate + UpdatedEmployee.Email;}
                if(UpdatedEmployee.Street != employee.Street){ViewData["Street"] = PotentialUpdate + UpdatedEmployee.Street;}
                if(UpdatedEmployee.HouseNumber != employee.HouseNumber){ViewData["HouseNumber"] = PotentialUpdate + UpdatedEmployee.HouseNumber;}
                if(UpdatedEmployee.City != employee.City){ViewData["City"] = PotentialUpdate + UpdatedEmployee.City;}
                if(UpdatedEmployee.PostalCode != employee.PostalCode){ViewData["PostalCode"] = PotentialUpdate + UpdatedEmployee.PostalCode;}
                if(UpdatedEmployee.Phonenumber != employee.Phonenumber){ViewData["PhoneNumber"] = PotentialUpdate + UpdatedEmployee.Phonenumber;}
                return Page();
            }
            return Page();
        }

        public IActionResult OnPostUpdate()
        {
            PersonalInformationLogic personalInformationLogic = new PersonalInformationLogic();
            if (personalInformationLogic.CheckValidationUpdate(employee.FirstName, employee.LastName, employee.Email, employee.Street, employee.City, employee.HouseNumber, employee.PostalCode, employee.Phonenumber))
            {
                PersonalInformationManagement personalInformationManagement = new PersonalInformationManagement();
                if (personalInformationManagement.CheckRequestUpdateExist(employee.ID))
                {
                    if (personalInformationManagement.UpdateRequestUpdateInformationEmp(employee))
                    {
                        if (personalInformationLogic.checkUpdatedValidation(employee.ID, employee.Email, User.Identity.Name))
                        {
                            this.Notyf.Information("Deleted changes because everything is the same", 6);
                            return RedirectToPage("PersonalInformation");

                        }
                        else
                        {
                            this.Notyf.Information("Updated your changes with succes");
                            return RedirectToPage("PersonalInformation");
                        }
                    }
                    else
                    {
                        return RedirectToPage("PersonalInformation");
                    }
                }
                else
                {
                    if(personalInformationLogic.CheckSameData(User.Identity.Name, employee.FirstName, employee.LastName, employee.Email, employee.Street, employee.City, employee.HouseNumber, employee.PostalCode, employee.Phonenumber))
                    {
                        this.Notyf.Information("You did not make any changes, update not possible");
                        return RedirectToPage("PersonalInformation");
                    }
                    else
                    {
                        if (personalInformationManagement.AddRequestUpdateInformationEmp(employee))
                        {
                            this.Notyf.Success("Succesfully send the changes", 5);
                            return RedirectToPage("PersonalInformation");
                        }
                        else
                        {
                            return RedirectToPage("PersonalInformation");
                        }
                    }
                   
                }
            }
            else
            {
                return RedirectToPage("PersonalInformation");
            }
        }

        public IActionResult OnPostContactUpdate()
        {
            PersonalInformationLogic personalInformationLogic = new PersonalInformationLogic();
            PersonalInformationManagement personalInformationManagement = new PersonalInformationManagement();
            if (personalInformationLogic.CheckValContactPerson(ContactPerson))
            {
                this.Notyf.Success("Updated with succes");
                personalInformationManagement.UpdateContactPerson(ContactPerson);
            }
            else
            {
                this.Notyf.Warning("Wrong input");
            }
            return RedirectToPage("PersonalInformation");

        }
    }
}
