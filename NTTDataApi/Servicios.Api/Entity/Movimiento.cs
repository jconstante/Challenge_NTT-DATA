using System;

#nullable disable

namespace Servicios.Api.Entity
{
    public partial class Movimiento
    {
        public int IdMov { get; set; }
        public int IdCuenta { get; set; }
        public string TipoMov { get; set; }
        public decimal Saldo { get; set; }
        public decimal? Valor { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Cuenta Cuenta { get; set; }
    }
}
