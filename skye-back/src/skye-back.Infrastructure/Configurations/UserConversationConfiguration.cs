using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skye_back.Domain.Conversation;
using skye_back.Domain.User;
using skye_back.Domain.UserConversations;

namespace skye_back.Infrastructure.Configurations;

public class UserConversationConfiguration: IEntityTypeConfiguration<UserConversation>

{
    public void Configure(EntityTypeBuilder<UserConversation> builder)
    {
        builder.ToTable("user_conversations");
        builder.HasKey(x => new { x.UserId, x.ConversationId }).HasName("pk_user_conversations");
        
        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();
        
        builder.Property(x => x.ConversationId)
            .HasColumnName("conversation_id")
            .IsRequired();
        
        builder.HasOne<User>()
            .WithMany(u => u.UserConversations)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Conversation>()
            .WithMany()
            .HasForeignKey(x => x.ConversationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.ConversationId);
    }
}