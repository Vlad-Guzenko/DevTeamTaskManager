using AutoMapper;

namespace DevTeamTaskManager.Application.Utils.AutoMapper;

public class ApplicationAutoMapper : Mapper, IApplicationAutoMapper
{
	public ApplicationAutoMapper(IConfigurationProvider configurationProvider)
		: base(configurationProvider) { }

	public static IApplicationAutoMapper Instantiate()
	{
		return new ApplicationAutoMapper(new MapperConfiguration(cfg => 
		{

		}));
	}
}