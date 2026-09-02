using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibraryManagementSystem.Data.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(Constants.MaxNameLength);
            builder.Property(x => x.Email).HasMaxLength(Constants.MaxEmailLength);
            builder.Property(x => x.Phone).HasMaxLength(Constants.PhoneLength);
        }
    }
}
