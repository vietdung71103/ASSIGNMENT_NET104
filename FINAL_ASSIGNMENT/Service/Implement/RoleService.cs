using FINAL_ASSIGNMENT.Service.Context;
using FINAL_ASSIGNMENT.Service.Implement;
using FINAL_ASSIGNMENT.Models;
using FINAL_ASSIGNMENT.Service.Interface;
namespace FINAL_ASSIGNMENT.Service.Implement
{
    public class RoleService :IRoleService
    {
        WebContext _dbContext;
        List<Role> _getRoles;
        public RoleService()
        {
            _getRoles = new List<Role>();
            _dbContext = new WebContext();
        }

        public bool AddRole(Role obj)
        {
            try
            {
                _dbContext.Roles.Add(obj);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteRole(Guid Id)
        {
            try
            {
                var get = _dbContext.Roles.Find(Id);
                _dbContext.Roles.Remove(get);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public List<Role> GetListRole()
        {
            _getRoles = _dbContext.Roles.ToList();
            return _getRoles;
        }

        public Role GetRoleByID(Guid Id)
        {
            return _dbContext.Roles.FirstOrDefault(c => c.RoleId == Id);
        }

        public List<Role> GetRoleByName(string Name)
        {
            return GetListRole().Where(c => c.RoleName.ToLower().Contains(Name)).ToList();
        }

        public bool UpdateRole(Role obj)
        {
            try
            {
                var role = _dbContext.Roles.Find(obj.RoleId);
                role.RoleName = obj.RoleName;
                role.Description = obj.Description;
                role.Status = obj.Status;
                _dbContext.Roles.Update(role);
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
