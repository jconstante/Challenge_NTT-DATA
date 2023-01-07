using System;
using System.Collections.Generic;

#nullable disable

namespace Servicios.Api.Entity
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public string NumCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal? SaldoIncial { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
