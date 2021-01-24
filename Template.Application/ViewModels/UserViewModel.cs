using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Application.ViewModels
{
    public class UserViewModel
    {
        // Campos que desejo retornar para o frontend 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
