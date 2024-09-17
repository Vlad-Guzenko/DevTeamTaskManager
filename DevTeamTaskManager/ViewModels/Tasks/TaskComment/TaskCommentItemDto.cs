namespace DevTeamTaskManager.API.ViewModels.Tasks.TaskComment;

public class TaskCommentItemDto
{
	public string Content { get; set; }

	public Guid AuthorId { get; set; }
}