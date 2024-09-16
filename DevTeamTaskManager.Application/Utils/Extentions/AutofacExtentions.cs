using Autofac;

using DevTeamTaskManager.Application.Utils.AutoMapper;

namespace DevTeamTaskManager.Application.Utils.Extentions;

public static class AutofacExtentions
{
	public static void RegisterAutoMapper(this ContainerBuilder builder)
	{
		builder.Register(component => ApplicationAutoMapper.Instantiate()).InstancePerLifetimeScope();
	}
}