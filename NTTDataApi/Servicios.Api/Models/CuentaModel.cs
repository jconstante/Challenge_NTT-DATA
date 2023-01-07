using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Servicios.Api.Models
{
    public partial class CuentaModel
    {
        //public CuentaModel()
        //{
        //    Movimientos = new HashSet<MovimientoModel>();
        //}
        public int IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public string NumCuenta { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public decimal? SaldoIncial { get; set; }
        public bool Estado { get; set; }
        public virtual ClienteModel Cliente { get; set; }
        //public virtual ICollection<MovimientoModel> Movimientos { get; set; }

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TipoCuenta
    {
        A,C
    }

}

