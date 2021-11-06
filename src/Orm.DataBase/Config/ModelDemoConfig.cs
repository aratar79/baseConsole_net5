using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Domain;

namespace Orm.DataBase.Config
{
    public class ModelDemoConfig
    {
        public ModelDemoConfig(EntityTypeBuilder<ModelDemo> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.NameModel).HasMaxLength(30).IsRequired().IsUnicode();
            entityTypeBuilder.Property(p => p.Description).HasMaxLength(250).IsRequired().IsUnicode();

            // add data seed method
            entityTypeBuilder.HasData(
                new ModelDemo
                {
                    NameModel = "Name demo 1",
                    Description = "Description demo 1"
                },
                new ModelDemo
                {
                    NameModel = "Name demo 2",
                    Description = "Description demo 2"
                }
            );
        }
    }
}