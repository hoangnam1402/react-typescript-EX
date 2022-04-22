using System;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<UserCreateDto, User>()
               .ForMember(src => src.FirstName, act => act.MapFrom(dest => dest.FirstName))
                .ForMember(src => src.LastName, act => act.MapFrom(dest => dest.LastName))
                .ForMember(src => src.JoinDate, act => act.MapFrom(dest => dest.JoinDate))
                .ForMember(src => src.FullName, act => act.MapFrom(dest => string.Format("{0} {1}", dest.FirstName, dest.LastName)))
                .ForMember(src => src.DOB, act => act.MapFrom(dest => dest.DOB))
                .ForMember(src => src.Gender, act => act.MapFrom(dest => dest.Gender))
                .ForMember(src => src.Type, act => act.MapFrom(dest => dest.Type))
                .ForMember(src => src.UserName, act => act.Ignore())
                .ForMember(src => src.Location, act => act.Ignore())
                .ForMember(src => src.FirstLogin, act => act.Ignore())
                .ForMember(src => src.IsDisable, act => act.Ignore())
                .ForMember(src => src.Id, act => act.Ignore())
                .ForMember(src => src.NormalizedEmail, act => act.Ignore())
                .ForMember(src => src.NormalizedUserName, act => act.Ignore())
                .ForMember(src => src.Email, act => act.Ignore())
                .ForMember(src => src.EmailConfirmed, act => act.Ignore())
                .ForMember(src => src.PasswordHash, act => act.Ignore())
                .ForMember(src => src.SecurityStamp, act => act.Ignore())
                .ForMember(src => src.ConcurrencyStamp, act => act.Ignore())
                .ForMember(src => src.PhoneNumber, act => act.Ignore())
                .ForMember(src => src.PhoneNumberConfirmed, act => act.Ignore())
                .ForMember(src => src.TwoFactorEnabled, act => act.Ignore())
                .ForMember(src => src.LockoutEnabled, act => act.Ignore())
                .ForMember(src => src.LockoutEnd, act => act.Ignore())
                .ForMember(src => src.AccessFailedCount, act => act.Ignore())
                .ForMember(src => src.StaffCode, act => act.Ignore())
                .ReverseMap();

            CreateMap<AssetDTO, Asset>().ForMember(src => src.IsDeleted, act => act.Ignore()).ReverseMap();

            CreateMap<AssetCreateDTO, Asset>()
                .ForMember(src => src.Name, act => act.MapFrom(dest => dest.Name))
                .ForMember(src => src.Specification, act => act.MapFrom(dest => dest.Specification))
                .ForMember(src => src.InstallDate, act => act.MapFrom(dest => dest.InstallDate))
                .ForMember(src => src.State, act => act.MapFrom(dest => dest.State))
                .ForMember(src => src.CategoryID, act => act.MapFrom(dest => dest.CategoryID))
                .ForMember(src => src.Code, act => act.Ignore())
                .ForMember(src => src.Location, act => act.Ignore())
                .ForMember(src => src.LastUpdate, act => act.Ignore())
                .ForMember(src => src.Id, act => act.Ignore())
                .ForMember(src => src.Category, act => act.Ignore())
                .ForMember(src => src.IsDeleted, act => act.Ignore())
                .ReverseMap();

            CreateMap<AssetCategoryDTO, AssetCategory>()
                .ForMember(scr => scr.Assets, act => act.Ignore())
                .ReverseMap();

            CreateMap<AssignmentDTO, Assignment>().ForMember(src => src.IsDelete, act => act.Ignore()).ReverseMap();

            CreateMap<AssignmentCreateDTO, Assignment>()
                .ForMember(src => src.AssetID, act => act.MapFrom(dest => dest.AssetID))
                .ForMember(src => src.AssignToID, act => act.MapFrom(dest => dest.AssignToID))
                .ForMember(src => src.AssignDate, act => act.MapFrom(dest => dest.AssignDate))
                .ForMember(src => src.Note, act => act.MapFrom(dest => dest.Note))
                .ForMember(src => src.AssignByID, act => act.Ignore())
                .ForMember(src => src.State, act => act.Ignore())
                .ForMember(src => src.Location, act => act.Ignore())
                .ForMember(src => src.Id, act => act.Ignore())
                .ForMember(src => src.Asset, act => act.Ignore())
                .ForMember(src => src.AssignBy, act => act.Ignore())
                .ForMember(src => src.AssignTo, act => act.Ignore())
                .ForMember(src => src.ReturnDate, act => act.Ignore())
                .ForMember(src => src.IsDelete, act => act.Ignore())
                .ReverseMap();

            CreateMap<AssetUpdateDTO, Asset>()
                .ForMember(src => src.Name, act => act.MapFrom(dest => dest.Name))
                .ForMember(src => src.Specification, act => act.MapFrom(dest => dest.Specification))
                .ForMember(src => src.InstallDate, act => act.MapFrom(dest => dest.InstallDate))
                .ForMember(src => src.State, act => act.MapFrom(dest => dest.State))
                .ForMember(src => src.LastUpdate, act => act.MapFrom((_,__,___) => DateTime.Now))
                .ForMember(src => src.Code, act =>  {
                                                    act.UseDestinationValue();
                                                    act.Ignore();
                                                })
                .ForMember(src => src.Location, act =>  {
                                                    act.UseDestinationValue();
                                                    act.Ignore();
                                                })
                .ForMember(src => src.Id, act =>  {
                                                    act.UseDestinationValue();
                                                    act.Ignore();
                                                })
                .ForMember(src => src.Category, act =>  {
                                                    act.UseDestinationValue();
                                                    act.Ignore();
                                                })
                .ForMember(src => src.CategoryID, act =>  {
                                                    act.UseDestinationValue();
                                                    act.Ignore();
                                                })
                .ForMember(src => src.IsDeleted, act => act.Ignore())
                .ReverseMap();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<User, UserCreateDto>()
                .ReverseMap();
            CreateMap<UserDto, UserCreateDto>()
                .ReverseMap();
            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<Asset, AssetCreateDTO>()
                .ReverseMap();
            CreateMap<AssetDTO, AssetCreateDTO>()
                .ReverseMap();
            CreateMap<Asset, AssetDTO>()
                .ReverseMap();
            CreateMap<Asset, AssetUpdateDTO>()
                .ReverseMap();
            CreateMap<AssetDTO, AssetUpdateDTO>()
                .ReverseMap();

            CreateMap<Assignment, AssignmentCreateDTO>()
                .ReverseMap();
            CreateMap<AssignmentDTO, AssignmentCreateDTO>()
                .ReverseMap();
            CreateMap<Assignment, AssignmentDTO>()
                .ReverseMap();
        }
    }
}
