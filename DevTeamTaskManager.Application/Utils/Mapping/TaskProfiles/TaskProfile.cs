using AutoMapper;

using DevTeamTaskManager.Application.Dtos.Tasks.Task;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

namespace DevTeamTaskManager.Application.Utils.Mapping.TaskProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<PTask, TaskItemDto>();
        CreateMap<PTask, TaskDetailDto>()
            .ForMember(p => p.Description, opt => opt.MapFrom(p => p.Description));

		CreateMap<Description, TaskDescriptionDetailDto>();
	}
}