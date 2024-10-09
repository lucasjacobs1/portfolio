using LogicLayer.Repositories;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Services.UserServices;

namespace LogicLayer.Services.User
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository { get; } 

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Models.User GetCandidateUserByApplicationIdFromAppointment(int id)
        {
            return this.userRepository.GetCandidateUserByApplicationIdFromAppointment(id);
        }

        public Models.User GetRecruiterUserByApplicationIdFromAppointment(int id)
        {
            return this.userRepository.GetRecruiterUserByApplicationIdFromAppointment(id);
        }

        public List<Models.User> can() => userRepository.FindAllCandidatesByRole();

    }
}
