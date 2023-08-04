using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Authorizes.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Authorizes.CommandHandlers
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;
        private readonly ISendTelegramMessage _msg;
        public LoginCommandHandler(IAppDbContext context, ITokenService tokenService, IHashService hashService, ISendTelegramMessage msg)
        {
            _context = context;
            _tokenService = tokenService;
            _hashService = hashService;
            _msg = msg;
        }
        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == request.Login, cancellationToken);
            var viewModel = new LoginViewModel();
            if (user == null || user.Password != _hashService.GetHash(request.Password))
            {
                throw new LoginException();
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

            viewModel.Token = "Bearer " + _tokenService.GetAccessToken(claims.ToArray());
            viewModel.UserRole = user.Role.ToString();

           /* var a = await _msg.SendMessage(636809820, "sgddjh");*/

            return viewModel;
        }
    }
}
