using DevTeamTaskManager.API.ViewModels.Enums;

namespace DevTeamTaskManager.API.ViewModels.Tasks.Task;

public class TaskCreationViewModel
{
	public string Title { get; set; }

	public Guid ReporterId { get; set; }

	public string Description { get; set; }

	public TaskStatusViewModel Status { get; set; }

	public TaskPriorityViewModel Priority { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime? DueDate { get; set; }
}