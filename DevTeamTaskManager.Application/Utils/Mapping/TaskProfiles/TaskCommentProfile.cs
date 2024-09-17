using AutoMapper;

using DevTeamTaskManager.Application.Dtos.Tasks.TaskComment;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate;

namespace DevTeamTaskManager.Application.Utils.Mapping.TaskProfiles;

public class TaskCommentProfile : Profile
{
    public TaskCommentProfile()
    {
		CreateMap<TaskComment, TaskCommentItemDto>();
	}
}