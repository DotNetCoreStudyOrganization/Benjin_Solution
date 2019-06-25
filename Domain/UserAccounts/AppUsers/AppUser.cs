namespace Domain.UserAccounts.AppUsers
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppUser : IdentityUser
    {
        public static readonly string DefaultPassword = "admin123456";

        public enum GenderEnum : byte
        {
            未知 = 0,
            男 = 1,
            女 = 2,
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public GenderEnum Gender { get; set; }
    }
}
