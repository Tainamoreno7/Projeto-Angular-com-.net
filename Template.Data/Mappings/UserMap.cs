using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;



namespace Template.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Id).IsRequired(); //obrigatório
            builder.Property(x => x.NameClient).HasMaxLength(100).IsRequired(); //obrigatório
            builder.Property(x => x.NameContact).HasMaxLength(100).IsRequired();//obrigatorio
            builder.Property(x => x.CNPJ).HasMaxLength(50);
            builder.Property(x => x.DateCreated);
            builder.Property(x => x.DateClient);
            
        }

    }
}