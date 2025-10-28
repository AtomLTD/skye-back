using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skye_back.Domain.ModelInfo;

namespace skye_back.Infrastructure.Configurations;

public class ModelInfoConfiguration : IEntityTypeConfiguration<ModelInfo>
{
    public void Configure(EntityTypeBuilder<ModelInfo> builder)
    {
        builder.ToTable("model_info");
        builder.HasKey(x => x.Id).HasName("pk_model_info");

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.OwnsOne(x => x.Model, nv =>
        {
            nv.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("model");

            nv.HasIndex(p => p.Value);
        });

        builder.Property(x => x.DisplayName)
            .IsRequired()
            .HasColumnName("display_name")
            .HasMaxLength(100);

        builder.Property(x => x.ContextWindow)
            .IsRequired()
            .HasColumnName("context_window");
        
        // Цена как VO (предположим: Value (decimal) + Currency (string))
        builder.OwnsOne(x => x.PriceInputPer1K, nv =>
        {
            nv.Property(p => p.Amount).HasColumnName("price_input_value").HasColumnType("numeric(18,6)");
            nv.Property(p => p.Currency).HasColumnName("price_input_currency").HasMaxLength(3);
        });
        
        builder.OwnsOne(x => x.PriceOutputPer1K, nv =>
        {
            nv.Property(p => p.Amount).HasColumnName("price_output_value").HasColumnType("numeric(18,6)");
            nv.Property(p => p.Currency).HasColumnName("price_output_currency").HasMaxLength(8);
        });

        builder.Property(x => x.Enabled)
            .IsRequired()
            .HasColumnName("enabled");

        builder.Property(x => x.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");

    }
}