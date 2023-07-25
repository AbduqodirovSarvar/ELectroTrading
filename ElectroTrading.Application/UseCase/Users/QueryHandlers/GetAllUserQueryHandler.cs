using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.QueryHandlers
{
    public class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<UserViewModel>>(await _context.Users.ToListAsync(cancellationToken));
        }
    }
}
