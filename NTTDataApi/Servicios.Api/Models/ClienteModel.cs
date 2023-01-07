using Servicios.Api.Entity;
using System;
using System.Collections.Generic;

namespace Servicios.Api.Models
{
    public partial class ClienteModel
    {
        //public ClienteModel()
        //{
        //    Cuentas = new HashSet<CuentaModel>();
        //}
        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        //public DateTime FechaCreacion { get; set; }
        //public DateTime? FechaModificacion { get; set; }
        public virtual PersonaModel Persona { get; set; }
        //public virtual ICollection<CuentaModel> Cuentas { get; set; }
    }
}

