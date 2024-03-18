using System;
using System.Collections.Generic;

namespace FactElectronica.Models;

public partial class Factura
{
    public int Consecutivo { get; set; }

    public string Numero { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int ConsecutivoCliente { get; set; }

    public int ConsecutivoVendedor { get; set; }

    public string? Observaciones { get; set; }

    public decimal? TotalMontoExento { get; set; }

    public decimal? TotalBaseImponible { get; set; }

    public decimal? TotalRenglones { get; set; }

    public decimal? TotalIva { get; set; }

    public decimal? TotalFactura { get; set; }

    public virtual Cliente ConsecutivoClienteNavigation { get; set; } = null!;

    public virtual Vendedor ConsecutivoVendedorNavigation { get; set; } = null!;

    public virtual RenglonFactura? RenglonFactura { get; set; }
}
