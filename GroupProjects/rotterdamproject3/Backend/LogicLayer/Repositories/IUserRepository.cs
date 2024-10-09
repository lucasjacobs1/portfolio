using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Models;
namespace LogicLayer.Repositories
{
    public interface IUserRepository
    {
        public List<User> FindAllCandidatesByRole();
        public User GetSpecificRecruiter(int recruiter);
        public User GetSpecificCandidate(int candidate);
        public User GetSpecificRecruiterByEmail(string email);
        User GetCandidateUserByApplicationIdFromAppointment(int id);
        User GetRecruiterUserByApplicationIdFromAppointment(int id);

    }
}
