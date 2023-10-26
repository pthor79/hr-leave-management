using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(
                       new ApplicationUser
                       {
                           Id = "F3481837-BD21-4C16-8244-5A58BF9DA830",
                           UserName = "admin@localhost.com",
                           NormalizedUserName = "admin@localhost.com",
                           Email = "admin@localhost.com",
                           NormalizedEmail = "admin@localhost.com",
                           EmailConfirmed = true,
                           PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                           FirstName = "System",
                           LastName = "Admin"
                       },
                       new ApplicationUser
                       {
                           Id = "C4C240FB-E802-4E38-9F84-839256D05E8E",
                           UserName = "user@localhost.com",
                           NormalizedUserName = "user@localhost.com",
                           Email = "user@localhost.com",
                           NormalizedEmail = "user@localhost.com",
                           EmailConfirmed = true,
                           PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                           FirstName = "System",
                           LastName = "user"
                       }
        );
    }
}
