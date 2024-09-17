using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DevTeamTaskManager.Application.Dtos.Tasks.TaskComment;

namespace DevTeamTaskManager.Application.Services.TaskServices.TaskCommentService;

public interface ITaskCommentService
{
	Task<TaskCommentItemDto> Create(TaskCommentCreationDto taskCommentCreationDto);

	Task Update(Guid taskCommentId, TaskCommentUpdateDto taskCommentUpdateDto);

	//Task<List<TaskCommentItemDto>> List(Guid taskId);

	Task Delete(Guid taskCommentId);
}