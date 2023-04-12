using FINAL_ASSIGNMENT.Models;

namespace FINAL_ASSIGNMENT.Service.Interface
{
    public interface IRoleService
    {
        public bool AddRole(Role obj);
        public bool UpdateRole(Role obj);
        public bool DeleteRole(Guid Id);
        public List<Role> GetListRole();

        public Role GetRoleByID(Guid Id);
        public List<Role> GetRoleByName(string Name);
    }
}
