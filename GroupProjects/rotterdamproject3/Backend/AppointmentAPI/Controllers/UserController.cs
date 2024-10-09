using DataAccessLayer.Repositories;
using LogicLayer.Models;
using LogicLayer.Repositories;
using LogicLayer.Services.UserServices;
using LogicLayer.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
         private IUserService userService { get; }

         public UserController()
         {
             IUserRepository userRepository = new UserRepository();
             this.userService = new UserService(userRepository);

         }

         [HttpGet]
         [Route("/recruiter/{id:int}")]
         public ActionResult<User> GetRecruiterUserByApplicationIdFromAppointment(int id)
         {
             return userService.GetRecruiterUserByApplicationIdFromAppointment(id);
         }

         [HttpGet]
         [Route("/candidate/{id:int}")]
         public ActionResult<User> GetCandidateUserByApplicationIdFromAppointment(int id)
         {
             return userService.GetCandidateUserByApplicationIdFromAppointment(id);
         }
     
        [HttpGet]
        public ActionResult<List<User>> FindCandidatesByRole()
        {
            return userService.can();
        }
    }
}
