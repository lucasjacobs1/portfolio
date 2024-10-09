using DataAccessLayer.Repositories;
using LogicLayer.Models;
using LogicLayer.Repositories;
using LogicLayer.Services.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers
{
    [Route("/SingleVacancy")]
    [ApiController]
    public class SingleVacancyController
    {
        private IApplicationService _applicationService { get; }

        public SingleVacancyController()
        {
            IApplicationRepository applicationRepository = new ApplicationRepository();
            this._applicationService = new ApplicationService(applicationRepository);
        }

        [HttpGet]
        public ActionResult<List<Application>> GetCandidatesForSingleVacancy(int vacancyId)
        {
            return this._applicationService.GetApplicationsByVacancy(vacancyId);
        }
    }
}
