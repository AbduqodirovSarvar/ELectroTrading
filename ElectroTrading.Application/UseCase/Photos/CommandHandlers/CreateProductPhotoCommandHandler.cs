using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.Services;
using ElectroTrading.Application.UseCase.Photos.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.CommandHandlers
{
    internal class CreateProductPhotoCommandHandler : ICommandHandler<CreateProductPhotoCommand, PhotoViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductPhotoCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PhotoViewModel> Handle(CreateProductPhotoCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Include(x => x.Compositions).ThenInclude(x => x.Composition).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            var photo = await _context.ProductPhotos.FirstOrDefaultAsync(x => x.ProductId == product.Id, cancellationToken);
            if(photo == null)
            {
                photo = new ProductPhoto();
                photo.ProductId = product.Id;
                photo.Product = product;
                photo.FileName = request.FileName;
                photo.FilePath = request.FilePath;

                await _context.ProductPhotos.AddAsync(photo, cancellationToken);
            }
            else
            {
                photo.FileName = request.FileName;
                photo.FilePath = request.FilePath;
            }
            
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

            var viewModel = _mapper.Map<PhotoViewModel>(photo);
            viewModel.Product = _mapper.Map<ProductViewModel>(product);

            return viewModel;
        }
    }
}
