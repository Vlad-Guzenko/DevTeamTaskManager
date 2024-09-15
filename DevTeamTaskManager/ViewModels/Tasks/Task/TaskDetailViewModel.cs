using DevTeamTaskManager.API.ViewModels.Enums;

namespace DevTeamTaskManager.API.ViewModels.Tasks.Task;

public class TaskDetailViewModel
{
	public string Title { get; set; }

	public Guid ReporterId { get; set; }

	public TaskDescriptionDetailViewModel Description { get; set; }

	public TaskStatusViewModel Status { get; set; }

	public TaskPriorityViewModel Priority { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime? DueDate { get; set; }
}

public class TaskDescriptionDetailViewModel
{
	public string Content { get; set; }
}