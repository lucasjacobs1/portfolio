using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Repositories
{
    public interface IVacancyRepository
    {
        List<Vacancy> GetAllVacancies();
      Vacancy GetSpecificVacancy(int vacancy);
    }
}
