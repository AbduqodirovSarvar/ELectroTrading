using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Photos.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.CommandHandlers
{
    public class UpdateProductPhotoCommandHandler : ICommandHandler<UpdateProductPhotoCommand, PhotoViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateProductPhotoCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PhotoViewModel> Handle(UpdateProductPhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = await _context.ProductPhotos.FirstOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken);
            if (photo == null)
            {
                throw new NotFoundException();
            }

            if (File.Exists(photo.FilePath))
            {
                File.Delete(photo.FilePath);
            }

            photo.FileName = request.FileName;
            photo.FilePath = request.FilePath;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<PhotoViewModel>(photo);
        }
    }
}
