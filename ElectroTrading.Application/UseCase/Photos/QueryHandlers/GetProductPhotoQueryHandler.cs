using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.UseCase.Photos.Commands;
using ElectroTrading.Application.UseCase.Photos.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Photos.QueryHandlers
{
    public class GetProductPhotoQueryHandler : IQueryHandler<GetProductPhotoQuery, (string, string)>
    {
        private readonly IAppDbContext _context;
        public GetProductPhotoQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<(string, string)> Handle(GetProductPhotoQuery request, CancellationToken cancellationToken)
        {
            var photo = await _context.ProductPhotos.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (photo == null)
            {
                throw new NotFoundException();
            }

            string contentType = "image/jpeg";

            if (File.Exists(photo.FilePath) && Path.GetExtension(photo.FilePath) == ".png")
            {
                contentType = "image/png";
            }

            return (photo.FilePath, contentType);
        }
    }
}
