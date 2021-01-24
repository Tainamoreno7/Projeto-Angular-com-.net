using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class User : Entity
     //herdando da classe Entity
    {

        // public Guid CNPJ { get; set; } //Representa um identificador global Exclusivo
        public string Name { get; set; }
        public string Email { get; set; }
        //public string Namecontact { get; set; }




    }

}