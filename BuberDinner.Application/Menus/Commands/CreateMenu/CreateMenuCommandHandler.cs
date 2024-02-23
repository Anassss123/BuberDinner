using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            return default!;
        }
    }
}