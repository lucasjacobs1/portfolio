using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class NotificationModel
    {
        public NotificationModel() { }
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

    }
}
