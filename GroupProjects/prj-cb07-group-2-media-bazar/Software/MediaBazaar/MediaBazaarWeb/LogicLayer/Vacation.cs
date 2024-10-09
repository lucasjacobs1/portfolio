using System.ComponentModel.DataAnnotations;

namespace MediaBazaarWeb.LogicLayer
{
    public class Vacation
    {
        private int id;
        private int employee_id;
        private DateTime start_date;
        private DateTime end_date;
        private string reason;
        private int pending;

        public Vacation()
        {

        }
        public Vacation(int id, int employee_id, DateTime start, DateTime end, string reason)
        {
            this.id = id;
            this.employee_id = employee_id;
            this.start_date = start;
            this.end_date = end;
            this.reason = reason;
        }
        public Vacation(int employee_id, DateTime start, DateTime end, string reason)
        {
            this.employee_id=employee_id;
            this.start_date=start;
            this.end_date=end;
            this.reason=reason;
        }

        #region
        public int Id { get { return id; } }
        public int EmployeeId { get { return employee_id; } set { this.employee_id = value; } }
        [Required]
        public DateTime StartDate { get { return start_date; } set { start_date = value; } }
        [Required]
        public DateTime EndDate { get { return end_date; } set { end_date = value;} }
        [Required]
        [MaxLength(200, ErrorMessage ="Maximum characters is 200")]
        [MinLength(8, ErrorMessage ="MinLenght is 10 characters")]
        public string Reason { get { return reason; } set { reason = value; } }
        public int Pending { get { return pending; } set { pending = value; } }

        #endregion
    }
}
