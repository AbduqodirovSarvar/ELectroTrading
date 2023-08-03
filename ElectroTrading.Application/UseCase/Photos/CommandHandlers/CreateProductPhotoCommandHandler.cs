﻿using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.Services;
using ElectroTrading.Application.UseCase.Photos.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException();
            }

            if (request?.file == null || request?.file.Length == 0)
            {
                throw new NotFoundException();
            }

            string fileName = MakeImageName.GetName(request.file.FileName);

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(),"Files", "Photos");

            string filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.file.CopyToAsync(stream, cancellationToken);
            }

            ProductPhoto photo = new ProductPhoto();
            photo.ProductId = product.Id;
            photo.FileName = fileName;
            photo.FilePath = filePath;

            await _context.ProductPhotos.AddAsync(photo, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var viewModel = _mapper.Map<PhotoViewModel>(photo);
            viewModel.Product = _mapper.Map<ProductViewModel>(product);

            return viewModel;
        }
    }
}