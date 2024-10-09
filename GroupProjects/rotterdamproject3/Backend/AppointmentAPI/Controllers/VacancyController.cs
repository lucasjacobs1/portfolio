using DataAccessLayer.Repositories;
using LogicLayer.Models;
using LogicLayer.Repositories;
using LogicLayer.Services.Vacancy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentAPI.Controllers
{
    [Route("/vacancies")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private IVacancyService vacancyService { get; }

        public VacancyController()
        {
            IVacancyRepository vacancyRepository = new VacancyRepository();
            this.vacancyService = new VacancyService(vacancyRepository);
        }

        [HttpGet]
        public ActionResult<List<Vacancy>> GetAllVacancies()
        {
            return vacancyService.GetAllVacancies();
        }

        [HttpGet]
        [Route("/vacancy")]
        public ActionResult<Vacancy> GetSpecificVacancy(int vacancyId)
        {
            return vacancyService.GetVacancyById(vacancyId);
        }
    }
}
