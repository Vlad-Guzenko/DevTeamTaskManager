using AutoMapper;

using DevTeamTaskManager.Application.Dtos.Tasks.Task;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;
using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate;

namespace DevTeamTaskManager.Application.Utils.Mapping.TaskProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<PTask, TaskItemDto>();
        CreateMap<PTask, TaskDetailDto>()
            .ForMember(p => p.Description, opt => opt.MapFrom(p => p.Description))
            .ForMember(p => p.Comments, opt => opt.MapFrom(p => p.TaskComments));

		CreateMap<Description, TaskDescriptionDetailDto>();
        CreateMap<TaskComment, TaskCommentDetailDto>();
	}
}