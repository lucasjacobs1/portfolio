using LogicLayer.Repositories;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services.ApplicationServices
{
    public class ApplicationService :IApplicationService
    {
        private readonly IApplicationRepository applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public void InsertApplication(Models.Application application)
        {
            applicationRepository.InsertApplication(application);
        }

        public List<Application> GetApplicationsByVacancy(int vacancy) => applicationRepository.GetApplicationssByVacancy(vacancy);
    }

}
