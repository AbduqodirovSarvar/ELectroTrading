using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Exceptions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Salary.Commands;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Salary.CommandHandlers
{
    public class CreateSalaryPaymentCommandHandler : ICommandHandler<CreateSalaryPaymentCommand, SalaryViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISendTelegramMessage _sendMsg;

        public CreateSalaryPaymentCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService, ISendTelegramMessage sendMsg)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _sendMsg = sendMsg;
        }

        public async Task<SalaryViewModel> Handle(CreateSalaryPaymentCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.EmployeeId, cancellationToken);
            if (employee == null)
            {
                throw new NotFoundException("Employee not found");
            }
                
            PaymentSalary createModel = _mapper.Map<PaymentSalary>(request);
            createModel.ByWhomId = _currentUserService.UserId;

            await _context.PaymentSalaries.AddAsync(createModel, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            SalaryViewModel viewModel = _mapper.Map<SalaryViewModel>(createModel);
            viewModel.Employee = _mapper.Map<EmployeeViewModel>(employee);

            await _sendMsg.SendMessage(await _sendMsg.MakeSalaryText(viewModel));

            return viewModel;
        }
    }
}
