using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;

namespace BuberDinner.Api.Mapping
{
    public class MenuAutoMapper : Profile
    {
        public MenuAutoMapper()
        {
            CreateMap<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId))
                .ForMember(dest => dest, opt => opt.MapFrom(src => src.Request));
        }
    }
}






        // public MenuMappingProfile()
        // {
        //     CreateMap<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
        //         .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId))
        //         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Request.Name))
        //         .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Request.Description))
        //         .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.Request.Sections.Select(s =>
        //             new MenuSectionCommand(s.Name, s.Descriptions, s.Items.Select(i => new MenuItemCommand(i.Name, i.Description)).ToList())
        //         )));

        //     CreateMap<Menu, MenuResponse>()
        //         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
        //         .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.AverageRating))
        //         .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId.Value));

        //     CreateMap<MenuSection, MenuSectionResponse>()
        //         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));

        //     CreateMap<MenuItem, MenuItemResponse>()
        //         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
        // }
