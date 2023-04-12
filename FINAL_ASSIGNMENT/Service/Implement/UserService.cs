using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Interface;

namespace FINAL_ASSIGNMENT.Service.Implement
{
    public class UserService: IUserService
    {
        WebContext _dbContext;
        List<User> _getListUser;
        public UserService()
        {
            _dbContext = new WebContext();
            _getListUser = new List<User>();
        }

        public bool AddUser(User obj)
        {
            try
            {
                _dbContext.Users.Add(obj);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteUser(Guid Id)
        {
            try
            {
                var get = _dbContext.Users.Find(Id);
                _dbContext.Users.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<User> GetListUser()
        {
            _getListUser = _dbContext.Users.ToList();
            return _getListUser;
        }

        public User GetUserByID(Guid Id)
        {
            return GetListUser().FirstOrDefault(c => c.Id == Id);
        }

        //public List<User> GetUserByName(string Name)
        //{
        //}

        public bool UpdateUser(User obj)
        {
            try
            {
                var pr = _dbContext.Users.FirstOrDefault(c => c.Id == obj.Id);
                pr.FullName = obj.FullName;
                pr.Avatar = obj.Avatar;
                pr.Email = obj.Email;
                pr.Status = obj.Status;
                _dbContext.Users.Update(pr);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
    }
}
