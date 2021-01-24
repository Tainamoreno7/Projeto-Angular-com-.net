using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Entities
{
    public class Client
    {

        public Guid Id { get; set; }
        public Guid CNPJ { get; set; } //Representa um identificador global Exclusivo
        public string NameClient { get; set; }
        public string Namecontact { get; set; }



    }

}