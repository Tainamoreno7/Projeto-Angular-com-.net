using System;
using System.Collections.Generic;
using System.Text;
using Template.Domain.Models;

namespace Template.Domain.Entities
{
    public class User : Entity
     //herdando da classe Entity
    {

        public string CNPJ { get; set; } //Representa um identificador global Exclusivo
        public string NameClient { get; set; }
        public string NameContact { get; set; }
        public DateTime DateClient { get; set; }

    //public string Namecontact { get; set; }




}

}