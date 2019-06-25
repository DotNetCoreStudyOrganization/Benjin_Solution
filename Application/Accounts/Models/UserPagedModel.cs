namespace Application.Accounts.Models
{
    using System;
    using Application.BaseModels;
    using AutoMapper;
    using Domain.UserAccounts.AppUsers;
    using X.PagedList;
    using Infrastructure.Models;

    public class UserPagedModel : AppBaseModel
    {
        private static readonly IMapper MapperObj = GetMapper<MappingProfile>();

        public string Id { get; set; }

        public string Name { get; set; }

        internal static PagedListModel<UserPagedModel> CreatePagedList(IPagedList<AppUser> entityList)
        {
            var pagedList = MapperObj.Map<IPagedList<UserPagedModel>>(entityList);

            return new PagedListModel<UserPagedModel>(pagedList);
        }

        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<AppUser, UserPagedModel>();
            }
        }
    }
}
