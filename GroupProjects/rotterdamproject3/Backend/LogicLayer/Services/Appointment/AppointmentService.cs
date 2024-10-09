using LogicLayer.Models;
using LogicLayer.Models.Enums;
using LogicLayer.Repositories;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models;
using LogicLayer.Repositories;
using LogicLayer.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Web.Http;

namespace LogicLayer.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {

        private IAppointmentRepository appointmentRepsoitory { get; }
        private IUserRepository userRepository { get; }
        private IApplicationRepository applicationRepository { get; }


        public AppointmentService(IAppointmentRepository appointmentRepsoitory, IUserRepository userRepository, IApplicationRepository applicationRepository)
        {
            this.appointmentRepsoitory = appointmentRepsoitory;
            this.userRepository = userRepository;
            this.applicationRepository = applicationRepository;
        }

        public CreateAppointmentResponse GenerateCreateAppointmentLink(CreateAppointmentRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.Username))
            {
                //ToDO:change the exception
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else if (String.IsNullOrWhiteSpace(request.Identifier))
            {
                //ToDO:change the exception
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            byte[] usernameHashed = ASCIIEncoding.ASCII.GetBytes(request.Username);
            byte[] identifierHashed = ASCIIEncoding.ASCII.GetBytes(request.Identifier);

            AppointmentLink newAppointmentLink = new AppointmentLink(byteArrayToString(usernameHashed), byteArrayToString(identifierHashed), LinkStatus.Created);

            appointmentRepsoitory.saveLinkHashes(newAppointmentLink);

            CreateAppointmentResponse createAppointmentResponse = new CreateAppointmentResponse(newAppointmentLink.link, newAppointmentLink.LinkStatus.ToString());

            return createAppointmentResponse;

            string byteArrayToString(byte[] arrInput)
            {
                int i;
                StringBuilder sOutput = new StringBuilder(arrInput.Length);
                for (i = 0; i < arrInput.Length; i++)
                {
                    sOutput.Append(arrInput[i].ToString("X2"));
                }
                return sOutput.ToString();
            }

        }

        public IsAppointmentHashVaildResponse IsAppointmentHashVaild(LinkValidation linkValidation)
        {
            AppointmentLink? appointmentLink = appointmentRepsoitory.GetAppointmentLink(linkValidation);

            if (appointmentLink == null)
            {
                return new IsAppointmentHashVaildResponse("Doesn't exist");
            }

            return new IsAppointmentHashVaildResponse(appointmentLink.LinkStatus.ToString());
        }
       

        public GetSpecificAppointmentResponse GetSpecificAppointment(int appointment)
        {
            GetSpecificAppointmentResponse response = new GetSpecificAppointmentResponse();
            Models.Appointment appointmentDetails = appointmentRepsoitory.GetSpecificAppointment(Convert.ToInt32(appointment));
            Models.User recruiterDetails = userRepository.GetSpecificRecruiter(appointmentDetails.RecruiterId);
            Models.Application application = applicationRepository.GetSpecificApplication(appointmentDetails.ApplicationId);
            response.Id = appointmentDetails.Id;
            response.RecruiterFirstName = recruiterDetails.FirstName;
            response.RecruiterLastName = recruiterDetails.LastName;
            response.CandidateFirstName = application.Candidate.FirstName;
            response.CandidateLastName = application.Candidate.LastName;
            response.StartDate = appointmentDetails.StartDate;
            response.EndDate = appointmentDetails.EndDate;
            response.Subject = appointmentDetails.Subject;
            response.Location = appointmentDetails.Location;
            return response;
        }

        public GetSpecificAppointmentResponse ChangeRecruiter(string email, int appointmentID)
        {
            GetSpecificAppointmentResponse response = new GetSpecificAppointmentResponse();
            Models.Appointment appointmentDetails = appointmentRepsoitory.GetSpecificAppointment(appointmentID);
            Models.User substitudeRecruiter = userRepository.GetSpecificRecruiterByEmail(email);
            Models.Application application = applicationRepository.GetSpecificApplication(appointmentDetails.ApplicationId);

            appointmentDetails.RecruiterId = substitudeRecruiter.Id;

            appointmentDetails = appointmentRepsoitory.UpdateSpecificAppointment(appointmentDetails);

            response.Id = appointmentDetails.Id;
           // if(appointmentDetails.RecruiterId == substitudeRecruiter.Id)
          //{ 
                response.RecruiterFirstName = substitudeRecruiter.FirstName;
                response.RecruiterLastName = substitudeRecruiter.LastName;
          //}
            response.CandidateFirstName = application.Candidate.FirstName;
            response.CandidateLastName = application.Candidate.LastName;
            response.StartDate = appointmentDetails.StartDate;
            response.EndDate = appointmentDetails.EndDate;
            response.Subject = appointmentDetails.Subject;
            response.Location = appointmentDetails.Location;
            return response;
        }

        public bool DeleteSpecificAppointment(int appointmentID)
        {
            Models.Appointment appointmentDetails = appointmentRepsoitory.GetSpecificAppointment(appointmentID);
            bool result = appointmentRepsoitory.DeleteSpecificAppointment(appointmentDetails);
            return result;
        }

        public GetAppointmentsResponse GetAllAppointments()
        {
            return this.appointmentRepsoitory.getAppointments();
        }

        public GetAppointmentsResponse GetAllAppointmentsByRecruiterId(int id)
        {
            return this.appointmentRepsoitory.GetAppointmentsByRecruiterId(id);
        }

        public GetAppointmentsResponse GetAllAppointmentsByDateAscending()
        {
            return this.appointmentRepsoitory.getAppointmentsFilterByDateAscending();
        }

        public GetAppointmentsResponse GetAllAppointmentsByDateDecending()
        {
            return this.appointmentRepsoitory.getAppointmentsFilterByDateDecending();
        }

        public GetAppointmentsResponse GetAppointmentsBySearchSubject(string subject) 
        {
            return this.appointmentRepsoitory.GetAppointmentsBySubjectName(subject);
        }


    }
}
