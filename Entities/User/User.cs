using Entities.User.VM;
using Microsoft.AspNetCore.Identity;

namespace Entities.User
{
    public class User
    {
        public string Id { get; set; }
        public virtual IdentityUser Identity { get; set; }

        public User(){}
    }
}
