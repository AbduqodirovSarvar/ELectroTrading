using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.CommandHandlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        public CreateUserCommandHandler(IAppDbContext context, IMapper mapper, IHashService hashService)
        {
            _context = context;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == request.Phone, cancellationToken);
            if (user != null)
            {
                throw new AlreadyExistsException();
            }

            User createUser = _mapper.Map<User>(request);
            createUser.Password = _hashService.GetHash(request.Password);
            createUser.CreatedDate= DateTime.UtcNow;

            await _context.Users.AddAsync(createUser, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserViewModel>(createUser);
        }
    }
}
