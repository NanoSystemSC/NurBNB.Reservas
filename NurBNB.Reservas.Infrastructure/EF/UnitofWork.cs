using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Infrastructure.EF.Context;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Infrastructure.EF
{
    internal class UnitofWork : IUnitOfWork
    {
        //private readonly IMediator _mediator;
        private readonly WriteDbContext _context;

        //public UnitofWork(IMediator mediator, WriteDbContext context)
        public UnitofWork(WriteDbContext context)
        {
            //_mediator = mediator;
            _context = context;
        }

        //private int _transactionCounter;

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
