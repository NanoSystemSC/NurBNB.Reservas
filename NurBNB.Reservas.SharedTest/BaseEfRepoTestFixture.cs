using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NurBNB.Reservas.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NurBNB.Reservas.Infrastructure.EF.Context;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace NurBNB.Reservas.Test
{
	[ExcludeFromCodeCoverage]
	public abstract class BaseEfRepoTestFixture
	{
		//protected AppDbContext _dbContext;
		protected WriteDbContext _dbContext;

		protected BaseEfRepoTestFixture()
		{
			var options = CreateNewContextOptions();
			//var mockEventDispatcher = new Mock<IDomainEventDispatcher>();

			//_dbContext = new AppDbContext(options, mockEventDispatcher.Object);

			_dbContext = new WriteDbContext(options);
		}

		protected static DbContextOptions<WriteDbContext> CreateNewContextOptions()
		{
			// Create a fresh service provider, and therefore a fresh
			// InMemory database instance.
			var serviceProvider = new ServiceCollection()
				//.AddEntityFrameworkInMemoryDatabase()
				.BuildServiceProvider();

			// Create a new options instance telling the context to use an
			// InMemory database and the new service provider.
			var builder = new DbContextOptionsBuilder<WriteDbContext>();

			builder.UseInternalServiceProvider(serviceProvider);
			//builder.UseInMemoryDatabase("cleanarchitecture")
			//       .UseInternalServiceProvider(serviceProvider);

			return builder.Options;
		}

		//protected EfRepository<Project> GetRepository()
		//{
		//    return new EfRepository<Project>(_dbContext);
		//}

		//public EfRepository<T> GetRepositoryGeneric<T>() where T : class, IAggregateRoot
		//{
		//    return new EfRepository<T>(_dbContext);
		//}
	}
}
