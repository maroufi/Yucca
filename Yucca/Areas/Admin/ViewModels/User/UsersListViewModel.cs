using System.Collections.Generic;

namespace Yucca.Areas.Admin.ViewModels.User
{
    public class UsersListViewModel
    {
        public IEnumerable<UserViewModel> UsersList { get; set; }
        public int PageCount { get; set; }
        public string Term { get; set; }
        public int PageNumber { get; set; }
        public int TotalUsers { get; set; }
    }
}
