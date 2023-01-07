using System;
using System.Collections.Generic;

#nullable disable

namespace Servicios.Api.Entity
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuentas = new HashSet<Cuenta>();
        }

        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; set; }

    }
}
