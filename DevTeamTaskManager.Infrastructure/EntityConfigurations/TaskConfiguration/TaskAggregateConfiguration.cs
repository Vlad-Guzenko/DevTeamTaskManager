using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

namespace DevTeamTaskManager.Infrastructure.EntityConfigurations.TaskConfiguration;

public class TaskAggregateConfiguration : IEntityTypeConfiguration<PTask>
{
	public void Configure(EntityTypeBuilder<PTask> builder)
	{
		builder.Property(p => p.Title).IsRequired();
		builder.Property(p => p.ReporterId).IsRequired();
		builder.Property(p => p.CreatedAt).IsRequired();

		builder.OwnsOne(p => p.Description);

		builder.Property(p => p.Status).HasConversion<string>().IsRequired();
		builder.Property(p => p.Priority).HasConversion<string>().IsRequired();
	}
}