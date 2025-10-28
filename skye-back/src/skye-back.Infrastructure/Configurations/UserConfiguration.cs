using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skye_back.Domain.User;

namespace skye_back.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id).HasName("pk_users");

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.OwnsOne(x => x.YandexId, nv =>
        {
            nv.Property(p => p.Value).IsRequired().HasColumnName("yandex_id");
        });

        builder.OwnsOne(x => x.Email, nv =>
        {
            nv.Property(p => p.Value).IsRequired().HasColumnName("email");
        });

        builder.OwnsOne(x => x.Name, nv =>
        {
            nv.Property(p => p.Value).IsRequired().HasColumnName("name");
        });

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");

        builder.Navigation(u => u.UserConversations)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}