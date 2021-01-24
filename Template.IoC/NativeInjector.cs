using Microsoft.Extensions.DependencyInjection;
using System;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Domain.Interfaces;
using Template.Data.Repositories;
using Template.Data.Repository;

namespace Template.IoC
    //Projeto responsavel pela injeção de dependencia e projeto controller
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
            {
                #region Services

                services.AddScoped<IUserService, UserService>();

                #endregion

                #region Repositories

                services.AddScoped<IUserRepository, UserRepository>();

                #endregion
            }
        }
    }
