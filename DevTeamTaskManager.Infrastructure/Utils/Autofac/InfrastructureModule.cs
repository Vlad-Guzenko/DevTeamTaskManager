using Autofac;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using BuildingBlocks.Domain.Persistance;

namespace DevTeamTaskManager.Infrastructure.Utils.Autofac;

public class InfrastructureModule : Module
{
	private IConfiguration _configuration;

	public InfrastructureModule(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	protected override void Load(ContainerBuilder builder)
	{
		RegisterDbContext(builder);

		RegisterGenericRepository(builder);

		builder.RegisterType<MigrateDb>().As<IStartable>().SingleInstance();
	}

	private void RegisterDbContext(ContainerBuilder builder)
	{
		builder
			.Register(c =>
			{
				var dbContextOptionsBuilder = new DbContextOptionsBuilder<DevTeamTaskManagerContext>()
				.UseLazyLoadingProxies()
				.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));

				return new DevTeamTaskManagerContext(dbContextOptionsBuilder.Options);
			})
			.AsSelf()
			.As<DbContext>()
			.InstancePerLifetimeScope();
	}

	private void RegisterGenericRepository(ContainerBuilder builder)
	{
		builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>))
				.InstancePerLifetimeScope();
	}
}