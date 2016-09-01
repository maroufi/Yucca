namespace Yucca.Areas.Admin.ViewModels.User
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int CommentCount { get; set; }
        public int OrderCount { get; set; }
        public string  RoleDescritpion { get; set; }
        public bool Baned  { get; set; }
        public string RegisterType { get; set; }
    }
}
