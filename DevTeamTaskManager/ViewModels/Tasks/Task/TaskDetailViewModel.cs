using DevTeamTaskManager.API.ViewModels.Enums;

namespace DevTeamTaskManager.API.ViewModels.Tasks.Task;

public class TaskDetailViewModel
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public Guid ReporterId { get; set; }

	public TaskDescriptionDetailViewModel Description { get; set; }

	public List<TaskCommentDetailViewModel> Comments { get; set; }

	public TaskStatusViewModel Status { get; set; }

	public TaskPriorityViewModel Priority { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime? DueDate { get; set; }
}

public class TaskDescriptionDetailViewModel
{
	public string Content { get; set; }
}

public class TaskCommentDetailViewModel
{
	public Guid Id { get;set; }

	public string Content { get; set; }

	public Guid AuthorId { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime? UpdatedAt { get; set; }
}