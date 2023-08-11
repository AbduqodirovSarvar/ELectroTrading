using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.BSProducts.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.BSProducts.QueryHandlers
{
    public class GetBSProductQueryHandler : IQueryHandler<GetBSProductQuery, BSProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetBSProductQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BSProductViewModel> Handle(GetBSProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.BoughtAndSoldsProducts.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (product == null)
                throw new NotFoundException();

            var viewModel = _mapper.Map<BSProductViewModel>(product);

            return viewModel;
        }
    }
}
