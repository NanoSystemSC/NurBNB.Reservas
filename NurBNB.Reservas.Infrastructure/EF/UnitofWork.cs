using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NurBNB.Reservas.Infrastructure.EF.Context;
using NurBNB.Reservas.SharedKernel.Core;

namespace NurBNB.Reservas.Infrastructure.EF
{
	[ExcludeFromCodeCoverage]
	internal class UnitofWork : IUnitOfWork
	{
		////private readonly IMediator _mediator;
		//private readonly WriteDbContext _context;

		////public UnitofWork(IMediator mediator, WriteDbContext context)
		//public UnitofWork(WriteDbContext context)
		//{
		//    //_mediator = mediator;
		//    _context = context;
		//}

		////private int _transactionCounter;

		//public async Task Commit()
		//{
		//    await _context.SaveChangesAsync();
		//    //throw new NotImplementedException();
		//}

		//**********************************************************************************

		private readonly IMediator _mediator;
		private readonly WriteDbContext _context;

		private int _transactionCounter;

		public UnitofWork(WriteDbContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
			_transactionCounter = 0;
		}

		public async Task Commit()
		{
			_transactionCounter++;

			var domainEvents = _context.ChangeTracker
				.Entries<Entity>()
				.Where(x => x.Entity.DomainEvents.Any())
				.Select(x =>
				{
					var domainEvents = x.Entity
									.DomainEvents
									.ToImmutableArray();
					x.Entity.ClearDomainEvents();

					return domainEvents;
				})
				.SelectMany(domainEvents => domainEvents)
				.ToList();

			foreach (var evento in domainEvents)
			{
				await _mediator.Publish(evento);
			}

			if (_transactionCounter == 1)
			{
				await _context.SaveChangesAsync();
			}
			else
			{
				_transactionCounter--;
			}
		}
	}
}
