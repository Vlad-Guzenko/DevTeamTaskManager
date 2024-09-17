using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BuildingBlocks.Domain.Persistance;

using DevTeamTaskManager.Application.Utils.AutoMapper;
using DevTeamTaskManager.Application.Dtos.Tasks.TaskComment;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;
using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate;

namespace DevTeamTaskManager.Application.Services.TaskServices.TaskCommentService;

public class TaskCommentService : ITaskCommentService
{
	private readonly IApplicationAutoMapper _mapper;
	private readonly IRepository<PTask> _taskRepository;
	private readonly IRepository<TaskComment> _taskCommentRepository;

	public TaskCommentService(IApplicationAutoMapper mapper, 
		IRepository<TaskComment> taskCommentRepository, IRepository<PTask> taskRepository)
	{
		_mapper = mapper;
		_taskRepository = taskRepository;
		_taskCommentRepository = taskCommentRepository;
	}

	public async Task<TaskCommentItemDto> Create(TaskCommentCreationDto taskCommentCreationDto)
	{
		if (!await _taskRepository.AnyAsync(PTaskSepcifications.IsExist(taskCommentCreationDto.TaskId)))
		{
			throw new ApplicationException($"Task with id: {taskCommentCreationDto.TaskId} doesn't exist");
		}

		var taskComment = TaskComment.NewDraft(taskCommentCreationDto.TaskId, 
			taskCommentCreationDto.Content, taskCommentCreationDto.AuthorId);

		_taskCommentRepository.Add(taskComment);
		await _taskCommentRepository.UnitOfWork.CommitAsync();

		return _mapper.Map<TaskCommentItemDto>(taskComment);
	}

	public async Task Update(Guid taskCommentId, TaskCommentUpdateDto taskCommentUpdateDto)
	{
		var taskComment = await _taskCommentRepository.GetAsync(taskCommentId)
			?? throw new ApplicationException($"Task comment with id: {taskCommentId} doesn't exist!");

		taskComment.Update(taskCommentUpdateDto.Content);
		await _taskCommentRepository.UnitOfWork.CommitAsync();
	}
	
	//public async Task<List<TaskCommentItemDto>> List(Guid taskId)
	//{
	//	var taskComments = await _taskCommentRepository.ListAsync(TaskCommentSpecifications.TaskComments(taskId));

	//	return _mapper.Map<List<TaskCommentItemDto>>(taskComments);
	//}

	public async Task Delete(Guid taskCommentId)
	{
		var taskComment = await _taskCommentRepository.GetAsync(taskCommentId)
			?? throw new ApplicationException($"Task comment with id: {taskCommentId} doesn't exist!");

		_taskCommentRepository.Remove(taskComment);
		await _taskCommentRepository.UnitOfWork.CommitAsync();
	}
}