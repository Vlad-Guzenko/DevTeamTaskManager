using AutoMapper;

using DevTeamTaskManager.Application.Utils.Mapping.TaskProfiles;

namespace DevTeamTaskManager.Application.Utils.AutoMapper;

public class ApplicationAutoMapper : Mapper, IApplicationAutoMapper
{
	public ApplicationAutoMapper(IConfigurationProvider configurationProvider)
		: base(configurationProvider) {
		configurationProvider.AssertConfigurationIsValid();
	}

	public static IApplicationAutoMapper Instantiate()
	{
		return new ApplicationAutoMapper(new MapperConfiguration(cfg => 
		{
			cfg.AddProfile(new TaskProfile());
			cfg.AddProfile(new TaskCommentProfile());
		}));
	}
}