using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class Vacancy
    {
        public Vacancy(int id, string title, string location, string meetingLocation)
        {
            Id=id;
            Title=title;
            Location=location;
            MeetingLocation=meetingLocation;
        }

        public Vacancy()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string MeetingLocation { get; set; }
    }
}
