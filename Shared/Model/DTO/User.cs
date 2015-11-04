using Shared.Model.Common;

namespace Shared.Model.DTO
{
    public class User:Entity<int>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
