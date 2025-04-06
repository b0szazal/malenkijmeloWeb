
namespace MalenkijMelo.Share.Models
{
    public class User : IDbEntity<User>
    {
        public User()
        {
        }

        public User(string id, string name, string email, string password, DateTime suspendedUntil)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            SuspendedUntil = suspendedUntil;
        }

        public User(string id, string name, string email, string password, DateTime suspendedUntil, DateTime adminPermissionExpirationDate, byte adminLevel) : this(id, name, email, password, suspendedUntil)
        {
            AdminPermissionExpirationDate = adminPermissionExpirationDate;
            AdminLevel = adminLevel;
        }

        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime SuspendedUntil {  get; set; }

        public bool IsRoleEmployee => Id[0] == 'm';

        public DateTime AdminPermissionExpirationDate { get; set; }

        public bool HasAdminPermissions => AdminPermissionExpirationDate > System.DateTime.Now;
        public byte AdminLevel { get; set; } = 0;

        public bool CheckIfEmpty() =>
            Id == string.Empty;

        public override string ToString() =>
            $"{Name} - Adminisztrátori szint: {AdminLevel}";

        public double RatingAvg { get; set; } = 0;
    }
}
