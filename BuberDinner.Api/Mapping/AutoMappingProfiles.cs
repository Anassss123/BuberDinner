using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.Common.Menu;
using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;
using MenuItem = BuberDinner.Domain.Menu.Entities.MenuItem;


namespace BuberDinner.Api.Mapping
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles(){
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<AuthenticationResult, AuthenticationResponse>();
            CreateMap<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                    .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Request.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Request.Description))
                    .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => 
                        src.Request.Sections.Select(s =>
                            new MenuSectionCommand(
                                s.Name, 
                                s.Description, 
                                s.Items.Select(i => new MenuItemCommand(i.Name, i.Description)).ToList()
                            )
                        ).ToList()
                    ));
            CreateMap<Menu, MenuResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => 
                    src.Sections.Select(s => 
                        new MenuSectionResponse(
                            s.Id.Value.ToString(),
                            s.Name, 
                            s.Description, 
                            s.Items.Select(i => new MenuItemResponse(i.Id.Value.ToString(), i.Name, i.Description)).ToList()
                        )
                    ).ToList()
                ))
                .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId.Value))
            ;
            CreateMap<MenuSection, MenuSectionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => 
                    src.Items.Select(i => new MenuItemResponse(i.Id.Value.ToString(), i.Name, i.Description)).ToList()
                ));
            CreateMap<MenuItem, MenuItemResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)); 
        }
    }
}
