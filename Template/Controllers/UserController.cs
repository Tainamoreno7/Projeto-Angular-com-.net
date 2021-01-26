using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsersController : ControllerBase
    {
        //Reponsável por comunicar com o frontend recebendo tudo que o frontend manda e enviando tudo que frontend precisa
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            //construtor
            this.userService = userService;
        }

        [HttpGet, AllowAnonymous]

        public IActionResult Get()
        {
            
            return Ok(this.userService.Get()); //economiza espaço de memória
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.userService.Post(userViewModel));
        }


        [HttpGet("{id}")]
        //Buscar o Campo ID
        public IActionResult GetById(string id)
        {
            return Ok(this.userService.GetById(id));
        }

        [HttpGet("register"), AllowAnonymous]
        //Buscar o Campo NameClient
        public IActionResult GetByName(string name)
        {
            return Ok(this.userService.GetByName(name));
        }

        [HttpPut, AllowAnonymous]
        //Editar o objeto
        public IActionResult Put(UserViewModel userViewModel)
        {
            return Ok(this.userService.Put(userViewModel));
        }

      



    }
}
