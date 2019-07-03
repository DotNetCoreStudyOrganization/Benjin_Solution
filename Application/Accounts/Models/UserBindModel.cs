namespace Application.Accounts.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.BaseModels;
    using AutoMapper;
    using Domain.UserAccounts.AppRoles;
    using Domain.UserAccounts.AppUsers;

    public class UserBindModel : AppBaseModel
    {
        private static readonly IMapper MapperObj = GetMapper<MappingProfile>();

        public enum GenderEnum : byte
        {
            未知 = 0,
            男 = 1,
            女 = 2,
        }

        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> RoleIds { get; set; }

        internal (AppUser user, IEnumerable<AppRole> roles) ToEntity(AppUser entity, IQueryable<AppRole> queryable)
        {
            var roles = queryable.Where(m => RoleIds.Contains(m.Id)).ToList();

            // 自行实现
            throw new System.NotImplementedException();
        }

        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<UserBindModel, AppUser>();
            }
        }
    }
}
