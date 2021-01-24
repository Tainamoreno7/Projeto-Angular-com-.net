using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    //Responsavel por 
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();
    }
}
