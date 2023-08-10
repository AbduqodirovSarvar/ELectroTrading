using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.FinishedProducts.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.FinishedProducts.CommandHandlers
{
    public class UpdateFinishedProductCommandHandler : ICommandHandler<UpdateFinishedProductCommand, FinishedProductViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateFinishedProductCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FinishedProductViewModel> Handle(UpdateFinishedProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.FinishedProducts.Include(x => x.Product).FirstOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            product.Amount = request?.Amount ?? product.Amount;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<FinishedProductViewModel>(product);

        }
    }
}
