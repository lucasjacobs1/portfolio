
using System;
using System.Collections.Generic;
using System.Text;
using MediaBazaar.Logic_Layer;

namespace MediaBazaar
{
    public class Administration
    {
        EmployeeManagement management = new EmployeeManagement();
        List<Employee> employees = new List<Employee>();
        List<Complaint> complaints = new List<Complaint>();
        public int id;

        public Administration()
        { }

       

        public void removeEmployee(int id)
        {
            management.DeleteEmployee(id);
            foreach (Employee employee in employees)
            {
                if (employee.ID == id)
                {
                    employees.Remove(employee);
                }
            }
        }

        public Employee getEmployee(int id)
        {
            foreach (Employee employee in employees)
            {
                if (employee.ID == id)
                {
                    return employee;
                }
            }
            return null;
        }

        //public void editEmployee(string email, string address, double salary, int phonenumber, int role)
        //{
        //    foreach (Employee employee in employees)
        //    {
        //        if (employee.ID == id)
        //        {
        //            employee.Email = email;
        //            employee.Role = role;
        //            employee.Salary = salary;
        //            employee.Address = address;
        //            employee.Bsn = BSN;
        //            employee.Phonenumber = phonenumber;
        //            employee.Role = role;

        //        }
        //    }
        //}
       

      


    }
}
