using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skye_back.Domain.Conversation;

namespace skye_back.Infrastructure.Configurations;

public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
{
    public void Configure(EntityTypeBuilder<Conversation> builder)
    {
        builder.ToTable("conversations");
        builder.HasKey(c => c.Id).HasName("pk_conversations");
        
        builder.Property(c => c.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.OwnsOne(x => x.Title, nv =>
        {
            nv.Property(p => p.Value).IsRequired().HasMaxLength(30).HasColumnName("title");
        });

        builder.OwnsOne(x => x.Model, nv =>
        {
            nv.Property(p => p.Value).IsRequired().HasColumnName("model");
        });

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

    }
}