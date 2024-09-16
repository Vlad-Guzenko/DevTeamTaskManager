using DevTeamTaskManager.API.ViewModels.Enums;

namespace DevTeamTaskManager.API.ViewModels.Tasks.Task;

public class TaskItemViewModel
{
	public string Title { get; set; }

	public Guid ReporterId { get; set; }

	public TaskStatusViewModel Status { get; set; }
}