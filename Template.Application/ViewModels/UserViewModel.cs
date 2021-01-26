using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Application.ViewModels
{
    public class UserViewModel
    {
        // Campos que desejo retornar para o frontend 
        public Guid Id { get; set; }
        public string NameContact { get; set; }
        public string NameClient { get; set; }
        public string CNPJ { get; set; }
        public DateTime DateClient { get; set; }
        
    }
}
