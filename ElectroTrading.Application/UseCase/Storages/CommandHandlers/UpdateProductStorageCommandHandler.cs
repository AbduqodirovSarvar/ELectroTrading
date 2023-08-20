using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Storages.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Storages.CommandHandlers
{
    public class UpdateProductStorageCommandHandler : ICommandHandler<UpdateProductStorageCommand, StorageViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateProductStorageCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StorageViewModel> Handle(UpdateProductStorageCommand request, CancellationToken cancellationToken)
        {
            var st = await _context.Storages.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (st == null)
            {
                throw new NotFoundException();
            }

            st.Amount = request?.Amount ?? st.Amount;
            st.Description = request?.Description ?? st.Description;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }
                else
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            var viewModel = _mapper.Map<StorageViewModel>(st);
            viewModel.Product = _mapper.Map<ProductViewModel>(st.Product);
            return viewModel;
        }
    }
}
