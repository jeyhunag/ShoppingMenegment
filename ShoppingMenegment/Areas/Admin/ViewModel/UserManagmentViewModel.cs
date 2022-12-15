using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace ShoppingMenegment.Areas.Admin.ViewModel
{
    public class UserManagmentViewModel
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }
        public int UserType { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public int EmployeeId { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}
