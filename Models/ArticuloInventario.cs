using System;
using System.Collections.Generic;

namespace FactElectronica.Models;

public partial class ArticuloInventario
{
    public int Consecutivo { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? TipoDeArticulo { get; set; }

    public string? AlicuotaIva { get; set; }

    public decimal? PrecioSinIva { get; set; }

    public decimal? PrecioConIva { get; set; }

    public decimal? CostoUnitario { get; set; }

    public decimal? Existencia { get; set; }

    public string? TipoDeProducto { get; set; }

    public string? Marca { get; set; }

    public string? UnidadDeVenta { get; set; }
}
