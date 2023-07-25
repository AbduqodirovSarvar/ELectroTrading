using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.CommandHandlers
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        public UpdateUserCommandHandler(IAppDbContext context, IMapper mapper, IHashService hashService)
        {
            _context = context;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (user == null)
                throw new NotFoundException();

            user.Phone = request?.Phone ?? user.Phone;
            user.Role = request?.Role ?? user.Role;
            if (request?.Password != null)
            {
                user.Password = _hashService.GetHash(request.Password);
            }
            
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
