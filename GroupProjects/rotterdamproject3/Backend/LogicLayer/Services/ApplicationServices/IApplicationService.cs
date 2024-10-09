using LogicLayer.Models;

namespace LogicLayer.Services.ApplicationServices
{
    public interface IApplicationService
    {
        void InsertApplication(Application application);
        List<Application> GetApplicationsByVacancy(int vacancy);
    }
}