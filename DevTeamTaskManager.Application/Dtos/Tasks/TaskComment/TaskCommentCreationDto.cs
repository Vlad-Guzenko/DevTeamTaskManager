using System;

namespace DevTeamTaskManager.Application.Dtos.Tasks.TaskComment;

public class TaskCommentCreationDto
{
    public Guid TaskId { get; set; }

    public string Content { get; set; }
    
    public Guid AuthorId { get; set; }
}