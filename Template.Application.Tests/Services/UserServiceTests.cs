﻿using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Template.Application.AutoMapper;
using Template.Application.Services;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using Xunit;

namespace Template.Application.Tests.Services
{
    public class UserServiceTests
    {
        private UserService userService;

        public UserServiceTests()
        {
            //dados irreais e não são seriados no banco
            userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        #region ValidatingSendingID

        [Fact]
        public void Post_SendingValidId()
        {
            //Testando o post - evitar que um ID não seja criado
            var exception = Assert.Throws<Exception>(() => userService.Post(new UserViewModel { Id = Guid.NewGuid() }));//
            Assert.Equal("UserID must be empty", exception.Message); //
        }
        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            //Teste enviando um Id Vazio
            var exception = Assert.Throws<Exception>(() => userService.GetById(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
            //Editar sem um ID
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel()));
            Assert.Equal("ID is invalid", exception.Message);
        }

        /*[Fact]
        //public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(""));
            Assert.Equal("UserID is not valid", exception.Message);
        }

        [Fact]
        public void Authenticate_SendingEmptyValues()
        //Autentar sem Email vazio
        {
            var exception = Assert.Throws<Exception>(() => userService.Authenticate(new UserAuthenticateRequestViewModel()));
            Assert.Equal("Email/Password are required.", exception.Message);
        }
        */
        #endregion
        
        #region ValidatingCorrectObject

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = userService.Post(new UserViewModel { NameClient = "User Default", NameContact = "Taina" });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            //Criando a lista com um objeto para que seja retornado pelo repository
            List<User> _users = new List<User>();
            _users.Add(new User { Id = Guid.NewGuid(), NameClient = "User Default", NameContact = "Taina", DateCreated = DateTime.Now , CNPJ = "73.686.370.0179-20", 
            DateClient = new DateTime(2020, 2, 2)});
            //Criando um objeto mock do UserRepository e configurando para retornar a lista criada anteriormente se chamar o método GetAll()
            var _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(x => x.GetAll()).Returns(_users);
            //Criando um objeto mock do AutoMapper para que possamos converter o retorno para o tipo List<UserViewModel>()
            var _autoMapperProfile = new AutoMapperSetup();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);
            //Istanciando nossa classe de serviço novamente com os novos objetos mocks que criamos
            userService = new UserService(_userRepository.Object, _mapper);
            //Obtendo os valores do método Get para validar se vai retornar o objeto criado acima.
            var result = userService.Get();
            //Validando se o retorno contém uma lista com objetos.
            Assert.True(result.Count > 0);
        }

        #endregion

        #region ValidatingRequiredFields

        [Fact]
        public void Post_SendingInvalidObject()
        {
            var exception = Assert.Throws<ValidationException>(() => userService.Post(new UserViewModel { NameClient = "User Default" }));
            Assert.Equal("The Email field is required.", exception.Message);
        }

        #endregion
    }
}