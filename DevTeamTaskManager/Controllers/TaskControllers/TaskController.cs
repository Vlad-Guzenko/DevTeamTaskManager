using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using DevTeamTaskManager.API.ViewModels.Tasks.Task;

using DevTeamTaskManager.Application.Dtos.Tasks.Task;
using DevTeamTaskManager.Application.Services.TaskServices.TaskService;

namespace DevTeamTaskManager.API.Controllers.TaskControllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly ITaskService _taskService;

    public TaskController(IMapper mapper, ITaskService taskService)
    {
        _mapper = mapper;
        _taskService = taskService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Guid>> Create(TaskCreationViewModel taskCreationViewModel)
    {
        var taskCreationDto = _mapper.Map<TaskCreationDto>(taskCreationViewModel);

        var createdTaskId = await _taskService.Create(taskCreationDto);

        return Created(nameof(Guid), createdTaskId);
    }

	[HttpPut]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Update(TaskUpdateViewModel taskUpdateViewModel)
	{
		var taskUpdateDto = _mapper.Map<TaskUpdateDto>(taskUpdateViewModel);

		await _taskService.Update(taskUpdateDto);

		return Ok();
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<List<TaskItemViewModel>>> List()
	{
		var taskItemDtos = await _taskService.List();

		var taskItemViewModels = _mapper.Map<List<TaskItemViewModel>>(taskItemDtos);

		return Ok(taskItemViewModels);
	}

	[HttpGet("{taskId}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<TaskDetailViewModel>> Get(Guid taskId)
	{
		var taskDetailDto = await _taskService.Get(taskId);

		var taskDetailViewModel = _mapper.Map<TaskDetailViewModel>(taskDetailDto);

		return Ok(taskDetailViewModel);
	}

	[HttpDelete("{taskId}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Delete(Guid taskId)
	{
		await _taskService.Delete(taskId);

		return NoContent();
	}
}