using Entities.User.VM;

namespace Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email{ get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }

        public User(){}
        public User(RegisterVM registerVm)
        {
            Username = registerVm.Username;
            Email = registerVm.Email;
        }
    }
}
