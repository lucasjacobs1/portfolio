using System;
using System.Collections.Generic;
using System.Text;

namespace MediaBazaar.Logic_Layer
{
    public class Scheldule
    {
        private int id;
        private int employeeId;
        private string description;
        private WorkingShifts workingShifts;

        public Scheldule(int id, int name, string description, WorkingShifts workingShifts)
        {
            this.id = id;
            this.EmployeeId = name;
            this.description = description;
            this.workingShifts = workingShifts;
        }

        public int Id { get { return id; } set { this.id = value; } }
        public int EmployeeId { get { return EmployeeId; } set { this.EmployeeId = value; } }
        public WorkingShifts WorkingShifts { get { return workingShifts; } set { workingShifts = value; } }
        public string Description { get { return description; } set { description = value; } }



    }
}
