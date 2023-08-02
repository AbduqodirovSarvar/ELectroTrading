using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Storages.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Storages.QueryHandlers
{
    public class GetProductStorageQueryHandler : IQueryHandler<GetProductStorageQuery, StorageViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetProductStorageQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageViewModel> Handle(GetProductStorageQuery request, CancellationToken cancellationToken)
        {
            var st = await _context.Storages.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (st == null)
            {
                throw new NotFoundException();
            }

            var viewModel = _mapper.Map<StorageViewModel>(st);
            viewModel.Product = _mapper.Map<ProductViewModel>(st.Product);

            return viewModel;
        }
    }
}
