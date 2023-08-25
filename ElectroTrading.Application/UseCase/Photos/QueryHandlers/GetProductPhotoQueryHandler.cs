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
    public class GetProductPhotoQueryHandler : IQueryHandler<GetProductPhotoQuery, PhotoFile>
    {
        private readonly IAppDbContext _context;
        public GetProductPhotoQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<PhotoFile> Handle(GetProductPhotoQuery request, CancellationToken cancellationToken)
        {
            var photo = await _context.ProductPhotos.FirstOrDefaultAsync(x => x.ProductId == request.ProductId, cancellationToken);
            if (photo == null)
            {
                throw new NotFoundException("Photo not found");
            }

            string contentType = "image/jpeg";

            if (File.Exists(photo.FilePath) && Path.GetExtension(photo.FilePath) == ".png")
            {
                contentType = "image/png";
            }

            return new PhotoFile(photo.FilePath, contentType);
        }
    }

    public class PhotoFile
    {
        public PhotoFile(string path, string type) 
        {
            Path = path;
            ContentType = type;
        }
        public string Path { get; set; } = string.Empty;
        public string ContentType { get; set; } = "image/jpeg";
    }
}
