using DevTeamTaskManager.API.ViewModels.Enums;

namespace DevTeamTaskManager.API.ViewModels.Tasks.Task;

public class TaskItemViewModel
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public Guid ReporterId { get; set; }

	public TaskStatusViewModel Status { get; set; }
}