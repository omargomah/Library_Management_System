using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibraryManagementSystem.Data.Configuration
{
    public class BorrowingConfiguration : IEntityTypeConfiguration<Borrowing>
    {
        public void Configure(EntityTypeBuilder<Borrowing> builder)
        {
            builder.HasIndex(x => new { x.MemberId, x.BookId }).IsUnique(false);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Borrowings)
                .HasForeignKey(x => x.BookId);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.Borrowings)
                .HasForeignKey(x => x.MemberId);
        }
    }
}
