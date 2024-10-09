using DataAccessLayer.Repositories;
using LogicLayer.Models;
using LogicLayer.Repositories;
using LogicLayer.Services.Appointment;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Net;

namespace AppointmentAPI.Controllers
{   
    [ApiController]
    [Route("/appointments")]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService appointmentService { get; }

      
        public AppointmentController()
        {
            IAppointmentRepository appointmentRepository = new AppointmentRepository();
            IUserRepository userRepository = new UserRepository();
            IApplicationRepository applicationRepository = new ApplicationRepository();
            this.appointmentService = new AppointmentService(appointmentRepository, userRepository, applicationRepository);
        }


        [HttpPost]
        [Route("/createLink")]
        public ActionResult<CreateAppointmentResponse> CreateNewAppointmentLink([System.Web.Http.FromUri] CreateAppointmentRequest request)
        {
            return appointmentService.GenerateCreateAppointmentLink(request);
       
        }

        [HttpGet]
        [Route("/verifyLink")]
        public ActionResult<IsAppointmentHashVaildResponse> IsAppointmentHashVaild(string usernameHashed,string identifierHashed)
        {
            return appointmentService.IsAppointmentHashVaild(new LinkValidation(usernameHashed,identifierHashed));

        }

        [HttpGet("{id}")]
        public ActionResult<GetSpecificAppointmentResponse> GetAppointment(int id)
        {
            return Ok(appointmentService.GetSpecificAppointment(id));
        }

        [HttpPut]
        public ActionResult<GetSpecificAppointmentResponse> UpdateRecruiterOfAnAppointment(UpdateAppointmentRecruiterRequest updateAppointment) {

            GetSpecificAppointmentResponse updatedAppointment = appointmentService.ChangeRecruiter(updateAppointment.RecruiterEmail, updateAppointment.Id);
            return Ok(updatedAppointment);
        }


        //Maybe it is a good idea to change it from void to list of all appointments
        [HttpDelete("{id}")]
        public ActionResult<HttpResponseMessage> DeleteAppointment(int id)
        {
            bool result = appointmentService.DeleteSpecificAppointment(id);
            if (result == true)
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        public ActionResult<GetAppointmentsResponse> getAllAppointments()
        {
            return appointmentService.GetAllAppointments();
        }

        [HttpGet]
        [Route("/RecruiterId/{id:int}")]
        public ActionResult<GetAppointmentsResponse> getAllAppointmentsByRecruiterId(int id)
        {
            return appointmentService.GetAllAppointmentsByRecruiterId(id);
        }

        [HttpGet]
        [Route("/FilterDateAscending")]
        public ActionResult<GetAppointmentsResponse> getAllAppointmentsFilterDateAscending()
        {
            return appointmentService.GetAllAppointmentsByDateAscending();
        }

        [HttpGet]
        [Route("/FilterDateDescending")]
        public ActionResult<GetAppointmentsResponse> getAllAppointmentsFilterDateDescending()
        {
            return appointmentService.GetAllAppointmentsByDateDecending();
        }

        [HttpGet]
        [Route("/SearchBySubject/{subject}")]
        public ActionResult<GetAppointmentsResponse> GetAppointmentsBySearchSubject(string subject)
        {
            return appointmentService.GetAppointmentsBySearchSubject(subject);
        }
    }
}