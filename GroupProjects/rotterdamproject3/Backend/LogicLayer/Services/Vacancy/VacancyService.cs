using LogicLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services.Vacancy
{
    public class VacancyService : IVacancyService
    {
        private IVacancyRepository vacancyRepository { get; }

        public VacancyService(IVacancyRepository vacancyRepository)
        {
            this.vacancyRepository = vacancyRepository;
        }

        public List<Models.Vacancy> GetAllVacancies()
        {
            return vacancyRepository.GetAllVacancies();
        }

        public Models.Vacancy GetVacancyById(int vacancyid) => vacancyRepository.GetSpecificVacancy(vacancyid);

      
    }
}
