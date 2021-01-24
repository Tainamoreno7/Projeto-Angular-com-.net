using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Id).IsRequired(); //obrigatório
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired(); //obrigatório
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(10).IsRequired();
        }

    }
}