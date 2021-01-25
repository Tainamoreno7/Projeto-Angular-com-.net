using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Template.Application.Interfaces;
using Template.Application.ViewModels;

using Template.Domain.Entities;
using Template.Domain.Interfaces;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Template.Application.Services
{
    //Recebe informação da Controller, trata-las e retornar para o banco
    //Recebe informações do Banco, trata-las e retornar para o serviço
    //Interface de contrato

    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }


        public List<UserViewModel> Get()
        {
            //Listando os usuários
            //o AutoMapper permite fazer a convesão de Lista e Objetos
            IEnumerable<User> _users = this.userRepository.GetAll();

            List<UserViewModel> _userViewModels = mapper.Map<List<UserViewModel>>(_users);//_nomevarivel=padrão utilizado para variaveis dentro do metodo

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            User _user = new User
            {
                Id = Guid.NewGuid(),
                Email = userViewModel.Email,
                Name = userViewModel.Name,


            };

            this.userRepository.Create(_user);

            return true;

        }
        public UserViewModel GetById(string id)
        //retornar um usuário especifico 
        {
            if (!Guid.TryParse(id, out Guid userId))//Transformar String em 
                throw new Exception("UserID is not valid");

            User _user = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_user == null)
                throw new Exception("User not found");//Se não encontrar o Usuário

            return mapper.Map<UserViewModel>(_user);
        }
        public bool Put(UserViewModel userViewModel)
        {
            if (userViewModel.Id == Guid.Empty)
                throw new Exception("ID is invalid");

            User _user = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted); //pegando o usuário pelo Id e não está deletado
            if (_user == null)//Validando
                throw new Exception("User not found");

            this.userRepository.Update(_user);//Convertendo as informações 

            return true;

        }



    }
}

    
