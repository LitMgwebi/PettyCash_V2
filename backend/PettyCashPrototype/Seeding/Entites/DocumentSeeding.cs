using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class DocumentSeeding: IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasDiscriminator<string>("DocumentType")
                .HasValue<Motivation>("Motivation")
                .HasValue<Receipt>("Receipt");
        }
    }
}
