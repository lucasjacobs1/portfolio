using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models;

namespace LogicLayer.Services.Appointment
{
    public interface IAppointmentService
    {
        Models.GetAppointmentsResponse GetAllAppointments();
        Models.GetAppointmentsResponse GetAllAppointmentsByRecruiterId(int id);
        Models.GetAppointmentsResponse GetAllAppointmentsByDateAscending();
        Models.GetAppointmentsResponse GetAllAppointmentsByDateDecending();
        Models.GetAppointmentsResponse GetAppointmentsBySearchSubject(string subject);

        public GetSpecificAppointmentResponse GetSpecificAppointment (int appointment);
        public GetSpecificAppointmentResponse ChangeRecruiter(string email, int appointmentID);
        public bool DeleteSpecificAppointment(int appointmentID);


       public CreateAppointmentResponse GenerateCreateAppointmentLink(CreateAppointmentRequest request);
        IsAppointmentHashVaildResponse IsAppointmentHashVaild(LinkValidation linkValidation);
    }
}
 