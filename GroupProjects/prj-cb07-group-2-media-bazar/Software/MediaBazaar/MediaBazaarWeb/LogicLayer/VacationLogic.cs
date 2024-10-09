namespace MediaBazaarWeb.LogicLayer
{
    public class VacationLogic
    {
        public bool CheckValAddVacation(Vacation vacation)
        {
            if(vacation.EndDate <= DateTime.Now || vacation.StartDate <= DateTime.Now || vacation.StartDate == vacation.EndDate)
            {
                return false;
            }
            else if(vacation.StartDate >= vacation.EndDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckValAddAbsence(Absence absence)
        {
            if(absence.Date <= DateTime.Now)
            {
                return false;
            }
            else { return true; }
        }
    }
}
