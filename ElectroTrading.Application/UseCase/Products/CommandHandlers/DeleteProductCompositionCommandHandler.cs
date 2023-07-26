using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.UseCase.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Products.CommandHandlers
{
    public class DeleteProductCompositionCommandHandler : ICommandHandler<DeleteProductCompositionCommand, bool>
    {
        public Task<bool> Handle(DeleteProductCompositionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
