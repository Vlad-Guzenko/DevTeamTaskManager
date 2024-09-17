namespace DevTeamTaskManager.API.ViewModels.Tasks.TaskComment;

public class TaskCommentCreationViewModel
{
	public Guid TaskId { get; set; }

	public string Content { get; set; }

	public Guid AuthorId { get; set; }
}