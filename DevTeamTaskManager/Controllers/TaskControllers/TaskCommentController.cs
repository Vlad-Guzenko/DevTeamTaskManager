using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using DevTeamTaskManager.API.ViewModels.Tasks.TaskComment;

using DevTeamTaskManager.Application.Dtos.Tasks.TaskComment;
using DevTeamTaskManager.Application.Services.TaskServices.TaskCommentService;

namespace DevTeamTaskManager.API.Controllers.TaskControllers;

[Route("api/[controller]")]
[ApiController]
public class TaskCommentController : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly ITaskCommentService _taskCommentService;

	public TaskCommentController(IMapper mapper, ITaskCommentService taskCommentService)
	{
		_mapper = mapper;
		_taskCommentService = taskCommentService;
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<Guid>> Create(TaskCommentCreationViewModel taskCommentCreationViewModel)
	{
		var taskCommentCreationDto = _mapper.Map<TaskCommentCreationDto>(taskCommentCreationViewModel);

		var createdCommentId = await _taskCommentService.Create(taskCommentCreationDto);

		return Created(nameof(Guid), createdCommentId);
	}

	[HttpPut("{id}")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Update(Guid id, TaskCommentUpdateViewModel taskCommentUpdateViewModel)
	{
		var taskCommentUpdateDto = _mapper.Map<TaskCommentUpdateDto>(taskCommentUpdateViewModel);

		await _taskCommentService.Update(id, taskCommentUpdateDto);

		return Ok();
	}

	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _taskCommentService.Delete(id);

		return NoContent();
	}
}