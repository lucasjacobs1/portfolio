namespace LogicLayer
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUserByEmail(string email);
        bool CheckEmailExists(string email);
        User GetUserById(int id);

    }
}