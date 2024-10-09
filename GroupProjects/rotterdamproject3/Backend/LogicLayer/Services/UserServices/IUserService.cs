using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services.UserServices
{
    public interface IUserService
    {
        Models.User GetCandidateUserByApplicationIdFromAppointment(int id);
        Models.User GetRecruiterUserByApplicationIdFromAppointment(int id);
        public List<Models.User> can();
    }
}
