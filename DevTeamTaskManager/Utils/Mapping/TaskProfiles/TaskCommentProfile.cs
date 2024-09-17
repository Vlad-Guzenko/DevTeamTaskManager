using AutoMapper;

using DevTeamTaskManager.API.ViewModels.Tasks.TaskComment;

using DevTeamTaskManager.Application.Dtos.Tasks.TaskComment;

namespace DevTeamTaskManager.API.Utils.Mapping.TaskProfiles;

public class TaskCommentProfile : Profile
{
    public TaskCommentProfile()
    {
        CreateMap<TaskCommentCreationViewModel, TaskCommentCreationDto>();
        CreateMap<TaskCommentUpdateViewModel, TaskCommentUpdateDto>();
    }
}