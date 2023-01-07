using Newtonsoft.Json.Converters;
using System;
using System.Text.Json.Serialization;

namespace Servicios.Api.Models
{
    public partial class MovimientoModel
    {
        public int IdMov { get; set; }
        public int IdCuenta { get; set; }
        public TipoMov TipoMov { get; set; }
        public decimal Saldo { get; set; }
        public decimal? Valor { get; set; }
        public DateTime Fecha { get; set; }
       
        //public virtual CuentaModel Cuenta { get; set; }
    }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum TipoMov
{
    D,R
}


