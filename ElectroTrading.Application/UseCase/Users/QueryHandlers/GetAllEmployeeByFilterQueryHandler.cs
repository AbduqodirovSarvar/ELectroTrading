using AutoMapper;
using ElectroTrading.Application.Abstractions;
using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.UseCase.Users.QueryHandlers
{
    public class GetAllEmployeeByFilterQueryHandler : IQueryHandler<GetAllEmployeeByFilterQuery, List<EmployeeViewModel>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISendTelegramMessage _msg;
        public GetAllEmployeeByFilterQueryHandler(IAppDbContext context, IMapper mapper, ISendTelegramMessage msg)
        {
            _context = context;
            _mapper = mapper;
            _msg = msg;
        }

        public async Task<List<EmployeeViewModel>> Handle(GetAllEmployeeByFilterQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.Include(x => x.Attendances).Include(x => x.EmployeeDebts).Include(x => x.PaymentSalarys).ToListAsync(cancellationToken);
            if (request?.Month != null)
            {
                employees = employees
                    .Where(x =>(x.IsDeleted == false) || (x.DeletedDate != null 
                        && x.DeletedDate.Value.Year >= request.Month.Value.Year 
                            && x.DeletedDate.Value.Month >= request.Month.Value.Month)).ToList();
            }

            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }
    }
}
