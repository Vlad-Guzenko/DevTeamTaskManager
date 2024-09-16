using AutoMapper;

using DevTeamTaskManager.API.ViewModels.Tasks.Task;

using DevTeamTaskManager.Application.Dtos.Tasks.Task;

namespace DevTeamTaskManager.API.Utils.Mapping.TaskProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskCreationViewModel, TaskCreationDto>();
        CreateMap<TaskUpdateViewModel, TaskUpdateDto>();
        CreateMap<TaskItemDto, TaskItemViewModel>();

        CreateMap<TaskDetailDto, TaskDetailViewModel>();
        CreateMap<TaskDescriptionDetailDto, TaskDescriptionDetailViewModel>();
    }
}