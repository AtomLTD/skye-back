using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skye_back.Domain.Conversation;
using skye_back.Domain.Message;

namespace skye_back.Infrastructure.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("messages");
        builder.HasKey(x => x.Id).HasName("pk_messages");

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(x => x.ConversationId)
            .HasColumnName("conversion_id")
            .IsRequired();

        builder.OwnsOne(x => x.Role, nv =>
        {
            nv.Property(p => p.Value)
                .HasColumnName("role")
                .IsRequired();
        });

        builder.OwnsOne(x => x.Content, nv =>
        {
            nv.Property(p => p.Value)
                .HasColumnName("content")
                .HasMaxLength(20 * 1000)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Model, nv =>
        {
            nv.Property(p => p.Value)
                .HasColumnName("model")
                .IsRequired();
        });

        builder.Property(x => x.PromptTokens)
            .IsRequired()
            .HasColumnName("prompt_tokens");

        builder.Property(x => x.CompletionTokens)
            .IsRequired()
            .HasColumnName("completion_tokens");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.HasIndex(x => x.ConversationId);
        builder.HasIndex(x => x.CreatedAt);
        
        builder.HasOne<Conversation>()
            .WithMany()
            .HasForeignKey(x => x.ConversationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}