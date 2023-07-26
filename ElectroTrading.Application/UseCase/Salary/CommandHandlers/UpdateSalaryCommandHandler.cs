using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Salary.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.CommandHandlers
{
    public class UpdateSalaryCommandHandler : ICommandHandler<UpdateSalaryCommand, SalaryViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public UpdateSalaryCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalaryViewModel> Handle(UpdateSalaryCommand request, CancellationToken cancellationToken)
        {
            var salary = await _context.PaymentSalaries.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (salary == null)
                throw new NotFoundException();

            salary.Summs = request?.Summs ?? salary.Summs;

            await _context.SaveChangesAsync(cancellationToken);

            SalaryViewModel viewModel = _mapper.Map<SalaryViewModel>(salary);
            viewModel.Employee = _mapper.Map<EmployeeViewModel>(salary.Employee);

            return viewModel;
        }
    }
}
