using AutoMapper;
using ElectroTrading.Application.Abstractions;
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
    public class GetAllProductStorageQueryHandler : IQueryHandler<GetAllProductStorageQuery, List<StorageViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllProductStorageQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StorageViewModel>> Handle(GetAllProductStorageQuery request, CancellationToken cancellationToken)
        {
            var sts = await _context.Storages.Include(x => x.Product).ToListAsync(cancellationToken);
            List<StorageViewModel> result = new List<StorageViewModel>();
            foreach(var st in sts)
            {
                var viewModel = _mapper.Map<StorageViewModel>(st);
                viewModel.Product = _mapper.Map<ProductViewModel>(st.Product);
                result.Add(viewModel);
            }
            return result.OrderByDescending(x => x.Id).ToList();
        }
    }
}
