namespace LogicLayer.Services.Vacancy
{
    public interface IVacancyService
    {
        List<LogicLayer.Models.Vacancy> GetAllVacancies();

        public LogicLayer.Models.Vacancy GetVacancyById(int id);
    }
}
