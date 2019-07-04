namespace Application.Accounts.Models
{
    using System;
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
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 角色标识集合
        /// </summary>
        public IEnumerable<string> RoleIds { get; set; }

        internal (AppUser user, IEnumerable<AppRole> roles) ToEntity(AppUser entity, IQueryable<AppRole> queryable)
        {

            if (entity == default)
            {
                entity = MapperObj.Map<AppUser>(this);
            }
            else
            {
                MapperObj.Map(this, entity);
            }

            var roles = queryable.Where(m => RoleIds.Contains(m.Id)).ToList();

            return (entity, roles);
        }

        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<UserBindModel, AppUser>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => string.IsNullOrEmpty(s.Id) ? Guid.NewGuid().ToString().ToUpper() : s.Id));
            }
        }
    }
}
