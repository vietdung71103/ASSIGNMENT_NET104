using FINAL_ASSIGNMENT.Models;
namespace FINAL_ASSIGNMENT.Service.Interface
{
    public interface IUserService
    {
        public bool AddUser(User obj);
        public bool UpdateUser(User obj);
        public bool DeleteUser(Guid Id);
        public List<User> GetListUser();

        public User GetUserByID(Guid Id);
        //public List<User> GetUserByName(string Name);
    }
}
