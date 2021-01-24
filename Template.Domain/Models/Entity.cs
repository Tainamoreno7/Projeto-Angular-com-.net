using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Domain.Models
{
    public class Entity
    {
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public bool IsDeleted { get; set; } //Campo para retornar false ou verdade evitando que se percar os dados e cause dano nos relacionamentos futuros

    }
}
