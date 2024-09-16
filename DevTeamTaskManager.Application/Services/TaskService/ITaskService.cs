using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DevTeamTaskManager.Application.Dtos.Tasks.Task;

namespace DevTeamTaskManager.Application.Services.TaskService;

public interface ITaskService
{
	Task<Guid> Create(TaskCreationDto taskCreationDto);

	Task Update(TaskUpdateDto taskUpdateDto);

	Task<List<TaskItemDto>> List();

	Task<TaskDetailDto> Get(Guid taskId);

	Task Delete(Guid taskId);
}