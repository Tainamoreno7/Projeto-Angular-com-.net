using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using Template.Data.Extensions;
using Template.Data.Mappings;
using Template.Domain.Entities;


/// <summary>
/// Essa Classe vai conter algumas configurações, os DbSets -as configurações aplicadas a nossa classe de mapeamento
/// </summary>

namespace Template.Data.Context
{
    public class TemplateContext : DbContext //herdar de um modulo nativo do EntityFrameworkCore =, pois terá muita coisa pronta
    {
        public TemplateContext(DbContextOptions<TemplateContext> option)
           : base(option) { } //Construtor da classe

        #region "DBSets" 
        //é uma região reservada para setar os quais são dos Dbsets 
        public DbSet<User> Users { get; set; }

        #endregion
        //Setando a classe de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//região dos mapeamentos
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.ApplyGlobalConfigurations();
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);



        }
    }
}