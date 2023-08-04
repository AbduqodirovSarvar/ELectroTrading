using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Photos.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.QueryHandlers
{
    public class GetAllPhotoQueryHandler : IQueryHandler<GetAllPhotoQuery, List<PhotoViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetAllPhotoQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PhotoViewModel>> Handle(GetAllPhotoQuery request, CancellationToken cancellationToken)
        {
            var photos = await _context.ProductPhotos.ToListAsync(cancellationToken);

            return _mapper.Map<List<PhotoViewModel>>(photos);
        }
    }
}
