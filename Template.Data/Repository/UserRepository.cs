using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Context;
using Template.Data.Repositories;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repository
{
    //Responsavel por comunicar com o banco e comunicar com classe de serviço 
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(TemplateContext context)
            : base(context) { }

        public IEnumerable<User> GetAll()//valor que esta no banco de dados
        {
            return Query(x => !x.IsDeleted);//buscar as informações
        }
    }
}
