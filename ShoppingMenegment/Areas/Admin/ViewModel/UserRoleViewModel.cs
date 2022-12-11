using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingMenegment.Areas.Admin.ViewModel
{
    public class UserRoleViewModel
    {
        public int userId { get; set; }
        public int employeeId { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string empFullName { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
