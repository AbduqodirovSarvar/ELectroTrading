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
    public class UserUpdateCommandHandler : ICommandHandler<UserUpdateCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        public UserUpdateCommandHandler(IAppDbContext context, IMapper mapper, IHashService hashService)
        {
            _context = context;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<UserViewModel> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException();
            }
            user.Phone = request?.Phone ?? user.Phone;
            user.Role = request?.Role ?? user.Role;
            if (request?.Password != null)
            {
                user.Password = _hashService.GetHash(request.Password);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
