using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Menu;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var menu = Menu.Create(
                name: request.Name,
                description: request.Description,
                averageRating : 0,
                sections :request.Sections.ConvertAll( 
                    s =>  MenuSection.Create(
                        s.Name,
                        s.Description,
                        s.Items.ConvertAll(
                            i => MenuItem.Create(
                                i.Name,
                                i.Description
                            )
                        )
                    )
                ),
                hostId:HostId.Create(request.HostId)
            );
            _menuRepository.Add(menu);
            return menu;
        }
    }
}