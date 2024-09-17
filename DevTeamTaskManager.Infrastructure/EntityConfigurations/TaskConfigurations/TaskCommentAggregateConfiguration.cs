using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate;

namespace DevTeamTaskManager.Infrastructure.EntityConfigurations.TaskConfigurations;

public class TaskCommentAggregateConfiguration : IEntityTypeConfiguration<TaskComment>
{
	public void Configure(EntityTypeBuilder<TaskComment> builder)
	{
		builder.HasKey(p => p.Id);
		builder.Property(p => p.Content).IsRequired();
		builder.Property(p => p.TaskId).IsRequired();
		builder.Property(p => p.AuthorId).IsRequired();

		builder.Property(p => p.CreatedAt).HasColumnType("timestamp with time zone").IsRequired();
		builder.Property(p => p.UpdatedAt).HasColumnType("timestamp with time zone");

		builder
			.HasOne(p => p.Task)
			.WithMany(p => p.TaskComments)
			.HasForeignKey(p => p.TaskId);
	}
}