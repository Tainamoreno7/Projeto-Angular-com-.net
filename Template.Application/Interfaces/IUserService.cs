using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.Interfaces;
using Template.Application.ViewModels;

namespace Template.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get(); //Contrato - Entregar a classe para controller sem saber que o metodo faz
        //retornar o atributo solicitado

        bool Post(UserViewModel UserViewModel);
        UserViewModel GetById(string id);
        bool Put(UserViewModel userViewModel);
    }
}
