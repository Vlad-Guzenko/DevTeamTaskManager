using BuildingBlocks.Domain.Exceptions;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

using TaskStatus = DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.TaskStatus;

namespace DevTeamTaskManager.UnitTests.Domain.TaskAggregateTests;

public class TaskAggregateTests
{
	[Fact]
	public void NewDraft_Success()
	{
		var expectedTitle = "Title";
		var expectedReporterId = Guid.NewGuid();
		var expectedDescription = "Description";
		var expectedStatus = TaskStatus.ToDo;
		var expectedPriority = TaskPriority.Low;
		var expectedCreatedAt = DateTime.UtcNow;
		var expectedDueDate = DateTime.UtcNow.AddMinutes(1);

		var task = PTask.NewDraft(
			expectedTitle, expectedReporterId,
			expectedDescription,
			expectedStatus,
			expectedPriority,
			expectedCreatedAt,
			expectedDueDate);

		Assert.NotNull(task);
	}

	[Theory]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData(null)]
	public void NewDraft_InvalidTitle_ThrowsException(string title)
	{
		Assert.Throws<DomainException>(() =>
		{
			PTask.NewDraft(title, Guid.NewGuid(), "description",
				TaskStatus.ToDo, TaskPriority.Low, DateTime.Now, DateTime.Now.AddMinutes(1));
		});
	}

	[Fact]
	public void NewDraft_EmptyReporter_ThrowsException()
	{
		var reporterId = Guid.Empty;

		Assert.Throws<DomainException>(() => PTask.NewDraft("title", reporterId, "description",
			TaskStatus.ToDo, TaskPriority.Low, DateTime.Now, DateTime.Now.AddMinutes(1)));
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	[InlineData(4)]
	public void NewDraft_WrongStatus_ThrowsException(int status)
	{
		Assert.Throws<DomainException>(() =>
		{
			PTask.NewDraft("title", Guid.NewGuid(), "description",
			(TaskStatus)status, TaskPriority.Low, DateTime.Now, DateTime.Now.AddMinutes(1));
		});
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	[InlineData(4)]
	public void NewDraft_WrongPriority_ThrowsException(int priority)
	{
		Assert.Throws<DomainException>(() =>
		{
			PTask.NewDraft("title", Guid.NewGuid(), "description",
			TaskStatus.ToDo, (TaskPriority)priority, DateTime.Now, DateTime.Now.AddMinutes(1));
		});
	}

	[Fact]
	public void Update_Success()
	{
		var expectedTitle = "UpdatedTitle";
		var expectedDescription = "UpdatedDescription";
		var expectedStatus = TaskStatus.Completed;
		var expectedPriority = TaskPriority.High;
		var expectedDueDate = DateTime.UtcNow.AddDays(5);

		var task = PTask.NewDraft(
			"Title", Guid.NewGuid(),
			"Description",
			TaskStatus.ToDo,
			TaskPriority.Low,
			DateTime.UtcNow,	
			DateTime.UtcNow.AddMinutes(1));

		task.Update(expectedTitle, expectedDescription, expectedStatus, expectedPriority, expectedDueDate);

		Assert.NotNull(task);
		Assert.Equal(expectedTitle, task.Title);
		Assert.Equal(expectedDescription, task.Description.Content);
		Assert.Equal(expectedStatus, task.Status);
		Assert.Equal(expectedPriority, task.Priority);
		Assert.Equal(expectedDueDate, task.DueDate);
	}

	[Theory]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData(null)]
	public void Update_WrongTitle_ThrowsException(string title)
	{
		var task = PTask.NewDraft(
			"Title", Guid.NewGuid(),
			"Description",
			TaskStatus.ToDo,
			TaskPriority.Low,
			DateTime.UtcNow,
			DateTime.UtcNow.AddMinutes(1));

		Assert.Throws<DomainException>(() =>
		{
			task.Update(title, "Description", TaskStatus.ToDo, TaskPriority.Low, DateTime.UtcNow.AddMinutes(1));
		});
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(4)]
	[InlineData(null)]
	public void Update_WrongStatus_ThrowsException(int status)
	{
		var task = PTask.NewDraft(
			"Title", Guid.NewGuid(),
			"Description",
			TaskStatus.ToDo,
			TaskPriority.Low,
			DateTime.UtcNow,
			DateTime.UtcNow.AddMinutes(1));

		Assert.Throws<DomainException>(() =>
		{
			task.Update("Title", "Description", (TaskStatus)status, TaskPriority.Low, DateTime.UtcNow.AddMinutes(1));
		});
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(4)]
	[InlineData(null)]
	public void Update_WrongPriority_ThrowsException(int priority)
	{
		var task = PTask.NewDraft(
			"Title", Guid.NewGuid(),
			"Description",
			TaskStatus.ToDo,
			TaskPriority.Low,
			DateTime.UtcNow,
			DateTime.UtcNow.AddMinutes(1));

		Assert.Throws<DomainException>(() =>
		{
			task.Update("Title", "Description", TaskStatus.ToDo, (TaskPriority)priority, DateTime.UtcNow.AddMinutes(1));
		});
	}
}