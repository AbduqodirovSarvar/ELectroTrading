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
    public class CreateDebtCommandHandler : ICommandHandler<CreateDebtCommand, DebtViewModel>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISendTelegramMessage _sendMsg;
        public CreateDebtCommandHandler(IAppDbContext context, IMapper mapper, ICurrentUserService currentUserService, ISendTelegramMessage sendMsg)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _sendMsg = sendMsg;
        }

        public async Task<DebtViewModel> Handle(CreateDebtCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.EmployeeId, cancellationToken);
            if (employee == null)
                throw new NotFoundException();

            EmployeeDebt createModel = _mapper.Map<EmployeeDebt>(request);
            createModel.EmployeeId = request.EmployeeId;
            createModel.ByWhomId = _currentUserService.UserId;

            await _context.EmployeesDebts.AddAsync(createModel, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            DebtViewModel viewModel = _mapper.Map<DebtViewModel>(createModel);
            viewModel.Employee = _mapper.Map<EmployeeViewModel>(request);

            await _sendMsg.SendMessage(await _sendMsg.MakeIndebtText(viewModel));

            return viewModel;
        }
    }
}
