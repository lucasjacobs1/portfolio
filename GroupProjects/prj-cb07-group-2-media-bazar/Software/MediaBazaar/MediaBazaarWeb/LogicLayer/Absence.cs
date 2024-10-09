using System.ComponentModel.DataAnnotations;

namespace MediaBazaarWeb.LogicLayer
{
    public class Absence
    {
        private int id;
        private int employee_id;
        private DateTime date;
        private string reason;
        public Absence()
        {
        }
        public Absence(int employee_id, DateTime date, string reason)
        {
            this.employee_id = employee_id;
            this.date = date;
            this.reason = reason;
        }
        public int Id { get { return id; } }
        public int Employee_id { get { return employee_id; } set { employee_id = value; } }
        [Required(ErrorMessage = "You need to select a date on when you will be absenced.") ]
        public DateTime Date { get { return date; } set { date = value; } }
        [Required(ErrorMessage = "Reason is required.")]
        [MinLength(10, ErrorMessage ="Minumum lenght is 10 characters.")]
        [MaxLength(200, ErrorMessage = "Maximum lenght is 200 characters.")]
        public string Reason { get { return reason; } set { reason = value; } }

    }
}
