using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skye_back.Domain.UserPreference;

namespace skye_back.Infrastructure.Configurations;

public class UserPreferenceConfiguration : IEntityTypeConfiguration<UserPreference>
{
    public void Configure(EntityTypeBuilder<UserPreference> builder)
    {
        builder.ToTable("user_preference");
        builder.HasKey(x => x.UserId).HasName("pk_user_preference");

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("user_id");
        
        builder.OwnsOne(x => x.DefaultModel, nv =>
        {
            nv.Property(p => p.Value)
                .HasColumnName("default_model")
                .IsRequired();
        });
        
        builder.OwnsOne(x => x.Theme, nv =>
        {
            nv.Property(p => p.Value)
                .HasColumnName("theme")
                .IsRequired();
        });
        
        builder.Property(x => x.StreamByDefault)
            .HasColumnName("stream_by_default")
            .IsRequired();
        builder.Property(x => x.StreamPromptDefault)
            .HasColumnName("stream_prompt_default")
            .IsRequired();
    }
}