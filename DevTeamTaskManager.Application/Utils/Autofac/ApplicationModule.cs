using Autofac;

using Microsoft.Extensions.Configuration;

using DevTeamTaskManager.Infrastructure.Utils.Autofac;

using DevTeamTaskManager.Application.Utils.Extentions;
using DevTeamTaskManager.Application.Services.TaskService;

namespace DevTeamTaskManager.Application.Utils.Autofac;

public class ApplicationModule : Module
{
	private readonly IConfiguration _configuration;

    public ApplicationModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }

	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterAutoMapper();

		builder.RegisterModule(new InfrastructureModule(_configuration));

		builder.RegisterType<TaskService>().As<ITaskService>().InstancePerLifetimeScope();
	}
}