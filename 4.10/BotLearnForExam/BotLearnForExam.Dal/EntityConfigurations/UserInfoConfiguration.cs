using BotLearnForExam.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BotLearnForExam.Dal.EntityConfigurations;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.ToTable("UserInfo");
        builder.HasKey(ui => ui.UserInfoId);

        builder.Property(ui => ui.FirstName).IsRequired(false);
        builder.Property(ui => ui.LastName).IsRequired(false);
        builder.Property(ui => ui.Address).IsRequired(false);
        builder.Property(ui => ui.PhoneNumber).IsRequired(false);
        builder.Property(ui => ui.Email).IsRequired(false);
        builder.Property(ui => ui.Summary).IsRequired(false);
    }
}
