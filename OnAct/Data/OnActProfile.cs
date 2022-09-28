using AutoMapper;
using OnAct.Data.Dtos.Activities;
using OnAct.Data.Dtos.Groups;
using OnAct.Data.Dtos.Places;
using OnAct.Data.Entities;

namespace OnAct.Data
{
    public class OnActProfile : Profile
    {

        public OnActProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<CreateActivityDto, Activity>();
            CreateMap<UpdateActivityDto, Activity>();

            CreateMap<Place, PlaceDto>();
            CreateMap<CreatePlaceDto, Place>();
            CreateMap<UpdatePlaceDto, Place>();

            CreateMap<Group, GroupDto>();
            CreateMap<CreateGroupDto, Group>();
            CreateMap<UpdateGroupDto, Group>();
        }

    }
}
