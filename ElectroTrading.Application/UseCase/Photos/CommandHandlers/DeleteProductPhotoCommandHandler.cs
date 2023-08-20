using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.Photos.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.CommandHandlers
{
    public class DeleteProductPhotoCommandHandler : ICommandHandler<DeleteProductPhotoCommand, bool>
    {
        private readonly IAppDbContext _context;
        public DeleteProductPhotoCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductPhotoCommand request, CancellationToken cancellationToken)
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

            _context.ProductPhotos.Remove(photo);
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
            return true;
        }
    }
}
