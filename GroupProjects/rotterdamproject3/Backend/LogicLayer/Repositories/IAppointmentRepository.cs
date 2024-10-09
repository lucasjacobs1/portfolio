using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models;
using LogicLayer.Models;

namespace LogicLayer.Repositories
{
    public interface IAppointmentRepository
    {
        public Appointment GetSpecificAppointment(int appointment);

        public Appointment UpdateSpecificAppointment(Appointment specificAppointment);

        public bool DeleteSpecificAppointment(Appointment specificAppointment);
        void saveLinkHashes(AppointmentLink appointemntLink);
        AppointmentLink GetAppointmentLink(LinkValidation linkValidation);
        GetAppointmentsResponse getAppointments();
        GetAppointmentsResponse GetAppointmentsByRecruiterId(int id);
        GetAppointmentsResponse getAppointmentsFilterByDateAscending();
        GetAppointmentsResponse getAppointmentsFilterByDateDecending();
        GetAppointmentsResponse GetAppointmentsBySubjectName(string subject);
    }
}
