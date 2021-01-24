using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            //isenção de dados padrões sem precisar utilizar a API

            builder.Entity<User>()
                .HasData(
                     new User { Id = Guid.Parse("c7dce21b-d207-4869-bf5f-08eb138bb919"), Name = "User Default", Email = "tainamoreno7@gmail.com", Password = "261395" } //guide online para que não precise gerar toda vez
                         );


            return builder;
        }
    }
}