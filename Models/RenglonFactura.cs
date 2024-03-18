using System;
using System.Collections.Generic;

namespace FactElectronica.Models;

public partial class RenglonFactura
{
    public int Consecutivo { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public string? Articulo { get; set; }

    public string? Descripcion { get; set; }

    public decimal Cantidad { get; set; }

    public decimal? PrecioSinIva { get; set; }

    public decimal? PrecioConIva { get; set; }

    public decimal? TotalRenglon { get; set; }

    public virtual Factura Factura { get; set; } = null!;
}
