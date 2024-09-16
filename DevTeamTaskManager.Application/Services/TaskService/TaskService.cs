using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using BuildingBlocks.Domain.Persistance;

using DevTeamTaskManager.Application.Dtos.Tasks.Task;
using DevTeamTaskManager.Application.Utils.AutoMapper;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

namespace DevTeamTaskManager.Application.Services.TaskService;

public class TaskService : ITaskService
{
	private readonly IApplicationAutoMapper _mapper;
	private readonly IRepository<PTask> _taskRepository;

	public TaskService(IApplicationAutoMapper mapper, IRepository<PTask> taskRepository)
	{
		_mapper = mapper;
		_taskRepository = taskRepository;
	}

	public async Task<Guid> Create(TaskCreationDto taskCreationDto)
	{
		var task = PTask.NewDraft(
			taskCreationDto.Title, taskCreationDto.ReporterId,
			taskCreationDto.Description,
			taskCreationDto.Status,
			taskCreationDto.Priority,
			taskCreationDto.CreatedAt,
			taskCreationDto.DueDate);

		_taskRepository.Add(task);
		await _taskRepository.UnitOfWork.CommitAsync();

		return task.Id;
	}

	public async Task Update(TaskUpdateDto taskUpdateDto)
	{
		var task = await _taskRepository.GetAsync(taskUpdateDto.Id)
			?? throw new ApplicationException($"Task with id: {taskUpdateDto.Id} doesn't exist");

		task.Update(taskUpdateDto.Title, taskUpdateDto.Description, 
			taskUpdateDto.Status, taskUpdateDto.Priority, taskUpdateDto.DueDate);

		await _taskRepository.UnitOfWork.CommitAsync();
	}

	public async Task<List<TaskItemDto>> List()
	{
		var tasks = await _taskRepository.ListAsync();

		return _mapper.Map<List<TaskItemDto>>(tasks);
	}

	public async Task<TaskDetailDto> Get(Guid taskId)
	{
		var task = await _taskRepository.GetAsync(taskId)
			?? throw new ApplicationException($"Task with id: {taskId} doesn't exist");

		return _mapper.Map<TaskDetailDto>(task);
	}

	public async Task Delete(Guid taskId)
	{
		var task = await _taskRepository.GetAsync(taskId)
			?? throw new ApplicationException($"Task with id: {taskId} doesn't exist");

		_taskRepository.Remove(task);

		await _taskRepository.UnitOfWork.CommitAsync();
	}
}