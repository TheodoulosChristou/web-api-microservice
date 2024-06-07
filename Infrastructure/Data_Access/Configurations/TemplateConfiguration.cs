using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Infrastructure.DataAccess.Configurations
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("Template");

            //compound 
            //builder.HasKey(a => new { a.templateId, a.templateId2 });
            //builder.Property(k => k.templateId).ValueGeneratedOnAdd();

            //builder
            //    .HasOne<Template2>()
            //    .WithMany()
            //    .HasForeignKey(sh => sh.FKKey)
            //    .IsRequired();

        }
    }
}