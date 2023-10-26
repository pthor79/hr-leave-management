using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity.Configurations;
public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
        new IdentityUserRole<string>
        {
            RoleId = "1914C3E4-3C9B-432B-94C0-28901976FD8A",
            UserId = "F3481837-BD21-4C16-8244-5A58BF9DA830"
        }, new IdentityUserRole<string>
        {
            RoleId = "3971A38F-A89B-4F11-A2A4-2755F3A8F799",
            UserId = "C4C240FB-E802-4E38-9F84-839256D05E8E"
        });
    }
}
